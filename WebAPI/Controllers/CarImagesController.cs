using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _hostingEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment hostingEnvironment)
        {
            _carImageService = carImageService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {

            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            carImage.ImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Images", file.FileName);
            var result =  _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] int Id)
        {
            var carImage = _carImageService.GetCarImageById(Id);
            if (carImage.Success)
            {
                string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Images", file.FileName);
                var result = _carImageService.Update(imagePath, file, carImage.Data);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(carImage);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int Id)
        {

            var carImage = _carImageService.GetCarImageById(Id);
            if (carImage.Success)
            {
                string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", "Images");
                var result = _carImageService.Delete(imagePath, carImage.Data);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(carImage);
        }
    }
}
