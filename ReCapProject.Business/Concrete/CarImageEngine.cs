using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Helpers;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReCapProject.Business.Concrete
{
    public class CarImageEngine : ICarImageEngine
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly ICarEngine _carEngine;

        public CarImageEngine(ICarImageRepository carImageRepository, ICarEngine carEngine)
        {
            _carImageRepository = carImageRepository;
            _carEngine = carEngine;
        }

        public IResult AddImage(int carId, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfCarExistsWithId(carId),
                CheckIfCountOfProductImage(carId)
                );

            if (result != null)
            {
                return result;
            }

            CarImage carImage = new CarImage();
            carImage.CarId = carId;
            carImage.Date = DateTime.Now;
            string fileName = CreateNewFileName(file);
            string folder = GetCarImageUploadFolder(carImage.CarId);
            carImage.ImagePath = Path.Combine(folder, fileName);
            FileHelper.FileUpload(fileName, folder, file);
            _carImageRepository.Add(carImage);
            _carImageRepository.SaveChanges();
            return new SuccessResult();
        }


        public IResult DeleteImage(int id)
        {
            var carImage = _carImageRepository.Get(x => x.Id == id);
            FileHelper.FileDelete(carImage.ImagePath);
            _carImageRepository.Delete(carImage);
            _carImageRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult UpdateImage(CarImage carImage, IFormFile file)
        {
            FileHelper.FileDelete(carImage.ImagePath);
            string fileName = CreateNewFileName(file);
            string folder = GetCarImageUploadFolder(carImage.CarId);
            carImage.ImagePath = Path.Combine(folder, fileName);
            FileHelper.FileUpload(fileName, folder, file);
            _carImageRepository.Update(carImage);
            _carImageRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetCarImages(int carId)
        {
            var images = _carImageRepository.GetList(x => x.CarId == carId);
            if (!images.Any())
            {
                images = GetDefaultImage(carId);
            }
            return new SuccessDataResult<List<CarImage>>(images);
        }

        private string GetCarImageUploadFolder(int carId)
        {
            return Path.Combine(FilePaths.MainFolderName, FilePaths.CarImageFolderName, carId.ToString());
        }

        private string CreateNewFileName(IFormFile file)
        {
            Guid guid = Guid.NewGuid();
            string extension = Path.GetExtension(file.FileName);
            string fileName = $"{guid}{extension}";
            return fileName;
        }

        private IDataResult<int> CheckIfCountOfProductImage(int carId)
        {
            var result = _carImageRepository.GetList(x => x.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorDataResult<int>(result, Messages.MaximumCarImagesWarning);
            }
            return new SuccessDataResult<int>(result);
        }

        private List<CarImage> GetDefaultImage(int carId)
        {
            List<CarImage> defaults = new List<CarImage>();
            foreach (var path in Directory.GetFiles(FilePaths.CarImageDefaultsFolderName))
            {
                defaults.Add(new CarImage()
                {
                    CarId = carId,
                    Date = DateTime.Now,
                    Id = 0,
                    ImagePath = Path.Combine()
                });
            }
            return defaults;
        }

        private IDataResult<Car> CheckIfCarExistsWithId(int carId)
        {
            var result = _carEngine.GetById(carId);
            if (result.Data is null)
            {
                return new ErrorDataResult<Car>(result.Data, Messages.NotFound);
            }
            return result;
        }
    }
}