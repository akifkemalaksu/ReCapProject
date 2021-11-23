using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.Abstract
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
