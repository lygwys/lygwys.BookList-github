using Abp.Authorization;
using lygwys.BookList.Authorization.Roles;
using lygwys.BookList.Authorization.Users;

namespace lygwys.BookList.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
