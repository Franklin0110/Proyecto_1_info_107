<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="ProyectoN1.Reserva" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Crear Reserva</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #87CEEB; /* Color de fondo celeste */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .reserva-container {
            background-color: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
            width: 400px;
            text-align: center;
        }

        .reserva-container h2 {
            margin-bottom: 20px;
            color: #333;
            font-size: 26px;
        }

        .reserva-container div {
            margin-bottom: 15px;
        }

        .reserva-container label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        .reserva-container select,
        .reserva-container input[type="date"] {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .reserva-container button {
            width: 100%;
            padding: 15px;
            border: none;
            border-radius: 5px;
            background-color: #28a745; /* Color del botón de reserva */
            color: white;
            font-size: 18px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .reserva-container button:hover {
            background-color: #218838; /* Color al pasar el ratón */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="reserva-container">
            <h2>Crear Reserva</h2>
            <div>
                <label for="origen">Aeropuerto de Origen:</label>
                <asp:DropDownList ID="listaOrigen" runat="server" OnSelectedIndexChanged="ddlOrigen_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione un aeropuerto" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="destino">Aeropuerto de Destino:</label>
                <asp:DropDownList ID="listaDestino" runat="server" OnSelectedIndexChanged="ddlDestino_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione un aeropuerto" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="fecha">Fecha del Viaje:</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnReservar" runat="server" Text="Reservar" />
            </div>
        </div>
    </form>
</body>
</html>
