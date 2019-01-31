using Abp.Application.Services.Dto;

namespace lygwys.BookList.Dtos
{
    public class PagedAndFilteredInputDto:PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 过滤文本
        /// </summary>
        public string FilterText { get; set; }
    }
}