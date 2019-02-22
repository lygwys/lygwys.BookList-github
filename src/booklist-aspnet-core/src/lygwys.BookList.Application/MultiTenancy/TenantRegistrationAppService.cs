using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Castle.Core.Internal;
using lygwys.BookList.Authorization.Roles;
using lygwys.BookList.Authorization.Users;
using lygwys.BookList.Editions;
using lygwys.BookList.MultiTenancy.Dto;
using Microsoft.AspNetCore.Identity;
using StringExtensions = Abp.Extensions.StringExtensions;

namespace lygwys.BookList.MultiTenancy
{
    public class TenantRegistrationAppService:BookListAppServiceBase, ITenantRegistrationAppService
    {
        private readonly EditionManager _editionManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public TenantRegistrationAppService( EditionManager editionManager, RoleManager roleManager, IAbpZeroDbMigrator abpZeroDbMigrator, IPasswordHasher<User> passwordHasher)
        {
            _editionManager = editionManager;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _passwordHasher = passwordHasher;
        }

        public async Task<TenantDto> RegisterTenantAsync(CreateTenantDto input)
        {
            var tenant = new Tenant(input.TenancyName,input.Name)
            {
                IsActive = true
            };
            // 连接字串要加密
            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);
            // 获得默认的版本信息 DefaultEditionName = "Standard"
            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }
            // 创建租户信息
            await TenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();
            // 初始化数据信息迁移，针对租户级
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);
            // 所以设置当前的工作单元为新注册登录的租户信息
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                // 创建租户
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));
                // role =admin permission user
                await CurrentUnitOfWork.SaveChangesAsync();
                // 创建角色
                var adminRole = _roleManager.Roles.Single(a => a.Name == StaticRoleNames.Tenants.Admin);
                // 授权当前角色所有权限
                await _roleManager.GrantAllPermissionsAsync(adminRole);
                // 创建admin用户信息
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);
                // 密码为空时提供默认密码
                adminUser.Password = _passwordHasher.HashPassword(adminUser,StringExtensions.IsNullOrWhiteSpace(input.PassWord)?User.DefaultPassword:input.PassWord);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync();
                // 角色授权给用户
                CheckErrors(await UserManager.AddToRoleAsync(adminUser,adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            return tenant.MapTo<TenantDto>();
        }
    }
}