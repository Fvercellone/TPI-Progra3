<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="vistaIncidencia.aspx.cs" Inherits="Mainpage.vistaIncidencia" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>

.chat-box{
    height:500px;
    overflow-y:auto;
    background:#f8f9fa;
    border:1px solid #dee2e6;
    border-radius:10px;
    padding:15px;
}

.mensaje-cliente{
    background:white;
    border-radius:10px;
    padding:12px;
    margin-bottom:15px;
    width:75%;
    border:1px solid #dee2e6;
}

.mensaje-empleado{
    background:#0d6efd;
    color:white;
    border-radius:10px;
    padding:12px;
    margin-bottom:15px;
    margin-left:auto;
    width:75%;
}

.fecha{
    font-size:12px;
    color:gray;
}

.mensaje-empleado .fecha{
    color:#d9d9d9;
}

</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid mt-4">

    <div class="row">

        <!-- DETALLE -->
        <div class="col-lg-7">

            <div class="card shadow">

                <div class="card-header">
                    <h4>Detalle de la incidencia</h4>
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <asp:Label ID="LBEstado" runat="server" CssClass="badge bg-warning fs-6"/>
                    </div>

                    <div class="mb-3">
                        <label>Título</label>
                        <asp:TextBox ID="Titulo" runat="server" CssClass="form-control"/>
                    </div>

                    <div class="mb-3">
                        <label>Descripción</label>
                        <asp:TextBox ID="Descripcion"
                            runat="server"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            Rows="4"/>
                    </div>

                    <div class="row">

                        <div class="col-md-6 mb-3">
                            <label>Cliente</label>
                            <asp:DropDownList ID="DDLCliente" runat="server" CssClass="form-select"/>
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Empleado</label>
                            <asp:DropDownList ID="DDLEmpleado" runat="server" CssClass="form-select"/>
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Prioridad</label>
                            <asp:DropDownList ID="DDLPrioridad" runat="server" CssClass="form-select"/>
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Categoría</label>
                            <asp:DropDownList ID="DDLCategoria" runat="server" CssClass="form-select"/>
                        </div>

                    </div>

                    <div class="mb-3">

                        <label>Comentario de resolución</label>

                        <asp:TextBox
                            ID="TBComentarioResolucion"
                            runat="server"
                            CssClass="form-control"
                            Rows="4"
                            TextMode="MultiLine"/>

                    </div>

                </div>

            </div>

        </div>


        <!-- CHAT -->
<div class="col-lg-5">

            <div class="card shadow">

                <div class="card-header">

                    <h4>Comentarios</h4>

                </div>

                <div class="card-body">

                    <div class="chat-box">



                        <% foreach (ComentarioIncidencia comentario in ListaComentarios) { %>

                            <% if(comentario.EsEmpleado){ %>

                                <div class="mensaje-empleado">

                                    <strong>
                                        <%= comentario.Autor %>
                                    </strong>

                                    <br />

                                    <%= comentario.Comentario %>

                                    <div class="fecha">

                                        <%= comentario.Fecha.ToString("dd/MM/yyyy HH:mm") %>

                                    </div>

                                </div>

                            <% } else { %>

                                <div class="mensaje-cliente">

                                    <strong>

                                        <%= comentario.Autor %>

                                    </strong>

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
                        placeholder="Escriba un comentario..."/>

                    <div class="mt-3">

                        <asp:Button
                            ID="BTNEnviarComentario"
                            runat="server"
                            Text="Enviar comentario"
                            CssClass="btn btn-primary w-100"/>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>

    <div>
        <asp:Button Text="Cancelar" runat="server" OnClick="Agregar_onClick" ID="btnAceptar" ControlToValidate="Nombre" ErrorMessage="Debe ingresar el nombre." Display="Dynamic" Visible="false"/>
        <asp:Button Text="Cancelar" runat="server" OnClick="Cancelar_onClick" ID="btnCancelar" ControlToValidate="Nombre" Display="Dynamic" Visible="false"/> 
    </div>

    <div>
        <asp:Button Text="Salir" runat="server" OnClick="Salir_onClick" ID="btnSalir" ControlToValidate="Nombre"  Display="Dynamic"/>
    </div>

    <div>   

       <asp:LinkButton HeaderText="Modificar" 
            runat="server" 
            ID="BTModificarFila" 
            Text="Modificar"
            CssClass="btn btn-warning btn-sm"
            CommandName="Modificar"
            CommandArgument='<%# Eval("ID") %>'
           OnClick="Modificar_onclick">
        </asp:LinkButton>

       <asp:LinkButton HeaderText="Reasignar" 
            runat="server" 
            ID="BTReasignarFila" 
            Text="Reasignar"
            CssClass="btn btn-info btn-sm"
            CommandName="Reasignar"
            CommandArgument='<%# Eval("ID") %>'
           OnClick="Reasignar_onclick">
        </asp:LinkButton>

       <asp:LinkButton HeaderText="Resolver" 
            runat="server" 
            ID="BTResolverFila" 
            Text="Resolver"
            CssClass="btn btn-success btn-sm"
            CommandName="Resolver"
            CommandArgument='<%# Eval("ID") %>'
           OnClick="Resolver_onclick">

        </asp:LinkButton>

       <asp:LinkButton HeaderText="Cerrar" 
            runat="server" 
            ID="BTCerrarFila" 
            Text="Cerrar"
            CssClass="btn btn-danger btn-sm"
            CommandName="Cerrar"
            CommandArgument='<%# Eval("ID") %>'
            OnClick="cerrar_onclick">
        </asp:LinkButton>

       <asp:LinkButton HeaderText="Re-abrir" 
            runat="server" 
            ID="BTReabrirFila" 
            Text="Re-abrir"
            CssClass="btn btn-info btn-sm"
            CommandName="Reabrir"
            CommandArgument='<%# Eval("ID") %>'
           OnClick="Reabrir_onclick">
        </asp:LinkButton>


    </div>


</asp:Content>

