using System;
using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concrete
{
    public class SectorManager : ISectorService
    {
        private readonly ISectorDal _sectorDal;
        private readonly IMapper _mapper;

        public SectorManager(ISectorDal sectorDal, IMapper mapper)
        {
            _sectorDal = sectorDal;
            _mapper = mapper;
        }

        public async Task<CreatedSectorResponse> Add(CreateSectorRequest createSectorRequest)
        {
            Sector sector = _mapper.Map<Sector>(createSectorRequest);
            Sector createdSector = await _sectorDal.AddAsync(sector);
            CreatedSectorResponse createdSectorResponse = _mapper.Map<CreatedSectorResponse>(createdSector);
            return createdSectorResponse;
        }

        public async Task<DeletedSectorResponse> Delete(DeleteSectorRequest deleteSectorRequest)
        {
            Sector sector = _mapper.Map<Sector>(deleteSectorRequest);
            Sector deletedSector = await _sectorDal.DeleteAsync(sector);
            DeletedSectorResponse deletedSectorResponse = _mapper.Map<DeletedSectorResponse>(deletedSector);
            return deletedSectorResponse;
        }

        public async Task<IPaginate<GetListSectorResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _sectorDal.GetListAsync(include: l => (IIncludableQueryable<Sector, object>)l.Include(l => l.Id),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListSectorResponse>>(data);
            return result;
        }

        public async Task<UpdatedSectorResponse> Update(UpdateSectorRequest updateSectorRequest)
        {

            Sector sector = _mapper.Map<Sector>(updateSectorRequest);
            Sector updateSector = await _sectorDal.UpdateAsync(sector);
            UpdatedSectorResponse updatedSectorResponse = _mapper.Map<UpdatedSectorResponse>(updateSector);
            return updatedSectorResponse;
        }
    }
}

