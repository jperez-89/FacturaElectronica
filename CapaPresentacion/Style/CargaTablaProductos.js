// FUNCION DEL BUSCADOR DE LA TABLA
(function (document) {
    'use strict';

    var LightTableFilter = (function (Arr) {

        var _input;

        function _onInputEvent(e) {
            _input = e.target;
            var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
            Arr.forEach.call(tables, function (table) {
                Arr.forEach.call(table.tBodies, function (tbody) {
                    Arr.forEach.call(tbody.rows, _filter);
                });
            });
        }

        function _filter(row) {
            var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
            row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
        }

        return {
            init: function () {
                var inputs = document.getElementsByClassName('light-table-filter');
                Arr.forEach.call(inputs, function (input) {
                    input.oninput = _onInputEvent;
                });
            }
        };
    })(Array.prototype);

    document.addEventListener('readystatechange', function () {
        if (document.readyState === 'complete') {
            LightTableFilter.init();
        }
    });

})(document);

// CARGA LOS DATOS DE LA TABLA BUSCAR PRODUCTOS
function AgregarFilasTablaProductos(data) {
    var template = "";
    for (var i = 0; i < data.length; i++) {
        template += "<tr>";
        template += ("<td>" + data[i].Id + "</td>");
        template += ("<td>" + data[i].ProductId + "</td>");
        template += ("<td>" + data[i].name + "</td>");
        template += ("<td>" + data[i].measure + "</td>");
        template += ("<td>" + data[i].unitPriceC + "</td>");
        template += ("<td>" + data[i].unitPriceD + "</td>");
        template += ("<td>" + ((data[i].CategoryID == 1) ? "Producto" : "Servicio") + "</td>");
        template += ("<td>" + ((data[i].state == true) ? "Activo" : "Inactivo") + "</td>");
        template += ("<td>" + "<a href='#'><img class='btn btn-circle' src='Style/img/editarcliente.jpg' title='Editar'/></a>" +
                              "<a href='#'><img class='btn btn-circle' src='Style/img/eliminarcliente.png' title='Eliminar'/></a>" + "</td>");
        template += "</tr>";
    }

    $('#tbl_body_Productos').append(template);
}

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "BuscarProducto.aspx/MostrarProductos",
        data: {},
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
        },
        success: function (data) {
            //console.log(data);
            AgregarFilasTablaProductos(data.d);
        }
    });
});