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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandEngine _brandEngine;

        public BrandsController(IBrandEngine brandEngine)
        {
            _brandEngine = brandEngine;
        }

        [Route("", Order = 1)]
        [Route("{skip}/{take}", Order = 2)]
        [HttpGet]
        public IActionResult Get(int skip = 0, int take = 10)
        {
            var result = _brandEngine.GetAll(skip, take);
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
            var result = _brandEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            var result = _brandEngine.Insert(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Brand brand)
        {
            var result = _brandEngine.Update(brand);
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
            var result = _brandEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}