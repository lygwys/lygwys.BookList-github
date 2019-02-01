

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lygwys.BookList.BookListManagement.BookTags;

namespace lygwys.BookList.BookListManagement.BookTags.Dtos
{
    public class CreateOrUpdateBookTagInput
    {
        [Required]
        public BookTagEditDto BookTag { get; set; }

    }
}