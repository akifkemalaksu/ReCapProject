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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerEngine _customerEngine;

        public CustomersController(ICustomerEngine customerEngine)
        {
            _customerEngine = customerEngine;
        }

        [Route("", Order = 1)]
        [Route("{skip}/{take}", Order = 2)]
        [HttpGet]
        public IActionResult Get(int skip = 0, int take = 10)
        {
            var result = _customerEngine.GetAll(skip, take);
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
            var result = _customerEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var result = _customerEngine.Insert(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            var result = _customerEngine.Update(customer);
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
            var result = _customerEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
