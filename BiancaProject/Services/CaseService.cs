
using BiancaProject.Contexts;
using BiancaProject.Models.Entities;
using BiancaProject.Models.Forms;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BiancaProject.Services
{
    internal class CaseService
    {
        private readonly DataContext _context = new DataContext();
        private readonly TenantService _tenantService = new TenantService();

        //registrate a new case
        public async Task<CaseEntity> CreateAsync(CaseRegistrationForm form)
        {
            var caseEntity = new CaseEntity()
            {
                Description = form.Description,
                TimeWritten = DateTime.Now,
                StatusId = 1,
                TenantId = (await _tenantService.GetOrCreateIfNotExistsAsync(form)).TenantId,
            };

            _context.Add(caseEntity);
            await _context.SaveChangesAsync();

            return caseEntity;
        }

        //get all cases
        public async Task<IEnumerable<CaseEntity>> GetAllAsync()
        {
            return await _context.Cases
                .Include(x => x.Tenant)
                .Include(x => x.Status)
                .Include(x => x.Commments)
                .ToListAsync();
        }

        //get a specific case
        public async Task<CaseEntity> GetAsync(string caseId)
        {
            var caseEntity = await _context.Cases
                .Include(x => x.Tenant)
                .Include(x => x.Status)
                .Include(x => x.Commments)
                .FirstOrDefaultAsync(x => x.CaseId == caseId);
            if (caseEntity != null)
                return caseEntity;

            return null!;
        }

        //change status of specific case
        public async Task ChangeStatusAsync(string caseId, int statusId)
        {
            var _case = await GetAsync(caseId);
            _case.StatusId = statusId;

            await _context.SaveChangesAsync();
        }
    }
}
