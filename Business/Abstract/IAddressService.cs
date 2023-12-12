using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedAddressResponse> Add(CreateAddressRequest createAddressRequest);

        Task<UpdatedAddressResponse> Update(UpdateAddressRequest updateAddressRequest);

        Task<DeletedAddressResponse> Delete(DeleteAddressRequest deleteddressRequest);

    }
}
