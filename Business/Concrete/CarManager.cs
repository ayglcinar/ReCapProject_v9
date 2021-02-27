using System.Collections.Generic;
using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        //public List<Car> GetAll()
        //{
        //    return _carDal.GetAll();
        //}

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))] // attribute demek

        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();
            if(result != null)
            {
                return result;
            }
            //if (car.DailyPrice > 0 && car.CarName.Length>2)
            //{
            //    _carDal.Add(car);
            //    Console.WriteLine("Araba basariyla eklendi.");
            //}
            //else
            //{
            //    Console.WriteLine("Lutfen gunluk fiyat kismini 0'dan buyuk giriniz ve/veya araba ismi 2 karakterden olusmalidir.");
            //}

            //if (car.CarName.Length < 2)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid); 
            //}

            //ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //public <List<Car> GetCarsByBrandId(int id)
        //{
        //    return _carDal.GetAll(p => p.BrandID == id);
        //}

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.BrandID == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.ColorID == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarDetails(),Messages.ShowCarDetails);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
