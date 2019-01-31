using Abp.Application.Services;
using Abp.Application.Services.Dto;
using lygwys.BookList.MultiTenancy.Dto;

namespace lygwys.BookList.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
