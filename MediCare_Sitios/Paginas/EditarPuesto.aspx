<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarPuesto.aspx.cs" Inherits="MediCare_Sitios.Formulario_web18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="../css/owl.carousel.min.css" />
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />

    <style type="text/css" media="screen">
        html, body {
            overflow: hidden;
        }
    </style>



    <div class="container" style="text-align: center">
        <b>
            <h5 style="color: #ff7f00; margin-top: 40px; margin-bottom: 50px">Agregar un nuevo puesto</h5>
        </b>
    </div>
    <div class="container">
        <div class="form-group">
            <label for="txtCodigoPuesto">Código del Puesto:</label>
            <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombreInteres">Nombre del Puesto:</label>
            <asp:TextBox ID="txtNombrePuesto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group" style="justify-content: center; align-items: center; text-align: center; margin-top: 40px">
            <asp:Button ID="btnEditarPuesto" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="editarPuesto_Click" />
        </div>
    </div>
    <script type="text/javascript">
        n = 300
        var i = document.getElementById("number");
        var id = window.setInterval(function () {
            document.onmousemove = function () {
                n = 300
            };

            n--;

            if (n <= -1) {
                alert("La sesión expiro");
                location.href = "Login.aspx";
            }
        }, 1200);
    </script>
</asp:Content>
