
$(document).ready(function () {
    $('#myDatatables').DataTable({
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
            "url": "/Producto/ObtenerDatos",
            "datatype": "JSON",

        },
        "columns": [

            { "data": "Productos" },
            { "data": "Precios" },
            { "data": "Tipo_Producto" },
            {
                "data": "id", "autoWidth": true, "class": "tabla", "render": function (data, type, row, meta) {
                  
                    return ' <img class="imagenProduct" src="' + row['imagen'] + '" alt="Image" width="70" height="70">'

                }
            },
            {
                "data": "id", "autoWidth": true, "class": "tabla", "render": function (data, type, row, meta) {
                    var estado = row['Estado'];
                    if (estado === true) {
                        return ' <strong>Activo</strong>'
                    }
                    else  {
                        return '<strong style="color:red">Inactivo</strong>'
                    }
                    

                }
            },
            {
                "data": "id", "autoWidth": true, "class": "tabla", "render": function (data, type, row, meta) {
                    var estado = row['Estado'];
                 
                    if (estado === true) {
                        return '<a class="btn btn-success " href = "/Producto/edit/'+ row['id'] + '" > <i class="material-icons">border_color</i>   Editar</a >  | <a type="button" onclick="inactivar(' + row['id'] + ')" class="btn btn-danger " id="eliminar" ><i class="material-icons" > delete_sweep</i > Inactivar</a >'
                    }
                    else {
                        return '<a class="btn btn-success " href = "/Producto/Edit/' + row['id'] + '" > <i class="material-icons">border_color</i>   Editar</a >  | <a type="button" onclick="inactivar(' + row['id'] + ')" class="btn btn-primary col-md-offset-4 col-lg-offset-0" id="eliminar" ><i class="material-icons" > done</i > Activar</a >'
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

            if (data == "true") {

                alertify.success("Pedido Modificado Correctamente")
            }
            else {
                alertify.error("Error al momento de modificar")
            }
        }
    })
    return true;
};





//$("button[name='elimina']").click(function () {
function inactivar(id) {
    var table = $("#myDatatables").DataTable();
    var Id = id;
  
    //swal({
    //    title: "Estas Seguro de Eliminarlo?",
    //    text: "Tu No Prodras Volver a Recuperar Este Producto!",
    //    type: "warning",
    //    showCancelButton: true,
    //    confirmButtonColor: "#DD6B55",
    //    confirmButtonText: "Si, Eliminado!",
    //    cancelButtonText: "No, Cancelar!",
    //    closeOnConfirm: false,
    //    closeOnCancel: false
    //},

        //function (isConfirm) {


            //if (isConfirm) {

                var url = "Delete";

                $.post(url, { id: Id })
                    .fail(function (req) {
                        console.log(req);
                        swal("Error!", "Se Produjo Un Error Al Momento De Elimnarlo.", "error");

                    }).done(function () {
                        table.ajax.reload();
                        //swal("Eliminado!", "Tu Producto Ha Sido Eliminado.", "success");

                    });


            //} else {
            //    swal("Cancelado", "Tu Producto Ha Sido Salvado :)", "error");
            //}
        };
//});

