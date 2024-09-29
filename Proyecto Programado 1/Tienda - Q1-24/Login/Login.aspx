<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tienda___Q1_24.login.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="./css/style.css">
    <title>Login</title>
    <script src="../Scripts/General.js"></script>

</head>

<body>
    <div class="main">
        <h1>Login Tienda UHispano</h1>
        <h3>Instroduzca su nombre y contraseña</h3>
        <form action="" runat="server">
            <label for="first">
                Usuario:
            </label>

            <asp:TextBox runat="server" type="text"
                ID="usuario"
                name="usuario"
                placeholder="Introduzca su usuario"></asp:TextBox>

            <label for="Contraseña">
                Contraseña:
            </label>
            <asp:TextBox runat="server" type="password"
                ID="Contraseña"
                name="Contraseña"
                placeholder="Introduzca su contraseña"> </asp:TextBox>

            <div class="wrap">
                <asp:Button runat="server" type="submit" Text="Enviar" OnClick="Validar_Usuario" />


            </div>


            <asp:Button runat="server" Text="volver" OnClick="btnVolver_Click" />

        </form>
        <p>
            ¿No estas registrado?
                  <a href="#"
                      style="text-decoration: none;">Registra Una Cuenta
                  </a>
        </p>
    </div>
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
