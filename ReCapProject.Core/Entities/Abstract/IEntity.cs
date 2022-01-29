using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Core.Entities.Abstract
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}