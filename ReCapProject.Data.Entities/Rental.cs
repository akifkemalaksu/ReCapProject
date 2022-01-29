using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities
{
    public class Rental : IEntity<int>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}