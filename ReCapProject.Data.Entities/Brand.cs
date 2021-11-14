using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Data.Entities
{
    public class Brand : IEntity<int>
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }
    }
}
