using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarImageService _carImageService;
        public CarImageManager(ICarImageDal carImageDal, ICarImageService _carImageService)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            if (true)
            {

            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Add);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarImageId == id), Messages.Listed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Update);
        }

        private IResult CheckIfCarImageLimitExceded()
        {
            var result = _carImageService.GetAll();
            if (result.Data.Count > 5)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageNull(string imagePath)
        {
            var result = _carImageDal.GetAll(c => c.ImagePath == imagePath).ToList();
            if (result!=null)
            {
                return new ErrorResult(Messages.Car);
            }
        }
    }
}
