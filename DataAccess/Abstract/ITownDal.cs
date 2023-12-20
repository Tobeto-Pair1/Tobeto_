using System;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract
{
	public interface ITownDal:IRepository<Town, Guid>, IAsyncRepository<Town, Guid>
	{
	}
}

