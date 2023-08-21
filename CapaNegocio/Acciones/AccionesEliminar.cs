using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Acciones
{
    public class AccionesEliminar : AccionesBases
    {
        #region Eliminar Clientes
        public string DelClientes(int id)
        {
            string resultado = "";
            Cliente clientes = dbLibContext.Clientes.FirstOrDefault(x => x.IDcliente == id);

            if (clientes != null)
            {
                dbLibContext.Clientes.DeleteOnSubmit(clientes);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Eliminar Empleados
        public string DelEmpleados(int id)
        {
            string resultado = "";
            Empleado empleados = dbLibContext.Empleados.FirstOrDefault(x => x.IDempleado == id);

            if (empleados != null)
            {
                dbLibContext.Empleados.DeleteOnSubmit(empleados);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Eliminar Facturas
        public string DelFactura(int id)
        {
            string resultado = "";
            Factura factura = dbLibContext.Facturas.FirstOrDefault(x => x.IDfactura == id);

            if (factura != null)
            {
                dbLibContext.Facturas.DeleteOnSubmit(factura);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Eliminar Farmaceutico

        public string DelFarmaceutico(int id)
        {
            string resultado = "";
            Farmaceutico farmaceuticos = dbLibContext.Farmaceuticos.FirstOrDefault(x => x.IDfarmaceutico == id);

            if (farmaceuticos != null)
            {
                dbLibContext.Farmaceuticos.DeleteOnSubmit(farmaceuticos);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Eliminar Farmacia
        public string DelFarmacia(int id)
        {
            string resultado = "";
            Farmacia farmacias = dbLibContext.Farmacias.FirstOrDefault(x => x.IDfarmacia == id);

            if (farmacias != null)
            {
                dbLibContext.Farmacias.DeleteOnSubmit(farmacias);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Eliminar Usuario
        public string DelUser(int id)
        {
            string resultado = "";
            User usuarios = dbLibContext.Users.FirstOrDefault(x => x.Id_user == id);

            if (usuarios != null)
            {
                dbLibContext.Users.DeleteOnSubmit(usuarios);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

            }
            else
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Eliminar Tipo Farmaceutico

        public string DelTipoFarmaceutico(int id)
        {
            string resultado = "";
            Tipo_Farmaceutico tpfarmaceutico = dbLibContext.Tipo_Farmaceuticos.FirstOrDefault(x => x.ID_TF == id);

            if (tpfarmaceutico != null)
            {
                dbLibContext.Tipo_Farmaceuticos.DeleteOnSubmit(tpfarmaceutico);
                dbLibContext.SubmitChanges();

                resultado = "Eliminar Completado";

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
