using Business.DTOs.ForeignLanguageLevels;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IForeignLanguageLevelService
{
    Task<IPaginate<GetListForeignLanguageLevelResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedForeignLanguageLevelResponse> Add(CreateForeignLanguageLevelRequest createForeignLanguageLevelRequest);
    Task<UpdatedForeignLanguageLevelResponse> Update(UpdateForeignLanguageLevelRequest updateLanguageLevelRequest);
    Task<DeletedForeignLanguageLevelResponse> Delete(DeleteForeignLanguageLevelRequest deleteLanguageLevelRequest);

}