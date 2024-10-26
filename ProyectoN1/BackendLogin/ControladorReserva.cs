using System;
using System.Collections.Generic;
using System.Web;

namespace ProyectoN1
{
    public class ControladorReserva
    {
        private ManejoXML<Reservar> _xmlReserva;

        public ControladorReserva()
        {
            _xmlReserva = new ManejoXML<Reservar>(HttpContext.Current.Server.MapPath("~/BackendLogin/reservas.xml"));
        }

        public void RegistrarReserva(int clienteID, Guid vueloID, int cantidadBoletos)
        {
            var reservas = _xmlReserva.Cargar();
            Reservar nuevaReserva = new Reservar
            {
                ClienteID = clienteID,
                VueloID = vueloID,
                FechaReserva = DateTime.Now,
                CantidadBoletos = cantidadBoletos
            };

            reservas.Add(nuevaReserva);
            _xmlReserva.Guardar(reservas);
        }

        public List<Reservar> ObtenerReservasPorCliente(int clienteID)
        {
            var reservas = _xmlReserva.Cargar();
            return reservas.FindAll(r => r.ClienteID == clienteID);
        }
    }
}