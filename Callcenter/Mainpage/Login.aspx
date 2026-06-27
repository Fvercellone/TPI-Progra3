<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mainpage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Formulario-->

     <div class="container text-center">
      <div class="row">
        <div class="col">

        </div>
        <div class="col-8 border mt-5">

                 
              <div class="mb-3">
                <asp:label for="IngresoUsuario"  class="form-label" runat="server">Ingrese Su Usuario</asp:label>
                <asp:TextBox type="text" class="form-control" ID="NombreUsuario" runat="server"/>          
              </div>

              <div class="mb-3">
                <asp:label for="exampleInputPassword1"  class="form-label" runat="server">Contraseña</asp:label>
                <asp:TextBox type="password" class="form-control" ID="ContraseñaUsuario" runat="server"></asp:TextBox>
              </div>
                
              <div id="IngresoUsuarioHelp" class="form-text">Nunca compartas tus datos con nadie.</div>

              <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label flex accordion-button" for="exampleCheck1">Márcame</label>
                <asp:Button ID="btnVolver" Text="Enviar" CssClass="btn btn-primary" runat="server" OnClick="btnVolver_Click" />
              </div>

        <div>
            <asp:Label ID="LBMensaje" runat="server" CssClass="text-danger" />
        </div>


        </div>
        <div class="col">
        </div>
      </div>
    </div>



</asp:Content>
