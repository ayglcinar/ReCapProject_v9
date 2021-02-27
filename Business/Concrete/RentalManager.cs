using Business.Abstract;
using Business.Constrants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarID == rental.CarID);
            foreach (var result in results)
            {
                if (result.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalNotAvailable);
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessRentCar);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            var updatedRental = _rentalDal.Get(r => r.CarID == rental.CarID);
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.ReturnDateNotNull);
            }

            updatedRental.ReturnDate = DateTime.Now;

            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdated);
        }

    }
}
