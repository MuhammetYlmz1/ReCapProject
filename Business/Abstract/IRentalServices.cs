using Core.Utilities;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalServices
    {

        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);


    }
}
