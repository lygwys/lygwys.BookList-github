using System.Threading.Tasks;
using Abp.Application.Services;
using lygwys.BookList.Sessions.Dto;

namespace lygwys.BookList.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
