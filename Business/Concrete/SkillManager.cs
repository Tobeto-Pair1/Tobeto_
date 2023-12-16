using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concrete;

public class SkillManager : ISkillService
{
    private readonly ISkillDal _skillDal;
    private readonly IMapper _mapper;
    
    public SkillManager(ISkillDal skillDal, IMapper mapper)
    {
        _skillDal = skillDal;
        _mapper = mapper;
    }
    public async Task<CreatedSkillResponse> Add(CreateSkillRequest createSkillRequest)
    {
        Skill skill = _mapper.Map<Skill>(createSkillRequest);
        Skill createdSkill = await _skillDal.AddAsync(skill);
        CreatedSkillResponse createdSkillResponse = _mapper.Map<CreatedSkillResponse>(createdSkill);
        return createdSkillResponse;
    }
    public async Task<DeletedSkillResponse> Delete(DeleteSkillRequest deleteSkillRequest)
    {
        Skill skill = _mapper.Map<Skill>(deleteSkillRequest);
        Skill deletedSkill = await _skillDal.DeleteAsync(skill);
        DeletedSkillResponse deletedSkillResponse = _mapper.Map<DeletedSkillResponse>(deletedSkill);
        return deletedSkillResponse;
    }
    public async Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _skillDal.GetListAsync(include: l => (IIncludableQueryable<Skill, object>)l.Include(l => l.Id),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListSkillResponse>>(data);
        return result;
    }
    public async Task<UpdatedSkillResponse> Update(UpdateSkillRequest updateSkillRequest)
    {
        Skill skill = _mapper.Map<Skill>(updateSkillRequest);
        Skill updateSkill = await _skillDal.UpdateAsync(skill);
        UpdatedSkillResponse updatedSkillResponse = _mapper.Map<UpdatedSkillResponse>(updateSkill);
        return updatedSkillResponse;
    }
}