<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerRequisitos.aspx.cs" Inherits="MediCare_Sitios.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <h4 style="font-weight: bold; color: #ff7f00; margin-top: 40px; margin-bottom: 50px; text-align: center;">Mantenimiento Oferentes</h4>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-6 text-center">
                <a id="btnAgregarOferente" runat="server" class="btn btn-primary mb-3" >
                    <asp:Button ID="Button1" runat="server" Text="Actualizar requisitos" class="fas fa-plus" style="margin-right: 5px;" OnClick="Button1_Click"/>                    
                </a>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-10">
                <asp:GridView ID="gvPuestos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="CodigoPuesto" HeaderText="CodigoPuesto" />
                        <asp:BoundField DataField="CodigoRequisito" HeaderText="CodigoRequisito" />
                        <asp:BoundField DataField="nombre" HeaderText="nombre" />
                        <asp:BoundField DataField="Cumple" HeaderText="cumple" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
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
                location.href = "Login.aspx";
            }
        }, 1200);
    </script>
</asp:Content>
