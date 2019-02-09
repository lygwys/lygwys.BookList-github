using lygwys.BookList.BookListManagement.BookTags.Dtos;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class BookTagSelectListDto : BookTagListDto
    {
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }
    }
}