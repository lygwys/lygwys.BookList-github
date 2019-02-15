

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using lygwys.BookList.Authorization;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CloudBookListPermissions" /> for all permission names. CloudBookList
    ///</summary>
    public class CloudBookListAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CloudBookListAuthorizationProvider()
		{

		}

        public CloudBookListAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CloudBookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了CloudBookList 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(CloudBookListPermissions.Node , L("CloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.Query, L("QueryCloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.Create, L("CreateCloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.Edit, L("EditCloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.Delete, L("DeleteCloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.BatchDelete, L("BatchDeleteCloudBookList"));
			entityPermission.CreateChildPermission(CloudBookListPermissions.ExportExcel, L("ExportExcelCloudBookList"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, BookListConsts.LocalizationSourceName);
		}
    }
}