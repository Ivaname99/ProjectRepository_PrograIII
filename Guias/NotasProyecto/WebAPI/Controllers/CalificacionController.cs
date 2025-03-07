using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDao _cdao = new CalificacionDao();

        #region Lista de Calificaciones
        [HttpGet("Calificaciones")]
        public List<Calificacion> get(int idMatricula)
        {
            return _cdao.seleccion(idMatricula);
        }
        #endregion
    }
}
