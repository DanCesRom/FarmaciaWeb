using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using CapaDatos.Database;
using CapaModelo;
using CapaNegocio.Acciones;



namespace CapaNegocio.Acciones
{
    public class AccionesBases
    {
        public DbLibraryEntityDataContext dbLibContext = new DbLibraryEntityDataContext();
    }
}
