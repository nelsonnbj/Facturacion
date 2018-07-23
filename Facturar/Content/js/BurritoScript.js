$("#addToList").click(function (e) {
    e.preventDefault();
    area = document.getElementById("AreaBurrito").innerHTML;

    
    if ($.trim(document.getElementById("producto").value) == "" || $.trim(document.getElementById("cantidad").value) == "" || $.trim(document.getElementById("cliente").value) == "") return;

    var IdProducto = document.getElementById("producto").value,
        cantidad = document.getElementById("cantidad").value,
        cliente = document.getElementById("cliente").value,
        comentario = document.getElementById("ComentarioAgregado").value,
        monto = 0,
        BurritoTableBody = $("#BurritoTable tbody");

    var url = $('#agregar').data('request-url');
    if (area == "areaBurritos") {
    $.get(url, { producto: document.getElementById("producto").value }, function (data) {
        $("#precio").empty();

        monto = data;


        var productItem = '<tr><td>' + IdProducto + '</td><td>' + cantidad + '</td><td>' + comentario + '</td><td>' + cliente + '</td><td>' + (parseFloat(cantidad) * parseInt(monto)) + '</td><td><a data-itemid="0" href="#" class="deleteItem">Remove</a></td></tr>';
        BurritoTableBody.append(productItem);

 
        ////////////////////////////Calcula el Total de Burrito///////////
       

            var total = (parseFloat(cantidad) * parseInt(monto));
            var montoTotal = document.getElementById("Burritos").innerHTML;
        document.getElementById("Burritos").value = "";

            if (montoTotal != "") {
                document.getElementById("Burritos").innerHTML = (parseInt(montoTotal) + parseInt(total));

            }
            else {
                document.getElementById("Burritos").innerHTML = total;
            }
            clearItem();

            //////////////////////Calcula el Total de Todas las Cuentas//////////////////
            burritoTotal = document.getElementById("Burritos").innerHTML;
            chimiTotal = document.getElementById("Chimi").innerHTML;

            if (chimiTotal == "") {
                document.getElementById("Total").innerHTML = burritoTotal;
            }

            else {
                document.getElementById("Total").innerHTML = (parseInt(burritoTotal) + parseInt(chimiTotal))
            }
    });
    }
});


//After Click Save Button Pass All Data View To Controller For Save Database
function SaveBurritos(data) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Facturas/SaveBurritos",
        data: data,

      
        //success: function (result) {
        //    alert(result);
        //    location.reload();
        //},
        //error: function () {
        //    alert("Error!")
        //}
    });
    
}

//Collect Multiple Order List For Pass To Controller
$("#SaveBurritos").click(function (e) {
    e.preventDefault();

    var orderArr = [];
    orderArr.length = 0;

    $.each($("#BurritoTable tbody tr"), function () {
        orderArr.push({
            IdProducto: $(this).find('td:eq(0)').html(),
            cantidad: $(this).find('td:eq(1)').html(),
            comenatrio: $(this).find('td:eq(2)').html(),
            nombre: $(this).find('td:eq(3)').html(),
            precio: $(this).find('td:eq(4)').html()
        });
    });


    var data = JSON.stringify({
        name: $("#cliente").val(),
        address: $("#producto").val(),
        orders: orderArr
    });

    $.when(SaveBurritos(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
        });
    alertify.success("Agregado");
    limpiar();
    //window.print();

});

////////Metodo que actualiza la Tabla y los Montos////////////
function limpiar() {
    $('#detailsTable tbody').children().remove();

    menos = document.getElementById("Burritos").innerHTML;
    totales = document.getElementById("Total").innerHTML;
    document.getElementById("Burritos").innerHTML = "";
    document.getElementById("Total").innerHTML = (parseInt(totales) - parseInt(menos));
}