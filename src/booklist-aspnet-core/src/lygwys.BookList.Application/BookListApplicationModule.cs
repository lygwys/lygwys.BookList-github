using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using lygwys.BookList.Authorization;
using lygwys.BookList.BookListManagement.Books.Mapper;
using lygwys.BookList.BookListManagement.BookTags.Mapper;
using lygwys.BookList.BookListManagement.CloudBooksLists.Authorization;
using lygwys.BookList.BookListManagement.CloudBooksLists.Mapper;

namespace lygwys.BookList
{
    [DependsOn(
        typeof(BookListCoreModule),
        typeof(AbpAutoMapperModule))]
    public class BookListApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookListAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CloudBookListAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);
                BookMapper.CreateMappings(configuration);
                BookTagMapper.CreateMappings(configuration);
                CloudBookListMapper.CreateMappings(configuration);
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookListApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
