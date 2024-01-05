using AutoMapper;
using Business.Abstract;
using Business.DTOs.UserLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserLanguageManager : IUserLanguageService
    {
        IUserLanguageDal _userLanguageDal;
        IMapper _mapper;
        public UserLanguageManager(IUserLanguageDal userLanguageDal, IMapper mapper)
        {
            _mapper = mapper;
            _userLanguageDal = userLanguageDal;
        }

        public async Task<CreatedUserLanguageResponse> Add(CreateUserLanguageRequest createUserLanguageRequest)
        {
            UserLanguage userLanguage = _mapper.Map<UserLanguage>(createUserLanguageRequest);
            UserLanguage createdUserLanguage = await _userLanguageDal.AddAsync(userLanguage);
            CreatedUserLanguageResponse createdUserLanguageResponse = _mapper.Map<CreatedUserLanguageResponse>(createdUserLanguage);
            return createdUserLanguageResponse;
        }

     

        public async Task<DeletedUserLanguageResponse> Delete(DeleteUserLanguageRequest deleteUserLanguageRequest)
        {
            UserLanguage userLanguage = _mapper.Map<UserLanguage>(deleteUserLanguageRequest);
            UserLanguage deletedUserLanguage = await _userLanguageDal.DeleteAsync(userLanguage);
            DeletedUserLanguageResponse deletedUserLanguageResponse = _mapper.Map<DeletedUserLanguageResponse>(deletedUserLanguage);
            return deletedUserLanguageResponse;
        }

        public async Task<IPaginate<GetListUserLanguageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userLanguageDal.GetListAsync(include: l => l.Include(l => l.User)
                 .Include(l=>l.ForeignLanguage).Include(l=>l.LanguageLevel),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListUserLanguageResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserLanguageResponse> Update(UpdateUserLanguageRequest updateUserLanguageRequest)
        {
            UserLanguage userLanguage = _mapper.Map<UserLanguage>(updateUserLanguageRequest);
            UserLanguage updateUserLanguage = await _userLanguageDal.UpdateAsync(userLanguage);
            UpdatedUserLanguageResponse updateUserLanguageResponse = _mapper.Map<UpdatedUserLanguageResponse>(updateUserLanguage);
            return updateUserLanguageResponse;
        }
    }
}
