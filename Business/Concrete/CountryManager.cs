using AutoMapper;
using Business.Abstract;
using Business.DTOs.Company;
using Business.DTOs.Country;
using Business.DTOs.Requests;
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
    public class CountryManager : ICountryService
    {
        IMapper _mapper;
        ICountryDal _countryDal;

        public CountryManager(IMapper mapper, ICountryDal countryDal)
        {
            _mapper = mapper;
            _countryDal = countryDal;
        }

        public async Task<CreatedCountryResponse> Add(CreateCountryRequest createCountryRequest)
        {
            Country country = _mapper.Map<Country>(createCountryRequest);
            Country createdCountry = await _countryDal.AddAsync(country);
            CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(createdCountry);
            return createdCountryResponse;
        }

        public async Task<DeletedCountryResponse> Delete(DeleteCountryRequest deleteCountryRequest)
        {
            Country country = _mapper.Map<Country>(deleteCountryRequest);
            Country deletedCountry = await _countryDal.DeleteAsync(country);
            DeletedCountryResponse deletedCountryResponse = _mapper.Map<DeletedCountryResponse>(deletedCountry);
            return deletedCountryResponse;
        }

        public async Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _countryDal.GetListAsync
               (include: a => a.Include(a => a.Cities),
               index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListCountryResponse>>(data);

            return result;
        }

        public async Task<UpdatedCountryResponse> Update(UpdateCountryRequest updateCountryRequest)
        {
            Country country = _mapper.Map<Country>(updateCountryRequest);
            Country updateCountry = await _countryDal.DeleteAsync(country);
            UpdatedCountryResponse updatedCountryResponse = _mapper.Map<UpdatedCountryResponse>(updateCountry);
            return updatedCountryResponse;
        }
    }
}
