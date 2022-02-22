using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}