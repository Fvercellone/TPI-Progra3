<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="formularioUsuarios.aspx.cs" Inherits="Mainpage.formularioUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="mb-3">
  <label for="Nombre" class="form-label">Usuario</label>
  <asp:textbox runat="server" type="text" class="form-control" id="Usuario_" placeholder="Nombre"/>
</div>


<div class="mb-3">
  <label for="Apellido" class="form-label">Contraseña</label>
  <asp:textbox runat="server" type="password" class="form-control" id="Contraseña_" placeholder="Contraseña"/>
</div>


<div class="mb-3">
  <label for="GMAIL" class="form-label">Rol</label>
  <asp:textbox runat="server" AutoCompleteType="email" class="form-control" id="Rol_" placeholder="Telefonista"/>
</div>
    
<div class="mb-3">
  <label for="DNI" class="form-label">DNI</label>
  <asp:textbox runat="server" type="number" class="form-control" id="DNIPersona" placeholder="123456789"/>
</div>

    <div>
        <asp:Button Text="aceptar" runat="server" onclick="Agregar_onClick"/>
    </div>

</asp:Content>
