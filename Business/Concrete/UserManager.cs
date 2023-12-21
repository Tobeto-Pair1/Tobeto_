using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;
    IMapper _mapper;



    public UserManager(IUserDal userDal)
    {
        this._userDal = userDal;

    }

   

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
    {
        User user = _mapper.Map<User>(createUserRequest);
        User createdUser = await _userDal.AddAsync(user);
        CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(createdUser);
        return createdUserResponse;

    }

        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
    {
        User user = _mapper.Map<User>(deleteUserRequest);
        User deletedUser = await _userDal.AddAsync(user);
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(deletedUser);
        return deletedUserResponse;
    }

    public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userDal.GetListAsync(include: a => a.Include(a => a.Address),
              index: pageRequest.PageIndex,
              size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        User user = _mapper.Map<User>(updateUserRequest);
        User updatedUser = await _userDal.AddAsync(user);
        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(updatedUser);
        return updatedUserResponse;
    }

    //public virtual Address Address { get; set; }
    //public virtual ICollection<UserSkill> UserSkills { get; set; }
    //public virtual ICollection<UserSocial> UserSocials { get; set; }
    //public virtual ICollection<Student> Students { get; set; }
    //public virtual ICollection<Employee> Employees { get; set; }
    //public virtual ICollection<Instructor> Instructors { get; set; }
    //public virtual ICollection<Experience> Experiences { get; set; }
}
