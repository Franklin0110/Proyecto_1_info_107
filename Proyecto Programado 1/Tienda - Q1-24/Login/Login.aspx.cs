using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tienda___Q1_24.login
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        Dictionary<string, string> usuarios = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Validar_Usuario(object sender, EventArgs e)
        {

            try
            {
                string usuario_content=usuario.Text;
                string password_content = Contraseña.Text;
                usuarios.Add("user1", "pass1");
                usuarios.Add("user2", "pass2");
                if (usuarios.Keys.Contains(usuario_content) &&  usuarios[usuario_content].Equals(password_content))
                {  
                    mensajeTexto.InnerText = "Usuario autenticado correctamente";
                    divMensaje.Style["display"] = "block";
                    Response.Redirect("/home.aspx");
                }
                else
                {
                    mensajeTexto.InnerText = "Usuario o contraseña Incorrecto";
                    divMensaje.Style["display"] = "block";
                }

            }
            catch (Exception error)
            {

                throw;
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
        }

    }


 
}