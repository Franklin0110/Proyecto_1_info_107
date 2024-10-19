using System;
using System.Collections.Generic;

namespace Proyecto1_progra4
{
    public class ControladorReserva
    {
        private ManejoXML<Reserva> _xmlReserva;

        public ControladorReserva()
        {
            _xmlReserva = new ManejoXML<Reserva>("reservas.xml");
        }

        public void RegistrarReserva(Reserva nuevaReserva)
        {
            var reservas = _xmlReserva.Cargar();
            reservas.Add(nuevaReserva);
            _xmlReserva.Guardar(reservas);
        }

        public List<Reserva> ObtenerReservasPorCliente(Cliente cliente)
        {
            var reservas = _xmlReserva.Cargar();
            return reservas.FindAll(r => r.Cliente.Identificacion == cliente.Identificacion);
        }
    }
}