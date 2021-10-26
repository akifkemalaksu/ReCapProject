using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.InMemory
{
    public class BrandDALInMemory : IBrandDAL
    {
        private readonly List<Brand> _brands;

        public BrandDALInMemory()
        {
            _brands = new List<Brand>();
        }

        public void Add(Brand brand)
        {
            brand.Id = _brands.Count > 0 ? _brands.Max(x => x.Id) + 1 : 1;
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Delete(brand.Id);
        }

        public void Delete(int Id)
        {
            int index = _brands.FindIndex(x => x.Id == Id);
            if (index != -1)
                _brands.RemoveAt(index);
            else
                throw new Exception("Marka bulunamadı.");
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int Id)
        {
            return _brands.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Brand brand)
        {
            int index = _brands.FindIndex(x => x.Id == brand.Id);
            if (index != -1)
                _brands[index] = brand;
            else
                throw new Exception("Marka bulunamadı.");
        }
    }
}
