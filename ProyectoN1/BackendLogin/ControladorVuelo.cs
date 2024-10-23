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
    }
}