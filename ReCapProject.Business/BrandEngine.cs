using ReCapProject.Business.Abstracts;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business
{
    public class BrandEngine : IBrandEngine
    {
        private readonly IBrandRepository _brandRepository;

        public BrandEngine(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Brand GetBrandById(int Id)
        {
            return _brandRepository.Get(Id);
        }
    }
}
