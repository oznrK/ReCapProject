﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
      
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
           
        }

        public IResult Add(Rental rental)
        {
            //var cars = _carDal.GetAll();
            //var selectedcar = new Car();
            //foreach (var item in cars)
            //{
            //    var car = _rentalDal.Get(r => r.CarId == item.CarId && r.ReturnDate == null);
            //    if (car == null) { selectedcar = item; break; }
            //}
            //if (selectedcar != null) {
            //    rental.CarId = selectedcar.CarId; 
            //    _rentalDal.Add(rental);
            //    return new SuccessResult(Messages.RentalAdded);
            //} 
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else { return new ErrorResult(Messages.ErrorMessage); }
           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
