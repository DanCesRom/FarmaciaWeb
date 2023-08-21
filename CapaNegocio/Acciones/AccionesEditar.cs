using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Acciones
{
    public class AccionesEditar : AccionesBases
    {
        //Modificar los Datos en las tablas de la Base de Datos

        #region Editar Empleado
        public string UpdateCliente(int id, string dni, string nombre, int edad)
        {
            string resultado = "";
            Cliente cliente = dbLibContext.Clientes.FirstOrDefault(x => x.IDcliente == id);

            if (cliente != null)
            {
                cliente.IDcliente = id;
                cliente.DNI = dni;
                cliente.Nombre = nombre;
                cliente.Edad = edad;

                dbLibContext.Clientes.GetModifiedMembers(cliente);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Empleado
        public string UpdateEmpleado(int id, string dni, string nombre, int idfarmacia)
        {
            string resultado = "";
            Empleado empleado = dbLibContext.Empleados.FirstOrDefault(x => x.IDempleado == id);

            if (empleado != null)
            {
                empleado.IDempleado = id;
                empleado.DNI = dni;
                empleado.Nombre = nombre;
                empleado.IDfarmacia = idfarmacia;


                dbLibContext.Empleados.GetModifiedMembers(empleado);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Factura
        public string UpdateFactura(int id, string codefactura, int monto, int idcliente, int idempleado)
        {
            string resultado = "";
            Factura factura = dbLibContext.Facturas.FirstOrDefault(x => x.IDfactura == id);

            if (factura != null)
            {
                factura.IDfactura = id;
                factura.CodeFactura = codefactura;
                factura.Monto = monto;
                factura.IDcliente = idcliente;
                factura.IDempleado = idempleado;

                dbLibContext.Facturas.GetModifiedMembers(factura);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Farmaceutico

        public string UpdateFarmaceutico(int id, string nombre, DateTime fechavencimiento, int cantidad, int precio, int idtf, int idfarmacia)
        {
            string resultado = "";
            Farmaceutico farmaceutico = dbLibContext.Farmaceuticos.FirstOrDefault(x => x.IDfarmaceutico == id);

            if (farmaceutico != null)
            {
                farmaceutico.IDfarmacia = id;
                farmaceutico.Nombre = nombre;
                farmaceutico.Fechavencimiento = fechavencimiento;
                farmaceutico.Cantidad = cantidad;
                farmaceutico.Precio = precio;
                farmaceutico.ID_TF = idtf;
                farmaceutico.IDfarmacia = idfarmacia;

                dbLibContext.Farmaceuticos.GetModifiedMembers(farmaceutico);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Farmacia

        public string UpdateFarmacia(int id, string calle, string sector, string provincia, string telefono, string estado)
        {
            string resultado = "";
            Farmacia farmacia = dbLibContext.Farmacias.FirstOrDefault(x => x.IDfarmacia == id);

            if (farmacia != null)
            {
                farmacia.IDfarmacia = id;
                farmacia.Calle = calle;
                farmacia.Sector = sector;
                farmacia.Provincia = provincia;
                farmacia.Telefono = telefono;
                farmacia.Estado = estado;

                dbLibContext.Farmacias.GetModifiedMembers(farmacia);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Tipo Farmaceutico

        public string UpdateTipoFarmaceutico(int id, string tipofarmaceutico, string categoria)
        {
            string resultado = "";
            Tipo_Farmaceutico tipo_Farmaceutico = dbLibContext.Tipo_Farmaceuticos.FirstOrDefault(x => x.ID_TF == id);

            if (tipo_Farmaceutico != null)
            {
                tipo_Farmaceutico.ID_TF = id;
                tipo_Farmaceutico.Tipofarmaceutico = tipofarmaceutico;
                tipo_Farmaceutico.Categoria = categoria;

                dbLibContext.Tipo_Farmaceuticos.GetModifiedMembers(tipo_Farmaceutico);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Editar Usuarios
        public string UpdateUsuarios(int id, string user, string pass, int nivel)
        {
            string resultado = "";
            if (dbLibContext.Users.Any(x => x.Usuario == user)) { resultado = "El nombre de Usuario ya está en uso. Por favor, elige otro nombre."; return resultado; }
            User usuarios = dbLibContext.Users.FirstOrDefault(x => x.Id_user == id);

            if (usuarios != null)
            {
                usuarios.Id_user = id;
                usuarios.Usuario = user;
                usuarios.Clave = pass;
                usuarios.CodNivel = nivel;

                dbLibContext.Users.GetModifiedMembers(usuarios);
                dbLibContext.SubmitChanges();

                resultado = "Modificacion Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion


    }
}
