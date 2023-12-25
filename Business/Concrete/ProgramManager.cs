using AutoMapper;
using Business.Abstract;
using Business.DTOs.Programs;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
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
            Program program = _mapper.Map<Program>(deleteProgramRequest);
            Program deleteProgram = await _programDal.DeleteAsync(program);
            DeletedProgramResponse deleteProgramResponse = _mapper.Map<DeletedProgramResponse>(deleteProgram);
            return deleteProgramResponse;
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
            Program Program = _mapper.Map<Program>(updateProgramRequest);
            Program updateProgram = await _programDal.UpdateAsync(Program);
            UpdatedProgramResponse updateProgramResponse = _mapper.Map<UpdatedProgramResponse>(updateProgram);
            return updateProgramResponse;
        }
    }
}
