using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.InMemory
{
    public class ColorDALInMemory : IColorDAL
    {
        private readonly List<Color> _colors;

        public ColorDALInMemory()
        {
            _colors = new List<Color>();
        }

        public void Add(Color color)
        {
            color.Id = _colors.Count > 0 ? _colors.Max(x => x.Id) + 1 : 1;
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Delete(color.Id);
        }

        public void Delete(int Id)
        {
            int index = _colors.FindIndex(x=>x.Id == Id);
            if (index != -1)
                _colors.RemoveAt(index);
            else
                throw new Exception("Renk bulunamadı.");
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int Id)
        {
            return _colors.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Color color)
        {
            int index = _colors.FindIndex(x => x.Id == color.Id);
            if (index != -1)
                _colors[index] = color;
            else
                throw new Exception("Renk bulunamadı.");
        }
    }
}
