using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Data.Entities
{
    public class Color : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}