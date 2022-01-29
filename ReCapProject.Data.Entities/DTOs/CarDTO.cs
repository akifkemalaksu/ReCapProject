using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities.DTOs
{
    public class CarDto : IDto
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}