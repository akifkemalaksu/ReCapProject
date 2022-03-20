using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities.ResponseModels
{
    public class RentalResponseModel : IResponseModel
    {
        public int CarId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal Price { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc { get; set; }
    }
}