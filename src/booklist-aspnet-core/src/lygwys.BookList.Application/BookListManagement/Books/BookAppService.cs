using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using lygwys.BookList.BookListManagement.Books.Authorization;
using lygwys.BookList.BookListManagement.Books.Dtos;
using Microsoft.EntityFrameworkCore;

namespace lygwys.BookList.BookListManagement.Books
{
    [AbpAuthorize(BookPermissions.BookManager)]
    public class BookAppService : BookListAppServiceBase, IBookAppService
    {
        private readonly IRepository<Book, long> _bookRepository;

        public BookAppService(IRepository<Book, long> bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
        public async Task CreateOrUpdateBook(CreateOrUpdataBookInput input)
        {
            if (input.Book.Id.HasValue)
            {
                //修改
                await Update(input.Book);
            }
            else
            {
                //添加
                await CreateBook(input.Book);
            }
        }


        [AbpAuthorize(BookPermissions.Create)]
        protected virtual async Task<BookEditDto> CreateBook(BookEditDto input)
        {
            //var dd = entity.MapTo(input);//将实体转换为dto
            //ObjectMapper.Map(input, entity);//将实体转换为dto
            //var model=ObjectMapper.Map<Book>(input);//将input转换成Book,尽量用这个，单元测试可以过，单例 数据有效隔离
            var entity = input.MapTo<Book>();//将input转换成Book，静态方法
            await _bookRepository.InsertAsync(entity);
            var dto = entity.MapTo<BookEditDto>();
            return dto;
        }


        [AbpAuthorize(BookPermissions.Edit)]
        protected virtual async Task Update(BookEditDto input)
        {
            Debug.Assert(input.Id != null, "input.Id != null");
            var entity =await _bookRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _bookRepository.UpdateAsync(entity);
        }


        [AbpAuthorize(BookPermissions.Query)]

        public async Task<PagedResultDto<BookListDto>> GetPagedBook(GetBookInput input)
        {
            var query = _bookRepository.GetAll().AsNoTracking().WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
                a => a.Name.Contains(input.FilterText));
            var count = await query.CountAsync();
            var entityList = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var entityListDtos = entityList.MapTo<List<BookListDto>>();
            return new PagedResultDto<BookListDto>(count, entityListDtos);
        }


        [AbpAuthorize(BookPermissions.Delete)]
        public async Task DeleteBook(EntityDto<long> input)
        {
            var entity = await _bookRepository.GetAsync(input.Id);
            if (entity !=null)
            {
                await _bookRepository.DeleteAsync(input.Id);
            }
        }


        [AbpAuthorize(BookPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            await _bookRepository.DeleteAsync(a => input.Contains(a.Id));
        }


        [AbpAuthorize(BookPermissions.Edit)]
        public async Task<GetBookForEditOutput> GetForEditBookAsync(NullableIdDto<long> input)
        {
            var output = new GetBookForEditOutput();
            BookEditDto dto;
            if (input.Id.HasValue)
            {
                var entity = await _bookRepository.GetAsync(input.Id.Value);
                dto = entity.MapTo<BookEditDto>();
            }
            else
            {
                dto=new BookEditDto();
            }

            output.Book = dto;

            return output;
        }
    }
}