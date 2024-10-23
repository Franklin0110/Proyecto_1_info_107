using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProyectoN1
{
    public partial class HomeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_client"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Cliente cliente = (Cliente)Session["current_client"];
            lblNombreCompleto.Text = cliente.Nombre + " " + cliente.Apellidos;
            lblIdentificacion.Text = cliente.Identificacion;
            lblFechaNacimiento.Text = cliente.FechaNacimiento.ToString();
            lblEdad.Text = cliente.Edad.ToString();
        }

        protected void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarVuelos.aspx");
        }

        protected void btnExportarReservas_Click(object sender, EventArgs e)
        {
            // Lógica para exportar reservas al excel (vacío por ahora)
        }
    }
}
