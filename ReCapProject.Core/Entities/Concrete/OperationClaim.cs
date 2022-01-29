using ReCapProject.Core.Entities.Abstract;

namespace ReCapProject.Core.Entities.Concrete
{
    public class OperationClaim : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}