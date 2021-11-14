using ReCapProject.Core.Business;
using ReCapProject.Data.Entities;
using System.Collections.Generic;

namespace ReCapProject.Business.Abstract
{
    public interface IColorEngine : IBusinessEngine<Color, int>
    {
        public void InsertAll(List<Color> colors);
    }
}