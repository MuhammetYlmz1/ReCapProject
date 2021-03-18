using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageServices _carImageServices;
        public CarImagesController(ICarImageServices carImageServices)
        {
            _carImageServices = carImageServices;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name=("Image"))] IFormFile file,[FromForm] CarImage carImage )
        {
            var result = _carImageServices.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update([FromForm(Name =("Image"))] IFormFile file,[FromForm(Name =("Id"))] int Id)
        {
            var carImage = _carImageServices.Get(Id).Data;
            var result = _carImageServices.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImage = _carImageServices.Get(Id).Data;

            var result = _carImageServices.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageServices.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagecarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageServices.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
