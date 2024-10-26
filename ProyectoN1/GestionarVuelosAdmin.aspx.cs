using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoN1
{
    public partial class GestionarVuelosAdmin : System.Web.UI.Page
    {
        ControladorVuelo _controlador_vuelos = new ControladorVuelo();
        ControladorReserva _controlador_reserva = new ControladorReserva();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                CargarVuelos_dispnibles();
            }
        }




        protected void CargarVuelos_dispnibles()
        {
            Cliente usuario = (Cliente)Session["Usuario"];
            List<Vuelo> _vuelos_a_cargar = new List<Vuelo>();
            List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
            List<Reservar> reservas = _controlador_reserva.ObtenerReservasPorCliente(usuario.ID);

            gvVuelos.DataSource = _vuelos;
            gvVuelos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Vuelo vuelo = new Vuelo
            {
                Origen = txtOrigen.Text,
                Destino = txtDestino.Text,
                Fecha = DateTime.Parse(txtFecha.Text),
                Capacidad = int.Parse(txtCupos.Text),
                ID = Guid.NewGuid()

            };
            _controlador_vuelos.RegistrarVuelo(vuelo);
            Response.Redirect("GestionarVuelosAdmin.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Vuelo vuelo = new Vuelo
            {
                Origen = txtOrigen.Text,
                Destino = txtDestino.Text,
                Fecha = DateTime.Parse(txtFecha.Text),
                Capacidad = int.Parse(txtCupos.Text),
                ID = Guid.Parse(txtID.Text)

            };
            _controlador_vuelos.ModificarVuelo(vuelo);
            Response.Redirect("GestionarVuelosAdmin.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            _controlador_vuelos.EliminarVuelo(Guid.Parse(txtID.Text));
            Response.Redirect("GestionarVuelosAdmin.aspx");
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }



        protected void btnCargar_vuelo_por_ID(object sender, EventArgs e)
        {
            if (!txtID.Text.Equals(""))
            {
                List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (vuelo.ID == Guid.Parse(txtID.Text))
                    {
                        txtDestino.Text = vuelo.Destino;
                        txtOrigen.Text = vuelo.Origen;
                        txtFecha.Text = vuelo.Fecha.ToString("yyyy-MM-dd");
                        txtCupos.Text = vuelo.Capacidad.ToString();

                    }
                }
            }
            else
            {
                lblError.Text = "No hay vuelo especificado en el ID";
                lblError.Visible = true;
            }
        }
    }
}