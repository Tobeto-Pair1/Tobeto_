﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class GetListUserSkillResponse
    {
        public Guid SkillId { get; set; }
        public Guid UserId { get; set; }
    }
}
