<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarRequisitos.aspx.cs" Inherits="MediCare_Sitios.WebForm2" %>

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
            <h5 style="color: #ff7f00; margin-top: 40px; margin-bottom: 50px">Asignar requisitos</h5>
        </b>
    </div>


    <asp:GridView ID="dvrequisitos" runat="server" AutoGenerateColumns="False" Width="580px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CodigoRequisito" HeaderText="CodigoRequisito" />
            <asp:BoundField DataField="CodigoPuesto" HeaderText="CodigoPuesto" />
            <asp:BoundField DataField="NombreRequisito" HeaderText="NombreRequisito" />
        </Columns>
    </asp:GridView>


    <div class="container">      
        <div class="form-group" style="justify-content: center; align-items: center; text-align: center; margin-top: 40px">
            <asp:Button ID="BtnAsignarPuesto" runat="server" Text="Asignar" CssClass="btn btn-primary" CommandName="MyCommand" OnClick="BtnAsignarPuesto_Click" Width="79px" />
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
                location.href = "login.aspx";
            }
        }, 1200);
    </script>
</asp:Content>
