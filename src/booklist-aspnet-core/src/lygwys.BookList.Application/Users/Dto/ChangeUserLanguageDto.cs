using System.ComponentModel.DataAnnotations;

namespace lygwys.BookList.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}