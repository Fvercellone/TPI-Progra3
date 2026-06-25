<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Mainpage.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cuerpo" >


   
        <asp:GridView ID="DGVCliente" runat="server"
    CssClass="table table-striped"
    AutoGenerateColumns="False"
    DataKeyNames="ID">

    <Columns>

        <asp:BoundField DataField="ID" HeaderText="ID" />

        <asp:BoundField DataField="Usuario" HeaderText="NombreCompleto" />

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
            <a href="formularioPersonas.aspx">agregar</a>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

    </div>
</asp:Content>
