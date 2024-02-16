using AutoMapper;
using Business.Abstract;
using Business.DTOs.Instructors;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concretes;


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
        Instructor ınstructor = await _ınstructorDal.GetAsync(u => u.Id == deleteInstructorRequest.Id);
        Instructor deletedInstructor = await _ınstructorDal.DeleteAsync(ınstructor);
        DeletedInstructorResponse deletedInstructorResponse = _mapper.Map<DeletedInstructorResponse>(deletedInstructor);
        return deletedInstructorResponse;
    }

    public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _ınstructorDal.GetListAsync(
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListInstructorResponse>>(data);
        return result;
    }

    public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest)
    {
        Instructor ınstructor = await _ınstructorDal.GetAsync(u => u.Id == updateInstructorRequest.Id);
        _mapper.Map(updateInstructorRequest, ınstructor);
        Instructor updatedInstructor = await _ınstructorDal.UpdateAsync(ınstructor);
        UpdatedInstructorResponse updatedInstructorResponse = _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
        return updatedInstructorResponse;
    }
    public async Task<UserAuth> GetByMail(string email)
    {
        var result = await _ınstructorDal.GetAsync(u => u.Email == email);
        UserAuth userAuth = _mapper.Map<UserAuth>(result);
        return userAuth;
    }
}
