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
            
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("**************************MENU**************************\n");
                Console.WriteLine("1-Yeni Araç Ekle\n2-Tüm Araçları Listele\n3-Listeden Bir Aracı Sil\n4-Listedeki Bir Aracın Bilgilerini Güncelle\n5-Araçları Çıkış Yıllarına Göre Sıralama\n6-En Pahalı Aracın Bilgileri\n7-En Ucuz Aracın Bilgileri\n8-Araçları Fiyatlarına Göre Listeleme\n9-Çıkış\n");
                Console.WriteLine("********************************************************\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddCar(carManager);
                        break;
                    case 2:
                        ListCars(carManager);
                        break;
                    case 3:
                        DeleteCar(carManager);
                        break;
                    case 4:
                        UpdateCar(carManager);
                        break;
                    case 5:
                        SortByModelYear(carManager);
                        break;
                    case 6:
                        TheMostExpensiveCar(carManager);
                        break;
                    case 7:
                        TheCheapestCar(carManager);
                        break;
                    case 8:
                        SortByPrice(carManager);
                        break;
                    case 9:
                        Console.WriteLine("Programdan çıkış yaptınız.\nİyi günler...");
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void UpdateCar(CarManager carManager)
        {
            ListCars(carManager);
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

        private static void DeleteCar(CarManager carManager)
        {
            ListCars(carManager);
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Listeden Silmek İstediğiniz Aracın Numarasını Giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            carManager.Delete(new Car { Id = id });
        }

        private static void ListCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}. {1} model {2} TL-->Açıklaması:{3}", car.Id, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void AddCar(CarManager carManager)
        {
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

        private static void GetByBrandId(CarManager carManager,int brandId)
        {
            int a = 1;
            Console.WriteLine("{0}.Segmenti Araçlar Model ve Fiyat Bilgileri\n----------------------------------------",brandId);
            foreach (var car in carManager.GetByBrandId(brandId))
            {
                Console.WriteLine("{0}. Model:{1}\n   Fiyat:{2}", a, car.ModelYear, car.DailyPrice);
                a++;
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
