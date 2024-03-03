using AutoMapper;
using Business.Abstract;
using Business.DTOs.Manufacturers;
using Business.DTOs.Manufacturers;
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
    public class ManufacturerManager: IManufacturerService
    {
        IManufacturerDal _manufacturerDal;
        IMapper _mapper;

        public ManufacturerManager(IManufacturerDal manufacturerDal, IMapper mapper)
        {
            _manufacturerDal = manufacturerDal;
            _mapper = mapper;
        }

        public async Task<CreatedManufacturerResponse> Add(CreateManufacturerRequest createManufacturerRequest)
        {
            Manufacturer manufacturer = _mapper.Map<Manufacturer>(createManufacturerRequest);
            Manufacturer createdManufacturer = await _manufacturerDal.AddAsync(manufacturer);
            CreatedManufacturerResponse createdManufacturerResponse = _mapper.Map<CreatedManufacturerResponse>(createdManufacturer);
            return createdManufacturerResponse;
        }

        public async Task<DeletedManufacturerResponse> Delete(DeleteManufacturerRequest deleteManufacturerRequest)
        {
            Manufacturer? manufacturer = await _manufacturerDal.GetAsync(u => u.Id == deleteManufacturerRequest.Id);
            await _manufacturerDal.DeleteAsync(manufacturer);
            DeletedManufacturerResponse deletedManufacturerResponse = _mapper.Map<DeletedManufacturerResponse>(manufacturer);
            return deletedManufacturerResponse;
        }

        public async Task<IPaginate<GetListManufacturerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _manufacturerDal.GetListAsync(
                   index: pageRequest.PageIndex,
                   size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListManufacturerResponse>>(data);
            return result;
        }

        public async Task<UpdatedManufacturerResponse> Update(UpdateManufacturerRequest updateManufacturerRequest)
        {
            Manufacturer? manufacturer = await _manufacturerDal.GetAsync(u => u.Id == updateManufacturerRequest.Id);
            _mapper.Map(updateManufacturerRequest, manufacturer);
            Manufacturer updateManufacturer = await _manufacturerDal.UpdateAsync(manufacturer);
            UpdatedManufacturerResponse updatedManufacturerResponse = _mapper.Map<UpdatedManufacturerResponse>(updateManufacturer);
            return updatedManufacturerResponse;
        }
    }
}
