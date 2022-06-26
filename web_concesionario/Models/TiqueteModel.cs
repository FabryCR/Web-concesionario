using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoFinal.Models
{
    public class TiqueteModel
    {
        //Selecciona los tiquetes
        public List<TiqueteObj> SelectTiquetes()
        {
            List<TiqueteObj> lista = new List<TiqueteObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Tiquete
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
                    
                    lista.Add(new TiqueteObj
                    {
                        IdTiquete = item.IdTiquete,
                        IdUsuario = item.IdUsuario,
                        IdVehiculo = item.IdVehiculo,
                        FechaTiquete = item.FechaTiquete,
                        Total = item.Total,
                        NombreUsuario = datosNombre.Nombre + " " + datosNombre.Apellido,
                        Vehiculo = datosVehiculo.Marca + ", " + datosVehiculo.Modelo + ", " + datosVehiculo.Anio,
                        Placa = datosVehiculo.Placa
                    });
                }
            }
            return lista;
        }

        //Inserta un Tiquete
        public void InsertTiquete(TiqueteObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {

                var tiq = new Tiquete();

                tiq.IdUsuario = obj.IdUsuario;
                tiq.IdVehiculo = obj.IdVehiculo;
                tiq.FechaDevolucion = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                tiq.FechaTiquete = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                tiq.Total = obj.Total;

                contexto.Tiquete.Add(tiq);
                contexto.SaveChanges();
            }
        }

        //Elimina un Tiquete
        public void DeleteTiquete(TiqueteObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Tiquete
                             where x.IdTiquete == obj.IdTiquete
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    contexto.Tiquete.Remove(datos);
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
                        Text = item.Nombre + ", " + item.Apellido
                    });
                }

                return lista;
            }
        }
        //Crea un SelectListItem con los vehículos disponibles de alquiler
        public List<SelectListItem> ListaVehiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.Tipo == "Alquiler"
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.IdVehiculo.ToString(),
                        Text = item.Marca + ", " + item.Modelo + ", " + item.Anio + ". " + "[Placa: " + item.Placa + "]"
                    });
                }

                return lista;
            }
        }
    }
}