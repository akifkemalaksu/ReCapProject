using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFRentalRepository : EFRepositoryBase<EFReCapContext, Rental, int>, IRentalRepository
    {
        public EFRentalRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}
