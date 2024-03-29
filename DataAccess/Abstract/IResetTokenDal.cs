using Core.DataAccess.Repositories;
using Core.Utilities.Security.JWT;

namespace DataAccess.Abstract;

public interface IResetTokenDal : IRepository<ResetToken, Guid>, IAsyncRepository<ResetToken, Guid>
{
}
