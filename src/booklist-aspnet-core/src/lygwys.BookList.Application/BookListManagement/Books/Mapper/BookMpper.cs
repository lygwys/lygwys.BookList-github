using AutoMapper;
using lygwys.BookList.BookListManagement.Books.Dtos;

namespace lygwys.BookList.BookListManagement.Books.Mapper
{
    internal class BookMpper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BookListDto>();
            //configuration.CreateMap< BookListDto, Book>();
            configuration.CreateMap<BookEditDto, Book>();
            configuration.CreateMap<Book, BookEditDto>();
            //
        }
    }
}