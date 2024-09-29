<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tienda___Q1_24.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrito de Compras</title>
     <%--Referencia a la hoja de estilo--%>
    <link href="Content/General.css" rel="stylesheet" />

    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="formGeneral" runat="server">
        <header>
            <div class="logo">
                <img src="Content/Media/logoUh2023.png"alt="ImagenLogo" />
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
            <h1>Carrito de Compras</h1>
            <div id="divCompras" runat="server"></div>
            <asp:Button ID="btnOrdenar" runat="server" Text="Aplicar Orden..."  CssClass="btnClass" OnClick="btnOrdenar_Click"/>
        
            <%--div para los botones de cargar y descargar archivos--%>
        <div class="divBotones" >
             <asp:Button ID="btnExportarTXT" runat="server" Text="Descargar TXT"  CssClass="btnClass" OnClick="btnExportarTXT_Click"/>
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImportarTXT" runat="server" Text="Importar TXT"  CssClass="btnClass" OnClick="btnImportarTXT_Click"/>
        

            <asp:Button ID="btnExportarXML" runat="server" Text="Descargar XML"  CssClass="btnClass" OnClick="btnExportarXML_Click"/>
                    <asp:Button ID="btnImportarXML" runat="server" Text="Importar XML"  CssClass="btnClass" OnClick="btnImportarXML_Click"/>
        
        </div>

        </div>
        

    </form>
    <footer><p>Sistema realizado Q1 - 2024</p></footer>


    <%--div oculto para un mensaje--%>
    
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
