﻿using AutoMapper;
using Business.Abstract;
using Business.DTOs.StudentAnswers;
using Business.DTOs.StudentAnswers;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class StudentAnswerManager: IStudentAnswerService
{
    IStudentAnswerDal _studentAnswerDal;
    IMapper _mapper;

    public StudentAnswerManager(IStudentAnswerDal studentAnswerDal, IMapper mapper)
    {
        _studentAnswerDal = studentAnswerDal;
        _mapper = mapper;
    }

    public async Task<CreatedStudentAnswerResponse> Add(CreateStudentAnswerRequest createStudentAnswerRequest)
    {
        StudentAnswer studentAnswer = _mapper.Map<StudentAnswer>(createStudentAnswerRequest);
        StudentAnswer createdStudentAnswer = await _studentAnswerDal.AddAsync(studentAnswer);
        CreatedStudentAnswerResponse createdStudentAnswerResponse = _mapper.Map<CreatedStudentAnswerResponse>(createdStudentAnswer);
        return createdStudentAnswerResponse;
    }

    public async Task<DeletedStudentAnswerResponse> Delete(DeleteStudentAnswerRequest deleteStudentAnswerRequest)
    {
        StudentAnswer? studentAnswer = await _studentAnswerDal.GetAsync(u => u.Id == deleteStudentAnswerRequest.Id);
        await _studentAnswerDal.DeleteAsync(studentAnswer);
        DeletedStudentAnswerResponse deletedStudentAnswerResponse = _mapper.Map<DeletedStudentAnswerResponse>(studentAnswer);
        return deletedStudentAnswerResponse;
    }

    public async Task<IPaginate<GetListStudentAnswerResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _studentAnswerDal.GetListAsync(include: a => a.Include(a => a.User).Include(a => a.Question),
      index: pageRequest.PageIndex,
      size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListStudentAnswerResponse>>(data);
        return result;
    }

    public async Task<UpdatedStudentAnswerResponse> Update(UpdateStudentAnswerRequest updateStudentAnswerRequest)
    {
        StudentAnswer? studentAnswer = await _studentAnswerDal.GetAsync(u => u.Id == updateStudentAnswerRequest.Id);
        _mapper.Map(updateStudentAnswerRequest, studentAnswer);
        StudentAnswer updateStudentAnswer = await _studentAnswerDal.UpdateAsync(studentAnswer);
        UpdatedStudentAnswerResponse updatedStudentAnswerResponse = _mapper.Map<UpdatedStudentAnswerResponse>(updateStudentAnswer);
        return updatedStudentAnswerResponse;
    }
}
