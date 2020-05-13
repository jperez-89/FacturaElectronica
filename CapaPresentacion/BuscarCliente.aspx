<%@ Page Title="Buscar Cliente" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="CapaPresentacion.BuscarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        // FUNCION QUE LLENA EL COMBO DE CANTON
        function LlenarddlCanton(ProvinciaID) {

            var Canton = new Array();
            <%= GetCanton() %>

            var ddlCanton = document.getElementById("ddlCanton");

            // Elimina los items cuando se elige otra Provincia
            var lengthddlCanton = ddlCanton.length - 1;
            for (var i = lengthddlCanton; i >= 0; i--) {
                ddlCanton.options[i] = null;
            }

            // Agrega los items con respecto a la Provincia seleccionada
            var j = 0;
            ddlCanton.options[j] = new Option(" ", "");
            ddlCanton.selectedIndex = j;
            for (var i = 0; i < Canton.length; i++) {
                if (Canton[i][0] == ProvinciaID) {
                    ddlCanton.options[++j] = new Option(Canton[i][2], Canton[i][1]);
                    //j++;
                }
            }
            // Agrega una item en blanco y la selecciona por defecto
        }

        // FUNCION QUE LLENA EL COMBO DE DISTRITO
        function LlenarddlDistrito(CantonID) {
            var Distrito = new Array();
            <%= GetDistrito() %>

            var ddlDistrito = document.getElementById("ddlDistrito");
            var lengthddlDistrito = ddlDistrito.length - 1;

            for (var i = lengthddlDistrito; i >= 0; i--) {
                ddlDistrito.options[i] = null;
            }
            var j = 0;
            ddlDistrito.options[j] = new Option(" ", "");
            ddlDistrito.selectedIndex = j;

            for (var i = 0; i < Distrito.length; i++) {
                if (Distrito[i][0] == CantonID) {
                    //  Nombre       ID
                    ddlDistrito.options[++j] = new Option(Distrito[i][2], Distrito[i][1]);
                    //j++;
                }
            }
        }
    </script>

    <script src="Style/CargaTablaClientes.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3 align="center" style="padding-top: 10px">Buscar de Clientes</h3>
    </section>
    <div class="container-fluid">
        <!-- BUSCADOR -->
        <div class="box box-primary">
            <div class="box-body">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="TxtBuscar" CssClass="form-control light-table-filter" data-table="order-table" placeholder="Buscar" ToolTip="Ingrese nombre o número de cédula"></asp:TextBox>
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
                        <asp:Button runat="server" ID="BtnNuevoCliente" CssClass="btn btn-secondary" Text="Nuevo Cliente" OnClick="BtnRegistrarCliente_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- FIN BUSCADOR -->

        <!-- TABLA -->
        <div class="box box-primary">
            <section class="box-body table-responsive">
                <table id="tbl_Clientes" class="order-table table dataTable compact table-hover table-primary">
                    <thead>
                        <tr>
                            <th>
                                <label>Id</label></th>
                            <th>
                                <label>Identificacion</label></th>
                            <th>
                                <label>Nombre</label></th>
                            <th>
                                <label>Telefono</label></th>
                            <th>
                                <label>Email</label></th>
                            <th>
                                <label>Estado</label></th>
                            <th>
                                <label>Acciones</label></th>
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
                    <h3 class="modal-title" id="myModalLabel">Actualizar Cliente</h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <!-- FIN HEADER-->

                <!--BODY-->
                <div class="modal-body">
                    <div class="row">
                        <div class="col col-lg-6">
                            <div class="form-group">
                                <label>Tipo de Identificacion</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoIdentificacion" runat="server">
                                    <asp:ListItem Value="F">Fisica</asp:ListItem>
                                    <asp:ListItem Value="J">Juridica</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Identificacion</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtIdentificacion" PlaceHolder="601230456 ó 3101123456" runat="server" ToolTip="No digitar guiones ni dejar espacios"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="Identificacion requerida" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="La identificacion solo debe tener numeros" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Nombre</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtNombre" runat="server" PlaceHolder="Nombre" ToolTip="Nombre Completo"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtNombre" runat="server" ErrorMessage="Nombre requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtNombre" runat="server" ErrorMessage="El Nombre solo debe contener letras" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="^\b[a-zA-Z\s_\-]{1,100}$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Telefono</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtTelefono" runat="server" PlaceHolder="88888888" ToolTip="12345678"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtTelefono" runat="server" ErrorMessage="Numero de telefono requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtTelefono" runat="server" ErrorMessage="El Numero de telefono solo debe tener numeros" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Correo electronico</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtEmail" runat="server" PlaceHolder="ejemplo@ejemplo.com" ToolTip="ejemplo@ejemplo.com"></asp:TextBox>

                                <asp:RequiredFieldValidator ControlToValidate="TxtEmail" ID="RequiredFieldValidator4" runat="server" ErrorMessage="El email es requerido" Display="Dynamic" Text="Email requerido" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ControlToValidate="TxtEmail" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Las direcciones de correo electrónico deben estar en el formato nombre@dominio.com" Display="Dynamic" Text="Formato no válido" ValidationGroup="All Validators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validar"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="col col-lg-6">
                            <div class="form-group">
                                <label>Pais</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="CR">Costa Rica</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Provincia</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" OnChange="LlenarddlCanton(this.value);">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Canton</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCanton" runat="server" CssClass="form-control" OnChange="LlenarddlDistrito(this.value);">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Distrito</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Direccion</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtDireccion" runat="server"></asp:TextBox>
                            </div>
                        </div>
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
