using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Users
{
    public class GetListUserResponse
    {
        public Guid Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? ImageId { get; set; }
        public DateTime BirthDate { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string TownName { get; set; }
        public string Description { get; set; }
    }
}
