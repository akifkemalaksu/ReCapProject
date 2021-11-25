using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorEngine _colorEngine;

        public ColorsController(IColorEngine colorEngine)
        {
            _colorEngine = colorEngine;
        }

        [Route("", Order = 1)]
        [Route("{skip}/{take}", Order = 2)]
        [HttpGet]
        public IActionResult Get(int skip = 0, int take = 10)
        {
            var result = _colorEngine.GetAll(skip, take);
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
            var result = _colorEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Color color)
        {
            var result = _colorEngine.Insert(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Color color)
        {
            var result = _colorEngine.Update(color);
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
            var result = _colorEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
