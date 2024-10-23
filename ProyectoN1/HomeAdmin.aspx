<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="ProyectoN1.HomeAdmin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home del Administrador</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #e9ecef;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .admin-home-container {
            background-color: #fff;
            padding: 30px; 
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
            width: 450px; 
            text-align: center; /* Centrar el texto */
        }

        .admin-home-container h2 {
            margin-bottom: 20px;
            color: #343a40; /* Color del título */
            font-size: 28px; /* Aumenté el tamaño de fuente */
        }

        .admin-home-container button {
            width: 100%;
            padding: 12px; 
            border: none;
            border-radius: 5px;
            background-color: #007bff; 
            color: white;
            font-size: 18px; /* Aumenté el tamaño de fuente */
            cursor: pointer;
            margin-top: 15px; 
            transition: background-color 0.3s ease;
        }

        .admin-home-container button:hover {
            background-color: #0056b3; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="admin-home-container">
            <h2>Bienvenido, Administrador</h2>
            <asp:Button ID="btnGestionarVuelos" runat="server" Text="Gestionar Vuelos" OnClick="btnGestionarVuelos_Click" />
            <asp:Button ID="btnVerReservas" runat="server" Text="Ver Reservas" OnClick="btnVerReservas_Click" />
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
        </div>
    </form>
</body>
</html>
