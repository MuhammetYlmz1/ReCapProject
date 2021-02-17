using Business.Concrete;
using DataAccess.Conctere;
using DataAccess.Conctere.EntityFramework;
using Entities.Concrete;

using System;

namespace ConsoleUl
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //CarOperations(carManager);
            var result = rentalManager.GetRentalDetailsDto();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.UserFirstName+" "+rental.UserLastName+" "+rental.BrandName+" "+rental.ColorName+" "+rental.CompanyName);


                }

            }


            /*var result = carManager.GetAll();
            if(result.Success==true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.DailyPrice+"---"+item.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }*/


            //Marka ekleme
            /*brandManager.Add(new Brand { Id = 205, Name = "Audi" }
                );*/


            //Aynı anda Cars,Brands,Colors tablolarından veri çekmek
            /* foreach (var cars in carManager.GetCarDetailDtos())
             {
                 Console.WriteLine(cars.CarName+""+cars.BrandName+""+cars.ColorName+""+cars.DailyPrice+"/"+cars.ModelYear+"/"+cars.Description);
             }*/


            //Araba ekleme işlemi
            /* carManager.Add(new Car
              {

                  BrandId = 200,
                  ColorId = 3,
                  DailyPrice = 200,
                  Description = "Açıklama2",
                  ModelYear=2008
              });*/

            /* carManager.Add(new Car
             {

                 BrandId = 201,
                 ColorId = 3,
                 DailyPrice = 300,
                 Description = "Açıklama3",
                 ModelYear = 2009
             });*/


            //BrandId ye göre arama
            /*foreach (var item in carManager.GetCarsByBrandId(201))
            {
                Console.WriteLine(item.Description);

            }*/


            //Silme işlemi
            /*carManager.Delete(new Car { Id = 5 });

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }*/




            //ColorId ye göre arama
            /* foreach (var item in carManager.GetCarsByColorId(2))
             {
                 Console.WriteLine(item.Id+" "+item.Description);


             }*/


            //Güncelleme işlemi
            /*carManager.Update(new Car { Id = 4, BrandId = 200, ColorId = 3, DailyPrice = 1500, Description = "Uygulama Başarılı", ModelYear = 2012 });*/
            /*foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0}---{1}",item.DailyPrice,item.Description);
            }*/


        }

        private static void CarOperations(CarManager carManager)
        {
            Console.WriteLine("--------Araba ile İlgili İşlemler------ \n");

            Console.WriteLine("Bir işlem türü giriniz");

            Console.WriteLine("1-Araba Ekleme İşlemi");
            Console.WriteLine("2-Araba Silme İşlemi");
            Console.WriteLine("3-Araba Güncelleme İşlemi");
            int islem = Convert.ToInt16(Console.ReadLine());
            switch (islem)
            {
                case 1:
                    Console.WriteLine("Sırası ile ColorId,BrandId,ModelYear,DailyPrice,Description şeklinde giriniz");
                    carManager.Add(new Car
                    {

                        ColorId = Convert.ToInt32(Console.ReadLine()),
                        BrandId = Convert.ToInt32(Console.ReadLine()),
                        ModelYear = Convert.ToInt32(Console.ReadLine()),
                        DailyPrice = Convert.ToInt32(Console.ReadLine()),
                        Description = Console.ReadLine()

                    }
                ); break;

            }
        }
    }
}
