

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using lygwys.BookList.BookListManagement.Books;


namespace lygwys.BookList.BookListManagement.Books.DomainService
{
    public interface IBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBook();



		 
      
         

    }
}
