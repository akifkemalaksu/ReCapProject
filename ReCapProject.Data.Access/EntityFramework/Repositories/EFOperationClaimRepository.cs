using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Data.Access.Abstract;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFOperationClaimRepository : EFRepositoryBase<EFReCapContext, OperationClaim, int>, IOperationClaimRepository
    {
        public EFOperationClaimRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}