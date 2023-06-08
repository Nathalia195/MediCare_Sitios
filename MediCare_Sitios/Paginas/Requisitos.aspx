<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Requisitos.aspx.cs" Inherits="MediCare_Sitios.Formulario_web19" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div style="max-width: 800px; margin: 0 auto;">

            <h2 style="text-align: center;">Requisitos del Puesto</h2>
            <div style="text-align: center; margin-top: 50px; margin-bottom: 10px;">
                <a id="btnAgregarPuesto" runat="server" class="btn btn-primary" href="RegistrarRequisito.aspx">
                    <i class="fas fa-plus"></i>Crear nuevo requisito</a>

                <%--   <asp:LinkButton ID="btnModificar" runat="server" CssClass="btn btn-warning">
    <i class="fas fa-pencil-alt"></i> Modificar
                </asp:LinkButton>--%>
            </div>
            <div style="overflow-x: auto;">

                <asp:GridView ID="gvRequisito" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowEditing="gvRequisito_RowEditing" OnRowCancelingEdit="gvRequisito_RowCancelingEdit" OnRowUpdating="gvRequisito_RowUpdating"
                    OnRowDeleting="gvRequisito_RowDeleting" DataKeyNames="CodigoRequisito">
                    <Columns>
                        <asp:BoundField DataField="CodigoRequisito" HeaderText="Código del Requisito" ReadOnly="true" />
                        <asp:BoundField DataField="NombreRequisito" HeaderText="Nombre del Requisito" />
                        <asp:BoundField DataField="CodigoPuesto" HeaderText="Código del Puesto" ReadOnly="true" />

                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" />
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                        <%--  <asp:TemplateField HeaderText="Requisitos">
                            <ItemTemplate>
                                <asp:Button ID="" runat="server" Text="Requisitos" OnClick="btnRequisitos_Click" class="btn btn-success" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
                    location.href = "Login.aspx";
                }
            }, 1200);
        </script>
</asp:Content>
