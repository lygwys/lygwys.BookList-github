namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class BookEditDto
    {
        /// <summary>
        /// 新添加的可空字段，其它都拷贝自Book实体
        /// </summary>
        public long? Id { get; set; }
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
        /// 价格链接
        /// </summary>
        public string PriceUrl { get; set; }
        /// <summary>
        /// 封面图片Url
        /// </summary>
        public string ImgStrUrl { get; set; }
    }
}