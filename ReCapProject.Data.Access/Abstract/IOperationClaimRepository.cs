using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entities.Concrete;
using System;

namespace ReCapProject.Data.Access.Abstract
{
    public interface IOperationClaimRepository : IRepository<OperationClaim, int>
    {
    }
}