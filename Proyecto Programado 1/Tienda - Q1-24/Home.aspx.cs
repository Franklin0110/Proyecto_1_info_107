using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Tienda___Q1_24
{
    public partial class Home : System.Web.UI.Page
    {

        List<oArticulo> listaArticulos= new List<oArticulo>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //cargar información del cliente

            oPersona objPersona= new oPersona{ id=1, nombre="Erick Brenes", direccion="Cartago", email="erick@correo.com",telefono="1234-2222", identificacion="1-2345-9999"};

            Session["objPersona"] = objPersona;



            listaArticulos.Add(new oArticulo { id = 1, nombre = "iPhone", cantidad = 0, urlImagen = "Content/Media/iphone.jpg", precio = 500000, estado = true });
            listaArticulos.Add(new oArticulo { id = 2, nombre = "Samsung s23", cantidad = 2, urlImagen = "Content/Media/samsung.png", precio = 450000, estado = true });
            listaArticulos.Add(new oArticulo { id = 3, nombre = "Huawei", cantidad = 3, urlImagen = "Content/Media/telefono.png", precio = 200000, estado = true });
            listaArticulos.Add(new oArticulo { id = 4, nombre = "Ipad", cantidad = 4, urlImagen = "Content/Media/ipad.jpg", precio = 7000000, estado = true });

            foreach (var item in listaArticulos)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");

                div.InnerHtml = "<p>" + item.nombre + "</p></br><img src='" + item.urlImagen + "' alt='" + item.nombre + "'/>";
                div.Attributes["class"] = "divProductos";

                Button btn= new Button();
                btn.Text = "Comprar";
                btn.ID = "btnArticulo_" + item.id;
                btn.Click += new EventHandler(btnComprar_click);

                div.Controls.Add(btn);
                divArticulos.Controls.Add(div);
            }

        }

        protected void btnComprar_click(object sender, EventArgs e) {
            try
            {
                //código que debe ser correcto en ejecución
                Button btn = (Button)sender;
                string btnID = btn.ClientID;

                if (!string.IsNullOrEmpty(btnID))
                {
                    int idArticulo = int.Parse(btnID.Split('_')[1]);

                    var objArticulo = new oArticulo();

                    objArticulo = listaArticulos.FirstOrDefault(p => p.id == idArticulo);

                    if (objArticulo != null){
                        if (objArticulo.cantidad > 0)
                        {

                            //instanciar el objeto de carrito de compras
                            oCarritoCompras objCarrito = new oCarritoCompras();

                            objCarrito.cantidadSolicitada = 1;
                            objCarrito.articulo = objArticulo;
                            //instanciar la nueva lista de carrito de compras

                            List<oCarritoCompras> listaCompras = (List<oCarritoCompras>)Session["listaCarrito"];

                            if (listaCompras == null)
                            {
                                listaCompras= new List<oCarritoCompras> ();
                            }

                            listaCompras.Add(objCarrito);

                            //Uso de la Session para compartir datos en el sitio
                            Session["listaCarrito"] = listaCompras;


                            //informamos del exito al cliente


                            mensajeTexto.InnerText = "Se guardó el artículo con éxito. Tiene " + listaCompras.Count() + " artículos seleccionados.";
                            divMensaje.Style["display"] = "block";
                        }
                        else
                        {
                            mensajeTexto.InnerText = "No hay articulos disponibles.";
                            divMensaje.Style["display"] = "block";
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontró el artículo.");
                    }
                }
                else
                {
                    mensajeTexto.InnerText = "No se encontró el artículo.";
                    divMensaje.Style["display"] = "block";
                }


            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: "+ ex.Message;
                divMensaje.Style["display"] = "block";
            }


        }

        protected void btnCarrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Carrito.aspx");
        }
        protected void btnPersona_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/login/login.aspx");
        }
        
    }
}