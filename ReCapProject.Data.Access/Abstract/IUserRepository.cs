using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ReCapProject.Data.Access.Abstract
{
    public interface IUserRepository : IRepository<User, int>
    {
        public ICollection<OperationClaim> GetOperationClaims(User user);
    }
}