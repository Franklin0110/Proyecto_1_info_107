﻿using System;

namespace Proyecto1_progra4
{
    public class Vuelo
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public int Capacidad { get; set; }
        public int AsientosDisponibles { get; set; }
    }
}