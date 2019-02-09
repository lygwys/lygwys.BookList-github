

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using lygwys.BookList.BookListManagement.Books;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class GetBookForEditOutput
    {

        public BookEditDto Book { get; set; }
        public List<BookTagSelectListDto> BookTags { get; set; }

    }
}