using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        #region Prueba
        // indica la url
        [HttpGet("prueba")]
        // metodo publico que se ejecutara si la url es llamada
        public string Get()
        {
            return "Hola mundo";
        }
        #endregion
    }
}
