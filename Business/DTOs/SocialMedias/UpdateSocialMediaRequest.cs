﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.SocialMedias;

public class UpdateSocialMediaRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
