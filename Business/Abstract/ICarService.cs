using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDTO>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<CarDetailDTO> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
