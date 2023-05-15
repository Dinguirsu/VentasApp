using Microsoft.AspNetCore.Mvc;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;
using WSVenta.Services;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var UserResponse = _userService.Auth(model);

            if(UserResponse == null) 
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Ususario o Password incorrecto";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = UserResponse;

            return Ok(respuesta);
        }
    }
}
