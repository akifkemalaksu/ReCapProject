using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFColorRepository : EFRepositoryBase<EFReCapContext, Color, int>, IColorRepository
    {
        public EFColorRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}
