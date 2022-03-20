using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFPaymentRentalMapRepository : EFRepositoryBase<EFReCapContext, PaymentRentalMap, int>, IPaymentRentalMapRepository
    {
        public EFPaymentRentalMapRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}