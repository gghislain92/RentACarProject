﻿using Business.Abstracts;
using Business.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BrandsController : ControllerBase{
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]

        public IActionResult Get(){
            
            return Ok(_brandService.GetAll()); 
        }

        [HttpGet("{brandName}")]
        public IActionResult Get([FromRoute]string brandName)
        {

            return Ok(_brandService.GetAll(brandName));
        }
    }
}
