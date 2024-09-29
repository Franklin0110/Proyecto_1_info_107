using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda___Q1_24
{
    public class classObjetos
    {
    }

    public class oArticulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get;set; }
        public string urlImagen { get;set; }
        public decimal precio { get;set; }
        public bool estado { get; set; }
    }

    public class oCarritoCompras
    {
        public oArticulo articulo { get; set; }
        public decimal cantidadSolicitada { get; set; }
    }

    public class oPersona
    {
        public int id { get; set; }

        public string nombre { get; set;}

        public string identificacion { get; set; }
        public string email { get; set; }

        public string telefono { get; set; }
        public string direccion { get; set; }

    }

    public class oLogin 
    {
        public string usuario { get; set; }

        public string password { get; set; }

    }

}