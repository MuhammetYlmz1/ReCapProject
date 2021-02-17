using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand>
    {
        /*List<Brand> GetAll();
        void Add(Brand car);
        void Update(Brand car);
        void Delete(Brand car);
        List<Brand> GetById(int id);*/
    }
}
