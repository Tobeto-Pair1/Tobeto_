using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract
{
	public interface ISectorDal : IRepository<Sector, Guid>, IAsyncRepository<Sector, Guid>
    {
	}
}

