using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoN1
{
    public partial class GestionarVuelos : System.Web.UI.Page
    {
        ControladorVuelo _controlador_vuelos = new ControladorVuelo();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvVuelos.DataSource = _controlador_vuelos.ObtenerVuelos();
            gvVuelos.DataBind();
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Vuelo _vuelo = new Vuelo {
                Origen = txtOrigen.Text,
                Destino = txtDestino.Text,
                AsientosDisponibles = int.Parse(txtCupo.Text),
                Fecha = DateTime.Parse(txtFecha.Text)
            };
            _controlador_vuelos.RegistrarVuelo(_vuelo);

            Response.Redirect("GestionarVuelos.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Lógica para modificar un vuelo existente
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar un vuelo existente
        }
    }
}
