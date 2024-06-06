using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WepApi91.Services;

namespace WepApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices)
        {
          _autorServices= autorServices;
        }


        [HttpGet]

        public async Task<IActionResult> GetAutores()
        {

            var result = await _autorServices.GetAutores();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autorServices.Crear(request);

            return Ok(result);  
        }

    }
}
