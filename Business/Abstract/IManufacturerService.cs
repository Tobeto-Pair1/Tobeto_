using Business.DTOs.Manufacturers;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IManufacturerService
    {
        Task<IPaginate<GetListManufacturerResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedManufacturerResponse> Add(CreateManufacturerRequest createManufacturerRequest);

        Task<UpdatedManufacturerResponse> Update(UpdateManufacturerRequest updateManufacturerRequest);

        Task<DeletedManufacturerResponse> Delete(DeleteManufacturerRequest deleteManufacturerRequest);
    }
}
