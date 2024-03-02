using AutoMapper;
using Business.Abstract;
using Business.DTOs.Grades;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GradeManager:IGradeService
    {
        IGradeDal _gradeDal;
        IMapper _mapper;

        public GradeManager(IGradeDal gradeDal, IMapper mapper)
        {
            _gradeDal = gradeDal;
            _mapper = mapper;
        }

        public async Task<CreatedGradeResponse> Add(CreateGradeRequest createGradeRequest)
        {
            Grade grade = _mapper.Map<Grade>(createGradeRequest);
            Grade createdGrade = await _gradeDal.AddAsync(grade);
            CreatedGradeResponse createdGradeResponse = _mapper.Map<CreatedGradeResponse>(createdGrade);
            return createdGradeResponse;
        }

        public async Task<DeletedGradeResponse> Delete(DeleteGradeRequest deleteGradeRequest)
        {
            Grade grade = _mapper.Map<Grade>(deleteGradeRequest);
            Grade deleteGrade = await _gradeDal.DeleteAsync(grade);
            DeletedGradeResponse deleteGradeResponse = _mapper.Map<DeletedGradeResponse>(deleteGrade);
            return deleteGradeResponse;
        }

        public async Task<IPaginate<GetListGradeResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _gradeDal.GetListAsync(include: g => g.Include(g => g.Exam).
            Include(g => g.User),
          index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListGradeResponse>>(data);
            return result;
        }

        public async Task<UpdatedGradeResponse> Update(UpdateGradeRequest updateGradeRequest)
        {
            Grade grade = _mapper.Map<Grade>(updateGradeRequest);
            Grade updateGrade = await _gradeDal.UpdateAsync(grade);
            UpdatedGradeResponse updateGradeResponse = _mapper.Map<UpdatedGradeResponse>(updateGrade);
            return updateGradeResponse;
        }
    }
}
