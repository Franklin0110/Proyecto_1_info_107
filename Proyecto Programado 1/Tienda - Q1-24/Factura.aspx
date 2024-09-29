<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Tienda___Q1_24.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Factura</title>
    <link href="Content/General.css" rel="stylesheet" />
    <link href="Content/Factura.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="logo">
                <img src="Content/Media/logoUh2023.png" alt="ImagenLogo" />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Media/logoUh2023.png" />
            </div>
            <nav>
                <ul>
                    <li><a href="Home.aspx" runat="server">Inicio</a></li>
                    <li><a href="About.aspx" runat="server">Acerca de...</a></li>
                </ul>
            </nav>
        </header>
        <div class="contenedor">
            <div class="claseFactura">

                <table id="tEncabezado">
                    <tr>
                        <td></td>
                        <td  class="alinearDerecha">
                                            <img src="Content/Media/Amazon_logo.svg" alt="ImagenLogo" />
                        </td>
                    </tr>
                    <tr>
                        <td><span id="lblNombreCliente" runat="server"></span></td>
                        <td class="alinearDerecha">
                            <h3>Empresa Celular UH</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Cédula: <span id="lblCedula" runat="server"></span></td>
                        <td class="alinearDerecha">
                            <h3>correo@correo.com</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Email: <span id="lblEmail" runat="server"></span></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Telefono: <span id="lblTelefono" runat="server"></span></td>
                        <td class="alinearDerecha">Factura #: <span id="lblNumFactura" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td>Dirección: <span id="lblDireccion" runat="server"></span></td>
                        <td class="alinearDerecha">Fecha: <span id="lblFecha" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="alinearDerecha">Total: <span id="lblTotal" runat="server"></span></td>
                    </tr>
                </table>
                <table id="tArticulos" runat="server">               
                </table>
                  <table id="tResumen" class="alinearDerecha">   
                       <tr>
                        <td>Subtotal</td>
                        <td><span id="lblSubtotal" runat="server"></span></td>
                    </tr>
                       <tr>
                        <td>IVA</td>
                        <td><span id="lblIVA" runat="server"></span></td>
                    </tr>
                       <tr>
                        <td>Total</td>
                        <td><span id="lblTotalResumen" runat="server"></span></td>
                    </tr>
                </table>
            </div>

        </div>


    </form>
    <footer>
        <p>Sistema realizado Q1 - 2024</p>
    </footer>


    <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
        <div class="message-box">
            <div id="mensajeContenido">
                <span id="mensajeTexto" runat="server"></span>
                <button id="cerrarMensaje" class="btnClass btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
            </div>
        </div>
    </div>
</body>
</html>
