using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Data.Entities
{
    public class Color : IEntity<int>
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
