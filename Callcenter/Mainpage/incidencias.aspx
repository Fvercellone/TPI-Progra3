<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="incidencias.aspx.cs" Inherits="Mainpage.incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <asp:GridView ID="DGVIncidencias" runat="server"
    CssClass="table table-striped"
    AutoGenerateColumns="False"
    DataKeyNames="ID"
    OnRowCommand="DGVIncidencias_RowCommand">

    <Columns>

        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="titulo" HeaderText="Título" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="Empleado" HeaderText="Empleado" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
        <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />

        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
                <asp:Button ID="BTModificarFila" runat="server"
                    Text="Modificar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Modificar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Reasignar">
            <ItemTemplate>
                <asp:Button ID="BTReasignarFila" runat="server"
                    Text="Reasignar"
                    CssClass="btn btn-primary btn-sm"
                    CommandName="Reasignar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Resolver">
            <ItemTemplate>
                <asp:Button ID="BTResolverFila" runat="server"
                    Text="Resolver"
                    CssClass="btn btn-success btn-sm"
                    CommandName="Resolver"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cerrar">
            <ItemTemplate>
                <asp:Button ID="BTCerrarFila" runat="server"
                    Text="Cerrar"
                    CssClass="btn btn-secondary btn-sm"
                    CommandName="Cerrar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

        <div>
            <a href="formularioIncidencias.aspx">agregar</a>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

</asp:Content>
