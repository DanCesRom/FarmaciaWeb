using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farmacia.Models
{
    public class Usuarios
    {
        public int Id_User { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int CodNivel { get; set; }

        public string ConfirmacionClave { get; set; }


    }
}