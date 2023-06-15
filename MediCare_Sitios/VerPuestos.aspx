<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerPuestos.aspx.cs" Inherits="MediCare_Sitios.WebForm3" %>
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
            <div class="col-md-10">
                <asp:GridView ID="gvPuestos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvPuestos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellidos" />                        
                        <asp:BoundField DataField="CodigoPuesto" HeaderText="CodigoPuesto" />
                        <asp:BoundField DataField="cumple" HeaderText="cumple" />
                        <asp:ButtonField CommandName="Select1"  ControlStyle-CssClass="btn btn-success" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:ButtonField>
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
                location.href = "login.aspx";
            }
        }, 1200);
    </script>
</asp:Content>
