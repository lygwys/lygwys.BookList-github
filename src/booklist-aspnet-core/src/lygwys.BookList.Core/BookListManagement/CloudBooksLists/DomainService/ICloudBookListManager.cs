

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using lygwys.BookList.BookListManagement.CloudBooksLists;


namespace lygwys.BookList.BookListManagement.CloudBooksLists.DomainService
{
    public interface ICloudBookListManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCloudBookList();



		 
      
         

    }
}
