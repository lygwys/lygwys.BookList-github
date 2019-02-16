

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
using lygwys.BookList.BookListManagement.Relationships;


namespace lygwys.BookList.BookListManagement.CloudBooksLists.DomainService
{
    /// <summary>
    /// CloudBookList领域层的业务管理
    ///</summary>
    public class CloudBookListManager :BookListDomainServiceBase, ICloudBookListManager
    {
		
		private readonly IRepository<CloudBookList,long> _repository;
        private readonly IRepository<BookListAndBook, long> _bookListAndBookRepository; //

		/// <summary>
		/// CloudBookList的构造方法
		///</summary>
		public CloudBookListManager(
			IRepository<CloudBookList, long> repository,
			IRepository<BookListAndBook, long> bookListAndBookRepository
        )
		{
			_repository =  repository;
		    _bookListAndBookRepository = bookListAndBookRepository;

		}

        public async Task CreateBookListAndBookRelationship(long bookListId, List<long> bookIds)
        {
            await _bookListAndBookRepository.DeleteAsync(a => a.CloudBookListId == bookListId);
            await CurrentUnitOfWork.SaveChangesAsync();
            // 创建book和书单的关系
            var insertdBookIds = new List<long>();
            foreach (long bookId in bookIds)
            {
                if (insertdBookIds.Exists(a=>a==bookId))
                {
                    continue;
                }

                await _bookListAndBookRepository.InsertAsync(new BookListAndBook()
                {
                    BookId = bookId,
                    CloudBookListId = bookListId
                });
                insertdBookIds.Add(bookId);
            }
        }

        public async Task DeleteByBookId(long? bookId)
        {
            await _bookListAndBookRepository.DeleteAsync(a => a.BookId == bookId.Value);
        }

        public async Task DeleteByBookId(List<long> bookIds)
        {
            await _bookListAndBookRepository.DeleteAsync(a => bookIds.Contains(a.BookId));
        }

        public async Task DeleteByBookListId(long? bookListId)
        {
            await _bookListAndBookRepository.DeleteAsync(a => a.BookId == bookListId);
        }

        public async Task DeleteByBookListId(List<long> bookListIds)
        {
            await _bookListAndBookRepository.DeleteAsync(a =>bookListIds.Contains(a.CloudBookListId));
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
