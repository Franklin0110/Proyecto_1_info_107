<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Tienda___Q1_24.Login.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="/css/Style.css" type="text/css" />
      <div class="main">
        <h1>Login Tienda UHispano</h1>
        <h3>Instroduzca su nombre y contraseña</h3>
        <form action="">
              <label for="first">
                    Usuario:
              </label>
              <input type="text" 
                     id="usuario" 
                     name="usuario" 
                     placeholder="Introduzca su usuario" required>

              <label for="Contraseña">
                    Contraseña:
              </label>
              <input type="password"
                     id="Contraseña" 
                     name="Contraseña"
                     placeholder="Introduzca su contraseña" required>

              <div class="wrap">
                    <button type="submit"
                            onclick="validar_Usuario()">
                          Enviar
                    </button>
              </div>
        </form>
        <p>¿No estas registrado?
              <a href="#"
                 style="text-decoration: none;">
                    Registra Una Cuenta
              </a>
        </p>
  </div>
</asp:Content>
