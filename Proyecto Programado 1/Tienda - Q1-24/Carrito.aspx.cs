using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Tienda___Q1_24
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaListaCompras();
        }

        private void CargaListaCompras()
        {
            try
            {
                //cargar la lista de compras de la página de Home

                var listaCompras= (List<oCarritoCompras>)Session["listaCarrito"];

                if (listaCompras == null)
                {
                    mensajeTexto.InnerText = "El carrito de compras está vacío.";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    //crea la tabla
                    HtmlTable tablaArticulos= new HtmlTable();

                    //crea la fila del encabezado
                    HtmlTableRow filaEncabezado= new HtmlTableRow();

                    //crea la celda de Articulo con dos columnas
                    HtmlTableCell celda= new HtmlTableCell  ();

                    celda.InnerText = "Artículo";
                    celda.ColSpan = 2;  
                    //agrega las celdas a la fila
                    filaEncabezado.Cells.Add (celda);
                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Cantidad" });
                    filaEncabezado.Cells.Add(new HtmlTableCell { InnerText = "Precio" });
                    //agrega la fila a la tabla
                    tablaArticulos.Rows.Add (filaEncabezado);

                    //agregar las filas de los articulos
                    //dinamico

                    foreach (var item in listaCompras)
                    {
                        HtmlTableRow fila = new HtmlTableRow();
                        fila.Cells.Add(new HtmlTableCell { InnerHtml = "<img src='" +item.articulo.urlImagen +"' alt='"+item.articulo.nombre +"' />" });
                        fila.Cells.Add(new HtmlTableCell { InnerText = item.articulo.nombre });
                        fila.Cells.Add(new HtmlTableCell { InnerText = item.cantidadSolicitada.ToString() });
                        fila.Cells.Add(new HtmlTableCell { InnerText = item.articulo.precio.ToString() });

                        tablaArticulos.Rows.Add(fila);
                    }

                    //agregar un CSS

                    tablaArticulos.Attributes["class"] = "gridview tablaArticulos";

                    //agregar al controldel HTML

                    divCompras.Controls.Add(tablaArticulos);

                }

            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
        }

        protected void btnExportarTXT_Click(object sender, EventArgs e)
        {
            try
            {
                //leer la lista del Carrito
                var listaCompras = (List<oCarritoCompras>)Session["listaCarrito"];

                if (listaCompras == null)
                {
                    mensajeTexto.InnerText = "El carrito de compras está vacío, no se puede Exportar.";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    string texto = string.Empty;
                    //recorrer la lista por cada uno de los articulos y se concatenan en una sola línea de String
                    foreach (var item in listaCompras) {
                        texto += item.articulo.id + ";" + item.articulo.nombre + ";" + item.articulo.cantidad
                            + ";" + item.articulo.urlImagen + ";" + item.articulo.precio + ";"
                            + item.articulo.estado + ";" + item.cantidadSolicitada;
                        texto += "\r\n";
                    }

                    string nombreArchivo3 = "CarritoCompras.txt";

                    //Código #1:

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=archivo.txt");
                    Response.ContentType = "application/text";
                    Response.Output.Write(texto);
                    Response.Flush();
                    Response.End();
                    Response.Close();

                    //-----------------------------------------------------------------------------------//

                    //Código #2:
                    string folder = "~/Uploads/";
                    string random = DateTime.Now.ToFileTime().ToString();
                    string nombreArchivo = "archivo.xml";

                    string rutaArchivo = Server.MapPath(folder + random + nombreArchivo);
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo);
                    Response.ContentType = "application/xml";
                    Response.WriteFile(rutaArchivo);
                    Response.End();
                    Response.Close();

                }
            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }

        }

        protected void btnImportarTXT_Click(object sender, EventArgs e)
        {
            try
            {
                //preguntar si existe el archivo, o si el archivo fue seleccionado

                if (FileUpload1.HasFile)
                {
                    //configurar el comportamiento del fileupload
                    string nombreArchivo= Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string extension= Path.GetExtension(FileUpload1.PostedFile.FileName);

                    if(extension!= ".txt")
                    {
                        mensajeTexto.InnerText = "El formato del archivo debe ser .TXT";
                        divMensaje.Style["display"] = "block";
                    }
                    else
                    {
                        //configurar una ruta para guardar el archivo cuando se sube al servidor
                        string folder = "~/Uploads/";
                        string random = DateTime.Now.ToFileTime().ToString();
                        string rutaArchivo = Server.MapPath(folder + random+  nombreArchivo);

                        //cargar el archivo al server
                        FileUpload1.SaveAs(rutaArchivo);

                        //leer el archivo

                        string[] lineas= File.ReadAllLines(rutaArchivo);

                        //recorrer el archivo para cargar la lista en memoria

                        if (lineas.Length > 0)
                        {
                            var lista = new List<oCarritoCompras>();

                            foreach (var item in lineas)
                            {
                                string[] linea = item.Split(';');

                                var objArticulo = new oArticulo();

                                objArticulo.id = Int32.Parse(linea[0]);
                                objArticulo.nombre = linea[1];
                                objArticulo.cantidad = Int32.Parse(linea[2]);
                                objArticulo.urlImagen = linea[3];
                                objArticulo.precio = decimal.Parse(linea[4]);
                                objArticulo.estado = bool.Parse(linea[5]);

                                var oCarritoCompras = new oCarritoCompras();

                                oCarritoCompras.articulo = objArticulo;
                                oCarritoCompras.cantidadSolicitada = Int32.Parse(linea[6]);

                                lista.Add(oCarritoCompras);
                            }

                            Session["listaCarrito"]=lista;

                            //cargamos en pantalla la lista
                            CargaListaCompras();

                            //eliminar el archivo....
                            File.Delete(rutaArchivo);
                        }
                        else
                        {
                            mensajeTexto.InnerText = "No hay datos que cargar.";
                            divMensaje.Style["display"] = "block";
                        }
                    }
                }
                else
                {
                    mensajeTexto.InnerText = "Debe seleccionar un archivo.";
                    divMensaje.Style["display"] = "block";
                }
            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
        }

        protected void btnExportarXML_Click(object sender, EventArgs e)
        {
            try
            {
                //leer la lista del Carrito
                var listaCompras = (List<oCarritoCompras>)Session["listaCarrito"];

                if (listaCompras == null)
                {
                    mensajeTexto.InnerText = "El carrito de compras está vacío, no se puede Exportar.";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    //configurar una ruta para guardar el archivo cuando se sube al servidor
                    string folder = "~/Uploads/";
                    string random = DateTime.Now.ToFileTime().ToString();
                    string nombreArchivo = "listaCarrito.xml";

                    string rutaArchivo = Server.MapPath(folder + random + nombreArchivo);

                    XmlSerializer serializer= new XmlSerializer(typeof(List<oCarritoCompras>));

                    using(var writer= new StreamWriter(rutaArchivo)) { 
                        serializer.Serialize(writer, listaCompras);
                    }

                    //respuesta al cliente
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo);
                    Response.ContentType = "application/xml";
                    Response.WriteFile(rutaArchivo);
                    Response.End(); 
                    Response.Close();


                    //eliminar el archivo del server
                    File.Delete(rutaArchivo);
                }

            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }

        }

        protected void btnImportarXML_Click(object sender, EventArgs e)
        {
            try
            {
                //preguntar si existe el archivo, o si el archivo fue seleccionado

                if (FileUpload1.HasFile)
                {
                    //configurar el comportamiento del fileupload
                    string nombreArchivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    if (extension != ".xml")
                    {
                        mensajeTexto.InnerText = "El formato del archivo debe ser .XML";
                        divMensaje.Style["display"] = "block";
                    }
                    else
                    {
                        //configurar una ruta para guardar el archivo cuando se sube al servidor
                        string folder = "~/Uploads/";
                        string random = DateTime.Now.ToFileTime().ToString();
                        string rutaArchivo = Server.MapPath(folder + random + nombreArchivo);

                        //cargar el archivo al server
                        FileUpload1.SaveAs(rutaArchivo);

                        //leer el archivo

                        
                        XmlSerializer serializer= new XmlSerializer(typeof(List<oCarritoCompras>));

                        using (var reader = new StreamReader(rutaArchivo))
                        {
                            //deserealizar el archivo XML y pasarlo a una lista
                            List<oCarritoCompras> listaCarrito= (List<oCarritoCompras>)serializer.Deserialize(reader);

                            Session["listaCarrito"] = listaCarrito;

                            //cargamos en pantalla la lista
                            CargaListaCompras();
                        }


                            //eliminar el archivo....
                            File.Delete(rutaArchivo);
                       
                    }
                }
                else
                {
                    mensajeTexto.InnerText = "Debe seleccionar un archivo.";
                    divMensaje.Style["display"] = "block";
                }
            }
            catch (Exception ex)
            {
                //si hay error
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
        }

        protected void btnOrdenar_Click(object sender, EventArgs e)
        {
            var listaCompras = (List<oCarritoCompras>)Session["listaCarrito"];

            if (listaCompras == null)
            {
                mensajeTexto.InnerText = "El carrito de compras está vacío.";
                divMensaje.Style["display"] = "block";
            }
            else
            {
                //proceso de compras, va a la BD y genera la compra, si la compra es exitosa....
                Response.Redirect("/Factura.aspx");
            }
            
        }


        protected void Importar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xml")
                    {
                        string rutaArchivo = Server.MapPath("~/Uploads/" 
                                                            + DateTime.Now.ToFileTime().ToString() 
                                                            + Path.GetFileName(FileUpload1.PostedFile.FileName));
                        FileUpload1.SaveAs(rutaArchivo);
                        XmlSerializer serializer = new XmlSerializer(typeof(List<objeto>));
                        using (var reader = new StreamReader(rutaArchivo))
                        {
                            List<objeto> lista = (List<objeto>)serializer.Deserialize(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class objeto
        {
            public int id;
            public string name;
            public string description;
        }


    }
}