using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("**************************MENU**************************\n");
                Console.WriteLine("1-Yeni Araç Ekle\n2-Tüm Araçları Listele\n3-Listeden Bir Aracı Sil\n4-Listedeki Bir Aracın Bilgilerini Güncelle\n5-Yeni Bir Marka Ekle\n6-Bir Markayı Sil\n7-Tüm Markaları Listele\n8-Bir Markayı Güncelle\n9-Renk Ekle\n10-Renk Sil\n11-Tüm Renkleri Listele\n12-Kullanıcı Ekle\n13-Kullanıcı Listele\n14-Kullanıcı Sil\n15-Kiralamak istediğiniz arabayı ekleyin\n16-Kiralık arabaları listeleyin\n17-Müşteri ekle\n18-Müşteri Listele\n19-Çıkış\n");
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
                        AddBrand(brandManager);
                        break;
                    case 6:
                        DeleteBrand(brandManager);
                        break;
                    case 7:
                        ListBrands(brandManager);
                        break;
                    case 8:
                        UpdateBrand(brandManager);
                        break;
                    case 9:
                        AddColor(colorManager);
                        break;
                    case 10:
                        DeleteColor(colorManager);
                        break;
                    case 11:
                        ListColors(colorManager);
                        break;
                    case 12:
                        AddUser(userManager);
                        break;
                    case 13:
                        ListUsers(userManager);
                        break;
                    case 14:
                        DeleteUser(userManager);
                        break;
                    case 15:
                        AddRental(rentalManager,carManager,customerManager);
                        break;
                    case 16:
                        ListRentals(rentalManager);
                        break;
                    case 17:
                        AddCustomer(userManager, customerManager);
                        break;
                    case 18:
                        ListCustomers(customerManager);
                        break;
                    case 19:
                        Console.WriteLine("Programdan çıkış yaptınız.\nİyi günler...");
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ListCustomers(CustomerManager customerManager)
        {
            Console.WriteLine("ID   |   MÜŞTERİNİN ŞİRKET İSMİ\n-------------------------");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.Id.ToString().PadRight(5, ' ')}|      {customer.CompanyName}");
            }
        }

        private static void AddCustomer(UserManager userManager, CustomerManager customerManager)
        {
            ListUsers(userManager);
            Console.Write("Müşteri eklemek için listeden bir numara seçiniz:");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşterinin şirket ismini giriniz:");
            string companyName = Console.ReadLine();
            customerManager.Add(new Customer { UserId = customerId, CompanyName = companyName });
        }

        private static void DeleteUser(UserManager userManager)
        {
            ListUsers(userManager);
            Console.Write("Silmek istediğiniz kullanıcının numarasını giriniz:");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(userManager.Delete(new User { Id = userId }).Message);
        }

        private static void ListUsers(UserManager userManager)
        {
            var users = userManager.GetAll();
            Console.WriteLine("ID   |   KULLANICININ ADI   |  KULLANICININ EMAİLİ\n---------------------------------------------------");
            foreach (var user in users.Data)
            {
                Console.WriteLine($"{user.Id.ToString().PadRight(5, ' ')}|      {user.FirstName} {user.LastName}     |{user.Email}");
            }
        }

        private static void AddUser(UserManager userManager)
        {
            Console.Write("Eklemek istediğiniz müşterinin emailini giriniz:");
            string email = Console.ReadLine();
            Console.Write("Eklemek istediğiniz müşterinin adını giriniz:");
            string firstName = Console.ReadLine();
            Console.Write("Eklemek istediğiniz müşterinin soyadını giriniz:");
            string lastName = Console.ReadLine();
            Console.Write("Eklemek istediğiniz müşterinin şifresini giriniz:");
            string password = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(userManager.Add(new User { Email = email, FirstName = firstName, LastName = lastName, Password = password }).Message);
        }

        private static void ListRentals(RentalManager rentalManager)
        {
            Console.WriteLine("ID   |   MARKA  |   MÜŞTERİ ADI  |   KİRALANMA TARİHİ   |   KİRADAN GERİ DÖNME TARİHİ   \n--------------------------------------------------");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.Id.ToString().PadRight(5, ' ')}|{rental.BrandName.PadRight(10, ' ')}|{rental.CustomerName.PadRight(16, ' ')}|{rental.RentDate.ToString().PadRight(22, ' ')}|{rental.ReturnDate.ToString().PadRight(20, ' ')}");
            }
        }

        private static void AddRental(RentalManager rentalManager,CarManager carManager,CustomerManager customerManager)
        {
            ListCars(carManager);
            Console.WriteLine("---------------------------------------------------------");
            ListCustomers(customerManager);
            Console.Write("Araba numarasını giriniz:");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşteri numarasını giriniz:");
            int customerId = Convert.ToInt32(Console.ReadLine());
            DateTime rentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime returnDate = Convert.ToDateTime(null);
            Console.Clear();
            Console.WriteLine(rentalManager.Add(new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate }).Message);
        }

        private static void DeleteColor(ColorManager colorManager)
        {
            ListColors(colorManager);
            Console.Write("Silmek İstediğiniz Rengin Numarasını Seçiniz:");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            colorManager.Delete(new Color { ColorId = colorId });
        }

        private static void ListColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}. {color.ColorName}");
            }
        }

        private static void AddColor(ColorManager colorManager)
        {
            Console.Write("Rengin Adını Giriniz:");
            string colorName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(colorManager.Add(new Color { ColorName = colorName }).Message);
        }

        private static void UpdateBrand(BrandManager brandManager)
        {
            ListBrands(brandManager);
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Listeden Güncellemek İstediğiniz Markanın Numarasını Giriniz:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Aracın Markasını Giriniz: ");
            string brandName = Console.ReadLine();
            Console.Clear();
            brandManager.Update(new Brand { BrandId = brandId, BrandName = brandName });
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
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}. {brand.BrandName}");
            }
        }

        private static void UpdateCar(CarManager carManager)
        {
            ListCars(carManager);
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Listeden Güncellemek İstediğiniz Aracın Numarasını Giriniz:");
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
            Console.WriteLine("ID   |    MARKA      |   RENK   |       AÇIKLAMA         \n-------------------------------------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.Id.ToString().PadRight(5,' ')}|{car.BrandName.PadRight(15,' ')}|{car.ColorName.PadRight(10,' ')}|{car.Description.PadRight(20,' ')}");
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
    }
}
