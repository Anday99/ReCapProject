using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarDtoService
    {
        List<CarDto> GetCarDto(List<Car> cars, List<Brand> brands);
    }
}
