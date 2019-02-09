

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
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.Relationships;


namespace lygwys.BookList.BookListManagement.Books.DomainService
{
    /// <summary>
    /// Book领域层的业务管理
    ///</summary>
    public class BookManager :BookListDomainServiceBase, IBookManager
    {
		
		private readonly IRepository<Book,long> _repository;
        private readonly IRepository<BookAndBookTag, long> _bookAndBookTagRepository;  //

		/// <summary>
		/// Book的构造方法
		///</summary>
		public BookManager(
			IRepository<Book, long> repository, IRepository<BookAndBookTag, long> bookAndBookTagRepository)
		{
		    _repository =  repository;
		    _bookAndBookTagRepository = bookAndBookTagRepository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBook()
		{
			throw new NotImplementedException();
		}
        /// <summary>
        /// 通过书籍查询标签
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<List<BookAndBookTag>> GetTagsByBookIdAsync(long bookId)
        {
            var list=await _bookAndBookTagRepository.GetAll().AsNoTracking().Where(a => a.BookId == bookId).ToListAsync();
            return list;
        }
        /// <summary>
        /// 通过标签查询书籍
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<List<BookAndBookTag>> GetBooksByTagId(long tagId)
        {
            var list = await _bookAndBookTagRepository.GetAll().AsNoTracking().Where(a => a.BookTagId == tagId)
                .ToListAsync();
            return list;
        }
        /// <summary>
        /// 创建书籍和标签的关联关系
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task CreateBookAndBookTagRelationship(long bookId, List<long> tagIds)
        {
            // 删除原有的关联-书箱上的所有标签
            await  _bookAndBookTagRepository.DeleteAsync(a=>a.BookId==bookId);
            await CurrentUnitOfWork.SaveChangesAsync(); //手动处理掉数据-调用工作单元进行操作(相当于DbContent.SaveChangesAsync())
            //添加关联
            var newBookTags=new List<long>();

            foreach (var tagId in tagIds)
            {
                if (newBookTags.Exists(a=>a==tagId)) // 如果newBookTags中有了tagId，就不执行下面方法，直接再循环处理下一个tagId
                {
                    continue;
                }

                await _bookAndBookTagRepository.InsertAsync(new BookAndBookTag()
                {
                    BookId = bookId,
                    BookTagId = tagId
                });

                newBookTags.Add(tagId);   
            }

        }

        // TODO:编写领域业务代码
        

	}
}
