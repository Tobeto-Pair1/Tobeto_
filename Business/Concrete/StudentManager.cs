using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concrete;

public class StudentManager:IStudentService
{
    private readonly IStudentDal _studentDal;
    private readonly IMapper _mapper;

    public StudentManager(IStudentDal studentDal, IMapper mapper)
    {
        _studentDal = studentDal;
        _mapper = mapper;
    }

    public async Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _studentDal.GetListAsync(include: l => (IIncludableQueryable<Student, object>)l.Include(l => l.Id),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListStudentResponse>>(data);
        return result;
    }

    public async Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest)
    {
        Student student = _mapper.Map<Student>(createStudentRequest);
        Student createdStudent = await _studentDal.AddAsync(student);
        CreatedStudentResponse createdStudentResponse = _mapper.Map<CreatedStudentResponse>(createdStudent);
        return createdStudentResponse;
    }

    public async Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest)
    {
        Student student = _mapper.Map<Student>(updateStudentRequest);
        Student updateStudent = await _studentDal.UpdateAsync(student);
        UpdatedStudentResponse updatedStudentResponse = _mapper.Map<UpdatedStudentResponse>(updateStudent);
        return updatedStudentResponse;
    }

    public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
    {
        Student student = _mapper.Map<Student>(deleteStudentRequest);
        Student deletedStudent = await _studentDal.DeleteAsync(student);
        DeletedStudentResponse deletedStudentResponse = _mapper.Map<DeletedStudentResponse>(deletedStudent);
        return deletedStudentResponse;
    }
}