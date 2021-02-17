using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IColorDal:IEntityRepository<Color>
    {
       /* List<Color> GetAll();
        void Add(Color car);
        void Update(Color car);
        void Delete(Color car);
        List<Color> GetById(int id);*/
    }
}
