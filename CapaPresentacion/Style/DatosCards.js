//Llenar cantidad de Clientes
function CargaCantClientes() {
    $.ajax({
        type: "POST",
        url: "Inicio.aspx/ListarCantClientes",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datas) {
            data = datas.d;
            $('#CantClientes').val(data);
        }
    });
}

//Llenar cantidad de Productos
function CargaCantProductos() {
    $.ajax({
        type: "POST",
        url: "Inicio.aspx/ListarCantProductos",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (datas) {
            data = datas.d;
            $('#CantProductos').val(data);
        }
    });
}

CargaCantProductos();
CargaCantClientes();