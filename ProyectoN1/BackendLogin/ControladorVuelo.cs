using System;
using System.Collections.Generic;
using System.Web;


namespace ProyectoN1
{
    public class ControladorVuelo
    {
        private ManejoXML<Vuelo> _xmlVuelo;

        public ControladorVuelo()
        {
            _xmlVuelo = new ManejoXML<Vuelo>(HttpContext.Current.Server.MapPath("~/BackendLogin/vuelos.xml"));
        }

        public List<Vuelo> ObtenerVuelos()
        {
            return _xmlVuelo.Cargar();
        }

        public void RegistrarVuelo(Vuelo nuevoVuelo)
        {
            var vuelos = _xmlVuelo.Cargar();
            vuelos.Add(nuevoVuelo);
            _xmlVuelo.Guardar(vuelos);
        }

        public void ModificarVuelo(Vuelo vuelo)
        {
            var vuelos = _xmlVuelo.Cargar();
            foreach (Vuelo vueloItem in vuelos)
            {
                if (vuelo.ID == vueloItem.ID)
                {
                    vueloItem.Origen = vuelo.Origen;
                    vueloItem.Destino = vuelo.Destino;
                    vueloItem.AsientosDisponibles = vuelo.AsientosDisponibles;
                    vueloItem.Capacidad = vuelo.Capacidad;
                    vueloItem.Fecha = vuelo.Fecha;
                    break;
                }

            }
            _xmlVuelo.Guardar(vuelos);
        }

        public void EliminarVuelo(Guid ID)
        {

            var vuelos = _xmlVuelo.Cargar();
            foreach (var vueloItem in vuelos)
            {
                if (ID == vueloItem.ID)
                {
                    vuelos.Remove(vueloItem);
                    break;
                }

            }
            _xmlVuelo.Guardar(vuelos);


        }
    }
}