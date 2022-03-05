using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarEngine _carEngine;

        public CarsController(ICarEngine carEngine)
        {
            _carEngine = carEngine;
        }

        [HttpGet]
        [Authorize(Roles = "Car.List")]
        public IActionResult Get()
        {
            var result = _carEngine.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetWithDetails")]
        public IActionResult GetDetails(int? brandId, int? colorId)
        {
            var result = _carEngine.GetAllWithDetails(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetWithDetails/{id}")]
        public IActionResult GetDetails(int id)
        {
            var result = _carEngine.GetWithDetails(id);
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
            var result = _carEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Car car)
        {
            var result = _carEngine.Insert(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Car car)
        {
            var result = _carEngine.Update(car);
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
            var result = _carEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}