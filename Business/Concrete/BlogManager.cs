﻿using Business.Abstract;
using Core.DataAccess.Paging;
using Business.DTOs.Blogs;
using Entities.Concretes;
using DataAccess.Abstract;
using AutoMapper;
using Core.DataAccess.Dynamic;
using Business.Rules;

namespace Business.Concrete;

public class BlogManager : IBlogService
{
    private readonly IBlogDal _blogDal;
    private readonly IMapper _mapper;
    private readonly BlogBusinessRules _blogBusinessRules;

    public BlogManager(IBlogDal blogDal, IMapper mapper, BlogBusinessRules blogBusinessRules)
    {
        _blogDal = blogDal;
        _mapper = mapper;
        _blogBusinessRules = blogBusinessRules;
    }

    public async Task<CreatedBlogResponse> Add(CreateBlogRequest createBlogRequest)
    {
        Blog blog = _mapper.Map<Blog>(createBlogRequest);
        Blog userCreated = await _blogDal.AddAsync(blog);
        CreatedBlogResponse createdBlogResponse = _mapper.Map<CreatedBlogResponse>(userCreated);
        return createdBlogResponse;
    }
    //Blog
    public async Task<DeletedBlogResponse> Delete(DeleteBlogRequest deleteBlogRequest)
    {
        Blog? blog = await _blogDal.GetAsync(u => u.Id == deleteBlogRequest.Id);
        await _blogDal.DeleteAsync(blog);
        DeletedBlogResponse deletedBlogResponse = _mapper.Map<DeletedBlogResponse>(blog);
        return deletedBlogResponse;
    }

    public async Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _blogDal.GetListAsync(index: pageRequest.PageIndex,size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListBlogResponse>>(data);
        return result;
    }

    public async Task<UpdatedBlogResponse> Update(UpdateBlogRequest updateBlogRequest)
    {
        Blog? blog = await _blogDal.GetAsync(u => u.Id == updateBlogRequest.Id);
        _mapper.Map(updateBlogRequest, blog);
        Blog updateblog = await _blogDal.UpdateAsync(blog);
        UpdatedBlogResponse updatedBlogResponse = _mapper.Map<UpdatedBlogResponse>(updateblog);
        return updatedBlogResponse;
    }

    public async Task<GetBlogResponse> GetByIdAsync(Guid id)
    {
        Blog? blog = await _blogDal.GetAsync(b => b.Id == id);
        await _blogBusinessRules.ThrowExceptionIfBlogIsNull(blog);
        GetBlogResponse getBlogResponse = _mapper.Map<GetBlogResponse>(blog);
        return getBlogResponse;
    }
}
