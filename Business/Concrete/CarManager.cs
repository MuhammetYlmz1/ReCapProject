
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Conctere.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager:ICarServices
    {

        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

           // ValidationTool.Validate(new CarValidator(),car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);//True değeri
        }

        public IResult AddTransactional(Car car)
        {
            Add(car);
            if (car.DailyPrice < 500)
            {
                throw new Exception("Daha fazla kiralama bedeli gir");
            }
            Add(car);
            return null;
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        { 
           /* if(DateTime.Now.Hour==21)
            {
               return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }*/
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [CacheAspect]
        //[PerformanceAspect(10)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
          
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
          return new SuccessResult(Messages.CarUpdate);
        }
    }
}
