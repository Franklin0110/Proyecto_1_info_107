using System;
using System.Collections.Generic;
using System.Web;

namespace ProyectoN1
{
    public class ControladorReserva
    {
        private ManejoXML<Reservar> _xmlReservar;

        public ControladorReserva()
        {
            _xmlReservar = new ManejoXML<Reservar>(HttpContext.Current.Server.MapPath(@"~/BackendLogin/reservas.xml"));
        }

        public void RegistrarReserva(Reservar nuevaReserva)
        {
            var reservas = _xmlReservar.Cargar();
            reservas.Add(nuevaReserva);
            _xmlReservar.Guardar(reservas);
        }

        public List<Reservar> ObtenerReservasPorCliente(Cliente cliente)
        {
            var reservas = _xmlReservar.Cargar();
            return reservas.FindAll(r => r.Cliente.Identificacion == cliente.Identificacion);
        }
    }
}