using Business.Dtos.Requests;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IUserService
{
    void Delete(User user); 
    Task Add(CreateUserRequest request);


}
