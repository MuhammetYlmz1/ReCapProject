using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto:IDto
    {

        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CompanyName { get; set; }
        public string ColorName { get; set; }
        public string  BrandName { get; set; }
        public string Description { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
