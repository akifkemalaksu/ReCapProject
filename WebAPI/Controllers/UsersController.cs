using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserEngine _userEngine;

        public UsersController(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        [Route("", Order = 1)]
        [Route("{skip}/{take}", Order = 2)]
        [HttpGet]
        public IActionResult Get(int skip = 0, int take = 10)
        {
            var result = _userEngine.GetAll(skip, take);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _userEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var result = _userEngine.Insert(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            var result = _userEngine.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _userEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
