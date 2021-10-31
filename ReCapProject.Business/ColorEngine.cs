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
    public class ColorEngine : IColorEngine
    {
        private readonly IColorRepository _colorRepository;

        public ColorEngine(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public Color GetColorById(int Id)
        {
            return _colorRepository.Get(Id);
        }
    }
}
