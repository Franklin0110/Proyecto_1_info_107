using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Web;

namespace ProyectoN1
{
    public class ControladorCliente
    {
        private ManejoXML<Cliente> _xmlCliente;

        public ControladorCliente()
        {

            _xmlCliente = new ManejoXML<Cliente>(HttpContext.Current.Server.MapPath(@"~/BackendLogin/clientes.xml"));
        }

        public Cliente Autenticar(string usuario, string contraseña)
        {
            var clientes = _xmlCliente.Cargar();
            foreach (var cliente in clientes)
            {
                if (cliente.Usuario == usuario && cliente.Contraseña == contraseña)
                {
                    return cliente;
                }
            }
            return null; // Usuario no encontrado o credenciales incorrectas
        }

        public bool RegistrarCliente(Cliente nuevoCliente)
        {
            try
            {
                var clientes = _xmlCliente.Cargar();
                clientes.Add(nuevoCliente);
                _xmlCliente.Guardar(clientes);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}