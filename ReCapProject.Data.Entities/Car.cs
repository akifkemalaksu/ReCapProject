using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ReCapProject.Data.Entities
{
    public class Car : IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public int brandId { get; set; }
        [Required]
        public int colorId { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required, Range(0, int.MaxValue)]
        public decimal DailyPrice { get; set; }
        [AllowNull]
        public string Description { get; set; }
    }
}
