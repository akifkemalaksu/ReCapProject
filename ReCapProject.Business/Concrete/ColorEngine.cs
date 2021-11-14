using ReCapProject.Business.Abstract;
using ReCapProject.Core.Business;
using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using System.Collections.Generic;

namespace ReCapProject.Business.Concrete
{
    public class ColorEngine : BusinessEngineBase<Color, IColorRepository, int>, IColorEngine
    {
        public ColorEngine(IColorRepository repository) : base(repository)
        {
        }

        public void InsertAll(List<Color> colors)
        {
            foreach (var color in colors)
            {
                _repository.Add(color);
            }
            _repository.SaveChanges();
        }
    }
}
