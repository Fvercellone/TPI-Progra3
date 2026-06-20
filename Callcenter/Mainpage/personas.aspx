<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="personas.aspx.cs" Inherits="Mainpage.personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cuerpo" >


   
        <asp:GridView ID="DGVPersonas" runat="server"
            CssClass="table table-striped"
            OnRowCommand="DGVPersonas_RowCommand" 

            DataKeyNames="DNI" >

    <Columns>
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:Button ID="BTEliminarFila" runat="server"
                    Text="Eliminar"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("DNI") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Activar">
            <ItemTemplate>
                <asp:Button ID="BTActivarFila" runat="server"
                    Text="Activar"
                    CssClass="btn btn-success btn-sm"
                    CommandName="Activar"
                    CommandArgument='<%# Eval("DNI") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
                <asp:Button ID="BTModificarFila" runat="server"
                    Text="Modificar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Modificar"
                    CommandArgument='<%# Eval("DNI") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

       <%-- <div id="Delete">
        <asp:Button ID="BTDelete" runat="server" Text="Borrar Registro" OnClick="BTDelete_Click" />
        <asp:TextBox ID="TBDNI" runat="server"></asp:TextBox>
        </div>

        <div id="Add">
        <asp:Button ID="BTADD" runat="server" Text="Activar Registro" OnClick="BTADD_Click" />
        <asp:TextBox ID="TBDNIADD" runat="server"></asp:TextBox>
        </div>--%>

<%--        <div id="Modify">
        <asp:Button ID="BTMODIFY" runat="server" Text="Modificar Registro" OnClick="BTMODIFY_Click" />
        <asp:TextBox ID="TBDNIMODIFY" runat="server"></asp:TextBox>
        </div>--%>

        <div>
            <a href="formulario.aspx">agregar</a>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

    </div>
</asp:Content>
