using Entities.Concretes;

namespace Business.DTOs.Company
{
    public class DeletedCompanyResponse
    {
        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public Guid ExperienceId { get; set; }

    }
}
