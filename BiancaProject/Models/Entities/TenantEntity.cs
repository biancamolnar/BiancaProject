using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BiancaProject.Models.Entities
{
    internal class TenantEntity
    {
        [Key]
        public int TenantId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    }
}
