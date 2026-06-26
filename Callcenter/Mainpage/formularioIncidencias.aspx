<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="formularioIncidencias.aspx.cs" Inherits="Mainpage.formularioIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="LBEstado" class="mb-3" runat="server" Text="Estado">Estado</asp:Label>
    </div>

<div class="mb-3">
  <label for="Titulo" class="form-label">Título</label>
  <asp:textbox runat="server" type="text" class="form-control" id="Titulo" placeholder="Título"/>
</div>


<div class="mb-3">
  <label for="Descripcion" class="form-label">Descripción</label>
  <asp:textbox runat="server" type="text" class="form-control" id="Descripcion" placeholder="Descripción"/>
</div>

    <div class="mb-3">
         <label for="Cliente" class="form-label">Cliente</label>
        <asp:DropDownList ID="DDLCliente" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
         <label for="Empleado" class="form-label">Empleado</label>
        <asp:DropDownList ID="DDLEmpleado" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
         <label for="Prioridad" class="form-label">Prioridad</label>
        <asp:DropDownList ID="DDLPrioridad" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
         <label for="Categoria" class="form-label">Categoría</label>
        <asp:DropDownList ID="DDLCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
    
    <div>
    <asp:Label ID="LBComentarioResolucion" runat="server" Text="Comentario de resolución:" Visible="false" />
    <asp:TextBox ID="TBComentarioResolucion" runat="server"
        CssClass="form-control"
        TextMode="MultiLine"
        Rows="4"
        Visible="false" />
    </div>

    <div>
        <asp:Button Text="aceptar" runat="server" OnClick="Agregar_onClick" ID="btnAceptar" ControlToValidate="Nombre" ErrorMessage="Debe ingresar el nombre." Display="Dynamic" />
        <a  class="btn btn-primary" role="button" href="Incidencias.aspx" >cancelar</a>  
    </div>

</asp:Content>
