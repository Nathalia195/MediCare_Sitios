<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantUsuario.aspx.cs" Inherits="MediCare_Sitios.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xl">
        <div class="table-responsive">
            <div class="table-wrapper">
                <div class="table-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h2>Mantenimiento Usuarios</h2>
                        </div>
                        <div class="col-sm-6">
                            <%--<a href="#addEmployeeModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar nuevo usuario</span></a></a>--%>
                            <asp:Button href="AgregarUsuario.aspx" ID="btnAgregarUsuario" runat="server" Text="Agregar usuario" class="btn btn-success" data-toggle="modal" OnClick="redi" />

                        </div>
                    </div>

                </div>

                <div>
                    <asp:GridView ID="GvUsuario" runat="server" OnRowCommand="DgvUsuario_RowCommand" AutoGenerateColumns="false" Width="100%" class="table table-striped table-hover">
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
</asp:Content>
