
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
using lygwys.BookList.BookListManagement.Books.DomainService;
using lygwys.BookList.BookListManagement.Books.Authorization;
using lygwys.BookList.BookListManagement.BookTags.DomainService;
using lygwys.BookList.BookListManagement.CloudBooksLists.DomainService;
using lygwys.BookList.BookListManagement.Relationships;
using lygwys.BookList.BookListManagement.CloudBooksLists;
using lygwys.BookList.BookListManagement.CloudBooksLists.Dtos;

namespace lygwys.BookList.BookListManagement.Books
{
    /// <summary>
    /// Book应用层服务的接口实现方法  
    ///</summary>
//    [AbpAuthorize]
    public class BookAppService : BookListAppServiceBase, IBookAppService
    {
        private readonly IRepository<Book, long> _entityRepository;
        private readonly IRepository<CloudBookList, long> _cloudBookListRepository;

        private readonly IBookManager _entityManager;
        private readonly IBookTagManager _bookTagManager;

        private readonly IRepository<BookAndBookTag, long> _bookAndBookTagRegRepository;
        private readonly ICloudBookListManager _cloudBookListManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BookAppService(
        IRepository<Book, long> entityRepository
        , IBookManager entityManager, IBookTagManager bookTagManager, IRepository<BookAndBookTag, long> bookAndBookTagRegRepository, ICloudBookListManager cloudBookListManager, IRepository<CloudBookList, long> cloudBookListRepository)
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _bookTagManager = bookTagManager;
            _bookAndBookTagRegRepository = bookAndBookTagRegRepository;
            _cloudBookListManager = cloudBookListManager;
            _cloudBookListRepository = cloudBookListRepository;
        }


        /// <summary>
        /// 获取Book的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BookPermissions.Query)]
        public async Task<PagedResultDto<BookListDto>> GetPaged(GetBooksInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<BookListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<BookListDto>>();

            return new PagedResultDto<BookListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取BookListDto信息
        /// </summary>
        [AbpAuthorize(BookPermissions.Query)]
        public async Task<BookListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<BookListDto>();
        }

        /// <summary>
        /// 获取编辑 Book
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BookPermissions.Create, BookPermissions.Edit)]
        public async Task<GetBookForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetBookForEditOutput();
            BookEditDto editDto;
            List<long> bookTagIds = null;  //
            // 获取所有标签信息
            // 哪些是选择了的，哪些不是的  建BookTagSelectListDto

            var bookTagListDtos = (await _bookTagManager.GetAll()).MapTo<List<BookTagSelectListDto>>();  //


            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);
                editDto = entity.MapTo<BookEditDto>();
                bookTagIds = (await _entityManager.GetTagsByBookIdAsync(entity.Id)).Select(a => a.BookTagId).ToList();
                if (bookTagIds.Count > 0)
                {
                    foreach (var bookTag in bookTagListDtos)
                    {
                        if (bookTagIds.Exists(a => a == bookTag.Id))
                        {
                            bookTag.IsSelected = true;
                        }
                    }
                }
            }
            else
            {
                editDto = new BookEditDto();
            }

            output.Book = editDto;
            output.BookTags = bookTagListDtos;  //
            return output;
        }


        /// <summary>
        /// 添加或者修改Book的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BookPermissions.Create, BookPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateBookInput input)
        {

            if (input.Book.Id.HasValue)
            {
                await Update(input.Book, input.TagIds); // , input.TagIds
            }
            else
            {
                await Create(input.Book, input.TagIds); // , input.TagIds
            }
        }


        /// <summary>
        /// 新增Book
        /// </summary>
        [AbpAuthorize(BookPermissions.Create)]
        protected virtual async Task<BookEditDto> Create(BookEditDto input, List<long> tagIds) //添加参数, List<long> tagIds
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Book>();
            var entityId = await _entityRepository.InsertAndGetIdAsync(entity);

            // 创建关联关系   
            if (tagIds.Count > 0)
            {
                await _entityManager.CreateBookAndBookTagRelationship(entityId, tagIds);
            }

            return entity.MapTo<BookEditDto>();
        }

        /// <summary>
        /// 编辑Book
        /// </summary>
        [AbpAuthorize(BookPermissions.Edit)]
        protected virtual async Task Update(BookEditDto input, List<long> tagIds) // , List<long> tagIds
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);

            // 创建关联关系   
            await _entityManager.CreateBookAndBookTagRelationship(entity.Id, tagIds);
        }



        /// <summary>
        /// 删除Book信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BookPermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            await _bookAndBookTagRegRepository.DeleteAsync(a => a.BookId == input.Id);  //
            await _entityRepository.DeleteAsync(input.Id);
            await _cloudBookListManager.DeleteByBookId(input.Id); //
        }



        /// <summary>
        /// 批量删除Book的方法
        /// </summary>
        [AbpAuthorize(BookPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            await _bookAndBookTagRegRepository.DeleteAsync(a => input.Contains(a.BookId)); //
            await _cloudBookListManager.DeleteByBookId(input); //
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
            
        }

        public async Task<CloudBookListShareDto> GetBookListShareAsync(long cloudbookListId, int tenantId)
        {
            if (cloudbookListId <= 0||tenantId<=0)
            {
                throw new UserFriendlyException(message:"租户或书单ID不能为空");
            }

            var tenant = await TenantManager.GetByIdAsync(tenantId);
            if (tenant==null)
            {
                throw new UserFriendlyException(message: "该租户下没有书单");
            }
            // 设置当前工作单元的租户ID
            using (CurrentUnitOfWork.SetTenantId(tenantId))
            {
                // 获取云书单内容信息
                var cloudBookList = await _cloudBookListRepository.GetAll()
                    .Include(a=>a.BookListAndBooks)
                    .ThenInclude(a=>a.Book)
                    .ThenInclude(a=>a.BookAndBookTags)
                    .ThenInclude(a=>a.BookTag)
                    .IgnoreQueryFilters()
                    .Where(b => b.Id == cloudbookListId).FirstOrDefaultAsync();
                var dto= cloudBookList.MapTo<CloudBookListShareDto>();
                if (cloudBookList.CreatorUserId.HasValue)
                {
                    var user = UserManager.Users.IgnoreQueryFilters()
                        .FirstOrDefaultAsync(d => d.Id == cloudBookList.CreatorUserId);
                    dto.UserName = user.Result.UserName;  // 视频中是user.UserName
                }
                // 当前书单下是否有书籍内容
                if (cloudBookList.BookListAndBooks==null)
                {
                    return dto;
                }
                dto.Books=new List<BookIncludeTagDto>();
                foreach (var bookListAndBook in cloudBookList.BookListAndBooks)
                {
                    // 获取书籍dto
                    var bookdto = bookListAndBook.Book.MapTo<BookIncludeTagDto>();
                    dto.Books.Add(bookdto);
                    if (bookListAndBook.Book.BookAndBookTags==null)
                    {
                        continue;
                    }
                    // 书籍标签的处理
                    bookdto.BookTags=new List<string>();
                    foreach (var bookAndbookTag in bookListAndBook.Book.BookAndBookTags)
                    {
                        bookdto.BookTags.Add(bookAndbookTag.BookTag.TagName);
                    }
                }

                return dto;
            }


        }


        /// <summary>
        /// 导出Book为excel表,等待开发。
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


