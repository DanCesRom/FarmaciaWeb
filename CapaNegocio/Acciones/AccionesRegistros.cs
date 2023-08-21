using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Acciones
{
    public class AccionesRegistros : AccionesBases
    {
        public string LogAction(int id, string detalle) 
        {
            string resultado = "";
            try
            {
                AuditLog auditario;
                auditario = new AuditLog
                {
                    Id_user = id,
                    Fecha = DateTime.Now,
                    Detalles = detalle,

                };

                dbLibContext.AuditLogs.InsertOnSubmit(auditario);
                dbLibContext.SubmitChanges();

                resultado = "Registro Completado";
            }
            catch (Exception) 
            {
                resultado = "Hubo un fallo";
            }
            return resultado;
        }

    }
}
