using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using lygwys.BookList.Roles.Dto;
using lygwys.BookList.Users.Dto;

namespace lygwys.BookList.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
