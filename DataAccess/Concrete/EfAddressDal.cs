using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAddressDal: EfRepositoryBase<Address, int, NorthwindContext>, IAddressDal
    {
        public EfAddressDal(NorthwindContext context) : base(context)
        {
        }
    }


}
