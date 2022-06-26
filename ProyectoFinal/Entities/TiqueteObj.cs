using System;

namespace ProyectoFinal.Entities
{
    public class TiqueteObj
    {
        public int IdTiquete { get; set; }
        public int IdUsuario { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaTiquete { get; set; }
        public decimal Total { get; set; }

        public string NombreUsuario { get; set; }
        public string Vehiculo { get; set; }
        public string Placa { get; set; }
    }
}