using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System;

namespace ProyectoFinal.Models
{
    public class LogModel
    {
        public void RegistrarCambio(LogObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                //var Log = new Bitacora();

                //Log.Ubicacion = obj.Ubicacion;
                //Log.Detalle = obj.Detalles;
                //Log.Fecha = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                //contexto.Bitacora.Add(Log);
                //contexto.SaveChanges();
            }
        }
    }
}