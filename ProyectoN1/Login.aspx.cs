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
        ControladorCliente _controlador_cliente = new ControladorCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = _controlador_cliente.Autenticar(txtUsuario.Text, txtContrasena.Text);
                 
                if (cliente != null)
                {
                    Session["current_client"] = cliente;
                    Response.Redirect("HomeUsuario.aspx");
                }
                else
                {

                }
            }
            catch (Exception err)
            {
                Console.Write(err);
                throw;
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}
