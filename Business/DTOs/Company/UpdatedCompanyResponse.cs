using Entities.Concretes;

namespace Business.DTOs.Company
{
    public class UpdatedCompanyResponse
    {
        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public Guid ExperienceId { get; set; }
    }
}
