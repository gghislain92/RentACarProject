using Business.Abstracts;
using Business.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet]

        public IActionResult Get()
        {

            return Ok(_brandService.GetAll());
        }

        [HttpGet("{brandName}")]
        public IActionResult Get([FromRoute] string brandName)
        {

            return Ok(_brandService.GetAll(brandName));
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            return Ok(_brandService.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(CreateBrandRequest brand)
        {
            _brandService.Add(brand);
            return Ok(brand);
        }
        [HttpPost("Update")]
        public IActionResult Update(UpdateBrandRequest brand)
        {
            _brandService.update(brand);
            return Ok(brand);
        }
        [HttpDelete]
        public IActionResult Delete(DeleteBrandRequest brand)
        {
            _brandService.delete(brand);
            return Ok();
        }


    }
}
