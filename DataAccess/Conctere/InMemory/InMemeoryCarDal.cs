using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Conctere
{
   public class InMemeoryCarDal:ICarDal
    {
        List<Car> _car;
        public InMemeoryCarDal()
        {
            _car = new List<Car>
            {//ColorId=2 -->Beyaz ,ColorId=3-->Siyah
                new Car{Id=1,BrandId=200,ColorId=2,ModelYear=2015,DailyPrice=1200,Description="Güzel bir araba"},
                new Car{Id=2,BrandId=201,ColorId=2,ModelYear=2016,DailyPrice=1500,Description="Spor bir araba"},
                new Car{Id=3,BrandId=201,ColorId=3,ModelYear=2017,DailyPrice=1700,Description="Güzel ve şık bir araba"},
                new Car{Id=4,BrandId=203,ColorId=3,ModelYear=2018,DailyPrice=1900,Description="Güçlü bir araba"},

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete=null;

            carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);


            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;


        }
      
        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
