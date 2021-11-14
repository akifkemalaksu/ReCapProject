using ReCapProject.Business.Abstract;
using ReCapProject.Core.Business;
using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System.Collections.Generic;

namespace ReCapProject.Business.Concrete
{
    public class BrandEngine : BusinessEngineBase<Brand, IBrandRepository, int>, IBrandEngine
    {
        public BrandEngine(IBrandRepository repository) : base(repository)
        {
        }

        public void InsertAll(List<Brand> brands)
        {
            foreach (var brand in brands)
            {
                _repository.Add(brand);
            }
            _repository.SaveChanges();
        }
    }
}
