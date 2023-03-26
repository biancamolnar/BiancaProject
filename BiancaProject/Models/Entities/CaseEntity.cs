using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiancaProject.Models.Entities
{
    internal class CaseEntity
    {
        [Key]
        public string CaseId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; } = null!;

        public DateTime TimeWritten { get; set; } = DateTime.UtcNow;

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public StatusEntity Status { get; set; } = null!;


        public int TenantId { get; set; }
        public TenantEntity Tenant { get; set; } = null!;

        public ICollection<CommentEntity> Commments { get; set; } = new HashSet<CommentEntity>();

    }
}
