<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="incidencias.aspx.cs" Inherits="Mainpage.incidencias" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="Cuerpo" >

       <div class="container-fluid mt-4">

            <div class="card shadow-sm">

                <div class="card-header">

                <div class="d-flex justify-content-between align-items-center">
                    <h4 class="mb-0">Incidencias</h4>
                    <% if ((Conexion.Validaciones.TienePermiso((Dominio.Usuarios)Session["usuario"], 2))) { %>
                    <asp:Button
                        ID="BTNAgregarIncidencia"
                        runat="server"
                        Text="Nueva incidencia"
                        CssClass="btn btn-primary"
                        OnClick="BTNAgregarIncidencia_Click" />
                    <%} %>
                </div>
        <div class="mb-3">
            <asp:Label Text="Filtrar Por Nombre de Incidencia" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />

            <asp:CheckBox Text="Filtro Avanzado" 
            CssClass="" ID="chkAvanzado" runat="server" 
            AutoPostBack="true"
            OnCheckedChanged="chkAvanzado_CheckedChanged"/>
        </div>

                <%if (chkAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                <asp:ListItem Text="ID" />
                                <asp:ListItem Text="Titulo" />
                                <asp:ListItem Text="Cliente" />
                                <asp:ListItem Text="Empleado" />
                                <asp:ListItem Text="Categoria" />
                                <asp:ListItem Text="Prioridad" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <%if (ddlCampo.SelectedItem.ToString() != "Categoria" && ddlCampo.SelectedItem.ToString() != "Prioridad")
                                { %>
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"/>
                            <%} %>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Filtro *" runat="server" />
                            <%if (ddlCampo.SelectedItem.ToString() != "Categoria" && ddlCampo.SelectedItem.ToString() != "Prioridad")
                                { %>

                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtroAvanzado_TextChanged" TextMode="Number" />
                            <%}else { %>
                                <asp:DropDownList runat="server" CssClass="form-control" id="ddlFiltro"/>
                            <%} %>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Estado" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" />
                                
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click"/>
                        </div>
                    </div>
                </div>
                <%} %>
                </div>
        
        <div class="card-body">

            <div class="row">

                <asp:Repeater ID="RptIncidencias" runat="server" OnItemCommand="RptIncidencias_ItemCommand">

                    <ItemTemplate>

                        <div class="col-12 col-md-6 col-lg-3 mb-4">

                            

                            <asp:LinkButton
                                ID="LBAbrirIncidencia"
                                runat="server"
                                CssClass="text-decoration-none text-dark d-block h-100"
                                CommandName="AbrirIncidencia"
                                CommandArgument='<%# Eval("id") %>'>

                                <div class="card h-100 shadow-sm incidencia-card">

                                    <div class="card-header px-4 pt-4">

                                        <h5 class="card-title mb-0">
                                            #<%# Eval("id") %> - <%# Eval("titulo") %>
                                        </h5>

                                        <div class="badge bg-success my-2">
                                            <%# Eval("Estado") %>
                                        </div>

                                        <div class="badge bg-warning text-dark my-2">
                                            <%# Eval("Prioridad") %>
                                        </div>

                                        <div class="badge bg-info text-dark my-2">
                                            <%# Eval("Categoria") %>
                                        </div>

                                    </div>

                                    <div class="card-body px-4 pt-2">

                                        <p>
                                            <%# Eval("descripcion") %>
                                        </p>

                                        <div class="mb-2">
                                            <img src="https://bootdey.com/img/Content/avatar/avatar3.png"
                                                 class="rounded-circle mr-1"
                                                 alt="Avatar"
                                                 width="30"
                                                 height="30" />

                                            <div class="badge bg-success my-2">
                                                <%# Eval("Cliente") %>
                                            </div>
                                        </div>

                                        <div>
                                            <img src="https://bootdey.com/img/Content/avatar/avatar2.png"
                                                 class="rounded-circle mr-1"
                                                 alt="Avatar"
                                                 width="30"
                                                 height="30" />

                                            <div class="badge bg-success my-2">
                                                <%# Eval("Empleado") %>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </asp:LinkButton>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>

            </div>

            </div>
        </div>

    </div>

    <div class="mt-3">
        <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
    </div>

</div>

</asp:Content>