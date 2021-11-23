using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public class Rental : IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
