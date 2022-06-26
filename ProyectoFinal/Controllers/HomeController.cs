using ExamenResuelto.App_Start;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {

        //Página Inicial para el Usuario
        public ActionResult Index()
        {
            return View();
        }

        //Página Inicial para el Administrador
        [AdminValidation]
        public ActionResult AdminIndex()
        {
            return View();
        }

        //Página de Login
        [AlreadyLogged]
        public ActionResult Login()
        {
            ViewBag.Message = String.Empty;
            return View();
        }

        [AlreadyLogged]
        //Login (POST)
        [HttpPost]
        public ActionResult Login(LoginObj Obj)
        {
            LoginModel Login = new LoginModel();
            int Respuesta;

            try
            {
                Respuesta = Login.Login(Obj);
            }
            catch (Exception)
            {
                throw;
            }

            switch (Respuesta)
            {
                case -1:
                    ViewBag.Message = "El usuario no existe";
                    return View();
                case 0:
                    ViewBag.Message = "Contraseña Incorrecta";
                    return View();
                case 1:
                    Session["Rol"] = 1;
                    Session["Name"] = Obj.Username;
                    return RedirectToAction("AdminIndex", "Home");
                case 2:
                    Session["Rol"] = 2;
                    Session["Name"] = Obj.Username;
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AlreadyLogged]
        //Página de Registro
        public ActionResult Registro()
        {
            return View();
        }

        //Registro (Post)
        [HttpPost]
        public ActionResult Registro(UsuarioObj obj)
        {
            LoginModel model = new LoginModel();

            try
            {
                model.Register(obj);
            }
            catch (Exception)
            {
                throw;
            }
            TempData["RegisterSuccess"] = "True";
            return RedirectToAction("Registro", "Home");
        }

        //Action que cierra sesión y luego redirige a Index
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //Página de Contacto
        public ActionResult Contact()
        {
            return View();
        }
    }
}