using System.ComponentModel.DataAnnotations;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class CreateOrUpdataBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }
    }
}