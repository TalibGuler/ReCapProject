using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
       
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       // [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( CarImage carImage)
        {
            BusinessRules.Run(CheckIfImageOverLimit(carImage.CarId));
            carImage.Date = DateTime.Now.Date;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Add);
        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetCarImage(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.CarImageId == id), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId), Messages.Listed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Update);
        }

        private IResult CheckIfImageOverLimit(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarId == id).Count;
            if (result >= 5) return new ErrorResult(Messages.Fail);
            return new SuccessResult();
        }

       
    }
}
