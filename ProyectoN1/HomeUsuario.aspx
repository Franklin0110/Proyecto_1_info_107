<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUsuario.aspx.cs" Inherits="ProyectoN1.HomeUsuario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio - Usuario</title>
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

        .home-container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            width: 600px;
            text-align: left;
        }

        .home-container h2 {
            margin-bottom: 20px;
            color: #333;
            font-size: 24px;
            text-align: center;
        }

        .home-container .info-section {
            margin-bottom: 20px;
        }

        .home-container .info-section label {
            display: block;
            font-weight: bold;
            color: #555;
        }

        .home-container .info-section .info-value {
            margin-bottom: 10px;
            color: #333;
        }

        .home-container .reservas-section h3 {
            margin-bottom: 10px;
            color: #333;
        }

        .home-container table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .home-container table th, .home-container table td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: left;
        }

        .home-container table th {
            background-color: #007bff;
            color: white;
        }

        .home-container button {
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            font-size: 14px;
            cursor: pointer;
        }

        .home-container button:hover {
            background-color: #0056b3;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="home-container">
            <h2>Bienvenido, <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label></h2>
            
            <div class="info-section">
                <h3>Información del Cliente</h3>
                <label>Nombre Completo:</label>
                <div class="info-value">
                    <asp:Label ID="lblNombreCompleto" runat="server" Text="Nombre y Apellido"></asp:Label>
                </div>
                <label>Identificación:</label>
                <div class="info-value">
                    <asp:Label ID="lblIdentificacion" runat="server" Text="ID"></asp:Label>
                </div>
                <label>Fecha de Nacimiento:</label>
                <div class="info-value">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                </div>
                <label>Edad:</label>
                <div class="info-value">
                    <asp:Label ID="lblEdad" runat="server" Text="Edad"></asp:Label>
                </div>
            </div>

            <div class="reservas-section">
                <h3>Reservas Realizadas</h3>
                <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="Vuelo" HeaderText="Vuelo" />
                        <asp:BoundField DataField="AeropuertoOrigen" HeaderText="Aeropuerto Origen" />
                        <asp:BoundField DataField="AeropuertoDestino" HeaderText="Aeropuerto Destino" />
                        <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" />
                        <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha de Llegada" />
                        <asp:BoundField DataField="CantidadBoletos" HeaderText="Boletos" />
                    </Columns>
                </asp:GridView>

                <asp:Button ID="btnNuevaReserva" runat="server" Text="Hacer Nueva Reserva" OnClick="btnNuevaReserva_Click" />
                <asp:Button ID="btnExportarReservas" runat="server" Text="Exportar Reservas" OnClick="btnExportarReservas_Click" />
            </div>
        </div>
    </form>
</body>
</html>
