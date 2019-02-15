
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace  lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class CloudBookListEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// 简介
		/// </summary>
		public string Intro { get; set; }




    }
}