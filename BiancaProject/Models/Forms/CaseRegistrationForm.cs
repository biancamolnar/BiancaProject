namespace BiancaProject.Models.Forms
{
    internal class CaseRegistrationForm
    {
        public string CaseId { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime TimeWritten { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
