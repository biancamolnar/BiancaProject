using System.ComponentModel.DataAnnotations;

namespace BiancaProject.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int CommentId { get; set; }

        public string? CommentText { get; set; }

        public DateTime TimeWritten { get; set; } = DateTime.UtcNow;


        public string CaseId { get; set; } = null!;
        public CaseEntity Case { get; set; } = null!;
    }
}
