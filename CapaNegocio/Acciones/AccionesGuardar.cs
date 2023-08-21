using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Acciones
{
    public class AccionesGuardar : AccionesBases
    {

        //Guardar los Datos en las tablas de la Base de Datos

        #region Guardar Tipo Farmaceuticos
        public string registrarTipo(string tipofarmaceutico, string categoria)
        {
            string resultado = "";
            if (dbLibContext.Tipo_Farmaceuticos.Any(x => x.Tipofarmaceutico == tipofarmaceutico)) { resultado = "El nombre de Tipo de Farmaceutico ya está en uso. Por favor, elige otro nombre."; return resultado; }
            try
            {
                Tipo_Farmaceutico tipoFarm;

                tipoFarm = new Tipo_Farmaceutico
                {

                    Tipofarmaceutico = tipofarmaceutico,
                    Categoria = categoria,

                };

                dbLibContext.Tipo_Farmaceuticos.InsertOnSubmit(tipoFarm);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Guardar Farmacias
        public string registrarFarmacia(string calle, string sector, string provincia, string telefono, string estado)
        {
            string resultado = "";
            if (dbLibContext.Farmacias.Any(x => x.Calle == calle)) { resultado = "Ya hay una farmacia que se encuentra en esa calle. Por favor, elige otra calle."; return resultado; }
            try
            {
                Farmacia Farm;

                Farm = new Farmacia
                {

                    Calle = calle,
                    Sector = sector,
                    Provincia = provincia,
                    Telefono = telefono,
                    Estado = estado


                };

                dbLibContext.Farmacias.InsertOnSubmit(Farm);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Guardar Farmaceuticos
        public string registrarFarmaceutico(string nombre, DateTime fechavencimiento, int cantidad, int precio, int idtf, int idfarmacia)
        {
            string resultado = "";
            try
            {
                Farmaceutico Farmico;

                Farmico = new Farmaceutico
                {

                    Nombre = nombre,
                    Fechavencimiento = (DateTime)fechavencimiento,
                    Cantidad = cantidad,
                    Precio = precio,
                    ID_TF = idtf,
                    IDfarmacia = idfarmacia


                };

                dbLibContext.Farmaceuticos.InsertOnSubmit(Farmico);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Guardar Facturas
        public string registrarFactura(string codefactura, int monto, int idcliente, int idempleado)
        {
            string resultado = "";
            if (dbLibContext.Facturas.Any(x => x.CodeFactura == codefactura)) { resultado = "El codigo de factura ya está en uso. Por favor, elige otro codigo."; return resultado; }
            try
            {
                Factura Fac;

                Fac = new Factura
                {

                    CodeFactura = codefactura,
                    Monto = monto,
                    IDcliente = idcliente,
                    IDempleado = idempleado,


                };

                dbLibContext.Facturas.InsertOnSubmit(Fac);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Guardar Empleados
        public string registrarEmpleado(string dni, string nombre, int idfarmacia)
        {
            string resultado = "";
            if (dbLibContext.Empleados.Any(x => x.DNI == dni)) { resultado = "El DNI de Empleado ya está en uso. Por favor, verifique los datos"; return resultado; }

            try
            {
                Empleado Emp;

                Emp = new Empleado
                {

                    DNI = dni,
                    Nombre = nombre,
                    IDfarmacia = idfarmacia,

                };

                dbLibContext.Empleados.InsertOnSubmit(Emp);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }
        #endregion

        #region Guardar Clientes

        public string registrarCliente(string dni, string nombre, int edad)
        {
            string resultado = "";
            if (dbLibContext.Clientes.Any(x => x.DNI == dni)) { resultado = "El DNI de Cliente ya está en uso. Por favor, verifique los datos"; return resultado; }
            try
            {
                Cliente cli;

                cli = new Cliente
                {

                    DNI = dni,
                    Nombre = nombre,
                    Edad = edad,

                };

                dbLibContext.Clientes.InsertOnSubmit(cli);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

        #region Guardar Usuarios

        public string registrarUsuarios(string user, string pass, int nivel)
        {
            string resultado = "";
            if (dbLibContext.Users.Any(x => x.Usuario == user)) { resultado = "El nombre de usuario ya está en uso. Por favor, elige otro nombre."; return resultado; }
            try
            {
                if (nivel < 0)
                { resultado = "No puede haber Nivel de Acesso Negativo"; return resultado; }
                User usuarios;

                usuarios = new User
                {

                    Usuario = user,
                    Clave = pass,
                    CodNivel = nivel,


                };

                dbLibContext.Users.InsertOnSubmit(usuarios);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }

            return resultado;
        }

        #endregion

        #region Guardar Usuarios -- Clients

        public string registrarUsuariosClientes(string user, string pass)
        {
            string resultado = "";
            if (dbLibContext.Users.Any(x => x.Usuario == user)) { resultado = "El nombre de usuario ya está en uso. Por favor, elige otro nombre."; return resultado; }
            try
            {
                User usuarios;

                usuarios = new User
                {

                    Usuario = user,
                    Clave = pass,
                    CodNivel = 0,


                };

                dbLibContext.Users.InsertOnSubmit(usuarios);
                dbLibContext.SubmitChanges();

                resultado = "Registro completado";

            }
            catch (Exception)
            {
                resultado = "Hubo un fallo";
            }


            return resultado;
        }

        #endregion

    }
}
