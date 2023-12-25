using AutoMapper;
using Business.Abstract;
using Business.DTOs.Cities;
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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        IMapper _mapper;

        public CityManager(ICityDal cityDal,IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }

        public async Task<CreatedCityResponse> Add(CreateCityRequest createCityRequest)
        {
            City city = _mapper.Map<City>(createCityRequest);
            City createdCity = await _cityDal.AddAsync(city);
            CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(createdCity);
            return createdCityResponse;
        }

        public async Task<DeletedCityResponse> Delete(DeleteCityRequest deleteCityRequest)
        {
            City city = _mapper.Map<City>(deleteCityRequest);
            City deleteCity = await _cityDal.DeleteAsync(city);
            DeletedCityResponse deleteCityResponse = _mapper.Map<DeletedCityResponse>(deleteCity);
            return deleteCityResponse;
        }

        public async Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _cityDal.GetListAsync(include: a => a.Include(a => a.Towns).
       Include(a => a.Country),
          index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListCityResponse>>(data);
            return result;
        }

        public async Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest)
        {
            City city = _mapper.Map<City>(updateCityRequest);
            City updateCity = await _cityDal.UpdateAsync(city);
            UpdatedCityResponse updateCityResponse = _mapper.Map<UpdatedCityResponse>(updateCity);
            return updateCityResponse;
        }
    }
}
