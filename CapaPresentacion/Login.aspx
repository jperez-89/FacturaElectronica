<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--Jquery--%>
    <script src="//code.jquery.com/jquery-3.3.1.js" type="text/javascript"></script>
    <script src="Style/Jquery/2.1.1/jquery.min.js" type="text/javascript"></script>

    <%-- Bootstrap --%>
    <link href="Style/Bootstrap-4.3.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Style/Bootstrap-4.3.1/js/bootstrap.min.js"></script>

    <%-- FontAwesome --%>
    <link href="Style/FontsAwesome-5.8.2/css/all.css" rel="stylesheet" type="text/css" />
    <script src="Style/FontsAwesome-5.8.2/js/all.js"></script>

    <%-- CSS Custom Style --%>
    <link href="https://fonts.googleapis.com/css?family=Poppins:600&display=swap" rel="stylesheet"/>
    <link href="Style/Login.css" rel="stylesheet"/>   

    <%-- CSS SweetAlert --%>
    <script src="Style/Swal-2/js/sweetalert2.min.js"></script>
    <link href="Style/Swal-2/css/sweetalert2.min.css" rel="stylesheet" type="text/css" />

    <%-- CSS Animated --%>
    <link href="Style/Swal-2/animated/animate-3-7-0.min.css" rel="stylesheet" />

    <%--Semantic--%>
    <script src="Style/Semantic/semantic.min.js"></script>
    <link href="Style/Semantic/semantic.min.css" rel="stylesheet" />

    <title>Factura Electrónica - Login</title>

    <script type="text/javascript">
        function Swalert(msg, alerta, presentacion) {
            Swal.fire({
                title: msg,
                type: alerta,
                animation: false,
                customClass: {
                    popup: 'animated ' + presentacion
                }
            }).then((result) => {
                if (result.value) {
                    document.getElementById("txtUsuario").focus();
                }
            })
        }
    </script>
</head>

<body>
    <img class="wave" src="Style/img/fondo.png" />

    <div class="contenedor">
        <div class="img">
            <img src="Style/img/LoginAutentication.svg" />
        </div>

        <div class="login-contentenedor ">
            <form id="formLogin" runat="server">
                <div class="ui image small circular">
                    <img src="Style/img/AvatarVerde.svg" />
                </div>
                <h2 class="title">Bienvenido</h2>

                <div class="input-div one">
                    <div class="i">
                        <i class="fas fa-user-alt"></i>
                    </div>
                    <div class="div">
                        <h5>Identificación</h5>
                        <asp:TextBox CssClass="input" Type="text" ID="txtDNI" MaxLength="9" ValidateRequestMode="Enabled" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDNI" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsuario" runat="server" ErrorMessage=" *" Display="Dynam
                        </div>
                        ic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>

                <div class="input-div pass">
                    <div class="i">
                        <i class="fas fa-lock"></i>
                    </div>
                    <div class="div">
                        <h5>Email</h5>
                        <asp:TextBox CssClass="input" Type="text" ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group ">
                    <asp:Button ID="btnigresar" runat="server" Text="Ingresar" CssClass="BtnLogin" OnClick="Btnigresar_Click" />
                    <a href="RecuperaPassword.aspx" class="ui tag label right floated button m-3">Olvidé mi contraseña</a>
                </div>
            </form>
        </div>
    </div>


    <%--FOOTER--%>
    <%-- <div class="form-box">--%>
    <%--<div class="boxfooter">
            <h4>Follow us</h4>
            <div class="row">
                <div class="col-md-4">
                    <a href="http://www.facebook.com/jotarwc" target="_blank">
                        <i class="fab fa-3x fa-facebook"></i>
                    </a>
                </div>

                <div class="col-md-4">
                    <a href="Login.aspx">
                        <i class="fab fa-3x fa-twitter-square"></i>
                    </a>
                </div>

                <div class="col-md-4">
                    <a href="https://www.instagram.com/jotarwc/" target="_blank">
                        <i class="fab fa-3x fa-instagram"></i>
                    </a>
                </div>

                <div class="col-md-8 p-4" >
                    &copy; FACTPITAHAYA  2019
                </div>
            </div>
        </div>--%>
    <%-- </div>--%>

    <script src="Style/Login.js" type="text/javascript"></script>
</body>
</html>
