<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MediCare_Sitios.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-sm-flex flex-column align-items-center justify-content-center mb-4" style="text-align: center;">
        <img src="../img/logo(5).png" style="width: 280px; height: 280px" />

        <asp:Label ID="Lbl_Bienvenida" Style="font-size: 18px; margin-bottom: 40px" runat="server" Text="Label"></asp:Label>
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
