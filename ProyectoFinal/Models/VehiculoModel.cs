using ProyectoFinal.Entities;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinal.DB;
using System.Web.Mvc;

namespace ProyectoFinal.Models
{
    public class VehiculoModel
    {
        //Selecciona los vehículos en Venta
        public List<VehiculoObj> SelectVenta()
        {
            List<VehiculoObj> lista = new List<VehiculoObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.Tipo == "Venta"
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new VehiculoObj
                    {
                        IdVehiculo = item.IdVehiculo,
                        Marca = item.Marca,
                        Modelo = item.Modelo,
                        Color = item.Color,
                        Anio = item.Anio,
                    });
                }
            }
            return lista;
        }

        //Selecciona los vehículos en Alquiler
        public List<VehiculoObj> SelectAlquiler()
        {
            List<VehiculoObj> lista = new List<VehiculoObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.Tipo == "Alquiler"
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new VehiculoObj
                    {
                        IdVehiculo = item.IdVehiculo,
                        Marca = item.Marca,
                        Modelo = item.Modelo,
                        Color = item.Color,
                        Anio = item.Anio,
                        Placa = item.Placa
                    });
                }
            }
            return lista;
        }

        //Inserta un vehículo
        public void InsertVehiculo(VehiculoObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {

                var carro = new Vehiculo();

                carro.Marca = obj.Marca;
                carro.Modelo = obj.Modelo;
                carro.Color = obj.Color;
                carro.Tipo = obj.Tipo;
                carro.Anio = obj.Anio;

                //Si es alquiler setea la placa
                if (obj.Tipo == "Alquiler")
                {
                    carro.Placa = obj.Placa;
                }

                contexto.Vehiculo.Add(carro);
                contexto.SaveChanges();
            }
        }

        //Actualiza los vehículos
        public void UpdateVehiculo(VehiculoObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.IdVehiculo == obj.IdVehiculo
                             select x).FirstOrDefault();

                datos.Marca = obj.Marca;
                datos.Modelo = obj.Modelo;
                datos.Color = obj.Color;
                datos.Anio = obj.Anio;
                
                //Si es alquiler setea la placa
                if (obj.Tipo == "Alquiler")
                {
                    datos.Placa = obj.Placa;
                }

                contexto.SaveChanges();
            }
        }

        //Elimina los vehículos
        public void DeleteVehiculo(VehiculoObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Vehiculo
                             where x.IdVehiculo == obj.IdVehiculo
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    contexto.Vehiculo.Remove(datos);
                    contexto.SaveChanges();
                }
            }
        }

        //Crea un SelectListItem con los dos tipos de datos, lo utiliza la vista.
        public List<SelectListItem> ListaTipos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = "Venta",
                Text = "Venta"

            });

            lista.Add(new SelectListItem()
            {
                Value = "Alquiler",
                Text = "Alquiler"

            });

            return lista;
        }
    }
}