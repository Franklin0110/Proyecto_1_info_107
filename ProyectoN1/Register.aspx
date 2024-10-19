<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Proyecto1_progra4.Register" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registro de Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Cliente</h2>
            <label for="Nombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br />

            <label for="Apellidos">Apellidos:</label>
            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox><br />

            <label for="Usuario">Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />

            <label for="Contraseña">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox><br />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
        </div>
    </form>
</body>
</html>