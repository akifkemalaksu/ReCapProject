using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;

namespace ReCapProject.Business.Abstract
{
    public interface ICarImageEngine : IBusinessEngine
    {
        IResult AddImage(int carId, IFormFile file);

        IResult DeleteImage(int id);

        IResult UpdateImage(CarImage carImage, IFormFile file);

        IDataResult<List<CarImage>> GetCarImages(int carId);
    }
}