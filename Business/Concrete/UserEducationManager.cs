using System;
using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concrete
{
    public class UserEducationManager : IUserEducationService
    {
        private readonly IUserEducationDal _userEducationDal;
        private readonly IMapper _mapper;

        public UserEducationManager(IUserEducationDal userEducationDal, IMapper mapper)
        {
            _userEducationDal = userEducationDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserEducationResponse> Add(CreateUserEducationRequest createUserEducationRequest)
        {
            UserEducation userEducation = _mapper.Map<UserEducation>(createUserEducationRequest);
            UserEducation createdUserEducation = await _userEducationDal.AddAsync(userEducation);
            CreatedUserEducationResponse createdUserEducationResponse = _mapper.Map<CreatedUserEducationResponse>(createdUserEducation);
            return createdUserEducationResponse;
        }

        public async Task<DeletedUserEducationResponse> Delete(DeleteUserEducationRequest deleteUserEducationRequest)
        {
            UserEducation userEducation = _mapper.Map<UserEducation>(deleteUserEducationRequest);
            UserEducation deletedUserEducation = await _userEducationDal.DeleteAsync(userEducation);
            DeletedUserEducationResponse deletedUserEducationResponse = _mapper.Map<DeletedUserEducationResponse>(deletedUserEducation);
            return deletedUserEducationResponse;
        }

        public async Task<IPaginate<GetListUserEducationResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userEducationDal.GetListAsync(include: l => (IIncludableQueryable<UserEducation, object>)l.Include(l => l.Id),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListUserEducationResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserEducationResponse> Update(UpdateUserEducationRequest updateUserEducationRequest)
        {
            UserEducation userEducation = _mapper.Map<UserEducation>(updateUserEducationRequest);
            UserEducation updateUserEducation = await _userEducationDal.UpdateAsync(userEducation);
            UpdatedUserEducationResponse updatedUserEducationResponse = _mapper.Map<UpdatedUserEducationResponse>(updateUserEducation);
            return updatedUserEducationResponse;
        }
    }
}

