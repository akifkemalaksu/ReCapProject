using ReCapProject.Core.Business;
using ReCapProject.Data.Entities;
using System.Collections.Generic;

namespace ReCapProject.Business.Abstract
{
    public interface IBrandEngine : IBusinessEngine<Brand, int>
    {
        public void InsertAll(List<Brand> brands);
    }
}