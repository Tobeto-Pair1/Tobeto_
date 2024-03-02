using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Experiences;

public class CreateExperienceRequest
{
    public Guid UserId { get; set; }
    public Guid CityId { get; set; }
    public string CompanyName { get; set; }
    public string PositionName { get; set; }
    public string SectorName { get; set; }
    public string Description { get; set; }
    public DateTime JobStart { get; set; }
    public DateTime JobCompletion { get; set; }
}
