using AutoMapper;
using Business.Abstract;
using Business.DTOs.SubTypes;
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
    public class SubTypeManager : ISubTypeService
    {
        ISubTypeDal _subTypeDal;
        IMapper _mapper;

        public SubTypeManager(ISubTypeDal subTypeDal, IMapper mapper)
        {
            _subTypeDal = subTypeDal;
            _mapper = mapper;
        }

        public async Task<CreatedSubTypeResponse> Add(CreateSubTypeRequest createSubTypeRequest)
        {
            SubType subType = _mapper.Map<SubType>(createSubTypeRequest);
            SubType createdSubType = await _subTypeDal.AddAsync(subType);
            CreatedSubTypeResponse createdSubTypeResponse = _mapper.Map<CreatedSubTypeResponse>(createdSubType);
            return createdSubTypeResponse;
        }

        public async Task<DeletedSubTypeResponse> Delete(DeleteSubTypeRequest deleteSubTypeRequest)
        {
            SubType subType = _mapper.Map<SubType>(deleteSubTypeRequest);
            SubType deleteSubType = await _subTypeDal.DeleteAsync(subType);
            DeletedSubTypeResponse deleteSubTypeResponse = _mapper.Map<DeletedSubTypeResponse>(deleteSubType);
            return deleteSubTypeResponse;
        }

        public async Task<IPaginate<GetListSubTypeResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _subTypeDal.GetListAsync(
                index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListSubTypeResponse>>(data);
            return result;
        }

        public async Task<UpdatedSubTypeResponse> Update(UpdateSubTypeRequest updateSubTypeRequest)
        {
            SubType subType = _mapper.Map<SubType>(updateSubTypeRequest);
            SubType updateSubType = await _subTypeDal.UpdateAsync(subType);
            UpdatedSubTypeResponse updateSubTypeResponse = _mapper.Map<UpdatedSubTypeResponse>(updateSubType);
            return updateSubTypeResponse;
        }
    }
}
