<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="vistaIncidencia.aspx.cs" Inherits="Mainpage.vistaIncidencia" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    .incidencia-card {
        cursor: pointer;
        transition: transform .15s ease, box-shadow .15s ease;
    }

    .incidencia-card:hover {
        transform: translateY(-3px);
        box-shadow: 0 .5rem 1rem rgba(0,0,0,.15);
    }

    .chat-box {
        height: 500px;
        overflow-y: auto;
        background: #f8f9fa;
        border: 1px solid #dee2e6;
        border-radius: 10px;
        padding: 15px;
    }

    .mensaje-cliente {
        background: white;
        border-radius: 10px;
        padding: 12px;
        margin-bottom: 15px;
        width: 75%;
        border: 1px solid #dee2e6;
    }

    .mensaje-empleado {
        background: #0d6efd;
        color: white;
        border-radius: 10px;
        padding: 12px;
        margin-bottom: 15px;
        margin-left: auto;
        width: 75%;
    }

    .fecha {
        font-size: 12px;
        color: gray;
    }

    .mensaje-empleado .fecha {
        color: #d9d9d9;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid mt-4">

    <!-- LISTADO DE INCIDENCIAS POR USUARIO -->
    <div class="row mb-4">

        <div class="col-12">

            <%--<div class="card shadow-sm">--%>


                <div class="card-body">

                    <div class="row">

                        <% foreach (incidencia item in ListaIncidencias) { %>

                                <div class="col-12 col-md-6 col-lg-3 mb-4">

                                    <a href="vistaIncidencia.aspx?id=<%= item.id %>"
                                       class="text-decoration-none text-dark d-block h-100">

                                        <div class="card h-100 shadow-sm incidencia-card">

                                            <div class="card-header px-4 pt-4">

                                                <h5 class="card-title mb-0">
                                                    #<%= item.id %> - <%= item.titulo %>
                                                </h5>

                                                <div class="badge bg-success my-2">
                                                    <%= item.Estado %>
                                                </div>

                                                <div class="badge bg-success my-2">
                                                    <%= item.alta %>
                                                </div>

                                                <div class="badge bg-warning text-dark my-2">
                                                    <%= item.Prioridad %>
                                                </div>

                                                <div class="badge bg-info text-dark my-2">
                                                    <%= item.Categoria %>
                                                </div>

                                            </div>

                                            <div class="card-body px-4">
                                                <p class="card-text">
                                                    <%= item.descripcion %>
                                                </p>
                                            </div>

                                        </div>

                                    </a>

                                </div>

                            <% } %>

                    </div>

                </div>

            </div>

        </div>

    </div>


    <!-- DETALLE + CHAT -->
    <div class="row">

        <!-- DETALLE -->
        <div class="col-lg-7 mb-4">

            <div class="card shadow">

                <div class="card-header">
                    <h4 class="mb-0">Detalle de la incidencia</h4>
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <asp:Label ID="LBEstado" runat="server" CssClass="badge bg-warning fs-6" />

                        <asp:Label ID="LBFechaAlta" runat="server" CssClass="badge bg-warning fs-6" />
                    </div>


                    <div class="mb-3">
                        <label>Título</label>
                        <asp:TextBox ID="Titulo" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label>Descripción</label>
                        <asp:TextBox
                            ID="Descripcion"
                            runat="server"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            Rows="4" />
                    </div>

                    <div class="row">

                        <div class="col-md-6 mb-3">
                            <label>Cliente</label>
                            <asp:DropDownList ID="DDLCliente" runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Empleado</label>
                            <asp:DropDownList ID="DDLEmpleado" runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Prioridad</label>
                            <asp:DropDownList ID="DDLPrioridad" runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Categoría</label>
                            <asp:DropDownList ID="DDLCategoria" runat="server" CssClass="form-select" />
                        </div>

                    </div>

                    <div class="mb-3">

                        <label>Comentario de resolución</label>

                        <asp:TextBox
                            ID="TBComentarioResolucion"
                            runat="server"
                            CssClass="form-control"
                            Rows="4"
                            TextMode="MultiLine" />

                    </div>

                    <div class="mt-3">

                        <asp:Button
                            Text="Aceptar"
                            runat="server"
                            OnClick="Agregar_onClick"
                            ID="btnAceptar"
                            CssClass="btn btn-primary"
                            Visible="false" />

                        <asp:Button
                            Text="Cancelar"
                            runat="server"
                            OnClick="Cancelar_onClick"
                            ID="btnCancelar"
                            CssClass="btn btn-secondary"
                            Visible="false" />

                        <asp:Button
                            Text="Salir"
                            runat="server"
                            OnClick="Salir_onClick"
                            ID="btnSalir"
                            CssClass="btn btn-outline-secondary" />

                    </div>

                </div>

            </div>

            <!-- ACCIONES -->
            <div class="card shadow mt-3">

                <div class="card-header">
                    <h5 class="mb-0">Acciones</h5>
                </div>

                <div class="card-body d-flex flex-wrap gap-2">

                    <asp:LinkButton
                        runat="server"
                        ID="BTModificarFila"
                        Text="Modificar"
                        CssClass="btn btn-warning btn-sm"
                        OnClick="Modificar_onclick" />

                    <asp:LinkButton
                        runat="server"
                        ID="BTReasignarFila"
                        Text="Reasignar"
                        CssClass="btn btn-info btn-sm"
                        OnClick="Reasignar_onclick" />

                    <asp:LinkButton
                        runat="server"
                        ID="BTResolverFila"
                        Text="Resolver"
                        CssClass="btn btn-success btn-sm"
                        OnClick="Resolver_onclick" />

                    <asp:LinkButton
                        runat="server"
                        ID="BTCerrarFila"
                        Text="Cerrar"
                        CssClass="btn btn-danger btn-sm"
                        OnClick="cerrar_onclick" />

                    <asp:LinkButton
                        runat="server"
                        ID="BTReabrirFila"
                        Text="Re-abrir"
                        CssClass="btn btn-info btn-sm"
                        OnClick="Reabrir_onclick" />

                </div>

            </div>

        </div>


        <!-- CHAT -->
        <div class="col-lg-5 mb-4">

            <div class="card shadow">

                <div class="card-header">
                    <h4 class="mb-0">Comentarios</h4>
                </div>

                <div class="card-body">

                    <div class="chat-box">

                        <% foreach (ComentarioIncidencia comentario in ListaComentarios) { %>

                            <% if (comentario.EsEmpleado) { %>

                                <div class="mensaje-empleado">

                                    <strong><%= comentario.Autor %></strong>

                                    <br />

                                    <%= comentario.Comentario %>

                                    <div class="fecha">
                                        <%= comentario.Fecha.ToString("dd/MM/yyyy HH:mm") %>
                                    </div>

                                </div>

                            <% } else { %>

                                <div class="mensaje-cliente">

                                    <strong><%= comentario.Autor %></strong>

                                    <br />

                                    <%= comentario.Comentario %>

                                    <div class="fecha">
                                        <%= comentario.Fecha.ToString("dd/MM/yyyy HH:mm") %>
                                    </div>

                                </div>

                            <% } %>

                        <% } %>

                    </div>

                    <hr />

                    <asp:TextBox
                        ID="TXTComentario"
                        runat="server"
                        CssClass="form-control"
                        Rows="3"
                        TextMode="MultiLine"
                        placeholder="Escriba un comentario..." />

                    <div class="mt-3">

                        <asp:Button
                            ID="BTNEnviarComentario"
                            runat="server"
                            Text="Enviar comentario"
                            CssClass="btn btn-primary w-100"
                            OnClick="EnviarComentario_onclick" />

                    </div>

                </div>

            </div>

        </div>

</div>

    <asp:Label ID="LBMensaje" runat="server" Text="Label" Visible="false">Error</asp:Label>

</asp:Content>