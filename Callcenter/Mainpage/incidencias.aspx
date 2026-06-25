<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="incidencias.aspx.cs" Inherits="Mainpage.incidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="DGVIncidencias" runat="server"
        CssClass="table table-striped"
        DataKeyNames="ID"/>
</asp:Content>
