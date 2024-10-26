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
            ControladorCliente _controlador_cliente = new ControladorCliente();

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                ControladorCliente controladorCliente = new ControladorCliente();
                Cliente cliente = controladorCliente.Autenticar(usuario, contraseña);

                if (cliente != null)
                {
                    Session["Usuario"] = cliente;

                    if (cliente.Rol == "cliente")
                    {
                        Response.Redirect("HomeUsuario.aspx");
                    }
                    else
                    {
                        Response.Redirect("HomeAdmin.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Usuario o Contraseña Incorrecto";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                throw;
            }
            
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}
