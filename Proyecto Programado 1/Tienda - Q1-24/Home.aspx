<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Tienda___Q1_24.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <%--Referencia a la hoja de estilo--%>
    <link href="Content/General.css" rel="stylesheet" />

    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="formGeneral" runat="server">
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
            <div>
                <asp:ImageButton ID="btnCarrito" runat="server" ImageUrl="~/Content/Media/carrito.png" CssClass="btnCarrito" OnClick="btnCarrito_Click" />
                <asp:ImageButton ID="btnPersona" runat="server" ImageUrl="~/Content/Media/Persona.jpg" CssClass="btnCarrito" OnClick="btnPersona_Click" AlternateText="Ingresar" />
            </div>
        </header>
        <div class="contenedor">
            <h1>Tienda</h1>
            <div id="divArticulos" runat="server"></div>
        </div>


    </form>
    <footer>
        <p>Sistema realizado Q1 - 2024</p>
    </footer>


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
