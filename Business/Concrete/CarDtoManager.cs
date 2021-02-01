using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarDtoManager : ICarDtoService
    {
        ICarDtoDal _carDtoDal;
        public CarDtoManager(ICarDtoDal carDtoDal)
        {
            _carDtoDal = carDtoDal;
        }
        public List<CarDto> GetCarDto(List<Car> cars, List<Brand> brands)
        {
            return _carDtoDal.GetCarDto(cars,brands);
        }
    }
}
