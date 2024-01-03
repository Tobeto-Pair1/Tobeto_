using AutoMapper;
using Business.Abstract;
using Business.DTOs.Users;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
   

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public  async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
    {

        User user = _mapper.Map<User>(createUserRequest);

        User userCreated = await _userDal.AddAsync(user);

        CreatedUserResponse createUserResponse = _mapper.Map<CreatedUserResponse>(userCreated);

        return createUserResponse;

    }



    public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
    {

        User user = _mapper.Map<User>(deleteUserRequest);

        User userDeleted = await _userDal.DeleteAsync(user);
       
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(userDeleted);
        
        return deletedUserResponse;

    }


    
public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userDal.GetListAsync(include: l => l.
           Include(l => l.Address.City).
           Include(l => l.Address.Country).
           Include(l => l.Address.Town),
                     index: pageRequest.PageIndex,
                     size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        User user = _mapper.Map<User>(updateUserRequest);

        User userUpdated = await _userDal.UpdateAsync(user);

        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(userUpdated);

        return updatedUserResponse;
    }

 


    

   

 


}
