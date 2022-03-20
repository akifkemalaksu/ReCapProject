using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.ResponseModels;
using System;

namespace ReCapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalEngine _rentalEngine;

        public RentalsController(IRentalEngine rentalEngine)
        {
            _rentalEngine = rentalEngine;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _rentalEngine.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetRentalsWithDetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalEngine.GetWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _rentalEngine.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("IsCarRented/{carId}")]
        public IActionResult GetIsCarRented(int carId, DateTime fromDate, DateTime toDate)
        {
            var result = _rentalEngine.GetByExpression(x =>
                x.CarId == carId &&
                (
                    (fromDate >= x.RentDate && fromDate <= x.ReturnDate) ||
                    !x.ReturnDate.HasValue ||
                    (toDate >= x.RentDate && toDate <= x.ReturnDate)
                )
            );
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(RentalResponseModel rental)
        {
            var result = _rentalEngine.InsertWithPayment(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Rental rental)
        {
            var result = _rentalEngine.Update(rental);
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
            var result = _rentalEngine.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}