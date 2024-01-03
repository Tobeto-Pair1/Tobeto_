using System;

namespace Business.DTOs.Towns
{
    public class CreateTownRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

