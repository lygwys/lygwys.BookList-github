using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using lygwys.BookList.BookListManagement.Books.Dtos;

namespace lygwys.BookList.BookListManagement.Books
{
    /// <summary>
    /// 书籍的应用层服务
    /// </summary>
    public interface IBookAppService:IApplicationService
    {
        //分页获取查询书籍的功能
        Task<PagedResultDto<BookListDto>> GetPagedBook(GetBookInput input);


        /// <summary>
        /// 添加或修改书籍信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateBook(CreateOrUpdataBookInput input);


        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteBook(EntityDto<long> input);


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task BatchDelete(List<long> input);


        /// <summary>
        /// 获取编辑状态下的Book实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task<GetBookForEditOutput> GetForEditBookAsync(NullableIdDto<long> input);


    }
}