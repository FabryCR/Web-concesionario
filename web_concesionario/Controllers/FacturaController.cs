using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class FacturaController : Controller
    {
        FacturaModel model = new FacturaModel();

        //------------Para vista de Admin------------

        [AdminValidation]
        //Lista de Facturas
        public ActionResult ListFactura()
        {
            List<FacturaObj> consulta;
            try
            {
                consulta = model.SelectFacturas();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }

        [AdminValidation]
        //Genera Factura
        public ActionResult AddFactura()
        {
            //Recupera los select list
            ViewBag.Usuarios = model.ListaUsuarios();
            ViewBag.Vehiculos = model.ListaVehiculos();
            return View();
        }

        [AdminValidation]
        //Genera Factura (POST)
        [HttpPost]
        public ActionResult AddFactura(FacturaObj Obj)
        {
            try
            {
                model.InsertFactura(Obj);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ListFactura", "Factura");
        }
        [AdminValidation]
        //Elimina Facturas
        [HttpPost]
        public ActionResult DeleteFactura(FacturaObj Obj)
        {
            try
            {
                model.DeleteFactura(Obj);
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