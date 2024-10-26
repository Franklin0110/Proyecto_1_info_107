using System;

namespace ProyectoN1
{
    public class Vuelo
    {
        public Guid ID { get; set; }  
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public int Capacidad { get; set; }
        public int AsientosDisponibles { get; set; }
    }
}