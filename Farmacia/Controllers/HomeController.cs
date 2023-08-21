using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos.Database;
using CapaModelo;
using CapaNegocio.Acciones;
using Microsoft.Ajax.Utilities;

namespace Farmacia.Controllers
{
    public class HomeController : Controller
    {
        public AccionesConsulta consultar = new AccionesConsulta();
        public AccionesEditar editar = new AccionesEditar();
        public AccionesEliminar eliminar = new AccionesEliminar();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eleccion()
        {
            return View();
        }

        public ActionResult Auditorio()
        {
            ViewBag.Message = "Pagina de Auditorio.";
            return View();
        }




        #region  Mostrar de Consultas 

        public ActionResult Consultar_Clientes()
        {
            List<Cliente> client = consultar.listCliente();
            return View(client);
        }

        public ActionResult Consultar_Empleados()
        {
            List<Empleado> employee = consultar.listEmpleado();
            return View(employee);
        }

        public ActionResult Consultar_Factura()
        {
            List<Factura> fact = consultar.listFactura();
            return View(fact);
        }

        public ActionResult Consultar_Farmaceutico()
        {
            List<Farmaceutico> farmaceutic = consultar.listFarmaceutico();
            return View(farmaceutic);
        }

        public ActionResult Consultar_Farmacia()
        {
            List<CapaDatos.Database.Farmacia> farmacias = consultar.listFarmacia();
            return View(farmacias);
        }

        public ActionResult Consultar_Tipo_Farmaceutico()
        {
            List<Tipo_Farmaceutico> tipo_Farmaceuticos = consultar.listTipo_Farmaceutico();
            return View(tipo_Farmaceuticos);
        }

        public ActionResult Consultar_User()
        {
            List<User> usuario = consultar.listUsuarios();
            return View(usuario);
        }
        #endregion

        #region Vistas Editar Tablas

        public ActionResult EditarCliente()
        { 
            return View();
        }

        public ActionResult EditarEmpleado()
        { 
            return View();
        }

        public ActionResult EditarFactura()
        {
            return View();
        }

        public ActionResult EditarFarmaceutico()
        {
            return View();
        }

        public ActionResult EditarFarmacia() 
        { 
            return View();
        }


        public ActionResult EditarTipoFarmaceutico()
        {
            return View();

        }


        public ActionResult EditarUser()
        {
            
            return View();
        }

        #endregion

        #region Editar Datos de Tablas

        //Tener en cuenta que editar logra hacer bypass a reestriccion de duplicates, es decir poner mimsmo valores, modificar de ser necesario

        [HttpPost]
        public ActionResult UpdateCliente(int id_cliente = 0, string dni_txt = "", string nombre_txt = "", int edad_txt = 0)
        {
            editar.UpdateCliente(id_cliente, dni_txt, nombre_txt, edad_txt);
            TempData["ClienteUpdateMessage"] = $"El Empleado con el ID: {id_cliente} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Clientes");

        }
        
        [HttpPost]
        public ActionResult UpdateEmpleado(int id_empleado = 0, string dni_txt = "", string nombre_txt = "", int idfarmacia_txt = 0)
        {
            editar.UpdateEmpleado(id_empleado, dni_txt, nombre_txt, idfarmacia_txt);
            TempData["EmpleadoUpdateMessage"] = $"El Empleado con el ID: {id_empleado} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Empleados");

        }

        [HttpPost]
        public ActionResult UpdateFactura(int id_factura = 0, string codefactura_txt = "", int monto_txt = 0, int idcliente_txt = 0, int idempleado_txt = 0)
        {
            editar.UpdateFactura(id_factura, codefactura_txt, monto_txt, idcliente_txt, idempleado_txt);
            TempData["FacturaUpdateMessage"] = $"La Factura con el ID: {id_factura} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Factura");

        }

        [HttpPost]
        public ActionResult UpdateFarmaceutico(int id_farmaceutico = 0, string nombre_txt = "", DateTime fechadevencimiento_txt = default(DateTime), int cantidad_txt = 0, int precio_txt = 0, int id_tf_txt = 0, int idfarmacia = 0)
        {
            editar.UpdateFarmaceutico(id_farmaceutico, nombre_txt, fechadevencimiento_txt, cantidad_txt, precio_txt, id_tf_txt, idfarmacia);
            TempData["FarmaceuticoUpdateMessage"] = $"El Farmaceutico con el ID: {id_farmaceutico} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Farmaceutico");

        }

        [HttpPost]
        public ActionResult UpdateFarmacacia(int id_farmacia_txt = 0, string calle_txt = "", string sector_txt = "", string provincia_txt = "", string telefono_txt = "", string estado_txt = "")
        {
            editar.UpdateFarmacia(id_farmacia_txt, calle_txt, sector_txt, provincia_txt, telefono_txt, estado_txt);
            TempData["FarmaciaUpdateMessage"] = $"La Farmacia con el ID: {id_farmacia_txt} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Farmacia");

        }

        [HttpPost]
        public ActionResult UpdateTipoFarmaceutico(int id_tf_txt = 0, string tipo_farmaceutico_txt = "", string categoria_txt = "")
        {
            editar.UpdateTipoFarmaceutico(id_tf_txt, tipo_farmaceutico_txt, categoria_txt);
            TempData["TipoFarmaceuticoUpdateMessage"] = $"El Tipo de Farmaceutico con el ID: {id_tf_txt} ha sido modificado exitosamente";
            return RedirectToAction("Consultar_Tipo_Farmaceutico");

        }

        [HttpPost]
        public ActionResult UpdateUsuarios(int idusuario_txt = 0, string usuario_txt = "", string clave_txt = "", int idnivel_txt = 0)
        {
            string resultado = editar.UpdateUsuarios(idusuario_txt, usuario_txt, clave_txt, idnivel_txt);
            if (resultado == "Modificacion Completado")
            {
                TempData["UserUpdateMessage"] = $"El Usuario con el ID: {idusuario_txt} ha sido modificado exitosamente";
            }

            else
            {
                TempData["UserRegisterErrorMessage"] = $"{resultado}";
            }

            
            return RedirectToAction("Consultar_User");
        
        }
        #endregion

        #region Eliminar Datos de Tablas

        [HttpPost]
        public ActionResult DelClientes(int id = 0)
        {
            eliminar.DelClientes(id);
            TempData["ClientesDeletedMessage"] = $"El cliente con el ID: {id} ha sido eliminada exitosamente";
            return RedirectToAction("Consultar_Clientes");
        }

        [HttpPost]
        public ActionResult DelEmpleados(int id = 0)
        {
            eliminar.DelEmpleados(id);
            TempData["EmpleadosDeletedMessage"] = $"El empleadp con el ID: {id} ha sido eliminada exitosamente";
            return RedirectToAction("Consultar_Empleados");
        }

        [HttpPost]
        public ActionResult DelFactura(int id = 0)
        {
            eliminar.DelFactura(id);
            TempData["FacturaDeletedMessage"] = $"La factura con el ID: {id} ha sido eliminada exitosamente";
            return RedirectToAction("Consultar_Factura");
        }
        
        [HttpPost]
        public ActionResult DelFarmaceutico(int id = 0)
        {
            eliminar.DelFarmaceutico(id);
            TempData["FarmaceuticoDeletedMessage"] = $"El Farmaceutico con el ID: {id} ha sido eliminado exitosamente";
            return RedirectToAction("Consultar_Farmaceutico");
        }

        [HttpPost]
        public ActionResult DelFarmacia(int id = 0)
        {
            eliminar.DelFarmacia(id);
            TempData["FarmaciaDeletedMessage"] = $"La Farmacia con el ID:{id} ha sido eliminado exitosamente";
            return RedirectToAction("Consultar_Farmacia");
        }

        [HttpPost]
        public ActionResult DelTipoFarmaceutico(int id = 0)
        {
            eliminar.DelTipoFarmaceutico(id);
            TempData["TipoFarmaceuticoDeletedMessage"] = $"El Tipo de Farmaceutico con el ID:{id} ha sido eliminado exitosamente";
            return RedirectToAction("Consultar_Tipo_Farmaceutico");
        }

        [HttpPost]
        public ActionResult DelUser(int id = 0)
        {
            eliminar.DelUser(id);
            TempData["UserDeletedMessage"] = $"El Usuario con el ID:{id} ha sido eliminado exitosamente";
            return RedirectToAction("Consultar_User");
        }

        #endregion


    }
}