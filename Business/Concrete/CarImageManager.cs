﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult AddImage(CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(image.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(CarImageCorrection(image).Entity);
            return new SuccessResult(Messages.CarImageAdded);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage image)
        {
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesOfACar(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(image.CarId));
            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(CarImageCorrection(image).Entity);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IEntityResult<CarImage> CarImageCorrection(CarImage image)
        {
            if (image.ImagePath == null)
            {
                image.ImagePath = @"C:\??.jpg";//DEFAULT JPG veya PNG yolu
            }

            string photoExtension = Path.GetExtension(image.ImagePath);

            if (photoExtension.ToLower() == ".jpg" || photoExtension.ToLower() == ".png")
            {
                string photoName = Guid.NewGuid() + photoExtension;
                if (!Directory.Exists(@"C:\??\" + image.CarId))//eğer yönlendirme var değilse bunu yapar
                {
                    Directory.CreateDirectory(@"D:\??\" + image.CarId);
                }
                File.Copy((image.ImagePath), (@"C:\??\" + image.CarId + @"\" + photoName));//COPY PHOTO TO DIRECTORY
                image.ImagePath = @"C:\??\" + image.CarId + @"\" + photoName;
                image.Date = DateTime.Now;

                return new SuccessEntityResult<CarImage>(image);
            }
            return new ErrorEntityResult<CarImage>(Messages.CarImageCantAdded);

        }
    }
}