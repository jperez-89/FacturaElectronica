var tabla = null, data = null, Cliente = null, r = null, btn1 = null, email = null, NumLinea = null, Totales = null, DatosTabla = null, nfila = 0, cfilas = 0;

function ActivaDiasCredito(obj) {
    if (obj.value == 'Si') {
        document.getElementById('ChCredito').value = 'No';
        document.getElementById('DiasCredito').disabled = false;
        document.getElementById('DiasCredito').focus();
    }
    else if (obj.value == 'No') {
        document.getElementById('DiasCredito').value = '0';
        document.getElementById('ChCredito').value = 'Si';
        document.getElementById('DiasCredito').disabled = true;
    }
}

// ------------------ JS DE CLIENTES
$(document).on('click', '#BtnModalClientes', function (e) {
    e.preventDefault();
    CargaModalClientes();
});

function CargaModalClientes() {
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/MostrarClientes",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datas) {
            data = datas.d;
            tabla = $('#Tbl_ModalClientes').dataTable({
                "order": [[1, 'asc']],
                retrieve: true,
                paging: false
            });

            tabla.fnClearTable();

            for (var i = 0; i < data.length; i++) {
                if (data[i].State == true) {
                    btn1 = '<button id="BtnAgregarCliente" data-dismiss="modal" title="Agregar" class="btn btn-primary btn-agregar"> <i class="fa fa-plus-circle"></i> </button>&nbsp';
                } else if (data[i].State == false) {
                    btn1 = '<button id="BtnAgregarCliente" disabled="false" title="Agregar" class="btn btn-danger"> <i class="fa fa-plus-circle"></i> </button>&nbsp';
                }

                tabla.fnAddData([
                    btn1,
                    data[i].Id,
                    data[i].DNI,
                    data[i].Name,
                    data[i].Email,
                    ((data[i].State == true) ? "Activo" : "Inactivo"),
                ]);
            }
        }
    });
}

$(document).on('click', '#BtnAgregarCliente', function (e) {
    e.preventDefault();
    // Boton - TR    -  TD
    r = $(this).parent().parent()[0];
    // De la tabla obtiene los datos de esa fila 
    Cliente = tabla.fnGetData(r);

    $("#TxtIdentificacion").val(Cliente[2]);
    $("#TxtNombre").val(Cliente[3]);
    document.getElementById("EmailCliente").innerText = Cliente[4];
    //$("#TxtTelefono").val(datos.d[i].phone);
    email = Cliente[4];

    tabla.fnClearTable();

    //$.ajax({
    //    type: "POST",
    //    url: "BuscarCliente.aspx/MostrarClientes",
    //    data: {},
    //    //dataType: "json",
    //    contentType: "application/json; charset=utf-8",
    //    error: function (xhr, ajaxOptions, throwError) {
    //        console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
    //    },
    //    success: function (datos) {
    //        // Busca y Valida el numero de cedula para mostrar los datos en el modal
    //        for (var i = 0; i < datos.d.length; i++) {
    //            if (datos.d[i].DNI == Cliente[2]) {
    //                $("#TxtIdentificacion").val(datos.d[i].DNI);
    //                $("#TxtNombre").val(datos.d[i].name);
    //                //$("#TxtTelefono").val(datos.d[i].phone);
    //                email = datos.d[i].email;
    //            }
    //        }
    //        tabla.fnClearTable(); 
    //    }
    //});
});

$(document).on('click', '#BtnCerrarModal', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
    $("#ModalClientes").modal('hide');
});

$(document).on('click', '#BtnXModalClientes', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
});

// ------------------ JS DE PRODUCTOS
// Muestra el listado de productos en un modal
$(document).on('click', '#BtnModalProductos', function (e) {
    e.preventDefault();
    CargaModalProductos();
});

// Carga los datos, traidos de la BD, al modal
function CargaModalProductos() {
    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/MostrarProductos",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datas) {
            data = datas.d;
            tabla = $('#Tbl_ModalProductos').dataTable({
                "order": [[1, 'asc']],
                retrieve: true,
                paging: false
            });

            tabla.fnClearTable();

            for (var i = 0; i < data.length; i++) {
                if (data[i].state == true) {
                    btn1 = '<button id="BtnAgregarProducto" data-dismiss="modal" title="Agregar" class="btn btn-primary btn-agregar"> <i class="fa fa-plus-circle"></i> </button>&nbsp';
                } else if (data[i].state == false) {
                    btn1 = '<button id="BtnAgregarProducto" disabled="false" title="Agregar" class="btn btn-danger"> <i class="fa fa-plus-circle"></i> </button>&nbsp';
                }

                tabla.fnAddData([
                    btn1,
                    data[i].Id,
                    data[i].ProductId,
                    data[i].name,
                    //data[i].measure,
                    data[i].unitPriceC,
                    data[i].unitPriceD,
                    ((data[i].CategoryID == 1) ? "Producto" : "Servicio"),
                    ((data[i].state == true) ? "Activo" : "Inactivo"),
                ]);
            }
        }
    });
}

// Se obtiene la seleccion del producto
$(document).on('click', '#BtnAgregarProducto', function (e) {
    e.preventDefault();
    // Boton - TR    -  TD
    r = $(this).parent().parent()[0];
    // De la tabla obtiene los datos de esa fila 
    FilaProducto = tabla.fnGetData(r);

    var itemsSelected = $('#ddlMoneda :selected');
    if (itemsSelected[0].value == "Colones") {
        $("#TxtPrecio").val(FilaProducto[4]);
    }
    else if (itemsSelected[0].value == "Dólares") {
        $("#TxtPrecio").val(FilaProducto[5]);
    }

    $("#TxtCodProducto").val(FilaProducto[2]);
    $("#TxtDetalle").val(FilaProducto[3]);

    var servicio = FilaProducto[6];
    tabla.fnClearTable();
    CalculaLinea();
});

// Cierre del modal de productos, del boton cerrar
$(document).on('click', '#BtnCerrarModalProductos', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
    $("#ModalProductos").modal('hide');
});
// Cierre del modal de productos, de la X
$(document).on('click', '#BtnXModalProductos', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
});

// Calcula el monto del descuento
$(document).on('change', '#TxtDescuento', function () {
    CalculaLinea();
    //PorceDescuento = document.getElementById('TxtDescuento').value;

    //mDescuento = ((precio * cantidad) * PorceDescuento) / 100;
    //TotLinea = TotProducto - mDescuento;

    //$('#TxtTotal').val(TotLinea);
});

// Calcula el monto del descuento
$(document).on('change', '#TxtIVA', function () {
    CalculaLinea();
    //var PorceIVA = document.getElementById('TxtIVA').value;
    //if (PorceDescuento != 0) {
    //    mIVA = ((precio * cantidad) * PorceIVA) / 100;
    //    TotLinea = TotLinea + mIVA;
    //} else {
    //    mIVA = (TotProducto * PorceIVA) / 100;
    //    TotLinea = TotProducto + mIVA;
    //}
    //$('#TxtTotal').val(TotLinea);
});

// Si aumenta la cantidad va aumentado el TotalLinea
$(document).on('change', '#TxtCantidad', function () {
    CalculaLinea();
})

// Hace todos los calculos
var precio = 0, cantidad = 0, mDescuento = 0, TotProducto = 0, PrecioProdConDescuento = 0, PorceDescuento = 0, mIVA = 0;
function CalculaLinea() {
    precio = document.getElementById('TxtPrecio').value;
    cantidad = document.getElementById('TxtCantidad').value;
    PorceDescuento = document.getElementById('TxtDescuento').value;
    PorceIVA = document.getElementById('TxtIVA').value;

    if (PorceDescuento == "" && PorceIVA == "") {
        TotProducto = cantidad * precio;
    }
    else if (PorceDescuento != "" && PorceIVA == "") {
        mDescuento = ((cantidad * precio) * PorceDescuento) / 100;
        TotProducto = (cantidad * precio) - mDescuento;
    }
    else if (PorceDescuento == "" && PorceIVA != "") {
        mIVA = ((cantidad * precio) * PorceIVA) / 100;
        TotProducto = (cantidad * precio) + mIVA;
    }
    else if (PorceDescuento != "" && PorceIVA != "") {
        mDescuento = ((cantidad * precio) * PorceDescuento) / 100;
        PrecioProdConDescuento = (cantidad * precio) - mDescuento;

        mIVA = (PrecioProdConDescuento * PorceIVA) / 100;

        TotProducto = PrecioProdConDescuento + mIVA;
    }

    $('#TxtTotal').val(TotProducto);
}

// AGREGA LA LINEA DEL PRODUCTO A LA TABLA
$(document).on('click', '#BtnAgregarLinea', function (e) {
    e.preventDefault();

    if ($("#TxtCodProducto").val() != "") {
        tabla = $('#Tbl_CargaProductos').dataTable({
            retrieve: true,
            paging: false
        });

        var NuevaCantidad = 0, existe = false;
        var porceIva = 0;

        // PROCESO EN CASO DE QUE SEA EL PRIMER PRODUCTO
        if (cfilas == 0) {
            tabla.fnAddData([
                '<button id="EliminarLinea" title="Eliminar Linea" class="btn btn-danger btn-delet"> <i class="fa fa-trash"></i> </button>',
                $("#TxtCodProducto").val(),
                $("#TxtDetalle").val(),
                $("#TxtCantidad").val(),
                $("#TxtPrecio").val(),
                ($("#TxtDescuento").val() == "") ? 0 : $("#TxtDescuento").val(),
                mDescuento,
                ($("#TxtIVA").val() == 0) ? porceIva : $("#TxtIVA").val(),
                mIVA,
                $("#TxtTotal").val()
            ]);
            cfilas += 1;
        }
        // ------------ PROCESO EN CASO DE QUE YA EXISTA EL PRODUCTO -------------------------------
        else {
            // PROCESO PARA BUSCAR SI EXISTE EL CODIGO
            for (var i = 0; i < cfilas; i++) {
                // Vamos obteniendo los datos de la fila
                DatosTabla = tabla.fnGetData(i);
                //Validamos si el codigo a ingresar existe
                if (DatosTabla[1] == $("#TxtCodProducto").val()) {
                    existe = true;
                    var CantExistente = DatosTabla[3];
                    var Precio = DatosTabla[4];
                    var DescExistente = DatosTabla[6];
                    var IvaExistente = DatosTabla[8];
                    var TotalLineaExistente = DatosTabla[9];
                    nfila = i;
                }
            }
            // ------------ SI EXISTE EL CODIGO SE ACTUALIZA LAS CANTIDADES Y TOTALES DE LINEA -------------------------------
            if (existe) {
                // Actualiza la Cantidad
                NuevaCantidad = Number(CantExistente) + Number($("#TxtCantidad").val());
                tabla.fnUpdate(NuevaCantidad, nfila, 3, 0, false);

                // Actualiza la el Descuento               
                var NuevoDescuento = DescExistente + mDescuento;
                tabla.fnUpdate(NuevoDescuento, nfila, 6, 0, false);

                //Actualiza el IVA
                var NuevoIVA = IvaExistente + mIVA;
                tabla.fnUpdate(NuevoIVA, nfila, 8, 0, false);

                //Actualiza el Total
                var NuevoTotalLinea = Number(TotalLineaExistente) + Number(TotProducto);
                tabla.fnUpdate(NuevoTotalLinea, nfila, 9, 0, false);

                // se cambia a falso por que en el if del for no se implemento el else, para que no se ejecute tantas veces por si no se valida el if
                existe = false;
            }
            // ------------ SI NO EXISTE EL CODIGO DEL PRODUCTO, AGREGA LA INFORMACION A LA TABLA ------------------------------- 
            else {
                tabla.fnAddData([
                    '<button id="EliminarLinea" title="Eliminar Linea" class="btn btn-danger btn-delet"> <i class="fa fa-trash"></i> </button>',
                    $("#TxtCodProducto").val(),
                    $("#TxtDetalle").val(),
                    $("#TxtCantidad").val(),
                    $("#TxtPrecio").val(),
                    ($("#TxtDescuento").val() == "") ? 0 : $("#TxtDescuento").val(),
                    mDescuento,
                    ($("#TxtIVA").val() == 0) ? porceIva : $("#TxtIVA").val(),
                    mIVA,
                    $("#TxtTotal").val()
                ]);
                cfilas += 1;
            }
        }

        CalcularTotales(tabla, cfilas);
        $("#TxtCodProducto").val('');
        $("#TxtDetalle").val('');
        $("#TxtCantidad").val('1');
        $("#TxtPrecio").val('0.00');
        $("#TxtTotal").val('0.00');
        $("#TxtDescuento").val('');
        $("#TxtIVA").val('');

    }

    else {
        Swal.fire({
            icon: 'warning',
            title: 'Debe agregar un producto',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK',
        });
    }
    mDescuento = 0, mIVA = 0;
})

// ELIMINA FILA DE LA TABLA
$(document).on('click', '#EliminarLinea', function (e) {
    e.preventDefault();

    Swal.fire({
        title: 'Seguro de que quiere eliminar ésta linea?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.value) {
            var row = $(this).closest("tr").get(0);
            tabla.fnDeleteRow(tabla.fnGetPosition(row));
            cfilas -= 1;

            CalcularTotales(tabla, cfilas);
        }
    })
});

function CalcularTotales(tabla, cfilas) {
    var SubTotal = 0, SubTotalDescuento = 0, TotalFactura = 0, SubTotalIVA = 0;

    // PROCESO QUE LLENA LOS CAMPOS DE TOTALES
    for (var i = 0; i < cfilas; i++) {
        DatosTabla = tabla.fnGetData(i);

        var NuevoTotalProducto = Number(DatosTabla[3]) * Number(DatosTabla[4]);;

        SubTotal += NuevoTotalProducto;
        SubTotalDescuento += Number(DatosTabla[6]);
        SubTotalIVA += Number(DatosTabla[8]);
        TotalFactura += Number(DatosTabla[9]);
    }
    $('#TxtSubtotal').val(numeral(SubTotal).format('0,0.00'));
    $('#TxtMontoDescuento').val(numeral(SubTotalDescuento).format('0,0.00'));
    $('#TxtImpuesto').val(numeral(SubTotalIVA).format('0,0.00'));
    $('#TxtTotalFactura').val(numeral(TotalFactura).format('0,0.00'));
}

// ------------------ JS CARGA MODAL IMPUESTOS
$(document).on('click', '#BtnModalImpuestos', function (e) {
    e.preventDefault();
    CargaModalImpuestos();
});

// CARGA EL MODAL DE IMPUESTOS
function CargaModalImpuestos() {
    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/ListarImpuestos",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datas) {
            data = datas.d;
            tabla = $('#Tbl_ModalImpuestos').dataTable({
                "order": [[1, 'asc']],
                retrieve: true,
                paging: true
            });

            tabla.fnClearTable();

            for (var i = 0; i < data.length; i++) {
                tabla.fnAddData([
                    '<button id="BtnAgregarImpuesto" data-dismiss="modal" title="Agregar" class="btn btn-primary btn-agregar"> <i class="fa fa-plus-circle"></i> </button>&nbsp',
                    data[i].Id,
                    data[i].Name,
                    data[i].Porcentaje
                ]);
            }
        }
    });
}

// Se obtiene la seleccion del producto
$(document).on('click', '#BtnAgregarImpuesto', function (e) {
    e.preventDefault();
    // Boton - TR    -  TD
    r = $(this).parent().parent()[0];
    // De la tabla obtiene los datos de esa fila 
    var impuesto = tabla.fnGetData(r);

    $("#TxtIVA").val(impuesto[3]);
    tabla.fnClearTable();
    CalculaLinea();
});

// Cierre del modal de productos, del boton cerrar
$(document).on('click', '#BtnCerrarModalImpuestos', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
    $("#ModalImpuestos").modal('hide');
});

// Cierre del modal de productos, de la X
$(document).on('click', '#BtnXModalImpuestos', function (e) {
    e.preventDefault();
    tabla.fnClearTable();
});

// ------------------------------------------------------------ EVENTO FACTURAR - GUARDAR FACTURA --------------------------------------
var EncaVenta = new Array();
var DetaVenta = new Array();
// BOTON FACTURAR - CREA LOS ARRAYS
$(document).on('click', '#BtnFacturar', function (e) {
    // SI HAY DATOS EN LA TABLA HAGA
    if (tabla != null) {        
        e.preventDefault();

        EncaVenta.push({
            Action: 'I',
            UserID: 0,
            NumFact: 0,
            FechaFact: $("#TxtFecha").val(),
            ClientDNI: $('#TxtIdentificacion').val(),
            Plazo: Number($('#DiasCredito').val()),
            Moneda: $('#ddlMoneda').val(),
            MedioPago: $('#ddlMedioPago').val(),
            EstadoHacienda: "Aceptado",
            Enviada: "Si",
            Anulada: "No",
            Observaciones: $("#TxtObservaciones").val()
        });

        // OBTIENE LA CANTIDAD DE LINEAS DE LA TABLA
        var lineas = tabla[0].rows.length - 1;

        // CREA EL OBJETO PARA TODAS LAS LINEAS
        for (var i = 0; i < lineas; i++) {
            DatosTabla = tabla.fnGetData(i);
            var LVenta = i + 1;
            var CodProdu = DatosTabla[1];
            var NombreProdu = DatosTabla[2];
            var CantProdu = DatosTabla[3];
            var PrecProdu = DatosTabla[4];
            var PorceDesc = DatosTabla[5];
            var MontoDesc = DatosTabla[6];
            var PorceIva = DatosTabla[7];
            var MontoIva = DatosTabla[8];
            var TotalLineaExistente = DatosTabla[9];

            DetaVenta.push({
                LineaVenta: Number(LVenta),
                ProductID: CodProdu,
                Nombre: NombreProdu,
                Cantidad: Number(CantProdu),
                PrecioUnit: Number(PrecProdu),
                PorceDesc: Number(PorceDesc),
                MontDesc: Number(MontoDesc),
                PorceIVA: Number(PorceIva),
                MontIVA: Number(MontoIva),
                TotalLinea: TotalLineaExistente
            });
        }

        GuardarDatosFactura(EncaVenta, DetaVenta);

        // SI NO HAY DATOS EN LA TABLA ENVIE MENSAJE
    } else {
        e.preventDefault();
        Swal.fire({
            icon: 'error',
            title: "Oops...",
            text: 'No puedes generar una factura sin datos',

            showClass: {
                popup: 'animate__animated animate__bounceInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__bounceOutDown'
            }
        });
    }
});

// GUARDA LA INFORMACION
function GuardarDatosFactura(EncaVenta, DetaVenta) {
    $.ajax({
        type: "POST",
        url: "NuevaFactura.aspx/GuardarDatosFactura",
        data: JSON.stringify({ 'ObjEncaVenta': EncaVenta, 'ObjDetaVenta': DetaVenta }),
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            if (xhr.status = 500) {
                Swal.fire({
                    title: "Lo sentimos...",
                    text: 'Error interno, comunicate con el administrador y proporcionale estos datos: ' + xhr.responseJSON.Message,

                    showClass: {
                        popup: 'animate__animated animate__bounceInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__bounceOutDown'
                    }
                })
            }
            //console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (respuesta) {
            if (respuesta.d) {

                Swal.fire({
                    icon: "success",
                    title: "Datos Guardados",
                    confirmButtonText: "Generar Factura",
                    showClass: {
                        popup: 'animate__animated animate__bounceInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__bounceOutDown'
                    }
                }).then((result) => {
                    if (result.value) {                        
                        GenerarFactura(DetaVenta);
                    }
                });

            } else {
                Swal.fire({
                    icon: "error",
                    title: "ERROR",
                    text: 'FALSO',

                    showClass: {
                        popup: 'animate__animated animate__bounceInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__bounceOutDown'
                    }
                });
            }
        }
    });
}

// GENERA LA FACTURA
function GenerarFactura(DetaVenta) {
    $.ajax({
        type: "POST",
        url: "NuevaFactura.aspx/obtenerNFactura",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            if (xhr.status = 500) {
                Swal.fire({
                    title: "Lo sentimos...",
                    text: 'Error interno, comunicate con el administrador y proporcionale estos datos: ' + xhr.responseJSON.Message,

                    showClass: {
                        popup: 'animate__animated animate__bounceInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__bounceOutDown'
                    }
                })
            }
            //console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (respuesta) {
            if (respuesta.d != null) {
                //AGREGA LOS DATOS DEL EMISOR
                document.getElementById("NombreEmpresa").innerHTML = "PATITO'S S.A";
                document.getElementById("DireccionEmpresa").innerHTML = "Puntarenas, Puntarenas, Pitahaya, 50 metros al sur del Centro de Nutrición";
                document.getElementById("TelefonoEmpresa").innerHTML = "+506 8318-2537";
                document.getElementById("CorreoEmpresa").innerHTML = "faelectrocr@patitos.com";

                //AGREGA DATOS DE LA FACTURA
                document.getElementById("Numfactura").innerHTML = respuesta.d;
                document.getElementById("FchFactura").innerHTML = EncaVenta[0].FechaFact;
                document.getElementById("Moneda").innerHTML = EncaVenta[0].Moneda;
                document.getElementById("FechaVencimientoFact").innerHTML = "15/06/2020";
                document.getElementById("OrdeCompra").innerHTML = "OC";
                document.getElementById("FormaPago").innerHTML = EncaVenta[0].MedioPago;

                //AGREGA LOS DATOS DEL RECEPTOR
                document.getElementById("NombreCliente").innerHTML = document.getElementById("TxtNombre").value;
                document.getElementById("CedulaCliente").innerHTML = document.getElementById("TxtIdentificacion").value;
                document.getElementById("DireccionCliente").innerHTML = "Direccion";
                document.getElementById("TelefonoCliente").innerHTML = "+506 2661-1500";
                document.getElementById("CorreoCliente").innerHTML = document.getElementById("EmailCliente").innerHTML;

                //GENERA LA TABLA DE LA FACTURA PARA EL O LOS DETALLES
                var tablaFactura = $('#Tbl_Factura').dataTable({
                    retrieve: true,
                    paging: false
                });

                //AGREGA EL O LOS DETALLES A LA TABLA DE LA FACTURA  -- tabla[0].rows.length - 1
                for (var x = 0; x < DetaVenta.length; x++) {
                    tablaFactura.fnAddData([
                        DetaVenta[x].ProductID,
                        DetaVenta[x].Nombre,
                        DetaVenta[x].Cantidad,
                        DetaVenta[x].PrecioUnit,
                        DetaVenta[x].PorceDesc,
                        DetaVenta[x].MontDesc,
                        DetaVenta[x].PorceIVA,
                        DetaVenta[x].MontIVA,
                        DetaVenta[x].TotalLinea
                    ]);
                }

                //AGREGA LOS TOTALES
                $('#TxtModalSubtotal').val(document.getElementById("TxtSubtotal").value);
                $('#TxtModalDescuento').val(document.getElementById("TxtMontoDescuento").value);
                $('#TxtModalIVA').val(document.getElementById("TxtImpuesto").value);
                $('#TxtModalTotal').val(document.getElementById("TxtTotalFactura").value);

                document.getElementById('ModalFactura').style.textAlign = "left";
                document.getElementById('ModalFactura').style.height = "auto";
                $('#BtnFacturar').attr('data-target', '#ModalFactura');
                $('#ModalFactura').modal("show");

            } else {
                Swal.fire({
                    icon: "error",
                    title: "Ops...",
                    text: 'NO SE PUEDE OBTENER EL NUMERO DE LA FACTURA',

                    showClass: {
                        popup: 'animate__animated animate__bounceInDown'
                    },
                    hideClass: {
                        popup: 'animate__animated animate__bounceOutDown'
                    }
                });
            }
        }
    });
}

$(document).on('click', '#BtnEnviarFact', function (e) {
    window.location = 'NuevaFactura.aspx';
});