﻿using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface ISocialMediaDal : IRepository<SocialMedia, Guid>, IAsyncRepository<SocialMedia, Guid>
{

}