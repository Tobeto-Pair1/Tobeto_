﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; }
        public string DepartmentName { get; set; }

    }
}