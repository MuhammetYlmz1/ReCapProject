﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Conctere.EntityFramework
{
    public class EfColorDal :EfEntityRepositoryBase<Color,MyDataBaseContext>,IColorDal
    {
       /* public void Add(Color entity)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();



            }
        }

        public void Delete(Color entity)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (MyDataBaseContext context = new MyDataBaseContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
