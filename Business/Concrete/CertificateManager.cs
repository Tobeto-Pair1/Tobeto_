using AutoMapper;
using Business.Abstract;
using Business.DTOs.Certificate;
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
   

    public class CertificateManager : ICertificateService
    {
        ICertificateDal _certificateDal;
        IMapper _mapper;

        public CertificateManager(ICertificateDal certificateDal, IMapper mapper)
        {
            _certificateDal = certificateDal;
            _mapper = mapper;
        }

        public async Task<CreatedCertificateResponse> Add(CreateCertificateRequest createCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
            Certificate createdCertificate = await _certificateDal.AddAsync(certificate);
            CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(createdCertificate);
            return createdCertificateResponse;
        }

        public async Task<DeletedCertificateResponse> Delete(DeleteCertificateRequest deleteCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(deleteCertificateRequest);
            Certificate deleteCertificate = await _certificateDal.DeleteAsync(certificate);
            DeletedCertificateResponse deletedCertificateResponse = _mapper.Map<DeletedCertificateResponse>(deleteCertificate);
            return deletedCertificateResponse;
        }

        public async Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _certificateDal.GetListAsync(include: a => a.Include(a => a.User),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListCertificateResponse>>(data);
            return result;
        }

        public async Task<UpdatedCertificateResponse> Update(UpdateCertificateRequest updateCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(updateCertificateRequest);
            Certificate updatedCertificate = await _certificateDal.UpdateAsync(certificate);
            UpdatedCertificateResponse updatedCertificateResponse = _mapper.Map<UpdatedCertificateResponse>(updatedCertificate);
            return updatedCertificateResponse;
        }
    }
}
