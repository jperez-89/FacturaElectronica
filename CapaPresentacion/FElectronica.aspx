<%@ Page Title="Comprobante Electrónico" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="FElectronica.aspx.cs" Inherits="CapaPresentacion.FElectronica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link runat="server" href="Style/Factura.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border pt-2">
        <!-- Logo -->
        <div class="row">
            <div class="col-3">
                <img style="width: 15rem;" src="Style/img/logo.jpg" />
            </div>

            <div class="col-2">
                <asp:Label Text="" runat="server" ID="NombreEmpresa" CssClass="font-weight-bold"></asp:Label>
                <asp:Label runat="server" ID="DireccionEmpresa"></asp:Label>
                <asp:Label runat="server" ID="TelefonoEmpresa"></asp:Label>
                <asp:Label runat="server" ID="CorreoEmpresa"></asp:Label>
            </div>

            <div class="col-3">
                <div class="input-group">
                    <h5 class="font-weight-bold">NUMERO DE FACTURA</h5>
                    <%--<h5 id="NumFactura" style="color: crimson;"></h5>--%> <%--00100001010000034148--%>
                    <asp:Label runat="server" ID="NumFactura" ForeColor="Crimson"></asp:Label>
                </div>
            </div>

            <div class="col-4">
                <div class="input-group">
                    <h5 class="pr-1">Fecha Factura:</h5>
                    <%--<h5 id="FchFaactura"></h5>--%>
                    <asp:Label runat="server" ID="FchFactura"></asp:Label>
                </div>

                <div class="input-group">
                    <h5 class="pr-1">Moneda:</h5>
                    <%--<h5 id="Moneda"></h5>--%>
                    <asp:Label runat="server" ID="Moneda"></asp:Label>
                </div>
            </div>
        </div>

        <!-- CLIENTE -->
        <div class="p-1 mb-2 mt-2">
            <div class="row">
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Cliente</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Identificación</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Direccion</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Telefono</h5>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <%--<h6 id="NombreCliente"></h6>--%>
                    <asp:Label runat="server" ID="NombreCliente"></asp:Label>
                </div>
                <div class="col-md-3">
                    <%--<h6 id="CedulaCliente"></h6>--%>
                    <asp:Label runat="server" ID="CedulaCliente"></asp:Label>
                </div>
                <div class="col-md-3">
                    <%--<h6 id="DireccionCliente"></h6>--%>
                    <asp:Label runat="server" ID="DireccionCliente"></asp:Label>
                </div>
                <div class="col-md-3">
                    <%--<h6 id="TelefonoCliente"></h6>--%>
                    <asp:Label runat="server" ID="TelefonoCliente"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Correo</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Fecha Vencimiento</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Orden de compra</h5>
                </div>
                <div class="col-md-3">
                    <h5 class="font-weight-bold">Forma Pago</h5>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <h6 runat="server" id="CorreoCliente"></h6>
                    <%--<asp:Label runat="server" ID="Label1"></asp:Label>--%>
                </div>
                <div class="col-md-3">
                    <h6 runat="server" id="FechaVencimientoFact"></h6>
                    <%--<asp:Label runat="server" ID="FechaVencimientoFact"></asp:Label>--%>
                </div>
                <div class="col-md-3">
                    <h6 runat="server" id="OrdeCompra"></h>
                    <%--<asp:Label runat="server" ID="OrdeCompra"></asp:Label>--%>

                </div>
                <div class="col-md-3">
                    <h6 runat="server" id="FormaPago"></h6>
                    <%--<asp:Label runat="server" ID="FormaPago"></asp:Label>--%>
                </div>
            </div>
        </div>

        <!-- TABLA -->
        <div class="row pb-2">
            <div class="col-md-12">
                <div class="box border">
                    <section class="box-body table-responsive">
                        <table id="Tbl_Factura" class="table dataTable compact table-primary"
                            data-searching="false">
                            <thead>
                                <tr>
                                    <th>
                                        <label>Código</label></th>
                                    <th>
                                        <label>Nombre</label></th>
                                    <th>
                                        <label>Cantidad</label></th>
                                    <th>
                                        <label>Precio</label></th>
                                    <th>
                                        <label>% Desc</label></th>
                                    <th>
                                        <label>Mont. Desc</label></th>
                                    <th>
                                        <label>% IVA</label></th>
                                    <th>
                                        <label>Mont. IVA</label></th>
                                    <th>
                                        <label>Total</label></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>

                                </tr>

                                <tr>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>

                                </tr>

                                <tr>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>
                                    <th>123</th>

                                </tr>
                            </tbody>
                        </table>
                    </section>
                </div>
            </div>
        </div>

        <!-- TOTALES -->
        <div class="p-3 mb-2 box box-success">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <input type="text" id="TxtModalSubtotal" disabled="disabled"
                                style="text-align: right;" class="form-control"
                                placeholder="0.00">
                        </div>
                        <span class="col-form-label font-weight-bold float-right">Subtotal</span>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <input type="text" id="TxtModalDescuento" disabled="disabled"
                                style="text-align: right;" class="form-control"
                                placeholder="0.00">
                        </div>
                        <span class="col-form-label font-weight-bold float-right">Descuento</span>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <input type="text" id="TxtModalIVA" disabled="disabled"
                                style="text-align: right;" class="form-control"
                                placeholder="0.00">
                        </div>
                        <span class="col-form-label font-weight-bold float-right">IVA</span>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <input type="text" id="TxtModalTotal" disabled="disabled"
                                style="text-align: right;" class="form-control font-weight-bold"
                                placeholder="0.00">
                        </div>
                        <span class="col-form-label font-weight-bold float-right">Total</span>
                    </div>
                </div>
            </div>
        </div>

        <!-- CUENTAS -->
        <div class="cuentas mb-5">
            <h5 class="font-weight-bold">Clave:</h5>
            <span>50615052000310102372000100001010000034148104503919</span>
            <h5>Transferencias bancarias a las cuentas:</h5>
            <h6>BNCR Colones</h6>
            <h6>CR123456</h6>
            <h6>BNCR Dólares</h6>
            <h6>CR123456</h6>
            <h6>BCR Colones</h6>
            <h6>CR123456</h6>
            <h6>BCR Dólares</h6>
            <h6>CR123456</h6>
            <h5>A nombre de: Nombre Empresa S.A</h5>
            <h6>Ced. Jurídica: 3-102-008555</h6>

            <div class="footer">
                <h6>Autorizada mediante resolución N° DGT-R-033-2019 del 20-06-2019</h6>
            </div>
        </div>

        <!-- BOTONES -->
        <div class="row">
            <div class="col-md-2">
                <button id="BtnPdf" class="btn btn-danger">Ver Factura</button>
            </div>
            <div class="col-md-2">
                <button id="BtnEnviarFact" class="btn btn-success">Enviar Factura</button>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>
