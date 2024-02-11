using AutoMapper;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business.Abstract;
using Business.DTOs.UserSkills;
using Business.DTOs.Skills;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class UserSkillManager : IUserSkillService
    {
        IUserSkillDal _userSkillDal;
        IMapper _mapper;

        public UserSkillManager(IUserSkillDal userSkillDal, IMapper mapper)
        {
            _userSkillDal = userSkillDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserSkillResponse> Add(CreateUserSkillRequest createUserSkillRequest)
        {
            UserSkill userSkill = _mapper.Map<UserSkill>(createUserSkillRequest);
            UserSkill createdUserSkill = await _userSkillDal.AddAsync(userSkill);
            CreatedUserSkillResponse createdUserSkillResponse = _mapper.Map<CreatedUserSkillResponse>(createdUserSkill);
            return createdUserSkillResponse;
        }

        public async Task<DeletedUserSkillResponse> Delete(DeleteUserSkillRequest deleteUserSkillRequest)
        {
            UserSkill userSkill = await _userSkillDal.GetAsync(u => u.Id == deleteUserSkillRequest.Id);
            _mapper.Map(deleteUserSkillRequest, userSkill);
            UserSkill deletedUserSkill = await _userSkillDal.DeleteAsync(userSkill);
            DeletedUserSkillResponse deletedUserSkillResponse = _mapper.Map<DeletedUserSkillResponse>(deletedUserSkill);
            return deletedUserSkillResponse;
        }

        public async Task<IPaginate<GetListUserSkillResponse>> GetListAsync(PageRequest pageRequest)
        {

            var data = await _userSkillDal.GetListAsync(include: a => a.Include(a => a.User).Include(a => a.Skill),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListUserSkillResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserSkillResponse> Update(UpdateUserSkillRequest updateUserSkillRequest)
        {
            UserSkill userSkill = _mapper.Map<UserSkill>(updateUserSkillRequest);
            UserSkill updatedUserSkill = await _userSkillDal.UpdateAsync(userSkill);
            UpdatedUserSkillResponse updatedUserSkillResponse = _mapper.Map<UpdatedUserSkillResponse>(updatedUserSkill);
            return updatedUserSkillResponse;
        }
    }
}
