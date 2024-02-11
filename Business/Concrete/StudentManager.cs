using AutoMapper;
using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.Students;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection.Metadata;

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
        var data = await _studentDal.GetListAsync(include: s => s
        .Include(s => s.User)
          .Include(l => l.User.Address.City)
          .Include(l => l.User.Address.Country)
           .Include(l => l.User.Address.Town),
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
        Student? student = await _studentDal.GetAsync(u => u.Id == updateStudentRequest.Id);
        _mapper.Map(updateStudentRequest, student);
        Student updateStudent = await _studentDal.UpdateAsync(student);
        UpdatedStudentResponse updatedStudentResponse = _mapper.Map<UpdatedStudentResponse>(updateStudent);
        return updatedStudentResponse;
    }

    public async Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest)
    {
        Student? student = await _studentDal.GetAsync(u => u.Id == deleteStudentRequest.Id);
        Student deletedStudent = await _studentDal.DeleteAsync(student);
        DeletedStudentResponse deletedStudentResponse = _mapper.Map<DeletedStudentResponse>(deletedStudent);
        return deletedStudentResponse;
    }
}