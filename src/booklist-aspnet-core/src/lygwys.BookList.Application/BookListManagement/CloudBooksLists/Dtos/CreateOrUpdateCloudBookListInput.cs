

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class CreateOrUpdateCloudBookListInput
    {
        [Required]
        public CloudBookListEditDto CloudBookList { get; set; }
        public List<long> BookIds { get; set; }  //
    }
}