using Business.DTOs.ContactInformations;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactInformationService
    {
        Task<IPaginate<GetListContactInformationResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedContactInformationResponse> Add(CreateContactInformationRequest createContactInformationRequest);

        Task<UpdatedContactInformationResponse> Update(UpdateContactInformationRequest updateContactInformationRequest);

        Task<DeletedContactInformationResponse> Delete(DeleteContactInformationRequest deleteContactInformationRequest);
    }
}
