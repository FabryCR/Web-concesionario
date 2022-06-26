using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System.Web.Http;

namespace ProyectoFinal.Controllers
{
    public class APILogController : ApiController
    {
        LogModel model = new LogModel();

        [HttpPost]
        [Route("apiProyecto/Log/RegistrarCambio")]
        public void RegistrarCambio(LogObj log)
        {
            //Registra la bítacora en la BD
            model.RegistrarCambio(log);
        }
    }
}