using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Common;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDAL _carImageDAL;
        public CarImageManager(ICarImageDAL carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result == null && file.Length > 0)
            {
                string fileExt = Path.GetExtension(file.FileName);
                string path = carImage.ImagePath.Substring(0, carImage.ImagePath.Length - file.FileName.Length - 1);
                var fileResult= FileManager.Add(path, file, true);
                if (fileResult.Result.Success)
                {
                    carImage.ImagePath = fileResult.Result.Message;
                    //carImage.Date = DateTime.Now;
                    _carImageDAL.Add(carImage);
                    return new SuccessResult(Messages.CarImageAdded);
                }
                else return new ErrorResult(fileResult.Result.Message);
            }
            else return new ErrorResult(result.Message);
            
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var result = _carImageDAL.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        public IResult Delete(string imagePath, CarImage carImage)
        {
            IResult result = BusinessRules.Run();
            if (result == null)
            {
                var fileResult = FileManager.Delete(imagePath,carImage.ImagePath);
                if (fileResult.Success)
                {
                    _carImageDAL.Delete(carImage);
                    return new SuccessResult(Messages.CarImageDeleted);
                }
                else return new ErrorResult(fileResult.Message);
            }
            else return new ErrorResult(result.Message);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll(), Messages.CarImagesListed);
        }

        public IResult Update(string imagePath, IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run();
            if (result == null && file.Length > 0)
            {
                string fileExt = Path.GetExtension(file.FileName);
                string path = imagePath.Substring(0, imagePath.Length - file.FileName.Length - 1);
                var fileResult = FileManager.Update(path, carImage.ImagePath, file, true);
                if (fileResult.Result.Success)
                {
                    carImage.ImagePath = fileResult.Result.Message;
                    //carImage.Date = DateTime.Now;
                    _carImageDAL.Update(carImage);
                    return new SuccessResult(Messages.CarImageUpdated);
                }
                else return new ErrorResult(fileResult.Result.Message);
            }
            else return new ErrorResult(result.Message);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            List<CarImage> nullImage = new List<CarImage>();
            nullImage.Add(new CarImage { Id=-1, CarId = carId, ImagePath = @"noImage.jpg" });
            var result = _carImageDAL.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new SuccessDataResult<List<CarImage>>(nullImage, Messages.CarImagesListed);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll(c => c.CarId == carId), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetCarImageById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDAL.Get(p => p.Id == Id), Messages.CarImagesListed);
        }
    }
}
