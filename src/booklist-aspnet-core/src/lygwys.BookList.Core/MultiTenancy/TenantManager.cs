using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using lygwys.BookList.Authorization.Users;
using lygwys.BookList.Editions;

namespace lygwys.BookList.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
