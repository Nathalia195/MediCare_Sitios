<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="MediCare_Sitios.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>

            <asp:Label ID="LblNombreUsuario" runat="server" Text="NombreUsuario"></asp:Label>  
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>

            <asp:Label ID="LblNombreCompleto" runat="server" Text="NombreCompleto"></asp:Label> 
            <asp:TextBox ID="txtNombreCompleto" runat="server"></asp:TextBox>

            <asp:Label ID="LblCorreoElectronico" runat="server" Text="CorreoElectronico" type="Email"></asp:Label>  
            <asp:TextBox ID="txtCorreoElectronico" runat="server"></asp:TextBox>

            <asp:Label ID="LblContrasena" runat="server" Text="Contrasena"></asp:Label>  
            <asp:TextBox ID="txtlContrasena" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Image ID="imgURL" runat="server" class="img-profile rounded-circle"  Width="100px" Height="100px"/>
            <asp:Label ID="LblImagen" runat="server" Text="Imagen"></asp:Label>  
            <asp:FileUpload ID="FileUpload1" runat="server" Text="Imagen" />

            <asp:Label ID="LblCodigoRol" runat="server" Text="CodigoRol"></asp:Label> 
              <asp:DropDownList ID="txtCodigoRol" runat="server" class="form-control"></asp:DropDownList>

            <asp:Label ID="LblCodigoEstado" runat="server" Text="CodigoEstado"></asp:Label> 
           <asp:DropDownList ID="txtCodigoEstado" runat="server" class="form-control"></asp:DropDownList>
           
        </div>
    <asp:Button ID="txtCancelar" runat="server" Text="Cancelar" OnClick="txtCancelar_Click" />
    <asp:Button id="btnGuardarUsuario" runat="server" Text="Guardar usuario" OnClick="btnGuardarUsuario_Click" />

</asp:Content>
