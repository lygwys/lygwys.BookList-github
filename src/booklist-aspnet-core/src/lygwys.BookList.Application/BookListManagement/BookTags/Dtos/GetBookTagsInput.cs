
using Abp.Runtime.Validation;
using lygwys.BookList.Dtos;
using lygwys.BookList.BookListManagement.BookTags;

namespace lygwys.BookList.BookListManagement.BookTags.Dtos
{
    public class GetBookTagsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
