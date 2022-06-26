using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    [AdminValidation]
    public class EmpleadoController : Controller
    {
        EmpleadoModel modelEmp = new EmpleadoModel();
        UsuarioModel modelUser = new UsuarioModel();

        //---------Para vista de Administrador------------

        //Select de Empleados
        public ActionResult ListEmpleado()
        {
            List<UsuarioObj> consulta;
            try
            {
                consulta = modelEmp.SelectEmpleados();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }

        //Insertar Empleado
        public ActionResult AddEmpleado()
        {
            return View();
        }

        //Insertar Empleado (POST)
        [HttpPost]
        public ActionResult AddEmpleado(UsuarioObj obj)
        {
            try
            {
                modelEmp.InsertEmpleado(obj);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ListEmpleado", "Empleado");
        }

        //Editar Empleado (POST)
        [HttpPost]
        public ActionResult EditEmpleado(UsuarioObj obj)
        {
            try
            {
                modelUser.UpdateUsuario(obj);
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }

        //Eliminar Empleado (POST)
        [HttpPost]
        public ActionResult DeleteEmpleado(UsuarioObj obj)
        {
            try
            {
                modelUser.DeleteUsuario(obj);
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}