using AutoMapper;
using Business.Abstract;
using Business.DTOs.Cities;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class CityManager : ICityService
{
    private readonly ICityDal _cityDal;
    private readonly IMapper _mapper;

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
        City city = await _cityDal.GetAsync(b => b.Id == deleteCityRequest.Id);
        City deleteCity = await _cityDal.DeleteAsync(city);
        DeletedCityResponse deleteCityResponse = _mapper.Map<DeletedCityResponse>(deleteCity);
        return deleteCityResponse;
    }

    public async Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _cityDal.GetListAsync(include: a => a.Include(a => a.Country),
      index: pageRequest.PageIndex,
      size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListCityResponse>>(data);        
        return result;
    }
    public async Task<IPaginate<GetListCityResponse>> GetListByCountry(Guid countryId)
    {
        var data = await _cityDal.GetListAsync(predicate: a => a.CountryId == countryId, size: 81);

        var result = _mapper.Map<Paginate<GetListCityResponse>>(data);
        return result;
    }
    public async Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest)
    {
        City city = await _cityDal.GetAsync(b => b.Id == updateCityRequest.Id);
        _mapper.Map(updateCityRequest, city);
        City updateCity = await _cityDal.UpdateAsync(city);
        UpdatedCityResponse updateCityResponse = _mapper.Map<UpdatedCityResponse>(updateCity);
        return updateCityResponse;
    }
}
