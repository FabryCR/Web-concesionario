using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class VehiculoController : Controller
    {
        VehiculoModel model = new VehiculoModel();


        //---------Para vista de Usuario------------

        //Vista de Usuario de vehículos en Venta
        public ActionResult EnVenta()
        {
            List<VehiculoObj> consulta;
            try
            {
                consulta = model.SelectVenta();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }
        //Vista de Usuario de vehículos en Alquiler
        public ActionResult EnAlquiler()
        {
            List<VehiculoObj> consulta;
            try
            {
                consulta = model.SelectAlquiler();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }

        //---------Para vista de Admin------------

        //Lista de Vehículos en Venta
        [AdminValidation]
        public ActionResult ListVenta()
        {
            List<VehiculoObj> consulta;
            try
            {
                consulta = model.SelectVenta();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }
        [AdminValidation]
        //Lista de Vehículos en Alquiler
        public ActionResult ListAlquiler()
        {
            List<VehiculoObj> consulta;
            try
            {
                consulta = model.SelectAlquiler();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }
        [AdminValidation]
        //Añadir Vehículo
        public ActionResult AddVehiculo()
        {
            ViewBag.Tipo = model.ListaTipos();
            return View();
        }
        [AdminValidation]
        //Añadir Vehículo (POST)
        [HttpPost]
        public ActionResult AddVehiculo(VehiculoObj obj)
        {
            try
            {
                model.InsertVehiculo(obj);
            }
            catch (Exception)
            {
                throw;
            }

            //Si es venta, al insertar devuelve su vista, sino, la de alquiler.
            if (obj.Tipo == "Venta")
            {
                return RedirectToAction("ListVenta", "Vehiculo");
            }
            else
            {
                return RedirectToAction("ListAlquiler", "Vehiculo");
            }
        }
        [AdminValidation]
        //Editar Vehículo (POST)
        [HttpPost]
        public ActionResult EditVehiculo(VehiculoObj obj)
        {
            try
            {
                model.UpdateVehiculo(obj);
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }
        [AdminValidation]
        //Eliminar Vehículo (POST)
        [HttpPost]
        public ActionResult DeleteVehiculo(VehiculoObj obj)
        {
            try
            {
                model.DeleteVehiculo(obj);
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}