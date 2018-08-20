

//var id = $("#despachar option:selected").value;
//console.log(id);
$(':checkbox[type=checkbox]').change(function (event) {
    //var l = $("#despachar").val();
    if (document.getElementById("despachar").checked) {
        var url = $('#despachar').data('request-url');
        $.post(url, { Codigo: "Despachado" });

        var int = self.setInterval("refresh()", 1000);
    }

    else {
        var url = $('#despachar').data('request-url');
        $.post(url, { Codigo: "activado" });
        var int = self.setInterval("refresh()", 1000);
    }
});

function refresh() {
    location.reload(true);
}

$(document).ready(function () {
    var oTable = $('#myDatatable').DataTable({

        "bLengthChange": false,
        responsive: true,
        "order": [[1, "asc"]],
        language: {
            processing: "Procesando",
            search: "Buscar:",
            lengthMenu: "Ver _MENU_ Filas",
            info: "_START_ - _END_ de _TOTAL_ elementos",
            infoEmpty: "0 - 0 de 0 elementos",
            infoFiltered: "(Filtro de _MAX_ entradas en total)",
            infoPostFix: "",
            loadingRecords: "Cargando datos.",
            zeroRecords: "No se encontraron datos",
            emptyTable: "No hay datos disponibles",
            paginate: {
                first: "Primero",
                previous: "Anterior",
                next: "Siguiente",
                last: "Ultimo"
            }
        }
    
    });
    });