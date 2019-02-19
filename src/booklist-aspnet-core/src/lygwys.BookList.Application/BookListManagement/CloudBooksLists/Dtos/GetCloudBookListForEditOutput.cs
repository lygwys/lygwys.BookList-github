

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using lygwys.BookList.BookListManagement.Books.Dtos;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class GetCloudBookListForEditOutput
    {

        public CloudBookListEditDto CloudBookList { get; set; }
        public List<BookSelectListDto> Books { get; set; } //
    }
}