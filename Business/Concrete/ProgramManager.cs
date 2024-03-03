using AutoMapper;
using Business.Abstract;
using Business.DTOs.Programs;
using Business.DTOs.Programs;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProgramManager : IProgramService
    {
        IProgramDal _programDal;
        IMapper _mapper;

        public ProgramManager(IProgramDal programDal, IMapper mapper)
        {
            _programDal = programDal;
            _mapper = mapper;
        }

        public async Task<CreatedProgramResponse> Add(CreateProgramRequest createProgramRequest)
        {
            Program program = _mapper.Map<Program>(createProgramRequest);
            Program createdProgram = await _programDal.AddAsync(program);
            CreatedProgramResponse createdProgramResponse = _mapper.Map<CreatedProgramResponse>(createdProgram);
            return createdProgramResponse;
        }

        public async Task<DeletedProgramResponse> Delete(DeleteProgramRequest deleteProgramRequest)
        {
            Program? program = await _programDal.GetAsync(u => u.Id == deleteProgramRequest.Id);
            await _programDal.DeleteAsync(program);
            DeletedProgramResponse deletedProgramResponse = _mapper.Map<DeletedProgramResponse>(program);
            return deletedProgramResponse;
        }

        public async Task<IPaginate<GetListProgramResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _programDal.GetListAsync(
               index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListProgramResponse>>(data);
            return result;
        }

        public async Task<UpdatedProgramResponse> Update(UpdateProgramRequest updateProgramRequest)
        {
            Program? program = await _programDal.GetAsync(u => u.Id == updateProgramRequest.Id);
            _mapper.Map(updateProgramRequest, program);
            Program updateProgram = await _programDal.UpdateAsync(program);
            UpdatedProgramResponse updatedProgramResponse = _mapper.Map<UpdatedProgramResponse>(updateProgram);
            return updatedProgramResponse;
        }
    }
}
