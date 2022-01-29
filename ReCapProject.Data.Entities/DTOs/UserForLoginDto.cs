using ReCapProject.Core.Entities.Abstract;
using System;

namespace ReCapProject.Data.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}