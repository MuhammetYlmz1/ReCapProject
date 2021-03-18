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
   public class EfRentalDal:EfEntityRepositoryBase<Rental,MyDataBaseContext>,IRentalDal
    {
       public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDataBaseContext context=new MyDataBaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 UserFirstName = user.FirstName,
                                 UserLastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 Description = car.Description,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,

                             };
                return result.ToList();

            }
        }
    }
}
