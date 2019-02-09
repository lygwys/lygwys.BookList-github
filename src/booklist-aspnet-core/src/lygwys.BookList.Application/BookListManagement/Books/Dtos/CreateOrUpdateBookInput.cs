

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lygwys.BookList.BookListManagement.Books;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }
        public List<long> TagIds { get; set; }

    }
}