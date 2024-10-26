using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProyectoN1
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnGestionarVuelos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarVuelosAdmin.aspx");
        }

        protected void btnVerReservas_Click(object sender, EventArgs e)
        {
            // Lógica para ver reservas (vacío por ahora)
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}
