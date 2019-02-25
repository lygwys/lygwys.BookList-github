using System.Collections.Generic;

namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    /// <summary>
    /// 书籍包含标签
    /// </summary>
    public class BookIncludeTagDto
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
        
        /// <summary>
        /// 购买链接
        /// </summary>
        public string PriceUrl { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImgStrUrl { get; set; }

        public List<string> BookTags { get; set; }
    }
}