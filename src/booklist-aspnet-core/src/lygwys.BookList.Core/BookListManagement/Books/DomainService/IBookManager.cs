

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.Relationships;


namespace lygwys.BookList.BookListManagement.Books.DomainService
{
    public interface IBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBook();

        // 处理书籍 标签表中间表的逻辑

        /// <summary>
        /// // 通过书籍查询标签
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<List<BookAndBookTag>> GetTagsByBookIdAsync(long bookId);
        /// <summary>
        /// // 通过标签查询书籍
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>

        Task<List<BookAndBookTag>> GetBooksByTagId(long tagId);


        /// <summary>
        ///  //创建书籍和标签的关联关系
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        Task CreateBookAndBookTagRelationship(long bookId,List<long> tagIds);

    }
}
