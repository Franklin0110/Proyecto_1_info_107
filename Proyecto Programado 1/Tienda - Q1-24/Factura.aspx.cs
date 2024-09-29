using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Tienda___Q1_24
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarFactura();
        }

        private void CargarFactura()
        {
            try
            {
                //obtener los datos del cliente de la session
                oPersona objPersona = (oPersona)Session["objPersona"];

                //obtener los datos del carrito de compras

                var listaCompras = (List<oCarritoCompras>)Session["listaCarrito"];


                //asignar los valores
                if (listaCompras == null || objPersona == null)
                {
                    mensajeTexto.InnerText = "El carrito de compras está vacío o no hay un cliente definido.";
                    divMensaje.Style["display"] = "block";
                }
                else
                {

                    //datos del cliente
                    lblNombreCliente.InnerText = objPersona.nombre;
                    lblTelefono.InnerText = objPersona.telefono;
                    lblEmail.InnerText = objPersona.email;
                    lblCedula.InnerText = objPersona.identificacion;
                    lblDireccion.InnerText = objPersona.direccion;

                    //datos de la factura
                    //definición de variables de totales
                    decimal subtotal_General = 0;
                    decimal iva = 0;
                    decimal total= 0;

                    //fila del encabezado
                    HtmlTableRow filaEncabezado= new HtmlTableRow();

                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Artículo" });
                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Precio" });
                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Cantidad" });
                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Total" });
                    tArticulos.Rows.Add(filaEncabezado);
                    //recorrer los articulos de carrito  y se pintan en la tabla

                    foreach (var item in listaCompras)
                    {
                        HtmlTableRow fila = new HtmlTableRow();

                        fila.Cells.Add(new HtmlTableCell { InnerText = item.articulo.nombre });
                        fila.Cells.Add(new HtmlTableCell { InnerText = item.articulo.precio.ToString() });
                        fila.Cells.Add(new HtmlTableCell { InnerText = item.cantidadSolicitada.ToString() });

                        decimal subtotal_linea = item.articulo.precio * item.cantidadSolicitada;
                        fila.Cells.Add(new HtmlTableCell { InnerText = subtotal_linea.ToString("C") });

                        subtotal_General += subtotal_linea;


                        //cargamos la fila a la tabla 
                        tArticulos.Rows.Add(fila);
                    }

                    //calcular los totales
                    iva = subtotal_General * 0.13m;
                    total= subtotal_General+iva; 
                    //asingar los valores
                    lblSubtotal.InnerText= subtotal_General.ToString("C");
                    lblIVA.InnerText=iva.ToString("C");
                    lblTotalResumen.InnerText= total.ToString("C");
                    lblTotal.InnerText = total.ToString("C");
                    lblFecha.InnerText = DateTime.Now.ToString();

                    tArticulos.Attributes["Class"] = "gridview";

                    Random rnd= new Random();
                    lblNumFactura.InnerText = rnd.Next(1000, 9999).ToString();
                }
               

            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
        }
    }
}