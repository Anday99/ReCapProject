using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDtoDal
    {
        List<CarDto> GetCarDto(List<Car> cars, List<Brand> brands);
    }
}
