<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="DentaCartASP.Formularios.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .divider:after,
        .divider:before {
            content: "";
            flex: 1;
            height: 1px;
            background: #eee;
        }

        .h-custom {
            height: calc(100% - 73px);
        }

        @media (max-width: 450px) {
            .h-custom {
                height: 100%;
            }
        }
    </style>
    <link href="../Estilos/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background-color:#FBFCFC ;">
    <form id="form1" runat="server">
 
            <div class="container-fluid h-custom vh-100 ">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-md-9 col-lg-6 col-xl-5" style="">
                       <img src="../img/dentalogo.png" class="img-fluid object-fit-cover" style="" width="1080" height="720"/>
                    </div>
                    <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                        <form>
                            <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                                <p class="lead fw-normal mb-0 me-3">Iniciar Sesion</p>
                                <button type="button" class="btn btn-primary btn-floating mx-1">
                                    <i class="fab fa-facebook-f"></i>
                                </button>

                                <button type="button" class="btn btn-primary btn-floating mx-1">
                                    <i class="fab fa-twitter"></i>
                                </button>

                                <button type="button" class="btn btn-primary  btn-floating mx-1">
                                    <i class="fab fa-linkedin-in"></i>
                                </button>
                            </div>

                            <div class="divider d-flex align-items-center my-4">
                                <p class="text-center fw-bold mx-3 mb-0">O</p>
                            </div>
                            <div id="alertaLogin">
                                <asp:Literal ID="ltlAlertaLogin" runat="server"></asp:Literal>
                            </div>
                            <!-- Email input -->
                            <div class="form-outline mb-4">
                                <asp:TextBox ID="txtEmailUsu" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                <label class="form-label" for="form3Example3">Correo</label>
                            </div>

                            <!-- Password input -->
                            <div class="form-outline mb-3">
                                <asp:TextBox ID="txtPassUsu" runat="server" CssClass="form-control form-control-lg" OnTextChanged="txtPassUsu_TextChanged" TextMode="Password"></asp:TextBox>
                                <label class="form-label" for="form3Example4">Password</label>
                            </div>

                            <div class="d-flex justify-content-between align-items-center">
                                <!-- Checkbox -->
                                <div class="form-check mb-0">
                                    <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
                                    <label class="form-check-label" for="form2Example3">
                                        Recuerdame
                                    </label>
                                </div>
                                <a href="#!" class="text-body">Olvidaste el password?</a>
                            </div>

                            <div class="text-center text-lg-start mt-4 pt-2 btn-lg">
                                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-lg" Style="width:100%;" OnClick="btnIngresar_Click" />

                                <p class="small fw-bold mt-2 pt-1 mb-0">
                                    No tienes una cuenta? 
                                    <a href="#!" class="link-danger">Registrarse</a><br/>
                                    <a href="Default.aspx" class="btn btn-warning">Regresar</a>
                                </p>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
     
    </form>
    <script src="../js/bootstrap.bundle.min.js"></script>
   <script type="text/javascript">
       function redirectToAnotherForm() {
           window.location.href = 'Cliente.aspx';
       }

       window.addEventListener('popstate', function (event) {
           // Manejar el evento popstate si es necesario
           redirectToAnotherForm();
       });
   </script>
</body>
</html>
