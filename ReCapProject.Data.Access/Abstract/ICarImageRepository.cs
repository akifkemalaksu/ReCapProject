﻿using ReCapProject.Core.DataAccess;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.Data.Access.Abstract
{
    public interface ICarImageRepository : IRepository<CarImage, int>
    {
    }
}