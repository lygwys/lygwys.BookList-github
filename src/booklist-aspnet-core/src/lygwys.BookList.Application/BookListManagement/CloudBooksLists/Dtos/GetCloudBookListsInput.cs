
using Abp.Runtime.Validation;
using lygwys.BookList.Dtos;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class GetCloudBookListsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
