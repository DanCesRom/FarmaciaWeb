using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos.Database;
using CapaNegocio.Acciones;
using Farmacia.Models;
using static System.Collections.Specialized.BitVector32;

namespace Farmacia.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public AccionesConsulta confirmar = new AccionesConsulta();

        public AccionesGuardar guardar = new AccionesGuardar();

        #region Controlador-Vista
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Clientes");
        }

        public ActionResult Logoutadm()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        #endregion

        #region HttpPost Conexion Iniciar Sesion

        [HttpPost]
        public ActionResult LoginUsuario(string user, string Password)
        {
 
            var usuario = confirmar.listUsuarios().ToList();

            if (usuario.Exists(x => x.Usuario.ToLower() == user.ToLower() && x.Clave == Password))
            {
                var autuser = usuario.FirstOrDefault(x => x.Usuario.ToLower() == user.ToLower());
                Session["NombreUsuario"] = autuser.Usuario;
                Session["NivelAccesso"] = autuser.CodNivel.ToString();
            }

            if (usuario.Exists(x => x.Usuario.ToLower() == user.ToLower() && x.Clave == Password && x.CodNivel == 1))
            {
                return RedirectToAction("Eleccion", "Home");
            }

            if (usuario.Exists(x => x.Usuario.ToLower() == user.ToLower() && x.Clave == Password && x.CodNivel == 2))
            {
                return RedirectToAction("About", "Home");
            }

            else if (usuario.Exists(x => x.Usuario.ToLower() == user.ToLower() && x.Clave == Password && x.CodNivel == 3))
            {
                return RedirectToAction("Contact", "Home");
            }

            else if (usuario.Exists(x => x.Usuario.ToLower() == user.ToLower() && x.Clave == Password && x.CodNivel == 0))
            {
                return RedirectToAction("Index", "Clientes");
            }
            else if (user == "host" && Password == "admin")
            {
                Session["NombreUsuario"] = user;
                Session["NivelAccesso"] = "1";
                return RedirectToAction("Consultar_User", "Home");
            }

            else
            {
                ViewBag.ErrorMessage = "Usuario o Contraseña incorrectos.";
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult registrarUsuariosClientes(string idusuario_txt = "", string idclave_txt = "")
        {
            string resultado = guardar.registrarUsuariosClientes(idusuario_txt, idclave_txt);
            TempData["ClienteRegisterUserMessage"] = $"Tu cuenta {idusuario_txt} ha sido creada exitosamente";

            if (resultado == "Registro completado")
            {
                TempData["ClienteRegisterUserMessage"] = $"El Usuario: {idusuario_txt} ha sido creado exitosamente";
                return RedirectToAction("Login");
            }

            else
            {
                TempData["UserRegisterErrorMessage"] = $"{resultado}";
                return RedirectToAction("Register");
            }

            
        }

        #endregion

    }
}