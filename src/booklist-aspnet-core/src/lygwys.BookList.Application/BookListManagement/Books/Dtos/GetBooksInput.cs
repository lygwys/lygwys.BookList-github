
using Abp.Runtime.Validation;
using lygwys.BookList.Dtos;
using lygwys.BookList.BookListManagement.Books;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class GetBooksInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
