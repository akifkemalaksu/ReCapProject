using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFBrandRepository : EFRepositoryBase<EFReCapContext, Brand, int>, IBrandRepository
    {
        public EFBrandRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }
    }
}
