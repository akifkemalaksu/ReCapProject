using ReCapProject.Core.Entities.Abstract;

namespace ReCapProject.Data.Entities
{
    public class PaymentRentalMap : IEntity<int>
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int RentalId { get; set; }
        public decimal Price { get; set; }
    }
}