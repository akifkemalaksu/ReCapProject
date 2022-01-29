using ReCapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ReCapProject.Core.Utilities.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, ICollection<OperationClaim> operationClaims);
    }
}