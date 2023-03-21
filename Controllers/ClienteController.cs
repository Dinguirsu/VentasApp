using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (VentaRealContext context = new VentaRealContext())
            {
                var list = context.Clientes.ToList();
                return Ok(list);
            }
                
        }
    }
}
