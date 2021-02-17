using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Conctere.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,MyDataBaseContext>,IUserDal
    {
    }
}
