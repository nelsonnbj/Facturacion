$("#addToList").click(function (e) {
    e.preventDefault();
    var area = document.getElementById("AreaBurrito").innerHTML;


    if ($.trim(document.getElementById("producto").value) == "" || $.trim(document.getElementById("cantidad").value) == "") return;

    var IdProductos = document.getElementById("producto").value,
        cantidad = document.getElementById("cantidad").value,

        comentario = document.getElementById("ComentarioAgregado").value,
        monto = 0,
        BurritoTableBody = $("#BurritoTable tbody");

    var url = $('#agregar').data('request-url');
    if (area == "areaBurritos") {
        $.get(url, { producto: document.getElementById("producto").value }, function (data) {
            $("#precio").empty();

            monto = data.Monto;
            tipo = data.Tipos;
            var IdProducto = data.id;
            var productItem = '<tr><td>' + IdProductos + '</td><td>' + cantidad + '</td><td class="ocultarComentario">' + comentario + '</td><td>' + (parseFloat(cantidad) * parseInt(monto)) + '</td><td hidden>' + tipo + '</td><td hidden>' + IdProducto + '</td><td  class="ocultarComentario"><a data-itemid="0" href="#" class="deleteItem"style="color:red">Eliminar</a></td></tr>';
            BurritoTableBody.append(productItem);
            CalculoTotal();
            ///////////////////////Muestra la tabla de pedidos//////////
            document.getElementById("tablaSegundaria").hidden = false;

            clearItem();


        });
    }
});

//After Click Save Button Pass All Data View To Controller For Save Database
function SaveOrder(data) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Facturas/SaveOrder",
        data: data,
    });

}

//Collect Multiple Order List For Pass To Controller
$("#SaveBurritos").click(function (e) {
    e.preventDefault();

    var orderArr = [];
    orderArr.length = 0;
    var tipoServicio = "Comer Aqui"
    if (document.getElementById("tipoServicioB").checked) {
        tipoServicio = "Empacar"
    }
    $.each($("#BurritoTable tbody tr"), function () {
        orderArr.push({
            producto: $(this).find('td:eq(0)').html(),
            cantidad: $(this).find('td:eq(1)').html(),
            comenatrio: $(this).find('td:eq(2)').html(),
            precio: $(this).find('td:eq(3)').html(),
            tipoproducto: $(this).find('td:eq(4)').html(),
            idproducto: $(this).find('td:eq(5)').html(),
        });
    });


    var data = JSON.stringify({
        name: "B",
        servicio: tipoServicio,
        address: $("#producto").val(),
        order: orderArr
    });

    $.when(SaveOrder(data)).then(function (response) {
        var turno = response.ticket;
        document.getElementById("turnoburrito").innerHTML = turno;
        window.print();
        limpiar();
        alertify.success("Pedido Facturado");

    }).fail(function (err) {
        console.log(err);
    });

});

////////Metodo que actualiza la Tabla y los Montos////////////
function limpiar() {
    document.getElementById("tablaSegundaria").hidden = true;
    $('#BurritoTable tbody').children().remove();

    menos = document.getElementById("Burritos").innerHTML;
    totales = document.getElementById("Total").innerHTML;
    document.getElementById("Burritos").innerHTML = 0;
    document.getElementById("Total").innerHTML = (parseInt(totales) - parseInt(menos));

}

/////////Metodo que agrega el producto al menu de pedidos/////////

$(".em-img-lazy").click(function () {
    var $instance = $(this);
    var nuevoProducto = $instance.attr("data-estado") || 0;
    document.getElementById("producto").value = nuevoProducto;
});