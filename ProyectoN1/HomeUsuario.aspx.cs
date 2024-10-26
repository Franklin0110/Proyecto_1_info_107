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
        ControladorVuelo _controlador_vuelos = new ControladorVuelo();
        ControladorReserva _controlador_reserva = new ControladorReserva();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Cliente cliente = (Cliente)Session["Usuario"];
            lblUsuario.Text = cliente.Nombre;
            lblNombreCompleto.Text = cliente.Nombre + " " + cliente.Apellidos;
            lblIdentificacion.Text = cliente.Identificacion;
            lblFechaNacimiento.Text = cliente.FechaNacimiento.ToShortDateString();

            CargarVuelos_dispnibles();
        }

        protected void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarVuelos.aspx");
        }

        protected void CargarVuelos_dispnibles()
        {
            Cliente usuario = (Cliente)Session["Usuario"];
            List<Vuelo> _vuelos_a_cargar = new List<Vuelo>();
            List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
            List<Reservar> reservas = _controlador_reserva.ObtenerReservasPorCliente(usuario.ID);


            foreach (Reservar reserva in reservas)
            {
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (reserva.VueloID == vuelo.ID)
                        _vuelos_a_cargar.Add(vuelo);
                }

            }
            gvReservas.DataSource = _vuelos_a_cargar;
            gvReservas.DataBind();
        }

        protected void btnSalir_funcion(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Login.aspx");
        }


    }
}
