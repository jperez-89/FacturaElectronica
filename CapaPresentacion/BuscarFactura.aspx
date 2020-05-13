<%@ Page Title="Buscar de Factura" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="BuscarFactura.aspx.cs" Inherits="CapaPresentacion.BuscarFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            //$('#FchFin').datepicker();

            $.fn.datepicker.defaults.format = "dd/mm/yyyy";
            $.fn.datepicker.defaults.todayBtn = true;
            $.fn.datepicker.defaults.autoclose = true;
            $.fn.datepicker.defaults.todayHighlight = true;
            $.fn.datepicker.defaults.endDate = "0d";

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <section class="content-header pt-2">
            <h3 class="">Facturas</h3>

            <div class="">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="Inicio.aspx">Inicio</a></li>
                        <li class="breadcrumb-item"><a href="#">Facturación</a></li>
                        <li class="breadcrumb-item active font-weight-bold" aria-current="page">Facturas</li>
                    </ol>
                </nav>
            </div>
        </section>

        <div class="row">
             <div class="col-md-2"></div>
            <div class="col-md-4">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <button class="btn btn-secondary" type="button" id="btnBuscarFact">Buscar</button>
                    </div>
                    <input type="text" class="form-control" placeholder="Cédula o Factura" aria-label="" aria-describedby="btnBuscarFact">
                </div>
            </div>            

            <div class="col-md-2">
                <div class="input-group date" data-provide="datepicker">
                    <div class="input-group-addon">
                        <div class="input-group-text" id="iconoFchIni">
                            <span><i class="fa fa-calendar-alt"></i></span>
                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="FchIni" name="FchIni" CssClass="form-control" aria-describedby="iconoFchIni"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-2">
                <div class="input-group date" data-provide="datepicker">
                    <div class="input-group-addon">
                        <div class="input-group-text" id="iconoFchFin">
                            <span><i class="fa fa-calendar-alt"></i></span>
                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="FchFin" name="FchFin" CssClass="form-control" aria-describedby="iconoFchFin"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        <!-- BUSCADOR -->
        <%--        <div class="box box-title">
            <div class="box-body">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="TxtBuscarFact" CssClass="form-control light-table-filter" data-table="order-table" placeholder="Buscar" ToolTip="Ingrese nombre o número de cédula"></asp:TextBox>                          
                        </div>
                    </div>

                    <div class="col-md-2">
                        <asp:Button runat="server" ID="BtnBuscarProdcuto" CssClass="btn btn-primary" Text="Buscar" />
                    </div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2"></div>

                    <div class="col-md-2">
                        <asp:Button runat="server" ID="BtnExcel" CssClass="btn btn-secondary" Text="Exportar a Excel" />
                    </div>

                    <div class="col-md-2">
                        <asp:Button runat="server" ID="BtnNuevoCliente" CssClass="btn btn-secondary" Text="Nuevo Cliente" />
                    </div>
                </div>
            </div>
        </div>--%>
        <!-- FIN BUSCADOR -->


        <!-- TABLA -->
        <div class="box box-primary">
            <section class="box-body table-responsive">
                <table id="tbl_Clientes" class="order-table table dataTable compact table-hover table-primary">
                    <thead>
                        <tr>
                            <th>
                                <label>Fecha</label></th>
                            <th>
                                <label>Número</label></th>
                            <th>
                                <label>Identificacion</label></th>
                            <th>
                                <label>Cliente</label></th>
                            <th>
                                <label>Plazo</label></th>
                            <th>
                                <label>Moneda</label></th>
                            <th>
                                <label>Medio Pago</label></th>
                            <th>
                                <label>Monto</label></th>
                            <th>
                                <label>Estado Hacienda</label></th>
                            <th>
                                <label>Enviada</label></th>
                            <th>
                                <label>Anulada</label></th>
                        </tr>
                    </thead>
                </table>
            </section>
        </div>
        <!-- FIN TABLA -->

    </div>
</asp:Content>
