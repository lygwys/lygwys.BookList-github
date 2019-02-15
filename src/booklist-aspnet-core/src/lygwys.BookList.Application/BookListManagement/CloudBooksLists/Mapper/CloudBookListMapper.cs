
using AutoMapper;
using lygwys.BookList.BookListManagement.CloudBooksLists;
using lygwys.BookList.BookListManagement.CloudBooksLists.Dtos;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Mapper
{

	/// <summary>
    /// 配置CloudBookList的AutoMapper
    /// </summary>
	internal static class CloudBookListMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <CloudBookList,CloudBookListListDto>();
            configuration.CreateMap <CloudBookListListDto,CloudBookList>();

            configuration.CreateMap <CloudBookListEditDto,CloudBookList>();
            configuration.CreateMap <CloudBookList,CloudBookListEditDto>();

        }
	}
}
