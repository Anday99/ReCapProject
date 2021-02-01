using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDtoDal : ICarDtoDal
    {
        public List<CarDto> GetCarDto(List<Car> cars,List<Brand> brands)
        {
            var dtoList = from c in cars
                          join b in brands
                          on c.BrandId equals b.BrandId
                          select new CarDto
                          {
                              Id = c.Id,
                              BrandName = b.BrandName,
                              DailyPrice = c.DailyPrice,
                              Description = c.Description
                          };

            return dtoList.ToList();
        }
    }
}
