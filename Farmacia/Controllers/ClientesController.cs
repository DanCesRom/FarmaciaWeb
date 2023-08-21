using CapaNegocio.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmacia.Controllers
{
    public class ClientesController : Controller
    {
        public AccionesConsulta consulta = new AccionesConsulta();
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Sucursales()
        {
            List<CapaDatos.Database.Farmacia> farmacias = consulta.listFarmacia();
            return View(farmacias);
        }

    }
}