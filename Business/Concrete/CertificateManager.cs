using AutoMapper;
using Business.Abstract;
using Business.DTOs.Certificate;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Utilities.FileUpload;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class CertificateManager : ICertificateService
{
    private readonly ICertificateDal _certificateDal;
    private readonly IMapper _mapper;
    private readonly IFileUploadAdapter _fileUploadAdapter;

    public CertificateManager(ICertificateDal certificateDal, IMapper mapper, IFileUploadAdapter fileUploadAdapter)
    {
        _certificateDal = certificateDal;
        _mapper = mapper;
        _fileUploadAdapter = fileUploadAdapter;
    }

    public async Task<CreatedCertificateResponse> Add(CreateCertificateRequest createCertificateRequest)
    {
        Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);

        certificate.FileName = createCertificateRequest.File.FileName;
        certificate.FileUrl = await _fileUploadAdapter.UploadPdf(createCertificateRequest.File);

        Certificate createdCertificate = await _certificateDal.AddAsync(certificate);
        CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(createdCertificate);
        return createdCertificateResponse;
    }

    public async Task<DeletedCertificateResponse> Delete(DeleteCertificateRequest deleteCertificateRequest)
    {
        Certificate certificate = await _certificateDal.GetAsync(f => f.Id == deleteCertificateRequest.Id);
        await _fileUploadAdapter.Delete(certificate.FileUrl);

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
        Certificate certificate = await _certificateDal.GetAsync(predicate: f => f.Id == updateCertificateRequest.Id);
        certificate = _mapper.Map(updateCertificateRequest, certificate);

        certificate.FileUrl = await _fileUploadAdapter.Update(updateCertificateRequest.File, certificate.FileUrl);
        Certificate updatedCertificate = await _certificateDal.UpdateAsync(certificate);
        UpdatedCertificateResponse updatedCertificateResponse = _mapper.Map<UpdatedCertificateResponse>(updatedCertificate);
        return updatedCertificateResponse;
    }
}
