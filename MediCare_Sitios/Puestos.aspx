<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Puestos.aspx.cs" Inherits="MediCare_Sitios.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div style="max-width: 800px; margin: 0 auto;">

            <h2 style="text-align: center;">Puestos</h2>
            <div style="text-align: center; margin-top: 50px; margin-bottom: 10px;">
                <a id="btnAgregarPuesto" runat="server" class="btn btn-primary" href="RegistroPuesto.aspx">
                    <i class="fas fa-plus" style="margin-right: 5px"></i>Crear Puesto</a>

                <%--   <asp:LinkButton ID="btnModificar" runat="server" CssClass="btn btn-warning">
    <i class="fas fa-pencil-alt"></i> Modificar
                </asp:LinkButton>--%>
            </div>
            <div style="overflow-x: auto;">
                <%-- <asp:GridView ID="gvPuesto" runat="server" AutoGenerateColumns="False" Width="100%" class="table table-striped table-hover" OnRowCommand="gv_puesto_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CodigoPuesto" HeaderText="Codigo Puesto" />
                        <asp:BoundField DataField="NombrePuesto" HeaderText="Nombre Puesto" />
                        <asp:ButtonField CommandName="Select" HeaderText="Editar" ShowHeader="True" Text="Editar">
                            <ControlStyle Font-Underline="True" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="Select1" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar">
                            <ControlStyle Font-Underline="True" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>--%>
                <asp:GridView ID="gvPuesto" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowEditing="gvPuesto_RowEditing" OnRowCancelingEdit="gvPuesto_RowCancelingEdit" OnRowUpdating="gvPuesto_RowUpdating"
                    OnRowDeleting="gvPuesto_RowDeleting" OnSelectedIndexChanged="gvPuesto_SelectedIndexChanged" DataKeyNames="CodigoPuesto">
                    <Columns>
                        <asp:BoundField DataField="CodigoPuesto" HeaderText="Código del Puesto" ReadOnly="true" />
                        <asp:BoundField DataField="NombrePuesto" HeaderText="Nombre del Puesto" />

                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" />
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                        <asp:TemplateField HeaderText="Requisitos">
                            <ItemTemplate>
                                <asp:Button ID="btnRequisitos" runat="server" Text="Requisitos" OnClick="btnRequisitos_Click" class="btn btn-success" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <br />

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
