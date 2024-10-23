using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProyectoN1
{
    public partial class Registrarse : System.Web.UI.Page
    {
        ControladorCliente _controlador_cliente = new ControladorCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente 
            { 
              Nombre = txtUsuario.Text,
              Apellidos = txtApellido.Text, 
              Contraseña = txtContrasena.Text, 
              FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text), 
              Identificacion = txtIdentificacion.Text, 
              Usuario = txtUsuario.Text, Rol = "cliente" 
            };
            if (_controlador_cliente.RegistrarCliente(cliente)) Response.Redirect("Login.aspx");


        }

        protected void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
