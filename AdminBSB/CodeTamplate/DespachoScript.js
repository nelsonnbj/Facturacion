﻿

   var secondsToRefresh = 60;
            var interval = setInterval(function () {
                location.reload(true);
            }, secondsToRefresh * 1000);

$("a[name='despacharPedidod']").click(function () {
    var url = $(this).data('url');
    swal({
        title: "Estas Sguro de Despacharlo?",
        text: "Despachar Pedido",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true,
    },


        function (isConfirm) {
            if (isConfirm) {
              
                $.post(url)
                    .fail(function (req) {
                        swal("Error!", "Se Produjo Un Error Al Momento De Despachar.", "error");
                    }).done(function () {
                        location.reload(true);

                    });
            }
        });
});


