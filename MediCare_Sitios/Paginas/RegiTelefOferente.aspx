<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegiTelefOferente.aspx.cs" Inherits="MediCare_Sitios.Formulario_web113" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container text-center">
    <h4 style="font-weight: bold; color: #ff7f00; margin-top: 40px; margin-bottom: 50px; text-align: center">Registrar Teléfono Oferente</h4>
</div>

<div class="container">
    <div class="form-group">
        <label for="txtIdentificacion">Identificación:</label>
        <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txttelefono">Teléfono:</label>
        <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group text-center">
        <asp:Button ID="btnRegistrarTeleOferente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrarTeleOferente_Click" />
    </div>
</div>

<script type="text/javascript">
    var n = 300;
    var id = window.setInterval(function () {
        document.onmousemove = function () {
            n = 300;
        };

        n--;

        if (n <= -1) {
            alert("La sesión ha expirado");
            location.href = "Login.aspx";
        }
    }, 1200);
</script>

</asp:Content>
