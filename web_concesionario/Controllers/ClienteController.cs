using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ClienteController : Controller
    {
        ClienteModel modelCliente = new ClienteModel();
        UsuarioModel modelUser = new UsuarioModel();

        //---------Para vista de Usuario------------

        //Muestra la información del usuario actualmente activo
        [Validation]
        public ActionResult MiCuenta()
        {
            UsuarioObj user;
            try
            {
                string username = Session["Name"].ToString();
                user = modelUser.UserInfo(username);
            }
            catch (Exception)
            {

                throw;
            }
           
            return View(user);
        }

        //---------Para vista de Administrador------------
        [AdminValidation]
        //Select de Clientes
        public ActionResult ListCliente()
        {
            List<UsuarioObj> consulta;
            try
            {
                consulta = modelCliente.SelectClientes();
            }
            catch (Exception)
            {
                throw;
            }
            return View(consulta);
        }
        [AdminValidation]
        //Editar Cliente (POST)
        [HttpPost]
        public ActionResult EditCliente(UsuarioObj obj)
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
        [AdminValidation]
        //Eliminar Cliente (POST)
        [HttpPost]
        public ActionResult DeleteCliente(UsuarioObj obj)
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