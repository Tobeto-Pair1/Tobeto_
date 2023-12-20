using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract
{
	public interface IUserEducationDal : IRepository<UserEducation, Guid>, IAsyncRepository<UserEducation, Guid>
    {
	}
}

