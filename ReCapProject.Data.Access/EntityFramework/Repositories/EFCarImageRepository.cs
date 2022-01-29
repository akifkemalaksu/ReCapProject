using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFCarImageRepository : EFRepositoryBase<EFReCapContext, CarImage, int>, ICarImageRepository
    {
        public EFCarImageRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}