using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             join r in context.Colors
                             on c.ColorID equals r.ColorID
                    select new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = r.ColorName,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();

            }
        }
    }
}
