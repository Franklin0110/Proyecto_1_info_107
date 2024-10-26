using System;

namespace ProyectoN1
{
    public class Reservar
    {
        public Guid ClienteID { get; set; }
        public Guid VueloID { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadBoletos { get; set; }
    }
}