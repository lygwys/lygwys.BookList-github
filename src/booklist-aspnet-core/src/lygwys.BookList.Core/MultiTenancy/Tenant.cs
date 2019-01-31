using Abp.MultiTenancy;
using lygwys.BookList.Authorization.Users;

namespace lygwys.BookList.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
