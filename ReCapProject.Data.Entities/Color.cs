using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public class Color : EntityBase<int>
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
    }
}
