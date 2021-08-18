using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carimage)
        {
            var imagelımıt = _carImageDal.GetAll(c => c.CarId == carimage.CarId).Count;
            if (imagelımıt > 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            var carImageResult = FileHelper.Upload(file);
            if (!carImageResult.Success)
            {
                return new ErrorResult(carImageResult.Message);
            }
            carimage.ImagePath = carImageResult.Message;
            carimage.UploadDate = DateTime.Now;
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.CarimageAdded);
        }

        public IResult Delete(IFormFile file, CarImage carimage)
        {
            var image = _carImageDal.Get(c => c.Id == carimage.Id);
            if (image != null)
            {
                FileHelper.Delete(image.ImagePath);
                _carImageDal.Delete(carimage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarId ==id));
        }

        public IResult Update(IFormFile file, CarImage carimage)
        {
            var image = _carImageDal.Get(c => c.Id == carimage.Id);
            if (image ==null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            var updated = FileHelper.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            carimage.ImagePath = updated.Message;
            _carImageDal.Update(carimage);
            return new SuccessResult();
        }
        //business Rules
        private IDataResult<List<CarImage>> CarImageCheck(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = path, UploadDate = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }

    }
}
