using System;
using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concrete
{
    public class TownManager : ITownService
    {
        private readonly ITownDal _townDal;
        private readonly IMapper _mapper;

        public TownManager(ITownDal townDal, IMapper mapper)
        {
            _townDal = townDal;
            _mapper = mapper;
        }

        public async Task<CreatedTownResponse> Add(CreateTownRequest createTownRequest)
        {

            Town town = _mapper.Map<Town>(createTownRequest);
            Town createdTown = await _townDal.AddAsync(town);
            CreatedTownResponse createdTownResponse = _mapper.Map<CreatedTownResponse>(createdTown);
            return createdTownResponse;

        }

        public async Task<DeletedTownResponse> Delete(DeleteTownRequest deleteTownRequest)
        {
            Town town = _mapper.Map<Town>(deleteTownRequest);
            Town deletedTown = await _townDal.DeleteAsync(town);
            DeletedTownResponse deletedTownResponse = _mapper.Map<DeletedTownResponse>(deletedTown);
            return deletedTownResponse;
        }

        public async Task<IPaginate<GetListTownResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _townDal.GetListAsync(include: l => (IIncludableQueryable<Town, object>)l.Include(l => l.Id),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListTownResponse>>(data);
            return result;
        }

        public async Task<UpdatedTownResponse> Update(UpdateTownRequest updateTownRequest)
        {
            Town town = _mapper.Map<Town>(updateTownRequest);
            Town updateTown = await _townDal.UpdateAsync(town);
            UpdatedTownResponse updatedTownResponse = _mapper.Map<UpdatedTownResponse>(updateTown);
            return updatedTownResponse;

           
        }
    }
}

