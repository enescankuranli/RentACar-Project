﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile file, CarImage carimage);
        IResult Delete(IFormFile file, CarImage carimage);
        IResult Update(IFormFile file, CarImage carimage);
    }
}
