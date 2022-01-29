using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities
{
    public class CarImage : IEntity<int>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}