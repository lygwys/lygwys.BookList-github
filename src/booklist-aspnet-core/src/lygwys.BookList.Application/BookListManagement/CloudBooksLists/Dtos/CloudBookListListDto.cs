

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class CloudBookListListDto : CreationAuditedEntityDto<long> 
    {

        
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