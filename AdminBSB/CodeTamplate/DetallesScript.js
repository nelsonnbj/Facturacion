$(document).ready(function () {
    $('#myDatatable').DataTable({
        "bLengthChange": false,
        responsive: true,
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
            },
            aria: {
                sortAscending: ": activer pour trier la colonne par ordre croissant",
                sortDescending: ": activer pour trier la colonne par ordre décroissant"
            }
        },

        "ajax": {
            "type": "Get",
            "url": "/Detalles/Datos",
            "datatype": "JSON",

        },
        "columns": [


      
            { "data": "Nombre_producto" },
            { "data": "Cantidad" },
            { "data": "Precio" },
            { "data": "Comentario" },
            { "data": "Ticket" },          
            {
                "data": "id", "autoWidth": true, "class": "tabla", "render": function (data, type, row, meta) {
                    var estado = row['Estado'];
                    if (estado === "Despachado") {
                        return '<a  class= "btn btn-success col-md-7" >Empacado</a>'
                    }
                    if (estado === "Cancelado") {
                        return '<a id="btnAgregarMeta" onclick="CambiarEstado(' + row['id'] +')" class="btn btn-primary col-lg-7 waves-blue" data-url="/Detalles/Detalle" > Reativar</a >'
                    }

                    if (estado === "Facturado") {
                        return '<a id="btnAgregarMeta" onclick="CambiarEstado(' + row['id'] + ')" class="btn btn-danger active col-lg-7 waves-blue" data-url="/Detalles/Detalle" > Cancelar</a >'
                    }

                }
            },
            { "data": "Estado" },
            {
                "data": "id", "autoWidth": true, "class": "tabla", "render": function (data, type, row, meta) {
                    var estado = row['Estado'];
                    if (estado === "Despachado") {
                        return '<a id="Editar" class="btnEditar btn btn-primary"  disabled="disabled"> Modificar </a>';
                    }

                    else {
                        return '<a id="Editar" onclick="edite(' + row['id'] + ')" class="btnEditar btn btn-primary" data-toggle="modal" data-id="id" data-target="#myModal"  data-toggle="modal"> Modificar </a>';

                    }                    
                }
            },
        ]
    });
});

function edite(vas) {
    $(".modal-body").load("/Detalles/Edit/" + vas);

};


function EditarModal() {
    var oTable = $('#myDatatable').DataTable()
    var url = $('#EditModal')[0].action;

    $.ajax({
        type: "POST",
        url: url,
        data: $('#EditModal').serialize(),
        success: function (data) {
            oTable.ajax.reload();

            if (data=="true") {
                
                alertify.success("Pedido Modificado Correctamente")
            }
            else {
                alertify.error("Error al momento de modificar")
            }
        }
    })
    return true;
};



/////////////////////////Identificar el area de maestro detalle//////////

var error = document.getElementById("error").innerHTML;

if (error === "false") {
    alertify.error("El Tickect Intoducido Es Incorrecto");

}

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Detalles/Edit/" + $(this).data("id"));

});

function CambiarEstado(ids) {
    var oTable = $("#myDatatable").DataTable();
    var url = $("#btnAgregarMeta").data('url');
    $.post(url, { id: ids }, function (data) {
        if (data) {
            oTable.ajax.reload();
        }
    });
}


$(function () {
    $(".select2").select2({
        placeholder: 'Seleccione... ',
        width: '100%',
        allowClear: true
    });

});