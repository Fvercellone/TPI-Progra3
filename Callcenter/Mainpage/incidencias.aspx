<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="incidencias.aspx.cs" Inherits="Mainpage.incidencias" %>
<%@ Import Namespace="Dominio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <%--<asp:GridView ID="DGVIncidencias" runat="server"
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
        <asp:TemplateField HeaderText="Re-abrir">
            <ItemTemplate>
                <asp:Button ID="BTReabrir" runat="server"
                    Text="Re-abrir"
                    CssClass="btn btn-secondary btn-sm"
                    CommandName="Re-abrir"
                    CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>--%>
<div class="row">

    <asp:Repeater ID="RptIncidencias" runat="server" OnItemCommand="RptIncidencias_ItemCommand">
    <ItemTemplate>

        <div class="col-12 col-md-6 col-lg-3 mb-4">

            <asp:LinkButton
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

        <div>
            <a href="vistaIncidencia.aspx">agregar</a>
        </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>

</asp:Content>
