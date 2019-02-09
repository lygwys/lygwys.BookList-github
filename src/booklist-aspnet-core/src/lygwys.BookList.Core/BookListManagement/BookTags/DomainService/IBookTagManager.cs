

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using lygwys.BookList.BookListManagement.BookTags;


namespace lygwys.BookList.BookListManagement.BookTags.DomainService
{
    public interface IBookTagManager : IDomainService
    {
        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBookTag();
        Task<List<BookTag>> GetAll();  //
    }
}
