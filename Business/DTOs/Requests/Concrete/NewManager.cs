using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewManager : INewService
    {
        INewDal _newDal;
        IMapper _mapper;

        public NewManager(INewDal newDal, IMapper mapper)
        {
            _newDal = newDal;
            _mapper = mapper;
        }

        public async Task<CreatedNewResponse> Add(CreateNewRequest createNewRequest)
        {
            New @new = _mapper.Map<New>(createNewRequest);
            New createdNew = await _newDal.AddAsync(@new);
            CreatedNewResponse createdNewResponse = _mapper.Map<CreatedNewResponse>(createdNew);
            return createdNewResponse;
        }

        public async Task<DeletedNewResponse> Delete(DeleteNewRequest deleteNewRequest)
        {
            New @new = _mapper.Map<New>(deleteNewRequest);
            New deletedNew = await _newDal.DeleteAsync(@new);
            DeletedNewResponse deletedNewResponse = _mapper.Map<DeletedNewResponse>(deletedNew);
            return deletedNewResponse;
        }

        public async Task<IPaginate<GetListNewResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _newDal.GetListAsync(include: l => l.Include(l => l.NotificationType),
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListNewResponse>>(data);
            return result;
        }

        public async Task<UpdatedNewResponse> Update(UpdateNewRequest updateNewRequest)
        {
            New @new = _mapper.Map<New>(updateNewRequest);
            New updatedNew = await _newDal.UpdateAsync(@new);
            UpdatedNewResponse updateNewResponse = _mapper.Map<UpdatedNewResponse>(updatedNew);
            return updateNewResponse;
        }
    }
}
