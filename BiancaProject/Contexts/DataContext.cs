using BiancaProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiancaProject.Contexts
{
    internal class DataContext : DbContext
    {
        #region constructors and overrides
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Besitzer\Desktop\BiancaProject\BiancaProject\Contexts\BiancaProjectDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        }
        #endregion

        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<TenantEntity> Tenants { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
    }
}
