using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities.DTOs
{
    public class RentalDto : IDto
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}