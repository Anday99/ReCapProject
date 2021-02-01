using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            CarDtoManager carDtoManager = new CarDtoManager(new InMemoryCarDtoDal());

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("**************************MENU**************************\n");
                Console.WriteLine("1-Yeni Araç Ekle\n2-Tüm Araçları Listele\n3-Listeden Bir Aracı Sil\n4-Listedeki Bir Aracın Bilgilerini Güncelle\n5-Yeni Bir Marka Ekle\n6-Bir Markayı Sil\n7-Tüm Markaları Listele\n8-Araçları Çıkış Yıllarına Göre Sıralama\n9-En Pahalı Aracın Bilgileri\n10-En Ucuz Aracın Bilgileri\n11-Araçları Fiyatlarına Göre Listeleme\n12-Çıkış\n");
                Console.WriteLine("********************************************************\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddCar(carManager);
                        break;
                    case 2:
                        ListCars(carDtoManager, carManager, brandManager);
                        break;
                    case 3:
                        DeleteCar(carDtoManager, carManager, brandManager);
                        break;
                    case 4:
                        UpdateCar(carDtoManager, carManager, brandManager);
                        break;
                    case 5:
                        AddBrand(brandManager);
                        break;
                    case 6:
                        DeleteBrand(brandManager);
                        break;
                    case 7:
                        ListBrands(brandManager);
                        break;
                    case 8:
                        SortByModelYear(carManager);
                        break;
                    case 9:
                        TheMostExpensiveCar(carManager);
                        break;
                    case 10:
                        TheCheapestCar(carManager);
                        break;
                    case 11:
                        SortByPrice(carManager);
                        break;
                    case 12:
                        Console.WriteLine("Programdan çıkış yaptınız.\nİyi günler...");
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void DeleteBrand(BrandManager brandManager)
        {
            ListBrands(brandManager);
            Console.Write("Silmek İstediğiniz Markanın Numarasını Seçiniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            brandManager.Delete(new Brand { BrandId = brandId });
        }

        private static void AddBrand(BrandManager brandManager)
        {
            Console.Write("Markanın Adını Giriniz:");
            string brandName = Console.ReadLine();
            Console.Clear();
            brandManager.Add(new Brand { BrandName = brandName });
        }

        private static void ListBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAllBrands())
            {
                Console.WriteLine($"{brand.BrandId}. {brand.BrandName}");
            }
        }

        private static void UpdateCar(CarDtoManager carDtoManager, CarManager carManager, BrandManager brandManager)
        {
            ListCars(carDtoManager, carManager, brandManager);
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Listeden Silmek İstediğiniz Aracın Numarasını Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Aracin BrandId'sini belirleyin: ");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracin ColorId'sini belirleyin: ");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracin ModelYear degerini belirleyin: ");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracin DailyPrice degerini belirleyin: ");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Arac Aciklamasini Yaziniz: ");
            string Description = Console.ReadLine();
            Console.Clear();
            carManager.Update(new Car { Id = id, BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });
        }

        private static void DeleteCar(CarDtoManager carDtoManager, CarManager carManager, BrandManager brandManager)
        {
            ListCars(carDtoManager,carManager,brandManager);
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Listeden Silmek İstediğiniz Aracın Numarasını Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            carManager.Delete(new Car { Id = id });
        }

        private static void ListCars(CarDtoManager carDtoManager,CarManager carManager,BrandManager brandManager)
        {
            foreach (var car in carDtoManager.GetCarDto(carManager.GetAll(), brandManager.GetAllBrands()))
            {
                Console.WriteLine($"{car.Id}. Marka: {car.BrandName.PadRight(10,' ')}     Fiyat: {car.DailyPrice.ToString().PadRight(10, ' ')}     Açıklama: {car.Description}");
            }
        }

        private static void AddCar(CarManager carManager)
        {
            Console.Write("Aracın BrandId'sini belirleyin: ");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın ColorId'sini belirleyin: ");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın ModelYear degerini belirleyin: ");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın DailyPrice degerini belirleyin: ");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Arac Aciklamasini Yaziniz: ");
            string Description = Console.ReadLine();
            Console.Clear();
            carManager.Add(new Car { BrandId = BrandId, ColorId = ColorId, ModelYear = ModelYear, DailyPrice = DailyPrice, Description = Description });
        }

        private static void SortByPrice(CarManager carManager)
        {
            int a = 1;
            Console.WriteLine("Fiyatlarına göre Sıralama\n----------------------------------------");
            foreach (var car in carManager.GetByPrice())
            {
                Console.WriteLine("{0}.Fiyat:{1} Çıkış Yılı:{2}\n", a, car.DailyPrice, car.ModelYear);
                a++;
            }
            Console.WriteLine("----------------------------------------");
        }

        private static void TheCheapestCar(CarManager carManager)
        {
            Console.WriteLine("En ucuz arabanın bilgileri\n----------------------------------------");
            Console.WriteLine("Fiyat:{0}\nÇıkış Yılı:{1}\nAçıklaması:{2}", carManager.GetByMostCheap().DailyPrice, carManager.GetByMostCheap().ModelYear, carManager.GetByMostCheap().Description);
            Console.WriteLine("----------------------------------------");
        }

        private static void TheMostExpensiveCar(CarManager carManager)
        {
            Console.WriteLine("En pahalı arabanın bilgileri\n----------------------------------------");
            Console.WriteLine("Fiyat:{0}\nÇıkış Yılı:{1}\nAçıklaması:{2}", carManager.GetByMostExpensive().DailyPrice, carManager.GetByMostExpensive().ModelYear, carManager.GetByMostExpensive().Description);
            Console.WriteLine("----------------------------------------");
        }

        private static void SortByModelYear(CarManager carManager)
        {
            int a = 1;
            Console.WriteLine("Çıkış yıllarına göre sıralama\n----------------------------------------");
            foreach (var car in carManager.GetByModelYear())
            {
                Console.WriteLine("{0}.Fiyat:{1} Çıkış Yılı:{2}\n", a, car.DailyPrice, car.ModelYear);
                a++;
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
