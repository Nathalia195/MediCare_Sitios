<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarPuesto.aspx.cs" Inherits="MediCare_Sitios.WebForm1" %>

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
            <h5 style="color: #ff7f00; margin-top: 40px; margin-bottom: 50px">Asignar un puesto</h5>
        </b>
    </div>

    <div class="container">
        <div class="form-group">
            <label for="txtCodigoPuesto">Identificación oferente:</label>
            <asp:TextBox ID="txtOferente" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtNombreInteres">Seleccionar puesto:</label>
            <asp:DropDownList ID="ddl_puesto" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group" style="justify-content: center; align-items: center; text-align: center; margin-top: 40px">
            <asp:Button ID="BtnAsignarPuesto" runat="server" Text="Asignar" CssClass="btn btn-primary" OnClick="BtnAsignarPuesto_Click" />
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
