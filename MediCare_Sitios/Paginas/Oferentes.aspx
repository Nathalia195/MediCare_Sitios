<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Oferentes.aspx.cs" Inherits="MediCare_Sitios.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container-fluid">

                    <!-- Page Heading -->

                     <div style="max-width: 800px; margin: 0 auto;">

            <h2 style="text-align: center;">Oferente</h2>
            <div style="text-align: center; margin-top: 50px; margin-bottom: 10px;">
                <asp:LinkButton ID="btnRistoferente" runat="server" CssClass="btn btn-primary" >
    <i class="fas fa-plus"></i> Registrar Oferente
                </asp:LinkButton>




                <asp:LinkButton ID="btnModificar" runat="server" CssClass="btn btn-warning">
    <i class="fas fa-pencil-alt"></i> Modificar
                </asp:LinkButton>
                
                       
                        <div>
                            <asp:GridView ID="gvOferentes" runat="server" AutoGenerateColumns="false" Width="90%" CssClass="gridview">
                                <Columns>
                                    <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" />
                                    <asp:BoundField DataField="CodigoTipoIdentificacion" HeaderText="Tipo Identificacion" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />


                                </Columns>
                            </asp:GridView>

                        </div>
                 


                </div>
</asp:Content>
