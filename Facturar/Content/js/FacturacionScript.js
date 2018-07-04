
//$(document).ready(function () {

//    var chimis = $("#chimi");

//   chimis.click(function () {
//       document.getElementById("#producto").innerHTML = "Chmi";

//    });
//});


//Add Multiple Order.
$("#addToList").click(function (e) {
    e.preventDefault();

    if ($.trim($("#produco").val()) == "" || $.trim($("#cantida").val()) == "" || $.trim($("#cliente").val()) == "") return;

    var producto = $("#produco").val(),
       cantidad = $("#cantida").val(),
       cliente = $("#cliente").val(),
        detailsTableBody = $("#detailsTable tbody");

    var productItem = '<tr><td>' + producto + '</td><td>' + cantidad + '</td><td>' + cliente + '</td><td>' + (parseFloat(cantidad) * parseInt('2')) + '</td><td><a data-itemid="0" href="#" class="deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(productItem);
    clearItem();
});


//After Add A New Order In The List, Clear Clean The Form For Add More Order.
//function clearItem() {
//    $("#productName").val('');
//    $("#price").val('');
//    $("#quantity").val('');
//}

// After Add A New Order In The List, If You Want, You Can Remove It.
//$(document).on('click', 'a.deleteItem', function (e) {
//    e.preventDefault();
//    var $self = $(this);
//    if ($(this).attr('data-itemId') == "0") {
//        $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
//            $(this).remove();
//        });
//    }
//});

//After Click Save Button Pass All Data View To Controller For Save Database
//function saveOrder(data) {
//    return $.ajax({
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        type: 'POST',
//        url: "/Home/SaveOrder",
//        data: data,
//        success: function (result) {
//            alert(result);
//            location.reload();
//        },
//        error: function () {
//            alert("Error!")
//        }
//    });
//}