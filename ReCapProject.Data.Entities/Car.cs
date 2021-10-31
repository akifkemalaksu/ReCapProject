using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ReCapProject.Data.Entities
{
    public class Car : EntityBase<int>
    {
        public int Id { get; set; }
        [Required]
        public virtual Brand brand { get; set; }
        [Required]
        public virtual Color color { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required, Range(0, int.MaxValue)]
        public decimal DailyPrice { get; set; }
        [AllowNull]
        public string Description { get; set; }
    }
}
