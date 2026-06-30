<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="personas.aspx.cs" Inherits="Mainpage.personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    .persona-card {
        cursor: pointer;
        transition: transform .15s ease, box-shadow .15s ease;
    }

    .persona-card:hover {
        transform: translateY(-3px);
        box-shadow: 0 .5rem 1rem rgba(0,0,0,.15);
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid mt-4">

    <div class="card shadow-sm">

        <div class="card-header d-flex justify-content-between align-items-center">
            <h4 class="mb-0">Personas / Clientes</h4>

            <div>
                <asp:Button
                    ID="BTNAgregarPersona"
                    runat="server"
                    Text="Agregar persona"
                    CssClass="btn btn-primary"
                    OnClick="Agregar_onclick" />

                <asp:Button
                    ID="BTNActualizar"
                    runat="server"
                    Text="Actualizar"
                    CssClass="btn btn-secondary" />
            </div>
        </div>

        <div class="card-body">

            <asp:Label
                ID="LBMensaje"
                runat="server"
                CssClass="text-danger" />

            <div class="row mt-3">

                <asp:Repeater
                    ID="RptPersonas"
                    runat="server"
                    OnItemCommand="RptPersonas_ItemCommand">

                    <ItemTemplate>

                        <div class="col-12 col-md-6 col-lg-3 mb-4">

                            <div class="card h-100 shadow-sm persona-card">

                                <div class="card-body">

                                    <div class="d-flex align-items-center mb-3">

                                        <img
                                            src="https://bootdey.com/img/Content/avatar/avatar1.png"
                                            alt="Avatar"
                                            class="rounded-circle img-thumbnail"
                                            width="55"
                                            height="55" />

                                        <div class="ms-3">

                                            <h5 class="mb-1">
                                                <%# Eval("Nombre") %> <%# Eval("Apellido") %>
                                            </h5>

                                            <span class="badge bg-info text-dark">
                                                DNI: <%# Eval("DNI") %>
                                            </span>

                                        </div>

                                    </div>

                                    <p class="mb-1 text-muted">
                                        <strong>Email:</strong> <%# Eval("Mail") %>
                                    </p>

                                    <p class="mb-1 text-muted">
                                        <strong>Teléfono:</strong> <%# Eval("Telefono") %>
                                    </p>

                                    <p class="mb-3">
                                        <strong>Estado:</strong>
                                        <%# Convert.ToBoolean(Eval("Activo")) ? "Activo" : "Inactivo" %>
                                    </p>

                                    <div class="d-flex gap-2">

                                        <asp:Button
                                            ID="BTModificar"
                                            runat="server"
                                            Text="Modificar"
                                            CssClass="btn btn-warning btn-sm w-50"
                                            CommandName="Modificar"
                                            CommandArgument='<%# Eval("DNI") %>' />

                                        <asp:Button
                                            ID="BTDetalle"
                                            runat="server"
                                            Text="Ver"
                                            CssClass="btn btn-primary btn-sm w-50"
                                            CommandName="Ver"
                                            CommandArgument='<%# Eval("DNI") %>' />

                                    </div>

                                    <div class="d-flex gap-2 mt-2">

                                        <asp:Button
                                            ID="BTEliminar"
                                            runat="server"
                                            Text="Baja"
                                            CssClass="btn btn-danger btn-sm w-50"
                                            CommandName="Eliminar"
                                            CommandArgument='<%# Eval("DNI") %>' />

                                        <asp:Button
                                            ID="BTActivar"
                                            runat="server"
                                            Text="Activar"
                                            CssClass="btn btn-success btn-sm w-50"
                                            CommandName="Activar"
                                            CommandArgument='<%# Eval("DNI") %>' />

                                    </div>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>

            </div>

        </div>

    </div>

</div>

</asp:Content>