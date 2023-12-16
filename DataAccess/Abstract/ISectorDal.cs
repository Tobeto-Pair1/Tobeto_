using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract
{
	public interface ISectorDal : IRepository<Sector, int>, IAsyncRepository<Sector, int>
    {
	}
}

