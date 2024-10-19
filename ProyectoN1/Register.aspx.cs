using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1_progra4
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Usuario = txtUsuario.Text,
                Contraseña = txtContraseña.Text,
                FechaNacimiento = DateTime.Now 
            };

            ControladorCliente controladorCliente = new ControladorCliente();
            controladorCliente.RegistrarCliente(nuevoCliente);
            Response.Redirect("Login.aspx");
        }
    }
}