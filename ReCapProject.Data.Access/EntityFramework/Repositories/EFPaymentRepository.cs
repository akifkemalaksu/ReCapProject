using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFPaymentRepository : EFRepositoryBase<EFReCapContext, Payment, int>, IPaymentRepository
    {
        public EFPaymentRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}