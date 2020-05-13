<%@ Page ClientIDMode="Static" EnableEventValidation="false" Title="Registrar Cliente" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="CapaPresentacion.Clientes" %>

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
                }
            }
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
                    ddlDistrito.options[++j] = new Option(Distrito[i][2], Distrito[i][1]);
                }
            }
        }
    </script>

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

<%-- BODY --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3 align="center" style="padding-top: 10px">Registrar Clientes</h3>
    </section>
    <div class="container-fluid">
        <section>
            <div class="row">
                <!-- PARTE IZQUIERDA -->
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators" CssClass="validar" />--%>
                            <div class="form-group">
                                <label>Tipo de Identificación</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoIdentificacion" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Identificación</label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtIdentificacion" ClientIDMode="Static" PlaceHolder="Indentificación" runat="server" ToolTip="601230456"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="Identificación requerida" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtIdentificacion" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Nombre</label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtNombre" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtNombre" ClientIDMode="Static" runat="server" PlaceHolder="Nombre" ToolTip="Nombre Completo"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtNombre" runat="server" ErrorMessage="Nombre requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtNombre" runat="server" ErrorMessage="Este campo sólo debe tener letras" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="^\b[a-zA-Z\s_\-]{1,20}$"></asp:RegularExpressionValidator>--%>
                            </div>

                            <div class="form-group">
                                <label>Teléfono</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtTelefono" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtTelefono" runat="server" PlaceHolder="Teléfono" ToolTip="83201567"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtTelefono" runat="server" ErrorMessage="Número de teléfono requerido" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtTelefono" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Correo electrónico</label><asp:RequiredFieldValidator ControlToValidate="TxtEmail" ID="RequiredFieldValidator4" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtEmail" runat="server" PlaceHolder="ejemplo@email.com" ToolTip="ejemplo@email.com"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ControlToValidate="TxtEmail" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email requerido" Display="Dynamic" Text="Email requerido" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ControlToValidate="TxtEmail" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Formato incorrecto" Display="Dynamic" Text="Formato no válido" ValidationGroup="All Validators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validar"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- PARTE DERECHA -->
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <label>País</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control">
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
                                <label>Cantón</label>
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
                                <label>Dirección</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtDireccion" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- FIN CLASS ROW -->
        </section>

        <!-- BOTONES -->
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button name="Ok" runat="server" Text="Guardar" ID="BtnGuardar" ClientIDMode="Static" CssClass="btn btn-success" Width="200px" OnClick="BtnGuardar_Click" />
                    </td>

                    <td>
                        <asp:Button runat="server" Text="Cancelar" ID="BtnCancelar" ClientIDMode="Static" CssClass="btn btn-danger" Width="200px" OnClick="BtnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
