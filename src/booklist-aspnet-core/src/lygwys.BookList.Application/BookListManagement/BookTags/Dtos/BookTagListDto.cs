

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using lygwys.BookList.BookListManagement.BookTags;

namespace lygwys.BookList.BookListManagement.BookTags.Dtos
{
    public class BookTagListDto : CreationAuditedEntityDto<long> 
    {

        
		/// <summary>
		/// TagName
		/// </summary>
		[MaxLength(55, ErrorMessage="TagName超出最大长度")]
		[Required(ErrorMessage="TagName不能为空")]
		public string TagName { get; set; }




    }
}