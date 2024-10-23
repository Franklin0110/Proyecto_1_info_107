using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoN1
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } = "cliente";

        public int Edad
        {
            get
            {
                return DateTime.Now.Year - FechaNacimiento.Year;
            }
        }
    }
}