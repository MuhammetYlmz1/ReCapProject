﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Conctere.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,MyDataBaseContext>,ICustomerDal
    {

    }
}
