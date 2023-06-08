<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantUsuario.aspx.cs" Inherits="MediCare_Sitios.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="container-xl">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row">
                            <div class="col-sm-12">
                                <h4 style="font-weight: bold;color: #ff7f00; margin-top: 40px; margin-bottom: 50px;text-align:center">Mantenimiento Usuarios</h4>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-sm-12" style="text-align:center">
                            <asp:Button href="AgregarUsuario.aspx" ID="btnAgregarUsuario" runat="server" Text="Agregar usuario" class="btn btn-primary" data-toggle="modal" OnClick="redi" />
                        </div>
                    </div>

                    <div>
                        <asp:GridView ID="Dgv_usuario" runat="server" AutoGenerateColumns="False" Width="100%" class="table table-striped table-hover" OnRowCommand="Dgv_usuario_RowCommand" OnSelectedIndexChanged="Dgv_usuario_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre usuario" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre completo" />
                                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                                <asp:BoundField DataField="CodigoEstado" HeaderText="Estado" />
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
        </div>
    </body>

    <script type="text/javascript">
        n = 300
        var i = document.getElementById("number");
        var id = window.setInterval(function () {
            document.onmousemove = function () {
                n = 300
            };

            n--;

            if (n <= -1) {
                alert("La sesión expiró");
                location.href = "Login.aspx";
            }
        }, 1000);
    </script>
</asp:Content>
