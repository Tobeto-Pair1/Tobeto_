using AutoMapper;
using Business.Abstract;
using Business.DTOs.BlogsPress;
using Business.Rules;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;


namespace Business.Concrete;

public class BlogPressManager : IBlogPressService
{
    private readonly IBlogPressDal _blogPressDal;
    private readonly IMapper _mapper;
    private readonly BlogPressBusinessRules _blogPressBusinessRules;
    
    public BlogPressManager(IBlogPressDal blogPressDal, IMapper mapper, BlogPressBusinessRules blogPressBusinessRules)
    {
        _blogPressDal = blogPressDal;
        _mapper = mapper;
        _blogPressBusinessRules = blogPressBusinessRules;
    }

    public async Task<CreatedBlogPressResponse> Add(CreateBlogPressRequest createBlogPressRequest)
    {
        BlogPress blogPress = _mapper.Map<BlogPress>(createBlogPressRequest);
        BlogPress userCreated = await _blogPressDal.AddAsync(blogPress);
        CreatedBlogPressResponse createdBlogPressResponse = _mapper.Map<CreatedBlogPressResponse>(userCreated);
        return createdBlogPressResponse;
    }
    public async Task<DeletedBlogPressResponse> Delete(DeleteBlogPressRequest deleteBlogPressRequest)
    {
        BlogPress? blogPress = await _blogPressDal.GetAsync(u => u.Id == deleteBlogPressRequest.Id);
        await _blogPressDal.DeleteAsync(blogPress);
        DeletedBlogPressResponse deletedBlogPressResponse = _mapper.Map<DeletedBlogPressResponse>(blogPress);
        return deletedBlogPressResponse;
    }

    public async Task<IPaginate<GetListBlogPressResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _blogPressDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListBlogPressResponse>>(data);
        return result;
    }

    public async Task<UpdatedBlogPressResponse> Update(UpdateBlogPressRequest updateBlogPressRequest)
    {
        BlogPress? blogPress = await _blogPressDal.GetAsync(u => u.Id == updateBlogPressRequest.Id);
        _mapper.Map(updateBlogPressRequest, blogPress);
        BlogPress updateblogPress = await _blogPressDal.UpdateAsync(blogPress);
        UpdatedBlogPressResponse updatedBlogPressResponse = _mapper.Map<UpdatedBlogPressResponse>(updateblogPress);
        return updatedBlogPressResponse;
    }
    public async Task<GetBlogPressResponse> GetByIdAsync(Guid id)
    {
        BlogPress? blogPress = await _blogPressDal.GetAsync(b => b.Id == id);
        await _blogPressBusinessRules.ThrowExceptionIfBlogPressIsNull(blogPress);
        GetBlogPressResponse getBlogPressResponse = _mapper.Map<GetBlogPressResponse>(blogPress);
        return getBlogPressResponse;
    }
}
