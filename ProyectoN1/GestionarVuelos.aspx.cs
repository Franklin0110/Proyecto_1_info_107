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
    public partial class GestionarVuelos : System.Web.UI.Page
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
                gvVuelos_PageIndexChanged(sender, e);
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente usuario = (Cliente)Session["Usuario"];

            List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
            foreach (Vuelo vuelo in _vuelos)
            {
                if (vuelo.Destino.ToString().Equals(ddlDestino.SelectedValue.ToString()) && vuelo.Origen.ToString().Equals(ddlOrigen.SelectedValue.ToString()) && vuelo.Fecha.ToString().Equals(ddlFecha.SelectedValue.ToString()))
                {
                    _controlador_reserva.RegistrarReserva(usuario.ID, vuelo.ID, int.Parse(txtCupos.Text));
                    break;
                }
            }

            Response.Redirect("GestionarVuelos.aspx");
        }

        protected void CargarVuelos_dispnibles()
        {
            Cliente usuario = (Cliente)Session["Usuario"];
            List<Vuelo> _vuelos_a_cargar = new List<Vuelo>();
            List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
            List<Reservar> reservas = _controlador_reserva.ObtenerReservasPorCliente(usuario.ID);
            foreach (Vuelo vuelo in _vuelos)
            {

                int existe = 0;
                foreach (var item in ddlDestino.Items)
                {
                    if (item.ToString().Equals(vuelo.Destino))
                    {
                        existe = 1;
                        break;
                    }

                }
                foreach (var item in ddlOrigen.Items)
                {
                    if (item.ToString().Equals(vuelo.Origen))
                    {
                        existe = 1;
                        break;
                    }

                }

                if (existe != 1)
                {
                    ddlDestino.Items.Add(vuelo.Destino);
                    ddlOrigen.Items.Add(vuelo.Origen);
                }
            }

            foreach (Reservar reserva in reservas)
            {
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (reserva.VueloID == vuelo.ID)
                        _vuelos_a_cargar.Add(vuelo);
                }

            }
            gvVuelos.DataSource = _vuelos_a_cargar;
            gvVuelos.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Lógica para modificar un vuelo existente
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUsuario.aspx");
        }

        protected void gvVuelos_PageIndexChanged(object sender, EventArgs e)
        {
            List<Vuelo> _vuelos = _controlador_vuelos.ObtenerVuelos();
            ddlFecha.Items.Clear();
            if (ddlDestino.SelectedItem != null & ddlOrigen != null)
            {
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (vuelo.Origen.Equals(ddlOrigen.SelectedItem.ToString()) && vuelo.Destino.Equals(ddlDestino.SelectedItem.ToString()))
                    {

                        ddlFecha.Items.Add(vuelo.Fecha.ToString());

                    }
                }

            }
        }
    }
}