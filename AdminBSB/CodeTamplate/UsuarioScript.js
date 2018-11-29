$(".ModalEditar").click(function (eve) {
    $('#myInput').focus()
    $(".modal-body").load("/Usuarios/Edit/" + $(this).data("id"));
})

$("button[name='eliminarUser']").click(function () {
    var Id = $(this).val();

    swal({
        title: "Estas Seguro de Eliminarlo?",
        text: "Tu No Prodras Volver a Recuperar Este Usuario!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Eliminado!",
        cancelButtonText: "No, Cancelar!",
        closeOnConfirm: false,
        closeOnCancel: false
    },

        function (isConfirm) {


            if (isConfirm) {

                var url = $("#Usuarios").data('url');

                $.post(url, { id: Id })
                    .fail(function (req) {
                        console.log(req);
                        swal("Error!", "Se Produjo Un Error Al Momento De Elimnarlo.", "error");

                    }).done(function () {
                        swal("Eliminado!", "El Usuario Ha Sido Eliminado.", "success");

                    });


            } else {
                swal("Cancelado", "El  USuario Ha Sido Salvado :)", "error");
            }
        });
});

function RoleCrear() {
    var role = $("#imputRole").val();
    
    var url = $('#agregar').data('request-url');
    $.get(url, { name: role }, function (response) {
        if (response.result == "Success!") {
            document.getElementById("imputRole").value = "";
            alertify.success("Correctamente agregado")
        }
        else {
            alertify.error("Error al momento de agregar");
        }


    }).fail(function (err) {
        alertify.error("Error En La Facturacion");
    });
}

function showRole() {
    document.getElementById("CrearRoles").style.display = "block";
}
