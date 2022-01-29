using ReCapProject.Core.Entities.Abstract;

namespace ReCapProject.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}