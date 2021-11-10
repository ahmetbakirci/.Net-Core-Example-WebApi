using Business.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICalendarService _calendarService;

        public ProductController(IProductService productService, ICalendarService calendarService)
        {
            _productService = productService;
            _calendarService = calendarService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_productService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpGet]
        [Route("{id}/GetImagesById")]
        public IActionResult GetImagesById(string id)
        {
            return Ok(_productService.GetImagesById(id));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return Ok(_productService.Add(product));
        }

        [HttpPut]
        public IActionResult Update(string id, Product product) {
            return Ok(_productService.Update(id, product));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [Route("AddImage")]
        public IActionResult AddImage(string productId, Image image)
        {
            _productService.AddImage(productId, image);
            return Ok(_productService.GetById(productId));
        }

        [HttpPost]
        [Route("ToBook")]
        public IActionResult ToBook(Calendar calendar)
        {
            _calendarService.GetAvailability(calendar.ProductId);
            try
            {
                return Ok(_calendarService.ToBook(calendar));
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAvailability")]
        public string GetAvailability(string productId) 
        {
            if (_calendarService.GetAvailability(productId))
                return "Das Product ist verfügbar.";

            return "Leider ist das Product nicht verfügbar!";
        }
    }
}
