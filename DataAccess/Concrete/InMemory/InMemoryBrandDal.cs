using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand> { 
                new Brand{BrandId=1,BrandName="BMW" },
                new Brand{BrandId=2,BrandName="Mercedes" },
                new Brand{BrandId=3,BrandName="Hyundai" },
                new Brand{BrandId=4,BrandName="Tesla" },
                new Brand{BrandId=5,BrandName="Nissan" },
                new Brand{BrandId=6,BrandName="Ford" }
            };
        }
        public void Add(Brand brand)
        {
            brand.BrandId = _brands.Last().BrandId + 1;
            _brands.Add(brand);
            Console.WriteLine("{0} markası markalar listesine eklendi.",brand.BrandName);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
            Console.WriteLine("{0} markası markalar listesinden silindi.",brandToDelete.BrandName);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
            Console.WriteLine("Güncellenen Marka Bilgileri\n--------------------------");
            Console.WriteLine("{0}-{1}",brandToUpdate.BrandId,brandToUpdate.BrandName);
        }
    }
}
