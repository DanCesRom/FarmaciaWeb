using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos.Database;
using CapaNegocio.Acciones;
using Microsoft.Win32;

namespace Farmacia.Controllers
{
    public class AddInfoController : Controller
    {
        // GET: EmpleadosAdd

        #region Controlador de Vistas
        public AccionesGuardar guardar = new AccionesGuardar();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarmaciaAdd()
        {
            return View();
        }
        public ActionResult FarmaceuticoAdd()
        {
            return View();
        }
        public ActionResult TipoFarmaceuticoAdd()
        {
            return View();
        }
        public ActionResult ClienteAdd()
        {
            return View();
        }
        public ActionResult FacturaAdd()
        {
            return View();
        }
        public ActionResult EmpleadosAdd()
        {
            return View();
        }

        public ActionResult UsersAdd()
        {
            return View();
        }

        #endregion

        #region HttpPost Registrar a Tablas

        [HttpPost]
        public ActionResult registrarTipoFarmacia(string tipofarmaceutico_txt = "", string categoriafarmaceutico_txt = "")
        {
            string resultado = guardar.registrarTipo(tipofarmaceutico_txt, categoriafarmaceutico_txt);
            

            if (resultado == "Registro completado")
            {
                TempData["TipoFarmaceuticoRegisterMessage"] = $"El Tipo Farmaceutico: {tipofarmaceutico_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["TipoFarmaceuticoRegisterErrorMessage"] = $"{resultado}.";
            }



            return RedirectToAction("Consultar_Tipo_Farmaceutico", "Home");
        }

        [HttpPost]
        public ActionResult registrarFarmacia(string callefarmacia_txt = "", string sectorfarmacia_txt = "", string provinciafarmacia_txt = "", string telefonofarmacia_txt = "", string estadofarmacia_txt = "")
        {
            string resultado = guardar.registrarFarmacia(callefarmacia_txt, sectorfarmacia_txt, provinciafarmacia_txt, telefonofarmacia_txt, estadofarmacia_txt);

            if (resultado == "Registro completado")
            {
                TempData["FarmaciaRegisterMessage"] = $"La Farmacia en la calle: {callefarmacia_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["FarmaciaRegisterErrorMessage"] = $"{resultado}.";
            }

            return RedirectToAction("Consultar_Farmacia", "Home");
        }

        [HttpPost]
        public ActionResult registrarFarmaceutico(string nombrefarmaceutico_txt = "", DateTime fechadevencimiento_txt = default(DateTime), int cantidadfarmaceutico_txt = 0, int preciofarmaceutico_txt = 0, int id_tf_txt = 0, int idfarmacia_txt = 0)
        {
            guardar.registrarFarmaceutico(nombrefarmaceutico_txt, fechadevencimiento_txt, cantidadfarmaceutico_txt, preciofarmaceutico_txt, id_tf_txt, idfarmacia_txt); 
            TempData["FarmaceuticoRegisterMessage"] = $"El Farmaceutico con el Nombre: {nombrefarmaceutico_txt} ha sido creado exitosamente";           
            return RedirectToAction("Consultar_Farmaceutico", "Home");
        }

        [HttpPost]
        public ActionResult registrarFactura(string codigodefactura_txt = "", int monto_txt = 0, int idcliente_txt = 0, int idempleado_txt = 0)
        {
            string resultado = guardar.registrarFactura(codigodefactura_txt, monto_txt, idcliente_txt, idempleado_txt);

            if (resultado == "Registro completado")
            {
                TempData["FacturaRegisterMessage"] = $"La Factura con el Codigo: {codigodefactura_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["FacturaRegisterErrorMessage"] = $"{resultado}.";
            }
            
            return RedirectToAction("Consultar_Factura", "Home");
        }

        [HttpPost]
        public ActionResult registrarEmpleado(string dniempleado_txt = "", string nombreempleado_txt = "", int idfarmaciaempleado_txt = 0)
        {
            string resultado = guardar.registrarEmpleado(dniempleado_txt, nombreempleado_txt, idfarmaciaempleado_txt);

            if (resultado == "Registro completado")
            {
                TempData["EmpleadoRegisterMessage"] = $"El Empleado con el DNI: {dniempleado_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["EmpleadoRegisterErrorMessage"] = $"{resultado}.";
            }
            return RedirectToAction("Consultar_Empleados", "Home");
        }

        [HttpPost]
        public ActionResult registrarCliente(string dnicliente_txt = "", string nombrecliente_txt = "", int edadcliente_txt = 0)
        {
            string resultado = guardar.registrarCliente(dnicliente_txt, nombrecliente_txt, edadcliente_txt);
            if (resultado == "Registro completado")
            {
                TempData["ClienteRegisterMessage"] = $"El Cliente con el DNI:{dnicliente_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["ClienteRegisterErrorMessage"] = $"{resultado}.";
            }
            
            return RedirectToAction("Consultar_Clientes", "Home");
        }

        [HttpPost]
        public ActionResult registrarUsuarios(string idusuario_txt = "", string idclave_txt = "", int idnivel_txt = 0)
        {
            string resultado = guardar.registrarUsuarios(idusuario_txt, idclave_txt, idnivel_txt);
            if (resultado == "Registro completado")
            {
                TempData["UserRegisterMessage"] = $"El Usuario: {idusuario_txt} ha sido creado exitosamente";
            }

            else
            {
                TempData["UserRegisterErrorMessage"] = $"{resultado}";
            }
            
            return RedirectToAction("Consultar_User", "Home");
        }

        #endregion 
    }
}
