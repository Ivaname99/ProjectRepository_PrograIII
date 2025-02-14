using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Repository;
using reactBackend.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDao _proDao = new ProfesorDao();
        // Se crea un endPoint con el metodo http post
        [HttpPost("autentificacion")]

        public string loginProfesor([FromBody] Profesor prof)
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass);
            if (prof1 != null)
            {
                return prof1.Usuario;
            }
            return "Elemento no encontrado";
        }
    }
}
