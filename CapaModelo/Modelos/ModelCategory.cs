using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDatos.Database;
using System.Data;

namespace CapaModelo
{
    public class Clientesssss
    {
        public int _IDClientes { get; set; }
        public string _DNI { get; set; }
        public string _Nombre { get; set; }
        public int _Edad { get; set; }
    }

    public class Empleadossssss
    {
        public int _IDEmpleado { get; set; }
        public string _DNI { get; set; }
        public string _Nombre { get; set; }
        public string _IDfarmacia { get; set; }
    }

    public class Facturasssss
    {
        public int _IDCFactura { get; set; }
        public string CodeFactura { get; set; }
        public string _Monto { get; set; }
        public int _IDCliente { get; set; }
        public string _IDEmpleado { get; set; }
    }


}
