
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using lygwys.BookList.BookListManagement.BookTags;

namespace  lygwys.BookList.BookListManagement.BookTags.Dtos
{
    public class BookTagEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// TagName
		/// </summary>
		[MaxLength(55, ErrorMessage="TagName超出最大长度")]
		[Required(ErrorMessage="TagName不能为空")]
		public string TagName { get; set; }




    }
}