using AutoMapper;
using Business.Abstract;
using Business.DTOs.Experiences;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class ExperienceManager : IExperienceService
{
    private readonly IExperienceDal _experienceDal;
    private readonly IMapper _mapper;

    public ExperienceManager(IExperienceDal experienceDal, IMapper mapper)
    {
        _experienceDal = experienceDal;
        _mapper = mapper;
    }

    public async Task<CreatedExperienceResponse> Add(CreateExperienceRequest createExperienceRequest)
    {
        Experience experience = _mapper.Map<Experience>(createExperienceRequest);
        Experience createdExperience = await _experienceDal.AddAsync(experience);
        CreatedExperienceResponse createdExperienceResponse = _mapper.Map<CreatedExperienceResponse>(createdExperience);
        return createdExperienceResponse;
    }

    public async Task<DeletedExperienceResponse> Delete(DeleteExperienceRequest deleteExperienceRequest)
    {
        Experience experience = await _experienceDal.GetAsync(e => e.Id == deleteExperienceRequest.Id);
        Experience deletedExperience = await _experienceDal.DeleteAsync(experience);
        DeletedExperienceResponse deletedExperienceResponse = _mapper.Map<DeletedExperienceResponse>(deletedExperience);
        return deletedExperienceResponse;
    }


    public async Task<IPaginate<GetListExperienceResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _experienceDal.GetListAsync(include: a => a.
               Include(a => a.City),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListExperienceResponse>>(data);
        return result;
    }

    public async Task<IPaginate<GetListExperienceResponse>> GetListByUser(Guid userId)
    {
        var data = await _experienceDal.GetListAsync(predicate: a => a.UserId == userId);

        var result = _mapper.Map<Paginate<GetListExperienceResponse>>(data);
        return result;
    }

    public async Task<UpdatedExperienceResponse> Update(UpdateExperienceRequest updateExperienceRequest)
    {
        Experience experience = await _experienceDal.GetAsync(e => e.Id == updateExperienceRequest.Id);
        _mapper.Map(updateExperienceRequest, experience);
        Experience updatedExperience = await _experienceDal.UpdateAsync(experience);
        UpdatedExperienceResponse updatedExperienceResponse = _mapper.Map<UpdatedExperienceResponse>(updatedExperience);
        return updatedExperienceResponse;
    }
}
