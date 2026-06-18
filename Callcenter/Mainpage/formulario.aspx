<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="formulario.aspx.cs" Inherits="Mainpage.formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="mb-3">
  <label for="Nombre" class="form-label">Nombre</label>
  <asp:textbox runat="server" type="text" class="form-control" id="Nombre" placeholder="Nombre"/>
</div>


<div class="mb-3">
  <label for="Apellido" class="form-label">Apellido</label>
  <asp:textbox runat="server" type="text" class="form-control" id="Apellido" placeholder="Apellido"/>
</div>


<div class="mb-3">
  <label for="GMAIL" class="form-label">GMAIL</label>
  <asp:textbox runat="server" AutoCompleteType="email" class="form-control" id="GMAIL" placeholder="name@example.com"/>
</div>

<div class="mb-3">
  <label for="Telefono" class="form-label">Telefono</label>
  <asp:textbox runat="server" type="number" class="form-control" id="Telefono" placeholder="+5400000000"/>
</div>

    
<div class="mb-3">
  <label for="DNI" class="form-label">DNI</label>
  <asp:textbox runat="server" type="number" class="form-control" id="DNI" placeholder="123456789"/>
</div>

    <div>
        <asp:Button Text="agregar" runat="server" onclick="Agregar_onClick"/>
    </div>

</asp:Content>
