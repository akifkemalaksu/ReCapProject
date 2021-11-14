using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Data.Entities
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
