

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using lygwys.BookList;
using lygwys.BookList.BookListManagement.CloudBooksLists;


namespace lygwys.BookList.BookListManagement.CloudBooksLists.DomainService
{
    /// <summary>
    /// CloudBookList领域层的业务管理
    ///</summary>
    public class CloudBookListManager :BookListDomainServiceBase, ICloudBookListManager
    {
		
		private readonly IRepository<CloudBookList,long> _repository;

		/// <summary>
		/// CloudBookList的构造方法
		///</summary>
		public CloudBookListManager(
			IRepository<CloudBookList, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitCloudBookList()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
