using AutoMapper;
using Business.Abstract;
using Business.DTOs.Skills;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

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
        Skill skill = await _skillDal.GetAsync(u => u.Id == deleteSkillRequest.Id);
        _mapper.Map(deleteSkillRequest, skill);
        Skill deletedSkill = await _skillDal.DeleteAsync(skill);
        DeletedSkillResponse deletedSkillResponse = _mapper.Map<DeletedSkillResponse>(deletedSkill);
        return deletedSkillResponse;
    }
    public async Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _skillDal.GetListAsync(index: pageRequest.PageIndex,size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListSkillResponse>>(data);
        return result;
    }
    public async Task<UpdatedSkillResponse> Update(UpdateSkillRequest updateSkillRequest)
    {
        Skill skill = await _skillDal.GetAsync(u => u.Id == updateSkillRequest.Id);
        _mapper.Map(updateSkillRequest, skill);
        Skill updateSkill = await _skillDal.UpdateAsync(skill);
        UpdatedSkillResponse updatedSkillResponse = _mapper.Map<UpdatedSkillResponse>(updateSkill);
        return updatedSkillResponse;
    }
}