using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCountryDal : EfRepositoryBase<Country, Guid, TobetoDbContext>, ICountryDal
    {
        public EfCountryDal(TobetoDbContext context) : base(context)
        {
            if (context.Countries.Any())
            {
                return;   // Veritabanında zaten ülkeler varsa metodu sonlandır
            }

            // Ülkeleri oluştur
            var countries = new List<Country>
        {
            new Country { Name = "Turkey" },
            new Country { Name = "USA" },
            new Country { Name = "Germany" }

            // Diğer ülkeleri buraya ekleyin
        };

            // Ülkeleri veritabanına ekle
            context.Countries.AddRange(countries);
            context.SaveChanges();
        }
    }
    }

