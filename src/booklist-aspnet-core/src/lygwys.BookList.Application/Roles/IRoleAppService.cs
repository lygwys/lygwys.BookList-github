using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using lygwys.BookList.Roles.Dto;

namespace lygwys.BookList.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
