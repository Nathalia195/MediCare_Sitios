<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MediCare_Sitios.Paginas.Login" %>

<!DOCTYPE html>
<html lang="es">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Inicio de Sesión</title>

    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../css/sb-admin-2.min.css" rel="stylesheet">
</head>

<body class="bg-gradient-primary">

    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">



            <div class="card o-hidden border-0 shadow-lg my-5">

                <!-- Nested Row within Card Body -->


                <div class="col-lg-12">
                    <div class="p-4">
                        <div class="text-center">
                            <img src="../img/logo(5).png" alt="Logo" style="width: 250px; height: 200px">
                            <h2 class="h4 text-gray-900 mb-4">Inicio de Sesión</h2>
                        </div>
                        <form class="user" runat="server">
                            <div class="form-group">

                                <asp:TextBox ID="Txt_usuario" runat="server" required="true" class="form-control form-control-user"
                                    aria-describedby="emailHelp"
                                    placeholder="Usuario" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="form-group">

                                <asp:TextBox ID="Txt_contrasena" runat="server" type="password" required="true" class="form-control form-control-user"
                                    placeholder="Contraseña" autocomplete="off"></asp:TextBox>

                            </div>
                            <%--  <div class="form-group">
                                <div class="custom-control custom-checkbox small">
                                    <input type="checkbox" class="custom-control-input" id="customCheck">
                                    <label class="custom-control-label" for="customCheck">
                                        Remember
                                                    Me</label>
                                </div>
                            </div>--%>
                            <asp:Button class="btn btn-primary btn-user btn-block" ID="Btn_Ingresar" runat="server" Text="Login" OnClick="Btn_Ingresar_Click" />

                            <hr>
                        </form>
                        <hr>
                    </div>
                </div>
            </div>


        </div>


    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../js/sb-admin-2.min.js"></script>

</body>


</html>

