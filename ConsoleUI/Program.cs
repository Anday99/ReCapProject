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
            int i = 1;
            Console.WriteLine("-------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}.{1} model {2} TL\n  Açıklaması:{3}",i,car.ModelYear,car.DailyPrice,car.Description);
                i++;
            }
            Console.WriteLine("-------------------------------");
            carManager.Add(new Car {Id=8,BrandId=2,ColorId=3,DailyPrice=145000,Description="Bastın mı gaza gider mi gider",ModelYear=2021});
            Console.WriteLine("-------------------------------");
            i = 1;
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}.{1} model {2} TL\n  Açıklaması:{3}", i, car.ModelYear, car.DailyPrice, car.Description);
                i++;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1-A Segmenti araçlar\n2-B Segmenti Araçlar\n3-C Segmenti Araçlar\n4-D Segmenti Araçlar\n5-Araçları Çıkış Yıllarına Göre Sıralama\n6-En Pahalı Aracın Bilgileri");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    int a = 1;
                    Console.WriteLine("A Segmenti Araçlar Model ve Fiyat Bilgileri\n----------------------------------------");
                    foreach (var car in carManager.GetByBrandId(1))
                    {
                        Console.WriteLine("{0}. Model:{1}\n   Fiyat:{2}",a,car.ModelYear,car.DailyPrice);
                        a++;
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 2:
                    a = 1;
                    Console.WriteLine("B Segmenti Araçlar Model ve Fiyat Bilgileri\n----------------------------------------");
                    foreach (var car in carManager.GetByBrandId(2))
                    {
                        Console.WriteLine("{0}. Model:{1}\n   Fiyat:{2}", a, car.ModelYear, car.DailyPrice);
                        a++;
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 3:
                    a = 1;
                    Console.WriteLine("C Segmenti Araçlar Model ve Fiyat Bilgileri\n----------------------------------------");
                    foreach (var car in carManager.GetByBrandId(3))
                    {
                        Console.WriteLine("{0}. Model:{1}\n   Fiyat:{2}", a, car.ModelYear, car.DailyPrice);
                        a++;
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 4:
                    a = 1;
                    Console.WriteLine("D Segmenti Araçlar Model ve Fiyat Bilgileri\n----------------------------------------");
                    foreach (var car in carManager.GetByBrandId(4))
                    {
                        Console.WriteLine("{0}. Model:{1}\n   Fiyat:{2}", a, car.ModelYear, car.DailyPrice);
                        a++;
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 5:
                    a = 1;
                    Console.WriteLine("Çıkış yıllarına göre sıralama\n----------------------------------------");
                    foreach (var car in carManager.GetByModelYear())
                    {
                        Console.WriteLine("{0}.Fiyat:{1} Çıkış Yılı:{2}\n",a,car.DailyPrice,car.ModelYear);
                        a++;
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("En pahalı arabanın bilgileri\n----------------------------------------");
                    foreach (var car in carManager.GetByMostExpensive())
                    {
                        Console.WriteLine("Fiyat:{0}\nÇıkış Yılı:{1}\nAçıklaması:{2}", car.DailyPrice, car.ModelYear,car.Description);
                    }
                    Console.WriteLine("----------------------------------------");
                    break;
                default:
                    break;
            }

            
        }
    }
}
