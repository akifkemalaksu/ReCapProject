using Microsoft.EntityFrameworkCore;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class ColorRepository : RepositoryBase<Color, int>, IColorRepository
    {
        public ColorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
