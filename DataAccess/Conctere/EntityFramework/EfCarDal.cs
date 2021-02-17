using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Conctere.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car, MyDataBaseContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
              using (MyDataBaseContext context=new MyDataBaseContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands on ca.BrandId equals b.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             select new CarDetailDto { CarId = ca.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = ca.DailyPrice,ModelYear=ca.ModelYear,Description=ca.Description };
                return result.ToList();

            }
        }

        



        /*public void Add(Car entity)
        {
            using (MyDataBaseContext context=new MyDataBaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();

            }
        }

       

        public void Update(Car entity)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }*/
    }
}
