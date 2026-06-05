<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mainpage.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex">

        <!-- Menú lateral -->
        <div class="position-fixed start-0 bg-body-tertiary border-end p-3 h-100">

            <h5>Menú</h5>

            <ul class="nav flex-column">
                <li class="nav-Page">
                    <asp:TextBox runat="server" />
                </li>

                <li class="nav-Page">
                    <a class="nav-link active" href="Menu_Inicial.aspx">Inicio</a>
                </li>

                <li class="nav-Page">
                    <a class="nav-link" href="#">Productos</a>
                </li>

                <li class="nav-Page">
                    <a class="nav-link" href="#">Clientes</a>
                </li>

                <li class="nav-Page">
                    <a class="nav-link" href="Login.aspx">Login</a>
                </li>

            </ul>

             <!-- Usuario abajo -->
                <div class="mt-auto border-top pt-5">
                    <asp:Label 
                        ID="lblTitulo" 
                        runat="server" 
                        Text="Usuario" 
                        CssClass="d-block mb-2 fw-semibold" />

                    <asp:Button 
                        ID="btnCerrarSesion"
                        runat="server"
                        Text="Cerrar sesión"
                        CssClass="btn btn-outline-danger btn-sm w-100" />
                        <!--OnClick="btnCerrarSesion_Click" -->
                </div>

        </div>

        <!-- Contenido principal -->
        <div class="container-fluid" style="margin-left: 250px; padding-top: 70px;">
            <h1>Menú Inicial</h1>
            <p>Contenido principal.</p>
        </div>

    </div>

</asp:Content>
