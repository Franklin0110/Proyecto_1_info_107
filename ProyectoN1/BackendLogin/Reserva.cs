using System;

namespace Proyecto1_progra4
{
    public class Reserva
    {
        public Cliente Cliente { get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadBoletos { get; set; }
    }
}