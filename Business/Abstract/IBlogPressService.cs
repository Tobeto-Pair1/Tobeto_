using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Business.DTOs.Blogs;
using Business.DTOs.BlogsPress;

namespace Business.Abstract;

public interface IBlogPressService
{

    Task<IPaginate<GetListBlogPressResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedBlogPressResponse> Add(CreateBlogPressRequest createBlogPressRequest);

    Task<UpdatedBlogPressResponse> Update(UpdateBlogPressRequest updateBlogPressRequest);

    Task<DeletedBlogPressResponse> Delete(DeleteBlogPressRequest deleteBlogPressRequest);

    Task<GetBlogPressResponse> GetByIdAsync(Guid id);


}