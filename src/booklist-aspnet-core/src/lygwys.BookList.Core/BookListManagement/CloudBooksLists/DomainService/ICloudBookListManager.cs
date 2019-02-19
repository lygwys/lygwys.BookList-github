

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using lygwys.BookList.BookListManagement.CloudBooksLists;
using lygwys.BookList.BookListManagement.Relationships;


namespace lygwys.BookList.BookListManagement.CloudBooksLists.DomainService
{
    public interface ICloudBookListManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCloudBookList();
        /// <summary>
        /// // 创建book和书单的关系
        /// </summary>
        /// <param name="bookListId"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task CreateBookListAndBookRelationship(long bookListId, List<long> bookIds);
        /// <summary>
        /// 根据书籍Id删除关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task DeleteByBookId(long? bookId);


        /// <summary>
        /// 根据书籍id集合删除关联
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        Task DeleteByBookId(List<long> bookIds);


        /// <summary>
        /// 根据书单Id删除关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task DeleteByBookListId(long? bookListId);


        /// <summary>
        /// 根据书单id集合删除关联
        /// </summary>
        /// <param name="bookListIds"></param>
        /// <returns></returns>
        Task DeleteByBookListId(List<long> bookListIds);


        /// <summary>
        /// 根据书单Id获取所有关联
        /// </summary>
        /// <param name="bookListId"></param>
        /// <returns></returns>
        Task<List<BookListAndBook>> GetByBookListIdAsync(long? bookListId);


        /// <summary>
        /// 根据书籍Id获取所有关联
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookListAndBook>> GetByBookIdAsync(long? bookId);
    }
}
