using Entities.Concretes;

namespace Business.DTOs.Requests
{
    public class DeleteCompanyRequest
    {
        public string Name { get; set; }

        public Guid ExperienceId { get; set; }
    }
}
