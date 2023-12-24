using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        IMapper _mapper;

        public CompanyManager(ICompanyDal companyDal, IMapper mapper)
        {
            _companyDal = companyDal;
            _mapper = mapper;
        }

        public async Task<CreatedCompanyResponse> Add(CreateCompanyRequest createCompanyRequest)
        {
            Company company = _mapper.Map<Company>(createCompanyRequest);
            Company createdCompany = await _companyDal.AddAsync(company);
            CreatedCompanyResponse createdCompanyResponse = _mapper.Map<CreatedCompanyResponse>(createdCompany);

            return createdCompanyResponse;
        }

        public async Task<DeletedCompanyResponse> Delete(DeleteCompanyRequest deleteCompanyRequest)
        {


            Company  company = _mapper.Map< Company>(deleteCompanyRequest);
            Company deletedCompany = await _companyDal.DeleteAsync(company);
            DeletedCompanyResponse deletedCompanyResponse = _mapper.Map<DeletedCompanyResponse>(deletedCompany);
            return deletedCompanyResponse;
        }

        public async Task<IPaginate<GetListCompanyResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _companyDal.GetListAsync 
                (include: a => a.Include(a => a.Experiences),
                index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListCompanyResponse>>(data);

            return result;
        }

        public async Task<UpdatedCompanyResponse> Update(UpdateCompanyRequest updateCompanyRequest)
        {
            Company company = _mapper.Map<Company>(updateCompanyRequest);
            Company updatedCompany = await _companyDal.UpdateAsync(company);
            UpdatedCompanyResponse updatedCompanyResponse = _mapper.Map<UpdatedCompanyResponse>(updatedCompany);
            return updatedCompanyResponse;
        }
    }
}
