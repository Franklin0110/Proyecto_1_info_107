<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarVuelos.aspx.cs" Inherits="ProyectoN1.GestionarVuelos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestionar Vuelos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }

        .container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            max-width: 800px;
            margin: auto;
        }

        h2 {
            color: #333;
            text-align: center;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        input[type="text"],
        input[type="date"],
        input[type="time"],
        input[type="number"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        button {
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
            margin-right: 10px;
        }

            button:hover {
                background-color: #0056b3;
            }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

            .table th,
            .table td {
                border: 1px solid #ccc;
                padding: 8px;
                text-align: left;
            }

            .table th {
                background-color: #007bff;
                color: white;
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
        <div class="container">
            <h2>Gestionar Vuelos</h2>
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>

            <div class="form-group">
                <label for="txtOrigen">Aeropuerto de Origen</label>
                <asp:TextBox ID="txtOrigen" runat="server" Placeholder="Ingrese el aeropuerto de origen"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDestino">Aeropuerto de Destino</label>
                <asp:TextBox ID="txtDestino" runat="server" Placeholder="Ingrese el aeropuerto de destino"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFecha">Fecha del Vuelo</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
                <!-- Se utilizará un calendario en el selector de fecha -->
            </div>
            <div class="form-group">
                <label for="txtHora">Hora del Vuelo</label>
                <asp:TextBox ID="txtHora" runat="server" TextMode="Time"></asp:TextBox>
                <!-- Al seleccionar este campo, se abrirá una lista desplegable de horas -->
            </div>
            <div class="form-group">
                <label for="txtCupo">Cupo de Pasajeros</label>
                <asp:TextBox ID="txtCupo" runat="server" Placeholder="Ingrese el número de pasajeros"></asp:TextBox>
            </div>
            <asp:Button type="submit" runat="server" OnClick="btnAgregar_Click" Text="Agregar Vuelo" />
            <asp:Button type="submit" runat="server" OnClick="btnModificar_Click" Text="Modificar Vuelo" />
            <asp:Button type="submit" runat="server" OnClick="btnEliminar_Click" Text="Eliminar Vuelo" />
        </div>

        <div class="container">
            <h2>Lista de Vuelos</h2>
            <asp:GridView ID="gvVuelos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Origen" HeaderText="Origen" />
                    <asp:BoundField DataField="Destino" HeaderText="Destino" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
