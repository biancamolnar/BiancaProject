using BiancaProject.Contexts;
using BiancaProject.Models.Entities;
using BiancaProject.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace BiancaProject.Services
{
    internal class TenantService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<TenantEntity> GetOrCreateIfNotExistsAsync(CaseRegistrationForm form)
        {
            var tenantEntity = await _context.Tenants.FirstOrDefaultAsync(x => x.Email == form.Email);
            if (tenantEntity == null)
            {
                tenantEntity = new TenantEntity()
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    PhoneNumber = form.PhoneNumber,
                    Email = form.Email
                };
                _context.Add(tenantEntity);
                await _context.SaveChangesAsync();
            }
            return tenantEntity;
        }

    }
}
