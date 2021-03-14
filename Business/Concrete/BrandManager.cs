using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _brandDAL;
        public BrandManager(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDAL.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDAL.GetAll(), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<Brand> GetByName(string name)
        {
            return new SuccessDataResult<Brand>(_brandDAL.GetByName(name));
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDAL.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
