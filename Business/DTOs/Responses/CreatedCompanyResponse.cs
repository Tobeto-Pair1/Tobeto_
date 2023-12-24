using Entities.Concretes;

namespace Business.DTOs.Responses
{
    public class CreatedCompanyResponse
    {
        public string Name { get; set; }
        public Guid CompanyId { get; set; }

        public Guid ExperienceId { get; set; }

    }
}
