using System;

namespace Business.DTOs.Towns
{
    public class DeleteTownRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

