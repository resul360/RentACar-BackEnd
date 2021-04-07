using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetails()
        {
            using (var context = new CarRentContext())
            {
                //INNER JOIN
                /*
                 SELECT b.Name,c.Name,clr.Name,c.DailyPrice
                        FROM [CARRENTALDB].[dbo].[Car] c
                                INNER JOIN Brand b ON c.BrandId=b.Id  
                                INNER JOIN Color clr ON c.ColorId=clr.Id  
                 */
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             select new CarDetailsDTO
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }

        }
    }
}
