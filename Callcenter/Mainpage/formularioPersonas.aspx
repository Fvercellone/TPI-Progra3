<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="formularioPersonas.aspx.cs" Inherits="Mainpage.formularioPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="mb-3">
  <label for="Nombre" class="form-label">Nombre</label>
  <asp:textbox  runat="server" type="text" class="form-control" id="Nombre" placeholder="Ejemplo: Nombre" OnTextChanged="Vacio_TextChanged" AutoPostBack="true"/>
</div>


<div class="mb-3">
  <label for="Apellido" class="form-label">Apellido</label>
  <asp:textbox  runat="server" type="text" class="form-control" id="Apellido" placeholder="Ejemplo: Apellido" OnTextChanged="Vacio_TextChanged" AutoPostBack="true"/>
</div>


<div class="mb-3">
  <label for="GMAIL" class="form-label">GMAIL</label>
  <asp:textbox  runat="server" AutoCompleteType="email" class="form-control" id="GMAIL" placeholder="Ejemplo: name@example.com" OnTextChanged="Vacio_TextChanged" AutoPostBack="true"/>
</div>

<div class="mb-3">
  <label for="Telefono" class="form-label">Telefono</label>
  <asp:textbox  runat="server" type="number" class="form-control" id="Telefono" placeholder="Ejemplo: +5400000000" OnTextChanged="Vacio_TextChanged" AutoPostBack="true"/>
</div>

    
<div class="mb-3">
  <label for="DNI" class="form-label">DNI</label>
  <asp:textbox  runat="server" type="number" class="form-control" id="DNI_" placeholder="Ejemplo: 123456789" OnTextChanged="Vacio_TextChanged" AutoPostBack="true"/>
</div>

    <div>
        <asp:Button Text="aceptar" runat="server" OnClick="Agregar_onClick" ID="btnAceptar" ControlToValidate="Nombre" ErrorMessage="Debe ingresar el nombre." Display="Dynamic" Enabled="False" />
        <asp:Button Text="cancelar" runat="server" OnClick="Cancelar_onClick" ID="Button2" />
    </div>

</asp:Content>
