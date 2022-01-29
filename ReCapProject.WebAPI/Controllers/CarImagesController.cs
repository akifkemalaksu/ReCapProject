using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities;

namespace ReCapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageEngine _carImageEngine;

        public CarImagesController(ICarImageEngine carImageEngine)
        {
            _carImageEngine = carImageEngine;
        }

        [HttpPost]
        public IActionResult Post(int id, [FromForm] IFormFile formFile)
        {
            var result = _carImageEngine.AddImage(id, formFile);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromForm] CarImage carImage, [FromForm] IFormFile formFile)
        {
            var result = _carImageEngine.UpdateImage(carImage, formFile);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(int id)
        {
            var result = _carImageEngine.GetCarImages(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _carImageEngine.DeleteImage(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}