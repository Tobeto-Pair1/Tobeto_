using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Business.DTOs.Blogs;

namespace Business.Abstract;

public interface IBlogService
{

    Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedBlogResponse> Add(CreateBlogRequest createBlogRequest);

    Task<UpdatedBlogResponse> Update(UpdateBlogRequest updateBlogRequest);

    Task<DeletedBlogResponse> Delete(DeleteBlogRequest deleteBlogRequest);
    
    Task<BlogResponse> GetByIdAsync(Guid id);


}