using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WepApi91.Services;

namespace WepApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioServices.ObtenerUsuarios();

            return Ok(result);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioServices.ObtenerUsuario(id);

            return Ok(result);
        }


        [HttpPost]

        public async Task<IActionResult> Crear([FromBody] UsuarioResponse request)
        {
            var result = await _usuarioServices.CrearUsuario(request);

            return Ok(result);  
        }
    }
}
