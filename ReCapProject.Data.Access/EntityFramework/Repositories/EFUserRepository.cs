using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Data.Access.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFUserRepository : EFRepositoryBase<EFReCapContext, User, int>, IUserRepository
    {
        public EFUserRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }

        public ICollection<OperationClaim> GetOperationClaims(User user)
        {
            return (from users in _dbSet
                    join userOperationClaims in _dbContext.UserOperationClaims on users.Id equals userOperationClaims.UserId
                    join operationClaims in _dbContext.OperationClaims on userOperationClaims.OperationClaimId equals operationClaims.Id
                    where users.Id.Equals(user.Id)
                    select operationClaims).ToList();
        }
    }
}