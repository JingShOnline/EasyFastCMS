using System.Linq;
using EasyFast.EntityFramework;
using EasyFast.Core.MultiTenancy;

namespace EasyFast.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly EasyFastDbContext _context;

        public DefaultTenantCreator(EasyFastDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
