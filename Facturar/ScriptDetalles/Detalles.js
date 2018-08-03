/////////////////////////Identificar el area de maestro detalle//////////

var error = document.getElementById("error").innerHTML;

if (error === "false") {
    alert("El Tickect Intoducido Es Incorrecto");

}

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Detalles/Edit/" + $(this).data("id"));

})