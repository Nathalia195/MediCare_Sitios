<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Oferentes.aspx.cs" Inherits="MediCare_Sitios.Formulario_web11" %>

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
                <a id="btnAgregarOferente" runat="server" class="btn btn-primary mb-3" href="RegisOferente.aspx">
                    <i class="fas fa-plus" style="margin-right: 5px;"></i>Crear Oferente
                </a>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-10">
                <asp:GridView ID="gvOferentes" runat="server" AutoGenerateColumns="false" SelectCommandType="StoredProcedure" SelectProcedure="sp_getoferente" CssClass="table table-striped" OnRowCommand="gvOferentes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" />
                        <asp:BoundField DataField="CodigoTipoIdentificacion" HeaderText="TipoIdentificacion" />
                        <asp:TemplateField HeaderText="Nombre completo">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreCompleto" runat="server" Text='<%# Eval("NombreCompleto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Select" HeaderText="Editar" ShowHeader="True" Text="Editar">
                            <ControlStyle Font-Underline="True" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="Select1" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar">
                            <ControlStyle Font-Underline="True" />
                        </asp:ButtonField>
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
