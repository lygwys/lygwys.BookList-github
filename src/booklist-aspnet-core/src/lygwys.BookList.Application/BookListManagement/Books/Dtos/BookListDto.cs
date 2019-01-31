using Abp.Application.Services.Dto;
using Abp.AutoMapper;

// ReSharper disable once IdentifierTypo
namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    //[AutoMap(typeof(Book))]
    public class BookListDto:EntityDto<long>
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
        /// 封面图片Url
        /// </summary>
        public string ImgStrUrl { get; set; }
    }
}