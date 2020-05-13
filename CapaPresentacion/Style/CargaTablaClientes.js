var tabla, data, r, DNI, btn1, btn;

function AddData(data) {
    tabla = $('#tbl_Clientes').dataTable();

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
            data[i].DNI,
            data[i].name,
            data[i].phone,
            data[i].email,
            ((data[i].state == true) ? "Activo" : "Inactivo"),
            btn1 +
            btn
        ]);
    }
}

function SendAjax() {
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/MostrarClientes",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (data) {
            AddData(data.d);
            //console.log(data.d)
        }
    });
}

// Actualizar Cliente
$(document).on('click', '#edit', function (e) {
    e.preventDefault();
        // Boton - TR    -  TD
    r = $(this).parent().parent()[0];
    // De la tabla obtiene los datos de esa fila 
    data = tabla.fnGetData(r);
    // Envia el numero de cedula a la funcion
    LlenarModal(data[1]);
});

// Eliminar Cliente
$(document).on('click', '#delet', function (e) {
    e.preventDefault();
    r = $(this).parent().parent()[0];
    data = tabla.fnGetData(r);
    var DNI = JSON.stringify({DNI: data[1]})

    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/EliminarCliente",
        data: DNI,
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

//Activar Cliente
$(document).on('click', '#active', function (e) {
    e.preventDefault();
    r = $(this).parent().parent()[0];
    data = tabla.fnGetData(r);
    var DNI = JSON.stringify({ DNI: data[1] })

    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/ActivarCliente",
        data: DNI,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (response) {
            if (response.d) {
                Swalert("Cliente Activado", "success", "zoomIn")
            } else {
                Swalert("No se activo", "danger", "zoomIn")
            }
        }
    });
});

// Cargar datos en el modal
function LlenarModal(DNI) {
    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/MostrarClientes",
        data: {},
        //dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datos) {
            // Busca y Valida el numero de cedula para mostrar los datos en el modal
            for (var i = 0; i < datos.d.length; i++) {
                if (datos.d[i].DNI == DNI) {
                    $("#TxtIdentificacion").val(datos.d[i].DNI);
                    $("#TxtNombre").val(datos.d[i].name);
                    $("#TxtTelefono").val(datos.d[i].phone);
                    $("#TxtEmail").val(datos.d[i].email);
                    $("#ddlDistrito").val(datos.d[i].districtID);
                    $("#TxtDireccion").val(datos.d[i].direction);
                }
            }
        }
    });
}

// Enviar datos actualizados al servidor
$(document).on('click', '#btnactualizar', function (e) {
    ActualzarCliente();
});

// FUNCION DE ACTUALIZAR CLIENTE
function ActualzarCliente() {
    var obj = JSON.stringify({
        TypeDNI: $("#ddlTipoIdentificacion").val(),
        DNI: $("#TxtIdentificacion").val(),
        Name: $("#TxtNombre").val(),
        Phone: $("#TxtTelefono").val(),
        Email: $("#TxtEmail").val(),
        District: $("#ddlDistrito").val(),
        Direction: $("#TxtDireccion").val()
    });

    $.ajax({
        type: "POST",
        url: "BuscarCliente.aspx/ActualizarCliente",
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

// CARGA LOS DATOS A LA TABLA
SendAjax();