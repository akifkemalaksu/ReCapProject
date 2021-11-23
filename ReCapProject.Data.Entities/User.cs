using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        public string Password { get; set; }
    }
}
