using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public interface EntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
