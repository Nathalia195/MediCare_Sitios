<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="MediCare_Sitios.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-sm-12">
            <h4 style="font-weight: bold; color: #ff7f00; margin-top: 40px; margin-bottom: 50px; text-align: center">Crear Nuevo Usuario</h4>
        </div>

        <div class="form-group">
            <label for="txtNombreUsuario">Nombre de Usuario:</label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control form-control-user" Placeholder="Nombre de usuario" AutoComplete="off"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtNombreCompleto">Nombre Completo:</label>
            <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control form-control-user" Placeholder="Nombre completo" AutoComplete="off"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtCorreoElectronico">Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control form-control-user" Placeholder="Correo electrónico" AutoComplete="off" TextMode="Email"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtlContrasena">Contraseña:</label>
            <asp:TextBox ID="txtlContrasena" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Contraseña" AutoComplete="off"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="FileUpload1">Imagen:</label>
            <asp:Image ID="imgURL" runat="server" CssClass="img-profile rounded-circle" Width="100px" Height="100px" />
            <asp:FileUpload ID="FileUpload1" runat="server" Text="Imagen" />
        </div>

        <div class="form-group">
            <label for="txtCodigoRol">Código de Rol:</label>
            <asp:DropDownList ID="txtCodigoRol" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtCodigoEstado">Código de Estado:</label>
            <asp:DropDownList ID="txtCodigoEstado" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="container text-center">
        <asp:Button ID="txtCancelar" runat="server" Text="Cancelar" OnClick="txtCancelar_Click" CssClass="btn btn-secondary m-2" />
        <asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar usuario" OnClick="btnGuardarUsuario_Click" CssClass="btn btn-primary m-2" />
    </div>

    <script type="text/javascript">
        var n = 300;
        var i = document.getElementById("number");
        var id = window.setInterval(function () {
            document.onmousemove = function () {
                n = 300;
            };

            n--;

            if (n <= -1) {
                alert("La sesión ha expirado");
                location.href = "login.aspx";
            }
        }, 1200);
    </script>
</asp:Content>
