using System;

namespace ProyectoFinal.Entities
{
    public class FacturaObj
    {
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Total { get; set; }

        public string NombreUsuario { get; set; }
        public string Vehiculo { get; set; }
    }
}