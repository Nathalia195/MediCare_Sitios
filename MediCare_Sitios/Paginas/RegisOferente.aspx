<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisOferente.aspx.cs" Inherits="MediCare_Sitios.Formulario_web15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
    <div class="text-center mb-4">
        <h4 style="font-weight: bold; color: #ff7f00; margin-top: 40px; margin-bottom: 50px; text-align: center"">Registrar Oferente</h4>
    </div>
    <div class="text-center">
        <a id="btnAgregarReferente" runat="server" class="btn btn-primary mr-2" href="RegiReferenteOferente.aspx">
            <i class="fas fa-plus" style="margin-right:5px"></i> Datos Referente
        </a>
        <a id="btnAgregarTelefono" runat="server" class="btn btn-primary mr-2" href="RegiTelefOferente.aspx">
            <i class="fas fa-plus"  style="margin-right:5px"></i> Registrar Telefono
        </a>
        <a id="btnAgregarCorreo" runat="server" class="btn btn-primary" href="RegiCorreoOfe.aspx">
            <i class="fas fa-plus"  style="margin-right:5px"></i> Registrar Correo
        </a>
    </div>

    <div class="form-group mt-4">
        <label for="txtIdentificacion">Identificación:</label>
        <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtcodtipoid">Código Tipo Identificación:</label>
        <asp:TextBox ID="txtcodtipoid" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtNombreOfe">Nombre:</label>
        <asp:TextBox ID="txtNombreOfe" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtApellidosOfe">Apellidos:</label>
        <asp:TextBox ID="txtApellidosOfe" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtRecidencia">Lugar Residencia:</label>
        <asp:TextBox ID="txtRecidencia" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtFechaNaci">Fecha Nacimiento:</label>
        <asp:TextBox ID="txtFechaNaci" runat="server" CssClass="form-control" type="date"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtCurricu">Curriculum:</label>
        <asp:FileUpload ID="flUpcurriculum" runat="server" />
    </div>
    <div class="form-group text-center">
     
        <asp:Button ID="btnRegisOferente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegisOferente_Click"/>
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
