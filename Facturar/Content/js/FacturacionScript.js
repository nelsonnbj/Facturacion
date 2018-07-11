﻿

$("#chimi").click(function () {
        document.getElementById("producto").value = "Chmi";
});

$("#pierna").click(function () {
    document.getElementById("producto").value = " Chimi Pierna";
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
    document.getElementById("producto").value = " Chimi Pechuga";
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
    document.getElementById("producto").value = " Hamburger Pechuga";
});
$("#Hambuerger_pierna").click(function () {
    document.getElementById("producto").value = " Hamburger Pierna";
});


//Add Multiple Order.
$("#addToList").click(function (e) {
    e.preventDefault();


    if ($.trim(document.getElementById("producto").value) == "" || $.trim(document.getElementById("cantidad").value) == "" || $.trim(document.getElementById("cliente").value) == "") return;
   
    var producto = document.getElementById("producto").value,
        cantidad = document.getElementById("cantidad").value,
        cliente = document.getElementById("cliente").value,
        detailsTableBody = $("#detailsTable tbody");

    var productItem = '<tr><td>' + producto + '</td><td>' + cantidad + '</td><td>' + cliente + '</td><td>' + (parseFloat(cantidad) * parseInt('2')) + '</td><td><a data-itemid="0" href="#" class="deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(productItem);
    clearItem();
});


//After Add A New Order In The List, Clear Clean The Form For Add More Order.
function clearItem() {
    producto = document.getElementById("producto").value="";
    document.getElementById("cantidad").value="";

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
        success: function (result) {
            alert(result);
            location.reload();
        },
        error: function () {
            alert("Error!")
        }
    });
}
 //Collect Multiple Order List For Pass To Controller
        $("#saveOrder").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                orderArr.push({
                    producto: $(this).find('td:eq(0)').html(),
                    cantidad: $(this).find('td:eq(1)').html(),
                    cliente: $(this).find('td:eq(2)').html(),
                    amount: $(this).find('td:eq(3)').html()
                });
            });


            var data = JSON.stringify({
                name: $("#cliente").val(),
                address: $("#producto").val(),
                order: orderArr
            });

            $.when(saveOrder(data)).then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
