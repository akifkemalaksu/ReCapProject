using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Data.Access.Abstract;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFUserOperationClaimRepository : EFRepositoryBase<EFReCapContext, UserOperationClaim, int>, IUserOperationClaimRepository
    {
        public EFUserOperationClaimRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}
