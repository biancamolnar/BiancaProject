using System.ComponentModel.DataAnnotations;

namespace BiancaProject.Models.Entities
{
    internal class StatusEntity
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string StatusName { get; set; } = null!;

        public ICollection<CaseEntity> CaseStatuses { get; set; } = new HashSet<CaseEntity>();

    }
}
