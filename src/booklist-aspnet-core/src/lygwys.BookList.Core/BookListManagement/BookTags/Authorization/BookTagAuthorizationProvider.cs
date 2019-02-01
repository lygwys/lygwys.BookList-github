

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using lygwys.BookList.Authorization;

namespace lygwys.BookList.BookListManagement.BookTags.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BookTagPermissions" /> for all permission names. BookTag
    ///</summary>
    public class BookTagAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BookTagAuthorizationProvider()
		{

		}

        public BookTagAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BookTagAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BookTag 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BookTagPermissions.Node , L("BookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.Query, L("QueryBookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.Create, L("CreateBookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.Edit, L("EditBookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.Delete, L("DeleteBookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.BatchDelete, L("BatchDeleteBookTag"));
			entityPermission.CreateChildPermission(BookTagPermissions.ExportExcel, L("ExportExcelBookTag"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, BookListConsts.LocalizationSourceName);
		}
    }
}