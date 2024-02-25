using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        public IActionResult Add(CreatedBrandRequest createdBrandRequest)
        {
            CreatedBrandResponses createdBrandResponses = _brandService.Add(createdBrandRequest);

            return Ok(createdBrandResponses);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandService.GetAll());
        }
    }
}
