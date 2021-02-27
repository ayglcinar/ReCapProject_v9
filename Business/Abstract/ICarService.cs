using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //List<Car> GetAll();
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //Car GetById(int carId);
        //IDataResult<Car> GetById(int carId);

        IResult Add(Car car);
        IResult Delete(Car card);
        IResult Update(Car car);
    }
}
