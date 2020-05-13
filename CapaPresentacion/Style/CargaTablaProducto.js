var tabla, data, r, btn1, btn;

function AddData(data) {
    tabla = $('#tbl_Productos').dataTable();

    for (var i = 0; i < data.length; i++) {
        if (data[i].state == true) {
            btn1 = '<button data-target="#imodal" data-toggle="modal" id="edit" title="Editar" class="btn btn-primary btn-edit"> <i class="fa fa-pen"></i> </button>&nbsp;';
            btn = '<button id="delet" title="Eliminar" class="btn btn-danger btn-delet"> <i class="fa fa-trash"></i> </button>';
        } else if (data[i].state == false) {
            btn1 = '<button disabled="false" data-target="#imodal" data-toggle="modal" id="edit" title="Editar" class="btn btn-primary btn-edit"> <i class="fa fa-pen"></i> </button>&nbsp;';
            btn = '<button id="active" title="Activar" class="btn btn-success btn-active"> <i class="fa fa-sync-alt"></i> </button>';
        }

        tabla.fnAddData([
            data[i].Id,
            data[i].ProductId,
            data[i].name,
            data[i].measure,
            Number(data[i].unitPriceC),
            Number(data[i].unitPriceD),
            ((data[i].CategoryID == 1) ? "Producto" : "Servicio"),
            ((data[i].state == true) ? "Activo" : "Inactivo"),
            btn1 +
            btn
        ]);
    }
}

function SendAjax() {
    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/MostrarProductos",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (data) {
            //console.log(data.d);
            AddData(data.d);
        }
    });
}

// Actualizar Producto
$(document).on('click', '#edit', function (e) {
    e.preventDefault();
    // Boton - TR    -  TD
    r = $(this).parent().parent()[0];
    // De la tabla obtiene los datos de esa fila 
    data = tabla.fnGetData(r);
    // Imprime la posicion 1 del array, o sea, el Codigo del Producto
    LlenarModal();
});

// Eliminar Producto
$(document).on('click', '#delet', function (e) {
    e.preventDefault();
    r = $(this).parent().parent()[0];
    data = tabla.fnGetData(r);
    //var Codigo = JSON.stringify({ Codigo: data[1] })

    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/EliminarProducto",
        data: JSON.stringify({ ProductId: data[1] }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (response) {
            if (response.d) {
                Swalert("Eliminado correctamente", "warning", "zoomIn")
            } else {
                Swalert("No se Eliminó", "danger", "zoomIn")
            }
        }
    });
});

//Activar Producto
$(document).on('click', '#active', function (e) {
    e.preventDefault();
    r = $(this).parent().parent()[0];
    data = tabla.fnGetData(r);
    //var DNI = JSON.stringify({ DNI: data[1] })

    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/ActivarProducto",
        data: JSON.stringify({ ProductId: data[1] }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (response) {
            if (response.d) {
                Swalert("Producto Activado", "success", "zoomIn")
            } else {
                Swalert("No se activo", "danger", "zoomIn")
            }
        }
    });
});

// Cargar datos en el modal
function LlenarModal() {
    $("#TxtCodigoProducto").val(data[1]);
    $("#TxtDescripcion").val(data[2]);
    $("#ddlUnidadMedida").val(data[3]);
    $("#TxtPrecioColon").val(data[4]);
    $("#TxtPrecioDolar").val(data[5]);
}

// Enviar datos actualizados al servidor
$(document).on('click', '#btnactualizar', function (e) {
    e.preventDefault();
    ActualizarProducto();
});

// FUNCION DE ACTUALIZAR PRODUCTO
function ActualizarProducto() {
    var obj = JSON.stringify({
        ProductId: $("#TxtCodigoProducto").val(),
        Name: $("#TxtDescripcion").val(),
        Measure: $("#ddlUnidadMedida").val(),
        PriceC: $("#TxtPrecioColon").val(),
        PriceD: $("#TxtPrecioDolar").val()
    });

    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/ActualizarProducto",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (response) {
            if (response.d) {
                Swalert("Actualizado correctamente", "success", "zoomIn")
            } else {
                Swalert("No se actualizo", "danger", "zoomIn")
            }
        }
    });
}

// CARGAR LOS DATOS A LA TABLA
SendAjax();