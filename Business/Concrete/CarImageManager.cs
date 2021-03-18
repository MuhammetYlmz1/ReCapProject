using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helper;
using Core.Utilities.Business;
using Business.Constans;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            // var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
            
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
        private IResult CheckImageLimitExceeded(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (imageCount > 5)
            {
                return new ErrorResult(Messages.ImageLimit);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        { 
            var path = @"\Image\logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
               

              return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };

            }
            return _carImageDal.GetAll(c => c.CarId == id);
        }
        
    }
}
