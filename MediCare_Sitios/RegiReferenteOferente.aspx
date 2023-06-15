<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegiReferenteOferente.aspx.cs" Inherits="MediCare_Sitios.Formulario_web112" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container text-center">
    <h4 style="font-weight: bold; color: #ff7f00; margin-top: 40px; margin-bottom: 50px; text-align: center">Registro de Referente</h4>
</div>

<div class="container">
    <div class="form-group">
        <label for="txtIdentificacion">Identificación Oferente:</label>
        <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtnombrereferente">Nombre Referente:</label>
        <asp:TextBox ID="txtnombrereferente" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txttelefonoferente">Teléfono Referente:</label>
        <asp:TextBox ID="txttelefonoferente" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group text-center">
        <asp:Button ID="btnRegisOferente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegisOferente_Click" />
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
            location.href = "login.aspx";
        }
    }, 1200);
</script>

</asp:Content>
