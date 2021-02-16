using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }
        public IResult Add(Color color)
        {
            _colorDAL.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDAL.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetByName(string name)
        {
            return new SuccessDataResult<Color>(_colorDAL.GetByName(name));
        }

        public IResult Update(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
