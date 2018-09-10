

$("#chimi").click(function () {
    document.getElementById("producto").value = "Chimi";
});

$("#pierna").click(function () {
    document.getElementById("producto").value = "Chimi Pierna";
});

$("#baconcheese").click(function () {
    document.getElementById("producto").value = "Bacon Cheese";
});

$("#pablo").click(function () {
    document.getElementById("producto").value = "Chimi Pablo";
});

$("#locotron").click(function () {
    document.getElementById("producto").value = "Rubio Burger";
});

$("#Chimi_pechuga").click(function () {
    document.getElementById("producto").value = "Chimi Pechuga";
});

$("#Chimi_DobleCarne").click(function () {
    document.getElementById("producto").value = "Chimi Doble Carne";
});

$("#Pechuga_Empanizada").click(function () {
    document.getElementById("producto").value = "Pechuga Empanizada";
});

$("#Hamburger_Res").click(function () {
    document.getElementById("producto").value = "Hamburger De Res";
});

$("#Hambuerger_pechuga").click(function () {
    document.getElementById("producto").value = "Hamburger Pechuga";
});
$("#Hambuerger_pierna").click(function () {
    document.getElementById("producto").value = "Hamburger Pierna";
});


//$("#producto").change(function () {
//    var url = $('#agregar').data('request-url');
//    $.get(url, { productos: $("#producto").val() }, function (data) {
//        $("#precio").empty();
//        $.each(data, function (index, row) {
//            $("#precio").append("<option value='" + row.precio + "'>" + row.precio + "</option>")
//        });

//    });
//})

//Add Multiple Order.


///////////////Validar area//////////////

$("#areaBurritos").click(function () {
    document.getElementById("AreaBurrito").innerHTML = "areaBurritos";
    document.getElementById("producto").value = "";
});

$("#areaChimi").click(function () {
    document.getElementById("AreaBurrito").innerHTML = "";
    document.getElementById("producto").value = "";
});

$("#addToList").click(function (e) {
    e.preventDefault();

    if ($.trim(document.getElementById("producto").value) === "" || $.trim(document.getElementById("cantidad").value) === "") return;

    var producto = document.getElementById("producto").value,
        cantidad = document.getElementById("cantidad").value,

        comentario = document.getElementById("ComentarioAgregado").value,
        monto = 0,
        detailsTableBody = $("#detailsTable tbody");

    var url = $('#agregar').data('request-url');
    area = document.getElementById("AreaBurrito").innerHTML;
    if (area !== "areaBurritos") {
        $.get(url, { producto: document.getElementById("producto").value }, function (data) {
            $("#precio").empty();
            var IdProducto = data.id;
            var monto = data.Monto;
            var tipo = data.Tipos;

            var productItem = '<tr><td>' + producto + '</td><td>' + cantidad + '</td><td>' + comentario + '</td><td>' + (parseFloat(cantidad) * parseInt(monto)) + '</td><td hidden>' + tipo + '</td><td hidden>' + IdProducto + '</td><td><a data-itemid="0" href="#" class="deleteItem">Remove</a></td></tr>';
            detailsTableBody.append(productItem);
            ///////////////////////Muestra la tabla de pedidos//////////
            document.getElementById("tablaPricipal").hidden=false;


            ////////////////////////////Calcula el Total de Chimi///////////


            var total = (parseFloat(cantidad) * parseInt(monto));
            var montoTotal = document.getElementById("Chimi").innerHTML;
            document.getElementById("Chimi").value = "";
            if (montoTotal != "") {
                document.getElementById("Chimi").innerHTML = (parseInt(montoTotal) + parseInt(total));

            }
            else {
                document.getElementById("Chimi").innerHTML = total;
            }
            clearItem();




            //////////////////////Calcula el Total de Todas las Cuentas//////////////////
            burritoTotal = document.getElementById("Burritos").innerHTML;
            chimiTotal = document.getElementById("Chimi").innerHTML;
            if (burritoTotal == "") {

                document.getElementById("Total").innerHTML = chimiTotal;
            }

            else {
                document.getElementById("Total").innerHTML = (parseInt(burritoTotal) + parseInt(chimiTotal))
            }
        });
    }
});


//After Add A New Order In The List, Clear Clean The Form For Add More Order.
function clearItem() {
    producto = document.getElementById("producto").value = "";
    document.getElementById("cantidad").value = "";
    document.getElementById("ComentarioAgregado").value = "";

}

// After Add A New Order In The List, If You Want, You Can Remove It.
$(document).on('click', 'a.deleteItem', function (e) {
    e.preventDefault();
    var $self = $(this);
    if ($(this).attr('data-itemId') == "0") {
        $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
            $(this).remove();
        });
    }
});

//After Click Save Button Pass All Data View To Controller For Save Database
function saveOrder(data) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Facturas/SaveOrder",
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
$("#saveOrder").click(function (e) {
    e.preventDefault();

    var orderArr = [];
    orderArr.length = 0;
    var tipoServicio = "Comer Aqui"
    if (document.getElementById("tipoServicio").checked) {
        tipoServicio = "Empacar"
    }

    $.each($("#detailsTable tbody tr"), function () {
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
        name: "Chimi",
        servicio: tipoServicio,
        address: $("#producto").val(),
        order: orderArr
    });

    $.when(saveOrder(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });

    alertify.success("Pedido Facturado");
    limpia()
   


    menos = document.getElementById("Chimi").innerHTML;
    totales = document.getElementById("Total").innerHTML;
    document.getElementById("Chimi").innerHTML = 0;
    document.getElementById("Total").innerHTML = (parseInt(totales) - parseInt(menos));
});


    ////////Metodo que actualiza la Tabla y los Montos////////////
function limpia() {
    document.getElementById("tablaPricipal").hidden = true;
    $('#detailsTable tbody').children().remove();
    menos = document.getElementById("Chimi").innerHTML;
    totales = document.getElementById("Total").innerHTML;
    document.getElementById("Chimi").innerHTML = 0;

    document.getElementById("Total").innerHTML = (parseInt(totales) - parseInt(menos));
}
/////////////////////////Agregar Comentario////////////////

$("#cebolla").click(function () {
    var texto = document.getElementById("Comentario").value;

    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Cebolla" + " / ";
    }
});


$("#tomaste").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Cebolla" + " / ";
    }
});


$("#repollo").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Repollo" + " / ";
    }
});

$("#catchut").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Ketchup" + " / ";
    }
});

$("#mayonesa").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Mayonesa" + " / ";
    }
});

$("#picante").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Picante" + " / ";
    }
});

$("#mostaza").click(function () {
    var texto = document.getElementById("Comentario").value;
    if (this.checked) {

    }
    else {
        document.getElementById("Comentario").value = texto + "Sin Mostaza" + " / ";
    }
});

///////////////////////FUNCION UTILIZADA PARA AGREGAR EL COMENTARIO A LA LISTA ///////////
function agregarComentario() {
    var comentario = document.getElementById("Comentario").value;
    document.getElementById("ComentarioAgregado").value = comentario;

    actualizarChbox();
    //var restorepage = document.body.innerHTML;
    //$('#ocultar1').attr('hidden', true);
    //$('#ocultar2').attr('hidden', true);
    //window.print();
    //document.body.innerHTML = restorepage;
}

////////////////////////FUNCION QUE LIMPIA LOS CHECHKBOX///////////////

function actualizarChbox() {
    document.getElementById("cebolla").checked = true;
    document.getElementById("tomaste").checked = true;
    document.getElementById("repollo").checked = true;
    document.getElementById("catchut").checked = true;
    document.getElementById("mayonesa").checked = true;
    document.getElementById("picante").checked = true;
    document.getElementById("mostaza").checked = true;
    document.getElementById("Comentario").value = "";

}

////////////Validar Cantidad////////////////

$("#cantidad").change(function () {

    var cantidad = $('#cantidad').val();
    if (cantidad <= 0) {
        alertify.error("La Cantidad debe ser mayor a 0");
        return false;
    }

    if (cantidad % 1 !== 0) {
        alertify.error("La Cantidad Debe Ser Entero");
        return false;
    }

    else {
        return true;

    }
});
//////////////////////Cambia el estatus del pedido//////////
//$(':checkbox[type=checkbox]').on("click", function ()
//$(':checkbox[type=checkbox]').on("click", function () {
//    if (document.getElementById("checkbo").checked) {
//        var url = $('#agregar').data('request-url');
//        $.post(url, { Codigo: "cancelado" });
//        var int = self.setInterval("refresh()", 1000);
//    }

//    else {
//        var url = $('#agregar').data('request-url');
//        $.post(url, { Codigo: "activado" });
//        var int = self.setInterval("refresh()", 1000);
//    }
//});

//function refresh() {
//    location.reload(true);
//}
/////////////////////////Identificar el area de maestro detalle//////////
var detalle = $("#detalles").val();
if (detalle == "") {
    var error = document.getElementById("error").innerHTML;
}
if (error === "false") {
    alert("El Tickect Intoducido Es Incorrecto");

}

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Detalles/Edit/" + $(this).data("id"));

})

function imprimir() {
    window.print;
};


////////////Metodo que calcula el cambio a devolver/////////////
function calculo1() {
    var monto= document.getElementById("Chimi").innerHTML;
    document.getElementById("cantida").innerHTML = monto;
}

function calculo2() {
    var monto = document.getElementById("Burritos").innerHTML;
    document.getElementById("cantida").innerHTML = monto;
}
function calculo3() {
    var monto = document.getElementById("Total").innerHTML;
    document.getElementById("cantida").innerHTML = monto;
}

$("#Comentari").change(function () {

    var pago = document.getElementById("cantida").innerHTML;
    var montos = document.getElementById("Comentari").value;
    var total = parseInt(montos) - parseInt(pago)
    document.getElementById("cambio").innerHTML = total;
});

function clearCalculo() {
    document.getElementById("cambio").innerHTML = "";
    document.getElementById("Comentari").value = "";
}