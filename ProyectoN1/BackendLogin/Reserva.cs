using System;

namespace ProyectoN1
{
    public class Reservar
    {
        public Cliente Cliente { get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadBoletos { get; set; }
    }
}