using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }

        public async Task<CreatedAddressResponse> Add(CreateAddressRequest createAddressRequest)
        {
            Address address = _mapper.Map<Address>(createAddressRequest);
            Address createdAddress = await _addressDal.AddAsync(address);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(createdAddress);
            return createdAddressResponse;
        }

        public async Task<DeletedAddressResponse> Delete(DeleteAddressRequest deleteAddressRequest)
        {
            Address address = _mapper.Map<Address>(deleteAddressRequest);
            Address deletedAddress = await _addressDal.DeleteAsync(address);
            DeletedAddressResponse deletedAddressResponse = _mapper.Map<DeletedAddressResponse>(deletedAddress);
            return deletedAddressResponse;
        }

        public async Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _addressDal.GetListAsync(include: a => a.Include(a => a.City).
            Include(a=>a.Country).Include(a=>a.Town),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListAddressResponse>>(data);
            return result;
        }

        public async Task<UpdatedAddressResponse> Update(UpdateAddressRequest updateAddressRequest)
        {
            Address address = _mapper.Map<Address>(updateAddressRequest);
            Address updateAddress = await _addressDal.UpdateAsync(address);
            UpdatedAddressResponse updatedAddressResponse = _mapper.Map<UpdatedAddressResponse>(updateAddress);
            return updatedAddressResponse;
        }
    }
}
