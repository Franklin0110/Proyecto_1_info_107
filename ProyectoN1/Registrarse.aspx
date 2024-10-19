<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="ProyectoN1.Registrarse" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Usuario</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .register-container {
            background-color: white;
            padding: 20px; 
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            width: 360px;
            text-align: left; 
        }

        .register-container h2 {
            margin-bottom: 20px;
            color: #333;
            font-size: 24px; 
            text-align: center; 
        }

        .register-container div {
            margin-bottom: 15px;
        }

        .register-container label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        .register-container input[type="text"],
        .register-container input[type="password"],
        .register-container input[type="date"] { /* Agregado input[type="date"] */
            width: 100%;
            padding: 10px; 
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .register-container button {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #007bff; 
            color: white;
            font-size: 16px;
            cursor: pointer;
            margin-top: 10px; 
        }

        .register-container button:hover {
            background-color: #0056b3; 
        }

        .error-message {
            color: red;
            text-align: center;
            margin-top: 10px;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Registro de Usuario</h2>
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            
            <div>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" Placeholder="Ingrese su nombre"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido(s)"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" Placeholder="Ingrese su apellido"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación"></asp:Label>
                <asp:TextBox ID="txtIdentificacion" runat="server" Placeholder="Ingrese su identificación"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <!-- Mantiene el mismo tamaño que los demás -->
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" Placeholder="Ingrese su usuario"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" Placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblConfirmarContrasena" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox ID="txtConfirmarContrasena" runat="server" TextMode="Password" Placeholder="Confirme su contraseña"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Regístrate" OnClick="btnRegistrarse_Click" />
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </div>
    </form>
</body>
</html>
