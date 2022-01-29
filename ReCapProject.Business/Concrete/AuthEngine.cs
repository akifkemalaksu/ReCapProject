using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Core.Utilities.Security;
using ReCapProject.Core.Utilities.Security.Hashing;
using ReCapProject.Data.Entities.DTOs;
using System;

namespace ReCapProject.Business.Concrete
{
    public class AuthEngine : IAuthEngine
    {
        private readonly IUserEngine _userEngine;
        private readonly ITokenHelper _tokenHelper;

        public AuthEngine(IUserEngine userEngine, ITokenHelper tokenHelper)
        {
            _userEngine = userEngine;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userEngine.GetOperationClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userEngine.GetByExpression(x => x.Email == userForLogin.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userEngine.Insert(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userEngine.GetByExpression(x => x.Email == email).Data is not null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}