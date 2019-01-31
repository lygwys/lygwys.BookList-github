using System.Threading.Tasks;
using Abp.Application.Services;
using lygwys.BookList.Authorization.Accounts.Dto;

namespace lygwys.BookList.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
