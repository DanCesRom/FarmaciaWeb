using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Database;
using System.Data;
using System.Data.SqlTypes;
using System.Net;

namespace CapaNegocio.Acciones
{
    public class AccionesConsulta : AccionesBases
    {
        #region Metodos de Listar / Listados de Tablas
        public List<Cliente> listCliente()
        {
            return dbLibContext.Clientes.ToList();
        }

        public List<Factura> listFactura()
        {
            return dbLibContext.Facturas.ToList();
        }

        public List<Empleado> listEmpleado()
        {
            return dbLibContext.Empleados.ToList();
        }

        public List<Farmacia> listFarmacia()
        {
            return dbLibContext.Farmacias.ToList();
        }

        public List<Farmaceutico> listFarmaceutico()
        {
            return dbLibContext.Farmaceuticos.ToList();
        }

        public List<Tipo_Farmaceutico> listTipo_Farmaceutico()
        {
            return dbLibContext.Tipo_Farmaceuticos.ToList();
        }

        public List<User> listUsuarios()
        {
            return dbLibContext.Users.ToList();
        }

        #endregion
    }
}
