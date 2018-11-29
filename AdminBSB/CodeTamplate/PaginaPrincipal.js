$(".btnCuadre").click(function (eve) {
    $("#modal-content").load("/Gastos/Cuadre");

});

$("button[name='Datos']").click(function () {
    swal({
        title: "Estas Seguro de Realizar el Cierre?",
        text: "Tu No Prodras Volver a Recuperar Estos Datos!",
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

                var url = $("#Acciones").data('url');

                $.post(url)
                    .fail(function (req) {
                        console.log(req);
                        swal("Error!", "Se Produjo Un Error Al Momento De Realizar El Cierre.", "error");

                    }).done(function () {
                        swal("Eliminado!", "El Cierre Se ha realizado Exitosamnete.", "success");

                    });


            } else {
                swal("Cancelado", "Datos Salvado :)", "error");
            }
        });
});

function Imprimir() {
    window.print();
}

