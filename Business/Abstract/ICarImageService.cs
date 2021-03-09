using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> GetCarImageById(int Id);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(string imagePath, IFormFile file, CarImage carImage);
        IResult Delete(string imagePath, CarImage carImage);
    }
}
