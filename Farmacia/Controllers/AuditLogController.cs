using CapaDatos.Database;
using CapaModelo;
using CapaNegocio.Acciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farmacia.Controllers
{

    public class AuditLogController : Controller
    {
        public AccionesRegistros registros = new AccionesRegistros();

        [HttpPost]
        public string LogAction(int id , string detalles)
        {
            string resultado = registros.LogAction(id,detalles);
            TempData["Probar"] = "Funcional";
            return resultado;
        }
    }
}