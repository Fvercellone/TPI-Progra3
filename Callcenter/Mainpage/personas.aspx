<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="personas.aspx.cs" Inherits="Mainpage.personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cuerpo" >


   
        <asp:GridView ID="DGVPersonas" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Mail" HeaderText="Email" SortExpression="Mail" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
                <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />

            </Columns>
        </asp:GridView>

        <div id="Delete">
        <asp:Button ID="BTDelete" runat="server" Text="Borrar Registro" OnClick="BTDelete_Click" />
        <asp:TextBox ID="TBDNI" runat="server"></asp:TextBox>
        </div>

        <div id="Add">
        <asp:Button ID="BTADD" runat="server" Text="Activar Registro" OnClick="BTADD_Click" />
        <asp:TextBox ID="TBDNIADD" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

    </div>
</asp:Content>
