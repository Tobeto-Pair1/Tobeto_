using AutoMapper;
using Business.Abstract;
using Business.DTOs.ContactInformations;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concrete;

public class ContactInformationManager : IContactInformationService
{
    private readonly IContactInformationDal _contactInformationDal;
    private readonly IMapper _mapper;

    public ContactInformationManager(IContactInformationDal contactInformationDal, IMapper mapper)
    {
        _contactInformationDal = contactInformationDal;
        _mapper = mapper;
    }

    public async Task<CreatedContactInformationResponse> Add(CreateContactInformationRequest createContactInformationRequest)
    {
        ContactInformation contactInformation = _mapper.Map<ContactInformation>(createContactInformationRequest);
        ContactInformation createdContactInformation = await _contactInformationDal.AddAsync(contactInformation);
        CreatedContactInformationResponse createdContactInformationResponse = _mapper.Map<CreatedContactInformationResponse>(createdContactInformation);
        return createdContactInformationResponse;
    }

    public async Task<DeletedContactInformationResponse> Delete(DeleteContactInformationRequest deleteContactInformationRequest)
    {
        ContactInformation contactInformation = await _contactInformationDal.GetAsync(b => b.Id == deleteContactInformationRequest.Id);
        ContactInformation deletedContactInformation = await _contactInformationDal.DeleteAsync(contactInformation);
        DeletedContactInformationResponse deletedContactInformationResponse = _mapper.Map<DeletedContactInformationResponse>(deletedContactInformation);
        return deletedContactInformationResponse;
    }

    public async Task<IPaginate<GetListContactInformationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _contactInformationDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListContactInformationResponse>>(data);
        return result;
    }

    public async Task<UpdatedContactInformationResponse> Update(UpdateContactInformationRequest updateContactInformationRequest)
    {
        ContactInformation contactInformation = await _contactInformationDal.GetAsync(b => b.Id == updateContactInformationRequest.Id);
        _mapper.Map(updateContactInformationRequest, contactInformation);
        ContactInformation updateContactInformation = await _contactInformationDal.UpdateAsync(contactInformation);
        UpdatedContactInformationResponse updatedContactInformationResponse = _mapper.Map<UpdatedContactInformationResponse>(updateContactInformation);
        return updatedContactInformationResponse;
    }
}
