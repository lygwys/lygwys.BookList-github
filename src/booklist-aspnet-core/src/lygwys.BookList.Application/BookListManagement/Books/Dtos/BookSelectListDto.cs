using lygwys.BookList.BookListManagement.BookTags.Dtos;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class BookSelectListDto : BookListDto
    {
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }
    }
}