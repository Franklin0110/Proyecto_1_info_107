<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarVuelosAdmin.aspx.cs" Inherits="ProyectoN1.GestionarVuelosAdmin" %>

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

        select {
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

        .error {
            color: #ff0000; /* Rojo intenso para llamar la atención */
            font-weight: bold; /* Negrita para resaltar */
            background-color: #ffe6e6; /* Fondo suave en tono rosado */
            border: 1px solid #ff0000; /* Borde rojo para enmarcar */
            padding: 10px; /* Espacio alrededor del texto */
            border-radius: 5px; /* Bordes redondeados */
            display: block; /* Asegura que se muestre como un bloque completo */
            margin-top: 10px; /* Espacio entre el error y los demás elementos */
            width: 96.5%; /* Se ajusta al ancho disponible */
            text-align: center; /* Centrar el texto */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestionar Vuelos</h2>
            <div class="form-group">
                <label for="ddlOrigen">ID del vuelo</label>
                <asp:TextBox ID="txtID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gvVuelos_PageIndexChanged" />
                </asp:TextBox>
                <asp:Button type="submit" runat="server" OnClick="btnCargar_vuelo_por_ID" Text="Cargar" />
                <label for="ddlOrigen">Aeropuerto de Origen</label>
                <asp:TextBox ID="txtOrigen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gvVuelos_PageIndexChanged" />
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlDestino">Aeropuerto de Destino</label>
                <asp:TextBox ID="txtDestino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gvVuelos_PageIndexChanged"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlFecha">Fecha del Vuelo</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCupos">Cupo de Pasajeros</label>
                <asp:TextBox runat="server" ID="txtCupos" Placeholder="Ingrese el número de pasajeros"></asp:TextBox>
            </div>
            <asp:Button type="submit" runat="server" OnClick="btnAgregar_Click" Text="Agregar Vuelo" />
            <asp:Button type="submit" runat="server" OnClick="btnModificar_Click" Text="Modificar Vuelo" />
            <asp:Button type="submit" runat="server" OnClick="btnEliminar_Click" Text="Eliminar Vuelo" />
            <asp:Button type="submit" runat="server" OnClick="btnVolver_Click" Text="Salir" />
            <asp:Label class="error" ID="lblError" runat="server" ForeColor="Red" Visible="false" Text="Algun error random"></asp:Label>
        </div>

        <div class="container">
            <h2>Lista de tus vuelos reservados</h2>
            <asp:GridView ID="gvVuelos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Origen" HeaderText="Origen" />
                    <asp:BoundField DataField="Destino" HeaderText="Destino" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
