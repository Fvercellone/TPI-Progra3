<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Mainpage.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cuerpo" >


   
        <asp:GridView ID="DGVUsuarios" runat="server"
            CssClass="table table-striped"
            OnRowCommand="DGVUsuarios_RowCommand" 

            DataKeyNames="ID" >

    <Columns>
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:Button ID="BTEliminarFila" runat="server"
                    Text="Eliminar"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Activar">
            <ItemTemplate>
                <asp:Button ID="BTActivarFila" runat="server"
                    Text="Activar"
                    CssClass="btn btn-success btn-sm"
                    CommandName="Activar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
                <asp:Button ID="BTModificarFila" runat="server"
                    Text="Modificar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Modificar"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

      

        <div>
            <a href="formularioUsuarios.aspx">agregar</a>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

    </div>
</asp:Content>
