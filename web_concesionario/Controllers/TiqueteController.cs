using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class TiqueteController : Controller
    {
        TiqueteModel model = new TiqueteModel();

        //------------Para vista de Admin------------

        [AdminValidation]
        //Lista de Tiquetes
        public ActionResult ListTiquete()
        {
            List<TiqueteObj> consulta;
            try
            {
                consulta = model.SelectTiquetes();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }
        [AdminValidation]
        //Genera Tiquete
        public ActionResult AddTiquete()
        {
            //Recupera los select list
            ViewBag.Usuarios = model.ListaUsuarios();
            ViewBag.Vehiculos = model.ListaVehiculos();
            return View();
        }
        [AdminValidation]
        //Genera Tiquete (POST)
        [HttpPost]
        public ActionResult AddTiquete(TiqueteObj Obj)
        {
            try
            {
                model.InsertTiquete(Obj);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ListTiquete", "Tiquete");
        }
        [AdminValidation]
        //Elimina Tiquetes
        [HttpPost]
        public ActionResult DeleteTiquete(TiqueteObj Obj)
        {
            try
            {
                model.DeleteTiquete(Obj);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
            return Json(true);
        }
    }
}