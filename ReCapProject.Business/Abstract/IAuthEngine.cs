using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Core.Utilities.Security;
using ReCapProject.Data.Entities.DTOs;
using System;

namespace ReCapProject.Business.Abstract
{
    public interface IAuthEngine
    {
        IDataResult<User> Register(UserForRegisterDto userForRegister);

        IDataResult<User> Login(UserForLoginDto userForLogin);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}