using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using lygwys.BookList.Authorization;

namespace lygwys.BookList.BookListManagement.Books.Authorization
{
    public class BookAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)  // IPermissionDefinitionContext中有权限的操作方法：添加 检查 删除
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, new FixedLocalizableString("页面"));
            var admin = pages.Children.FirstOrDefault(a => a.Name == PermissionNames.Pages_Administrator)??pages.CreateChildPermission(PermissionNames.Pages_Administrator,L("Administrator"));
            var entityPermission = admin.CreateChildPermission(BookPermissions.BookManager, L("BookManager"));
            entityPermission.CreateChildPermission(BookPermissions.Query, L("Query"));
            entityPermission.CreateChildPermission(BookPermissions.BatchDelete, L("BatchDelete"));
            entityPermission.CreateChildPermission(BookPermissions.Create, L("Create"));
            entityPermission.CreateChildPermission(BookPermissions.Delete, L("Delete"));
            entityPermission.CreateChildPermission(BookPermissions.Edit, L("Edit"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name,BookListConsts.LocalizationSourceName);
        }
    }
}