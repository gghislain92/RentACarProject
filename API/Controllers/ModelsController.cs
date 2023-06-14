using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Request;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_modelService.GetAll());
        }

        [HttpGet("{modelName}")]
        public IActionResult Get([FromRoute] string modelName)
        {
            return Ok(_modelService.GetAll(modelName));
        }

        [HttpPost]
        public IActionResult Add(CreateModelRequest model)
        {
            _modelService.Add(model);
            return Ok(model);
        }
    }
}
