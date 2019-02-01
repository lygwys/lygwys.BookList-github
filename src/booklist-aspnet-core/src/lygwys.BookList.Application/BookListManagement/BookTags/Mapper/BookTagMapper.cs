
using AutoMapper;
using lygwys.BookList.BookListManagement.BookTags;
using lygwys.BookList.BookListManagement.BookTags.Dtos;

namespace lygwys.BookList.BookListManagement.BookTags.Mapper
{

	/// <summary>
    /// 配置BookTag的AutoMapper
    /// </summary>
	internal static class BookTagMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BookTag,BookTagListDto>();
            configuration.CreateMap <BookTagListDto,BookTag>();

            configuration.CreateMap <BookTagEditDto,BookTag>();
            configuration.CreateMap <BookTag,BookTagEditDto>();

        }
	}
}
