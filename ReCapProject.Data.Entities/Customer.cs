using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}