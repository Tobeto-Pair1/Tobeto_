namespace Business.DTOs.ContactInformations
{
    public class UpdateContactInformationRequest
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
