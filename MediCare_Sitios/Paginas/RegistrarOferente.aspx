<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarOferente.aspx.cs" Inherits="MediCare_Sitios.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="text-align: center">
            <b>
                <h4 style="color: #8C2641">Registrar Oferente</h4>
            </b>
        </div>
        <div class="container">
            <div class="form-group">
                <label for="txtIdentificacion">Identificacion:</label>
                <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtcodtipoid">cod Tipo Identificacion:</label>
                <asp:TextBox ID="txtcodtipoid" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

               <div class="form-group">
                <label for="txtNombreOfe">Nombre:</label>
                <asp:TextBox ID="txtNombreOfe" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group">
                <label for="txtApellidosOfe">Apellidos:</label>
                <asp:TextBox ID="txtApellidosOfe" runat="server" CssClass="form-control"></asp:TextBox>
            </div> 

              <div class="form-group">
                <label for="txtRecidencia">Lugar Recidencia:</label>
                <asp:TextBox ID="txtRecidencia" runat="server" CssClass="form-control"></asp:TextBox>
            </div> 

              <div class="form-group">
                <label for="txtFechaNaci">Fecha Nacimiento:</label>
                <asp:TextBox ID="txtFechaNaci" runat="server" CssClass="form-control" type="date" ></asp:TextBox>
            </div> 

             <div class="form-group">
                <label for="txtCurricu">Curriculum:</label>
                <asp:TextBox ID="txtCurricu" runat="server" CssClass="form-control"></asp:TextBox>
            </div> 

            <div class="form-group" style="justify-content: center; align-items: center; text-align: center">
                <asp:Button ID="btnRegistrarOferente" runat="server" Text="Registrar" CssClass="btn btn-primary"   />
            </div>
        </div>
</asp:Content>
