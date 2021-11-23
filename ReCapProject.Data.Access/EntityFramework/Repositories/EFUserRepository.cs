using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFUserRepository : EFRepositoryBase<EFReCapContext, User, int>, IUserRepository
    {
        public EFUserRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}
