using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoN1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            if (ValidarCredenciales(usuario, contrasena))
            {
                Response.Redirect("PaginaPrincipal.aspx"); // aqui se pone a que pantalla ir
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true; // Mostrar mensaje de error
            }
        }

        private bool ValidarCredenciales(string usuario, string contrasena)
        {
            // se valida.
            return usuario == "admin" && contrasena == "1234"; // Ejemplo simple
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}
