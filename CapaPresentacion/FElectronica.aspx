<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="FElectronica.aspx.cs" Inherits="CapaPresentacion.FElectronica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container border p-2">
          <!-- Logo -->
          <div class="row">
               <div class="col-md-3">
                    <img style="width: 15rem;" src="Style/img/logo.jpg" />
               </div>

               <div class="col-md-2">
                    <h5 class="font-weight-bold">NOMBRE EMPRESA S.A</h5>
                    <h5>Direccion</h5>
                    <h5>Telefono</h5>
                    <h5>Correo</h5>
               </div>

               <div class="col-md-3">
                    <div class="input-group">
                         <h5 class="font-weight-bold">NUMERO DE FACTURA</h5>
                         <span style="color: crimson">00100001010000034148</span>
                    </div>
               </div>

               <div class="col-md-4">
                    <div class="input-group">
                         <h5 class="pr-1">Fecha Factura:</h5>
                         <span>15/05/2020</span>
                    </div>
                    
                    <div class="input-group">
                         <h5 class="pr-1">Moneda:</h5>
                         <span>Colones</span>
                    </div>
               </div>
          </div>

          <!-- CLIENTE -->
          <div class="p-1 mb-2 mt-2">
               <div class="row">
                    <div class="col-md-3"><h5 class="font-weight-bold">Cliente</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Identificación</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Direccion</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Telefono</h5></div>
               </div>

               <div class="row">
                    <div class="col-md-3"><h6>CONSTRUCTORA HERNAN SOLIS, SR.L</h6></div>                    
                    <div class="col-md-3"><h6>3102008555</h6></div>
                    <div class="col-md-3"><h6>ROMOSHER DE LA CASA DE OSCAR ARIAS100 OESTE, EDIFICIO TORRE</h6></div>
                    <div class="col-md-3"><h6>40001390</h6></div>
               </div>

               <div class="row">
                    <div class="col-md-3"><h5 class="font-weight-bold">Correo</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Fecha Vencimiento</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Orden de compra</h5></div>
                    <div class="col-md-3"><h5 class="font-weight-bold">Forma Pago</h5></div>                    
               </div>

               <div class="row">
                    <div class="col-md-3"><h6>facturaelectronica@hsolis.com</h6></div>
                    <div class="col-md-3"><h6>15-05-2020</h6></div>
                    <div class="col-md-3"><h6>24283</h6></div>
                    <div class="col-md-3"><h6>Contado</h6></div>
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
          <div class="p-3 mb-2 box box-success shadow">
               <div class="row">
                    <div class="col-md-3">
                         <div class="form-group">
                              <div class="input-group">
                                   <input type="text" id="TxtModalSubtotal" disabled="false"
                                        Style="text-align: right;" class="form-control"
                                        placeholder="0.00">
                              </div>
                              <span class="col-form-label font-weight-bold float-right">Subtotal</span>
                         </div>
                    </div>
                    <div class="col-md-3">
                         <div class="form-group">
                              <div class="input-group">
                                   <input type="text" id="TxtModalDescuento" disabled="false"
                                        Style="text-align: right;" class="form-control"
                                        placeholder="0.00">
                              </div>
                              <span class="col-form-label font-weight-bold float-right">Descuento</span>
                         </div>
                    </div>
                    <div class="col-md-3">
                         <div class="form-group">
                              <div class="input-group">
                                   <input type="text" id="TxtModalIVA" disabled="false"
                                        Style="text-align: right;" class="form-control"
                                        placeholder="0.00">
                              </div>
                              <span class="col-form-label font-weight-bold float-right">IVA</span>
                         </div>
                    </div>
                    <div class="col-md-3">
                         <div class="form-group">
                              <div class="input-group">
                                   <input type="text" id="TxtModalTotal" disabled="false"
                                        Style="text-align: right;" class="form-control font-weight-bold"
                                        placeholder="0.00">
                              </div>
                              <span class="col-form-label font-weight-bold float-right">Total</span>
                         </div>
                    </div>
               </div>
          </div>

          
          <div class="mb-5">
               <h5 class="font-weight-bold">Clave:</h5>
               <span>50615052000310102372000100001010000034148104503919</span>
               <h6>Autorizada mediante resolución N° DGT-R-033-2019 del 20-06-2019</h6>
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
