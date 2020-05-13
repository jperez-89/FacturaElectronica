<%@ Page Title="Registrar Producto" ClientIDMode="Static" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="NuevoProducto.aspx.cs" Inherits="CapaPresentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar {
            color: red;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h3 align="center" style="padding-top: 10px">Registrar Producto</h3>
    </section>
    <div class="container-fluid">
        <section>
            <div class="row">
                <!-- PARTE IZQUIERDA -->
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AllValidators" CssClass="validar" />--%>
                                <label>Código de Producto</label><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TxtCodigoProducto" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtCodigoProducto" runat="server" ToolTip="Código de Producto"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Tipo de Codigo</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlTipoCodigo" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Descripción</label><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtDescripcion" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtDescripcion" runat="server" PlaceHolder="Descripción" ToolTip="Descripción"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtDescripcion" runat="server" ErrorMessage="Este campo sólo debe tener letras" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="^\b[a-zA-Z\s_\-]{1,3000}$"></asp:RegularExpressionValidator>--%>
                            </div>

                            <div class="form-group">
                                <label>Unidad de Medida</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlUnidadMedida" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Precio ¢</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtPrecioColon" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtPrecioColon" runat="server" placeholder="0.00"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtPrecioColon" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label>Precio $</label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtPrecioDolar" runat="server" ErrorMessage=" *" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TxtPrecioDolar" runat="server" placeholder="0.00"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtPrecioDolar" runat="server" ErrorMessage="Este campo sólo debe tener números" Display="Dynamic" ValidationGroup="AllValidators" CssClass="validar" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- BOTONES -->
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button name="Ok" runat="server" Text="Guardar" ID="BtnGuardar" CssClass="btn btn-success" Width="200px" OnClick="BtnGuardar_Click" />
                    </td>

                    <td>
                        <asp:Button runat="server" Text="Cancelar" ID="BtnCancelar" CssClass="btn btn-danger" Width="200px" OnClick="BtnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

