
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.Books.Dtos;
using lygwys.BookList.BookListManagement.CloudBooksLists;
using lygwys.BookList.BookListManagement.CloudBooksLists.Dtos;
using lygwys.BookList.BookListManagement.CloudBooksLists.DomainService;
using lygwys.BookList.BookListManagement.CloudBooksLists.Authorization;
using lygwys.BookList.BookListManagement.Relationships;


namespace lygwys.BookList.BookListManagement.CloudBooksLists
{
    /// <summary>
    /// CloudBookList应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class CloudBookListAppService : BookListAppServiceBase, ICloudBookListAppService
    {
        private readonly IRepository<CloudBookList, long> _entityRepository;

        private readonly ICloudBookListManager _entityManager;
        private readonly IRepository<BookListAndBook, long> _bookListAndBookRepository; //
        private readonly IRepository<Book, long> _bookRepository; //

        /// <summary>
        /// 构造函数 
        ///</summary>
        public CloudBookListAppService(
        IRepository<CloudBookList, long> entityRepository
        ,ICloudBookListManager entityManager, IRepository<BookListAndBook, long> bookListAndBookRepository, IRepository<Book, long> bookRepository)
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
            _bookListAndBookRepository = bookListAndBookRepository;
            _bookRepository = bookRepository;
        }


        /// <summary>
        /// 获取CloudBookList的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(CloudBookListPermissions.Query)] 
        public async Task<PagedResultDto<CloudBookListListDto>> GetPaged(GetCloudBookListsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<CloudBookListListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<CloudBookListListDto>>();

			return new PagedResultDto<CloudBookListListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取CloudBookListListDto信息
		/// </summary>
		[AbpAuthorize(CloudBookListPermissions.Query)] 
		public async Task<CloudBookListListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<CloudBookListListDto>();
		}

		/// <summary>
		/// 获取编辑 CloudBookList
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloudBookListPermissions.Create,CloudBookListPermissions.Edit)]
		public async Task<GetCloudBookListForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetCloudBookListForEditOutput();
            CloudBookListEditDto editDto;
		    var allBooklistDtos = (await _bookRepository.GetAllListAsync()).MapTo<List<BookSelectListDto>>();

            if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<CloudBookListEditDto>();

				//cloudBookListEditDto = ObjectMapper.Map<List<cloudBookListEditDto>>(entity);

			    var bookids= (await _entityManager.GetByBookListIdAsync(entity.Id)).Select(a=>a.BookId).ToList();
			    
			    foreach (var book in allBooklistDtos)
			    {
			        if (bookids.Exists(a => a == book.Id))
			        {
			            book.IsSelected = true;
			        }
			    }

			}
			else
			{
				editDto = new CloudBookListEditDto();
			}

			output.CloudBookList = editDto;
		    output.Books = allBooklistDtos;
			return output;
		}


		/// <summary>
		/// 添加或者修改CloudBookList的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloudBookListPermissions.Create,CloudBookListPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateCloudBookListInput input)
		{

			if (input.CloudBookList.Id.HasValue)
			{
				await Update(input.CloudBookList,input.BookIds); //
			}
			else
			{
				await Create(input.CloudBookList, input.BookIds); //
			}
		}


		/// <summary>
		/// 新增CloudBookList
		/// </summary>
		[AbpAuthorize(CloudBookListPermissions.Create)]
		protected virtual async Task<CloudBookListEditDto> Create(CloudBookListEditDto input, List<long> bookIds)  //
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <CloudBookList>(input);
            var entity=input.MapTo<CloudBookList>();
		    var entityId = await _entityRepository.InsertAndGetIdAsync(entity);
		    if (bookIds.Count>0)
		    {
		        await _entityManager.CreateBookListAndBookRelationship(entityId, bookIds);
		    }
			return entity.MapTo<CloudBookListEditDto>();
		}

		/// <summary>
		/// 编辑CloudBookList
		/// </summary>
		[AbpAuthorize(CloudBookListPermissions.Edit)]
		protected virtual async Task Update(CloudBookListEditDto input,List<long> bookIds)  //
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		    if (bookIds.Count > 0)  //
		    {
		        await _entityManager.CreateBookListAndBookRelationship(entity.Id, bookIds);
		    }
        }



		/// <summary>
		/// 删除CloudBookList信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloudBookListPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
		    await _entityManager.DeleteByBookListId(input.Id);   //
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除CloudBookList的方法
		/// </summary>
		[AbpAuthorize(CloudBookListPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
		    await _entityManager.DeleteByBookListId(input); //
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出CloudBookList为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


