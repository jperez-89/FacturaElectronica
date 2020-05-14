<%@ Page EnableEventValidation="false" Title="Registro de Factura" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="NuevaFactura.aspx.cs" Inherits="CapaPresentacion.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Style/CodigosNuevaFactura.js" type="text/javascript"></script>--%>
    <style>
        td {
            padding: 20px;
        }

        .validar {
            color: red;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <section class="content-header pt-2">
            <h3 class="">Registro de Facturas</h3>

            <div class="">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Inicio.aspx">Inicio</a></li>
                        <li class="breadcrumb-item"><a href="#">Facturación</a></li>
                        <li class="breadcrumb-item active font-weight-bold" aria-current="page">Registro de Facturas</li>
                    </ol>
                </nav>
            </div>
        </section>

        <%--PRINCIPAL--%>
        <div class="">
            <div class="p-2 box box-success shadow">
                <%--ROW CLIENTE--%>
                <div class="row">
                    <%--Indentificacion--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Identificación</label><asp:RequiredFieldValidator ID="Required_ValidarDNI" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="   *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            <div class="input-group">
                                <span>
                                    <button data-target="#ModalClientes" data-toggle="modal" id="BtnModalClientes" class="btn btn-secondary" title="Buscar Clientes"><i class="fa fa-search"></i></button>
                                </span>
                                <asp:TextBox MaxLength="10" ID="TxtIdentificacion" runat="server" CssClass="form-control" placeholder="Buscar"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="RegularExpresion_ValidarDNI" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                    </div>
                    <%--Cliente--%>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Cliente</label>
                            <div class="input-group">
                                <asp:TextBox ID="TxtNombre" runat="server" Enabled="false" CssClass="form-control" placeholder="Cliente"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--Medio Pago--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Medio Pago</label>
                            <asp:DropDownList ID="ddlMedioPago" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="Efectivo">Efectivo</asp:ListItem>
                                <asp:ListItem Value="Tarjeta">Tarjeta</asp:ListItem>
                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                <asp:ListItem Value="Transferencia">Transferencia</asp:ListItem>
                                <asp:ListItem Value="Depósito">Depósito</asp:ListItem>
                                <asp:ListItem Value="Otro">Otro</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--Moneda--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Moneda</label>
                            <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="Colones">Colones</asp:ListItem>
                                <asp:ListItem Value="Dólares">Dólares</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--Check Credito--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Crédito</label><br />
                            <input type="button" class="btn btn-bitbucket" value="Si" id="ChCredito" onclick="ActivaDiasCredito(this);" />
                        </div>
                    </div>
                    <%--Dias credito--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Días</label>
                            <%--<input id="DiasCredito" class="form-control" disabled="disabled" min="1" type="number" value="0" />--%>
                            <asp:TextBox min="1" type="number" value="0" runat="server" CssClass="form-control" Enabled="false" ID="DiasCredito"></asp:TextBox>
                        </div>
                    </div>
                    <%--Fecha--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Fecha</label>
                            <asp:TextBox runat="server" Width="90%" CssClass="form-control p-1" Enabled="false" ID="TxtFecha"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%-- FIN ROW CLIENTE--%>

                <%--ROW PRODUCTO--%>
                <div class="row">
                    <%--Codigo Producto--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Código Producto</label>
                            <div class="input-group">
                                <span>
                                    <button data-target="#ModalProductos" data-toggle="modal" id="BtnModalProductos" class="btn btn-secondary" title="Buscar Productos"><i class="fa fa-search"></i></button>
                                </span>
                                <asp:TextBox MaxLength="10" ID="TxtCodProducto" runat="server" CssClass="form-control" placeholder="Buscar"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--Producto--%>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Detalle</label>
                            <div class="input-group">
                                <asp:TextBox ID="TxtDetalle" runat="server" Enabled="false" CssClass="form-control" placeholder="Producto"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--Cantidad--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Cantidad</label>
                            <div class="input-group">
                                <input min="1" id="TxtCantidad" class="form-control" type="number" value="1" />
                            </div>
                        </div>
                    </div>
                    <%--Precio--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Precio</label>
                            <div style="width: 90px" class="input-group">
                                <asp:TextBox runat="server" name="Precio" CssClass="form-control" ID="TxtPrecio" Text="0.00"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--Descuento--%>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Descuento</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtDescuento" Text=""></asp:TextBox>
                                <%--<span>
                            <label class="col-form-label"> %</label></span>--%>
                            </div>
                        </div>
                    </div>
                    <%--IVA--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">IVA</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtIVA" Text=""></asp:TextBox>
                                <span>
                                    <button data-target="#ModalImpuestos" data-toggle="modal" id="BtnModalImpuestos" class="btn btn-secondary" title="Buscar Impuesto"><i class="fa fa-search"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <%--Total--%>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bold">Total</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" Enabled="false" CssClass="form-control" Style="text-align: right;" name="Total" ID="TxtTotal" Text="0.00"></asp:TextBox>
                                <span>
                                    <button id="BtnAgregarLinea" class="btn btn-info" title="Agregar Producto"><i class="fa fa-plus"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <%--FIN ROW PRODUCTO--%>
            </div>

            <%--TABLA PRODUCTOS--%>
            <div class="box">
                <section class="box-body table-responsive">
                    <table id="Tbl_CargaProductos" class="table dataTable compact table-hover table-primary" data-searching="false">
                        <thead>
                            <tr>
                                <th></th>
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
                    </table>
                </section>
            </div>
            <%--FIN TABLA--%>
            <br />

            <%--TOTALES--%>
            <div class="p-2 box box-success shadow">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox ID="TxtSubtotal" runat="server" Enabled="false" Style="text-align: right;" CssClass="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <span class="col-form-label font-weight-bold float-right">Subtotal</span>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox ID="TxtMontoDescuento" runat="server" Enabled="false" Style="text-align: right;" CssClass="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <span class="col-form-label font-weight-bold float-right">Descuento</span>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox ID="TxtImpuesto" runat="server" Enabled="false" Style="text-align: right;" CssClass="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <span class="col-form-label font-weight-bold float-right">IVA</span>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="input-group">
                                <asp:Label runat="server" ID="lblTotalFactura"></asp:Label>
                                <asp:TextBox ID="TxtTotalFactura" runat="server" Enabled="false" Style="text-align: right;" CssClass="form-control font-weight-bold" placeholder="0.00"></asp:TextBox>
                            </div>
                            <span class="col-form-label font-weight-bold float-right">Total</span>
                        </div>
                    </div>
                </div>
            </div>
            <%--FIN TOTALES--%>
            <br />

            <%--BOTON BOTONES--%>
            <div class="row container-fluid">
                <div class="col-md-1">
                    <label class="font-weight-bold">Observaciones </label>
                </div>
                <div class="col-md-7">
                    <div class="input-group">
                        <asp:TextBox ID="TxtArea" runat="server" Columns="78" Rows="1" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Button runat="server" ID="BtnFacturar" CssClass="form-control btn btn-facebook btn-lg active" Text="Facturar" />
                    </div>
                    <%--OnClick="BtnFacturar_Click"--%>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="form-control btn btn-danger btn-lg active" Text="Cancelar" />
                    </div>
                    <%--ID="BtnCancelarFactura"--%>
                </div>
            </div>
            <div id="listado">

            </div>
            <%-- FIN BOTON GUARDAR--%>
        </div>
        <%--FIN PRINCIPAL--%>
    </div>
    <%--FIN CONTAINER--%>


    <%--MODAL CLIENTE--%>
    <div id="ModalClientes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" class="modal fade">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="myModalLabel">Búsqueda de Cliente</h3>
                    <button type="button" id="BtnXModalClientes" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%--<input type="button" value="Agregar Nuevo" class="btn btn-primary align-content-end">--%>
                    <%-- <div class="row">
                        <div class="col-md-4">
                            <input type="text" id="TxtBuscarClientes" name="txtBuscarClientes" placeholder="Buscar" class="form-control light-table-filter" data-table="order-table">
                        </div>
                        <div class="col-md-2">
                            <input type="button" value="Buscar" class="btn btn-primary btn-block">
                        </div>
                    </div>
                    <br>--%>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table id="Tbl_ModalClientes" class="order-table table dataTable compact table-hover table-primary">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Código</th>
                                            <th>Identificación</th>
                                            <th>Nombre</th>
                                            <th>Email</th>
                                            <th>Estado</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br>
                </div>
                <div class="modal-footer float-left">
                    <div class=" float-left">
                        <a href="NuevoCliente.aspx" class="btn btn-success">Agregar Nuevo</a>

                    </div>
                    <button id="BtnCerrarModal" type="button" class="btn btn-primary">Cerrar</button>
                </div>
            </div>

        </div>
    </div>
    <%--FIN MODAL CLIENTE--%>

    <%--MODAL PRODUCTOS--%>
    <div id="ModalProductos" tabindex="-1" role="dialog" aria-labelledby="myModalLabelProd" class="modal fade">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="myModalLabelProd">Búsqueda de Producto</h3>
                    <button type="button" id="BtnXModalProductos" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%--<div class="row">
                        <div class="col-md-4">
                            <input type="text" id="TxtBuscarProductos" placeholder="Buscar" class="form-control light-table-filter" data-table="order-table">
                        </div>
                        <div class="col-md-2">
                            <input type="button" value="Buscar" class="btn btn-primary btn-block">
                        </div>
                    </div>--%>
                    <%--<br>--%>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table id="Tbl_ModalProductos" class="order-table table dataTable compact table-hover table-primary">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Id</th>
                                            <th>Código</th>
                                            <th>Nombre</th>
                                            <th>Precio Colón</th>
                                            <th>Precio Dólar</th>
                                            <th>Tipo</th>
                                            <th>Estado</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br>
                </div>
                <div class="modal-footer">
                    <button id="BtnCerrarModalProductos" type="button" class="btn btn-primary btn-custom">Cerrar</button>
                </div>
            </div>

        </div>
    </div>
    <%--FIN MODAL CLIENTE--%>

    <%--MODAL IMPUESTOS--%>
    <div id="ModalImpuestos" tabindex="-1" role="dialog" aria-labelledby="myModalLabelImpuestos" class="modal fade">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="myModalLabelImpuestos">Búsqueda de Impuesto</h3>
                    <button type="button" id="BtnXModalImpuestos" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%-- <div class="row">
                        <div class="col-md-4">
                            <input type="text" id="TxtBuscarImpuesto" placeholder="Buscar" class="form-control light-table-filter" data-table="order-table">
                        </div>
                        <div class="col-md-2">
                            <input type="button" value="Buscar" class="btn btn-primary btn-block">
                        </div>
                    </div>
                    <br>--%>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table id="Tbl_ModalImpuestos" data-searching="false" data-info="false" class="order-table table dataTable compact table-hover table-primary">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Id</th>
                                            <th>Nombre</th>
                                            <th>Porcentaje</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br>
                </div>
                <div class="modal-footer">
                    <button id="BtnCerrarModalImpuestos" type="button" class="btn btn-primary btn-custom">Cerrar</button>
                </div>
            </div>

        </div>
    </div>
    <%--FIN MODAL IMPUESTOS--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="Style/CodigosNuevaFactura.js" type="text/javascript"></script>
</asp:Content>
