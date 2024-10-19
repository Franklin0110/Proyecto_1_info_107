using System;
using System.Collections.Generic;

namespace Proyecto1_progra4
{
    public class ControladorCliente
    {
        private ManejoXML<Cliente> _xmlCliente;

        public ControladorCliente()
        {
            _xmlCliente = new ManejoXML<Cliente>("clientes.xml");
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

        public void RegistrarCliente(Cliente nuevoCliente)
        {
            var clientes = _xmlCliente.Cargar();
            clientes.Add(nuevoCliente);
            _xmlCliente.Guardar(clientes);
        }
    }
}