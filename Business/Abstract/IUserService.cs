﻿using Business.DTOs.Request;
using Business.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IUserService
{

    public Task Add(CreateUserRequest request);





}