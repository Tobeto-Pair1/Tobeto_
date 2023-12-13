using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public class EducationManager : IEducationService
{
   IEducationDal _educationDal;
    IMapper _mapper;

    public EducationManager(IEducationDal educationDal, IMapper mapper)
    {
        _educationDal = educationDal;
        _mapper = mapper;
    }

    public async Task<CreatedEducationResponse> Add(CreateEducationRequest createEducationRequest)
    {
        Education education = _mapper.Map<Education>(createEducationRequest);
        Education createdEducation = await _educationDal.AddAsync(education);
        CreatedEducationResponse educationResponse = _mapper.Map<CreatedEducationResponse>(createdEducation);
        return educationResponse;

    }

    public async Task<DeletedEducationResponse> Delete(DeleteEducationRequest deleteEducationRequest)
    {
        Education education = _mapper.Map<Education>(deleteEducationRequest);
        Education deletedEducation = await _educationDal.DeleteAsync(education);
        DeletedEducationResponse educationResponse = _mapper.Map<DeletedEducationResponse>(deletedEducation);
        return educationResponse;
    }

    public async Task<IPaginate<GetListEducationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _educationDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListEducationResponse>>(data);
        return result;
    }
}
