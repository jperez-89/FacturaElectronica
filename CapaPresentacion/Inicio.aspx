<%@ Page ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaPresentacion.Inicio1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Style/js/AdminLTE/app.js" type="text/javascript"></script>--%>
    <%--<link href="Style/sb-admin.css" rel="stylesheet" />--%>
    <script src="Style/DatosCards.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- CUADROS INFORMATIVOS-->
        <div class="row mt-3">
            <!-- CARD CLIENTES -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2"> <%----%>
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                    <h5>Clientes</h5>
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800">
                                    <asp:TextBox CssClass="h5 text-info font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="CantClientes"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-user fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD PRODUCTOS -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    <h5>Productos</h5>
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800">
                                    <asp:TextBox CssClass="h5 text-success font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="CantProductos"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-user fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD FACTURAS -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                    <h5>Facturas</h5>
                                </div>
                                <asp:TextBox CssClass="h5 text-warning font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="CantFacturas">15</asp:TextBox>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD NOTAS DE CREDITO -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    <h5>Notas de Crédito</h5>
                                </div>
                                <asp:TextBox CssClass="h5 text-primary font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="TxtNotasCredito">2</asp:TextBox>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%--<div class="row mt-3">
            <!-- CARD CLIENTES -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    <h5>Clientes</h5>
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800">
                                    <asp:TextBox CssClass="h5 text-primary font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="TextBox1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-user fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD PRODUCTOS -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                    <h5>Productos</h5>
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800">
                                    <asp:TextBox CssClass="h5 text-success font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="TextBox2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-user fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD FACTURAS -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                    <h5>Facturas</h5>
                                </div>
                                <asp:TextBox CssClass="h5 text-warning font-weight-bold m-2" BorderWidth="0" Font-Size="Large" ReadOnly="true" runat="server" ID="TextBox3">15</asp:TextBox>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- CARD NOTAS DE CREDITO -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                    <h5>Task</h5>
                                </div>
                                <div class="row no-gutters align-items-center">
                                    <div class="col-auto">
                                        <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">50%</div>
                                    </div>
                                    <div class="col">
                                        <div class="progress progress-sm mr-2">
                                            <div class="progress-bar bg-info" role="progressbar" style="width: 50%" aria-valuenow="50"
                                                aria-valuemin="0" aria-valuemax="100">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>

        <%--FOOTER--%>
        <div class="footer w-auto h-auto" style="margin: initial">
            <div class="row">
                <div class="col col-md-4">
                    <h6>Contactanos:</h6>
                    <a href="mailto:jrwc1989@gmailcom">
                        <img style="width: 30px" src="Style/img/gmail.png" /></a>
                    <a href="https://api.whatsapp.com/send?phone=50683182537&text=Hola_Necesito_Ayuda" target="_blank">
                        <img style="width: 30px" src="Style/img/whatsapp.png" /></a>
                </div>

                <div class="col col-md-4">
                    <h6>Siguenos en:</h6>
                    <a href="#" target="_blank">
                        <img style="width: 30px" src="Style/img/facebook.png" /></a>
                    <a href="#" target="_blank">
                        <img style="width: 40px" src="Style/img/Instagram.png" /></a>
                    <a href="#" target="_blank">
                        <img style="width: 30px" src="Style/img/twitter.png" /></a>
                </div>

                <div class="col col-md-4">
                    <h6>Puntarenas - Costa Rica</h6>
                    <h6>© DERECHOS RESERVADOS - 2019</h6>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
