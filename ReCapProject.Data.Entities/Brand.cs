using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public class Brand : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
