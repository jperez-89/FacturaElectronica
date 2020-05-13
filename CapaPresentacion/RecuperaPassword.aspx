<%@ Page Language="C#" Title="Recuperar contraseña" AutoEventWireup="true" CodeBehind="RecuperaPassword.aspx.cs" Inherits="CapaPresentacion.RecuperaPassword" %>

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
    <link href="Style/StyleN.css" rel="stylesheet" />

    <%-- CSS SweetAlert --%>
    <script src="Style/Swal-2/js/sweetalert2.min.js"></script>
    <link href="Style/Swal-2/css/sweetalert2.min.css" rel="stylesheet" type="text/css" />

    <%-- CSS Animated --%>
    <link href="Style/Swal-2/animated/animate-3-7-0.min.css" rel="stylesheet" />

    <%--Semantic--%>
    <script src="Style/Semantic/semantic.min.js"></script>
    <link href="Style/Semantic/semantic.min.css" rel="stylesheet" />

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
                    location.href = 'Login.aspx';
                }
            })
        }

        //function sw(msg) {
        //    Swal.fire({
        //        showClass: {
        //            popup: 'animated fadeInDown faster'
        //        },
        //        title: 'Correo enviado',
        //        icon: 'info',
        //        html:
        //            '<b>' + msg + '</b>, volver al ' +
        //            '<a href="Login.aspx">Login</a>',
        //        showConfirmButton: false
        //    })
        //}
    </script>

</head>
<body class="container" style="background-color:#009688">
    <form id="RecPass" class="w-50 p-5 m-auto ui form success" runat="server">
        <div class="box-form">
            <div class="card">
                <div class="card-header">
                    <h2>Recuperar contraseña</h2>
                </div>

                <div class="card-body">

                    <label for="txtIdentificacion" class="col-sm-10 col-form-label">Ingrese número de indentificación con que se registró en el sistema</label>
                    <div class="col-sm-10">
                        <%--<input type="email" class="form-control" id="txtEmail" placeholder="Correo Electrónico">--%>
                        <asp:TextBox runat="server" type="text" CssClass="form-control" id="txtIdentificacion" placeholder="Identificación"></asp:TextBox>
                    </div>
                </div>

                <div class="card-footer">
                    <div class="form-group row">
                        <div class="col-sm-10">
                            <%--<button id="btnRecPass" type="submit" runat="server" class="ui submit primary button" OnClick="BtnRecPass_Click">Enviar</button>--%>
                            <%--<asp:Button Text="Enviar" id="btnRecPass" type="submit" runat="server" class="ui submit primary button"/>--%>

                            <asp:Button ID="BtnRecPass" runat="server" Text="Enviar" CssClass="ui submit primary button" OnClick="BtnRecPass_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- <div class="form-group row">
            <label for="inputPassword3" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <input type="password" class="form-control" id="inputPassword3">
            </div>
        </div>

        <div class="form-group row">
            <label for="inputPassword3" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <input type="password" class="form-control" id="inputPassword3">
            </div>
        </div>--%>
    </form>
</body>
</html>
