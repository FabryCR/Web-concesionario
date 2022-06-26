using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoFinal.Models
{
    public class FacturaModel
    {
        //Selecciona las facturas
        public List<FacturaObj> SelectFacturas()
        {
            List<FacturaObj> lista = new List<FacturaObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Factura
                             select x).ToList();


                foreach (var item in datos)
                {
                    //Conseguir el nombre del usuario del ID 
                    var datosNombre = (from x in contexto.Usuario
                                       where x.IdUsuario == item.IdUsuario
                                       select x).FirstOrDefault();

                    //Conseguir el nombre del vehiculo del ID 
                    var datosVehiculo = (from x in contexto.Vehiculo
                                       where x.IdVehiculo == item.IdVehiculo
                                       select x).FirstOrDefault();
                    lista.Add(new FacturaObj
                    {
                        IdFactura = item.IdFactura,
                        IdUsuario = item.IdUsuario,
                        IdVehiculo = item.IdVehiculo,
                        FechaFactura = item.FechaFactura,
                        Total = item.Total,
                        NombreUsuario = datosNombre.Nombre + " " + datosNombre.Apellido,
                        Vehiculo = datosVehiculo.Marca + ", " + datosVehiculo.Modelo + ", " + datosVehiculo.Anio
                    });
                }
            }
            return lista;
        }

        //Inserta una Factura
        public void InsertFactura(FacturaObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {

                var fact = new Factura();

                fact.IdUsuario = obj.IdUsuario;
                fact.IdVehiculo = obj.IdVehiculo;
                fact.FechaEntrega = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fact.FechaFactura = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fact.Total = obj.Total;

                contexto.Factura.Add(fact);
                contexto.SaveChanges();
            }
        }

        //Elimina una factura
        public void DeleteFactura(FacturaObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Factura
                             where x.IdFactura == obj.IdFactura
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    contexto.Factura.Remove(datos);
                    contexto.SaveChanges();
                }
            }
        }

        //Crea un SelectListItem con los usuarios Disponibles
        public List<SelectListItem> ListaUsuarios()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.IdUsuario.ToString(),
                        Text = item.Nombre + ", " +item.Apellido
                    });
                }

                return lista;
            }
        }
        //Crea un SelectListItem con los vehículos disponibles de venta
        public List<SelectListItem> ListaVehiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.Tipo == "Venta"
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.IdVehiculo.ToString(),
                        Text = item.Marca + ", " + item.Modelo + ", " + item.Anio
                    });
                }

                return lista;
            }
        }
    }
}