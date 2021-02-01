using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=45000,ModelYear=1970,Description="Temiz kullanılmış"},
                new Car{Id=2,BrandId=1,ColorId=4,DailyPrice=65000,ModelYear=2013,Description="15.000 km de"},
                new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=67890,ModelYear=2018,Description="Öğretmenden satılık"},
                new Car{Id=4,BrandId=2,ColorId=3,DailyPrice=54678,ModelYear=2006,Description="Aile arabası"},
                new Car{Id=5,BrandId=4,ColorId=1,DailyPrice=234000,ModelYear=2017,Description="Temiz kullanılmış"},
                new Car{Id=6,BrandId=4,ColorId=3,DailyPrice=123890,ModelYear=2009,Description="Temiz kullanılmış"},
                new Car{Id=7,BrandId=2,ColorId=2,DailyPrice=345750,ModelYear=2020,Description="Temiz kullanılmış"}
            };
        }
        public void Add(Car car)
        {
            car.Id = _cars.Last().Id + 1;
            _cars.Add(car);
            Console.WriteLine("{0} model araba {1} TL fiyatı ile eklendi.",car.ModelYear,car.DailyPrice);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("{0} model araba {1} TL fiyatı ile silindi.", carToDelete.ModelYear, carToDelete.DailyPrice);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByModelYear()
        {
            return _cars.OrderByDescending(c=>c.ModelYear).ToList();
        }

        public List<Car> GetByPrice()
        {
            return _cars.OrderByDescending(c => c.DailyPrice).ToList();
        }

        public Car GetMostCheap()
        {
            return _cars.FirstOrDefault(c => c.DailyPrice == _cars.Min(car => car.DailyPrice));
        }

        public Car GetMostExpensive()
        {
            return _cars.FirstOrDefault(c => c.DailyPrice == _cars.Max(car => car.DailyPrice));
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

            Console.WriteLine("Güncellenen araç bilgileri\n---------------------------");
            Console.WriteLine("{0}. {1} model {2} TL-->Açıklaması:{3}\n", carToUpdate.Id, carToUpdate.ModelYear, carToUpdate.DailyPrice, carToUpdate.Description);
        }
    }
}
