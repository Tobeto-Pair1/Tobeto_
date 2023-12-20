using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
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

public class InstructorManager : IInstructorService
{
    IInstructorDal _ınstructorDal;
    IMapper _mapper;

    public InstructorManager(IInstructorDal ınstructorDal, IMapper mapper)
    {
        _ınstructorDal = ınstructorDal;
        _mapper = mapper;
    }

    public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
    {
        Instructor ınstructor = _mapper.Map<Instructor>(createInstructorRequest);
        Instructor createdInstructor = await _ınstructorDal.AddAsync(ınstructor);
        CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
        return createdInstructorResponse;
    }

    public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
    {
        Instructor ınstructor = _mapper.Map<Instructor>(deleteInstructorRequest);
        Instructor deletedInstructor = await _ınstructorDal.DeleteAsync(ınstructor);
        DeletedInstructorResponse deletedInstructorResponse = _mapper.Map<DeletedInstructorResponse>(deletedInstructor);
        return deletedInstructorResponse;
    }

    public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _ınstructorDal.GetListAsync(include: a => a.Include(a => a.User),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListInstructorResponse>>(data);
        return result;
    }

    public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest)
    {
        Instructor ınstructor = _mapper.Map<Instructor>(updateInstructorRequest);
        Instructor updatedInstructor = await _ınstructorDal.UpdateAsync(ınstructor);
        UpdatedInstructorResponse updatedInstructorResponse = _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
        return updatedInstructorResponse;
    }
}
