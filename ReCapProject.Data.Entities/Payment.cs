using ReCapProject.Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReCapProject.Data.Entities
{
    public class Payment : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(16)]
        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        [MaxLength(2)]
        public string ExpireMonth { get; set; }

        [MaxLength(4)]
        public string ExpireYear { get; set; }

        [MaxLength(3)]
        public string Cvc { get; set; }
    }
}