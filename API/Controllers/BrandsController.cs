using Business.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase{
        [HttpGet]

        public IActionResult Get(){
            
            return Ok(brandManager.GetAll()); 
        }
    }
}
