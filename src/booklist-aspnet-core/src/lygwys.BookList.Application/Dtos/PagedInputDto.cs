using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace lygwys.BookList.Dtos
{
    public class PagedInputDto:IPagedResultRequest
    {
        [Range(1,AppConsts.MaxPageSize)]//最多有多少行（1000）
        public int MaxResultCount { get; set; }//每页显示多少行（10）

        [Range(0,int.MaxValue)]//跳页，从第一页
        public int SkipCount { get; set; }

        public PagedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}