using ReCapProject.Core.DataAccess;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReCapProject.Data.Access.Abstract
{
    public interface IRentalRepository : IRepository<Rental, int>
    {
        public ICollection<RentalDto> GetAllRentalsDetails();
    }
}