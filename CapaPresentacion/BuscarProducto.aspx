<%@ Page Title="Buscar Producto" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="BuscarProducto.aspx.cs" Inherits="CapaPresentacion.BuscarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Style/CargaTablaProducto.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3 align="center" style="padding-top: 10px">Buscar Productos</h3>
    </section>

    <div class="container-fluid">
        <!-- BUSCADOR -->
        <div class="box box-primary">
            <div class="row box-body">
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="TxtBuscar" CssClass="form-control light-table-filter" data-table="order-table" placeholder="Buscar" ToolTip="Ingrese nombre o código"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-3">
                    <asp:Button runat="server" ID="BtnBuscarProdcuto" CssClass="btn btn-primary" Width="100px" Text="Buscar" />
                </div>

                <div class="col-md-4" align="right">
                    <asp:Button runat="server" ID="BtnExcel" CssClass="btn btn-secondary float-right" Width="130px" Text="Exportar a Excel" />
                </div>

                <div class="col-md-1" align="right">
                    <asp:Button runat="server" ID="BtnNuevoProducto" CssClass="btn btn-secondary" Width="130px" Text="Nuevo Producto" OnClick="BtnRegistrarProducto_Click" />
                </div>
            </div>
        </div>
        <!-- FIN BUSCADOR -->

        <!-- TABLA -->
        <div class="box">
            <section class="box-body table-responsive">
                <table id="tbl_Productos" class="order-table table dataTable compact table-hover table-primary">
                    <thead>
                        <tr>
                            <th>
                                <label>Id</label></th>
                            <th>
                                <label>Codigo</label></th>
                            <th>
                                <label>Nombre</label></th>
                            <th>
                                <label>Medida</label></th>
                            <th>
                                <label>Precio Colon</label></th>
                            <th>
                                <label>Precio Dolar</label></th>
                            <th>
                                <label>Tipo</label></th>
                            <th>
                                <label>Estado</label></th>
                            <th>
                                <label>Acciones</label>
                        </tr>
                    </thead>
                </table>
            </section>
        </div>
        <!-- FIN TABLA -->
    </div>
    <!-- MODAL -->
    <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <!--HEADER-->
                <div class="modal-header">
                    <h3 class="modal-title" id="myModalLabel">Actualizar Producto</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <!-- FIN HEADER-->

                <!--BODY-->
                <div class="modal-body">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators" CssClass="validar" />

                    <div class="form-group">
                        <label>Codigo de Producto</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox Enabled="false" CssClass="form-control" ID="TxtCodigoProducto" runat="server" ToolTip="Ingrese el codigo"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Descripcion</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TxtDescripcion" runat="server" PlaceHolder="Descripcion" ToolTip="Descripciono"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtDescripcion" runat="server" ErrorMessage="Descripcion requerida" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtDescripcion" runat="server" ErrorMessage="La descripcion solo debe contener letras" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="^\b[a-zA-Z\s_\-]{1,3000}$"></asp:RegularExpressionValidator>
                    </div>

                    <div class="form-group">
                        <label>Unidad de Medida</label>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlUnidadMedida" runat="server" CssClass="form-control">
                            <asp:ListItem Value="Unidad">Unidad</asp:ListItem>
                            <asp:ListItem Value="Tons">Toneladas</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Precio ¢</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TxtPrecioColon" runat="server" placeholder="0.00"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtPrecioColon" runat="server" ErrorMessage="Precio requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtPrecioColon" runat="server" ErrorMessage="El Precio solo debe tener numeros" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                    </div>

                    <div class="form-group">
                        <label>Precio $</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TxtPrecioDolar" runat="server" placeholder="0.00"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtPrecioDolar" runat="server" ErrorMessage="Precio requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtPrecioDolar" runat="server" ErrorMessage="El Precio solo debe tener numeros" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>
                <!--FIN BODY-->

                <!--FOOTHER-->
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                </div>
                <!--FIN FOOTHER-->
            </div>
        </div>
    </div>
    <!-- FIN MODAL -->
</asp:Content>
