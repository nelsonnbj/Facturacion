//function buscarDatos() {
//    var Empleado = $('#Codigo').val();
//    //var permisoEditar = $('#permisoEditar').val();
//    var oTable = $('#myDatatable tbody').DataTable({
//        "order": [[7, "desc"], [5, 'asc']],
//        //"order": [[0, "desc"]],
//        "bLengthChange": false,
//        responsive: true,
//        //destroy: true,
//        //"columnDefs": [
//        //    {
//        //        "targets": [7],
//        //        "visible": false,
//        //        "searchable": false
//        //    }],
//        language: {
//            processing: "Procesando",
//            search: "Buscar:",
//            serverSide: true,
//            lengthMenu: "Ver _MENU_ Filas",
//            info: "_START_ - _END_ de _TOTAL_ elementos",
//            infoEmpty: "0 - 0 de 0 elementos",
//            infoFiltered: "(Filtro de _MAX_ entradas en total)",
//            infoPostFix: "",
//            loadingRecords: "Cargando datos.",
//            zeroRecords: "No se encontraron datos",
//            emptyTable: "No hay datos disponibles",
//            paginate: {
//                first: "Primero",
//                previous: "Anterior",
//                next: "Siguiente",
//                last: "Ultimo"
//            },
//            aria: {
//                sortAscending: ": Ordenación ascendente",
//                sortDescending: ": Ordenación descendente"
//            }
//        },

//        "ajax": {
//            "url": 'Detalles/Busquedad',
//            "data": { "Codigo": $('#Codigo').val()},
//            "type": "get",
//            "datatype": "json"

//        },

//        "columns": [
//            {
//                "data": "id", "autoWidth": true, "render": function (data, type, row, meta) {
//                    var id = row['Id'];
//                    var url = finder.getAppFile('Detalles/Edit/' + data);
//                    if (permisoEditar === "True") {
//                        return '<a class="btn btn-table" href =' + url + '>' + data + '</a>';
//                    }
//                    else {
//                        return '<a>' + data + '</a>';
//                    }
//                }
//            },
//            { "data": "Producto", "autoWidth": true },
//            { "data": "Cantidad", "autoWidth": true },
//            { "data": "Precio", "autoWidth": true },
//            { "data": "comenatrio", "autoWidth": true },
//            { "data": "Ticket", "autoWidth": true },
//            { "data": "nombre", "autoWidth": true },
//            { "data": "Estado", "autoWidth": true },

//        ]

//    })

//}

    //var permiso = $("#permiso").val();
    //console.log(permiso);
    //var pointer = $("#pointer").data("value");

//var oTable = $('#myDatatable').DataTable({
//        "bLengthChange": true,
//        responsive: true,
//        "order": [[0, "asc"]],
//        language: {
//            processing: "Procesando",
//            search: "Buscar:",
//            lengthMenu: "Ver _MENU_ Filas",
//            info: "_START_ - _END_ de _TOTAL_ elementos",
//            infoEmpty: "0 - 0 de 0 elementos",
//            infoFiltered: "(Filtro de _MAX_ entradas en total)",
//            infoPostFix: "",
//            loadingRecords: "Cargando datos.",
//            zeroRecords: "No se encontraron datos",
//            emptyTable: "No hay datos disponibles",
//            paginate: {
//                first: "Primero",
//                previous: "Anterior",
//                next: "Siguiente",
//                last: "Ultimo"
//            },
//            aria: {
//                sortAscending: ": activer pour trier la colonne par ordre croissant",
//                sortDescending: ": activer pour trier la colonne par ordre décroissant"
//            }
//        },



//    })



//function BuscarEmpleado() {

//    var Codigo = $('#Codigo').val();
 

//    if (Codigo !== "") {

//        //console.log(finder.getAppFile("Detalles/Detalles"));
//        $.post(finder.getAppFile("Detalles/Detalle"), { Codigo: Codigo}).done(function (data) {

//            if (!data.ok) {
//                alertify.error("NO FUE ENCONTRADO EL EMPLEADO");
//                return;
//            }

//            //$('#tableActivo').show();
//            //$('#fotoEmpleado').attr('src', data.urlimagen);
//            //var s = data.nombre.capitalize();
//            //document.getElementById('nombre').innerHTML = data.nombre.toProperCase();
//            //document.getElementById('cargo').innerHTML = data.cargo.toProperCase();
//            //document.getElementById('ubicacion').innerHTML = data.ubicacion.toProperCase();
//            //document.getElementById('tipoempleado').innerHTML = data.tipoempleado.toProperCase();
//            //document.getElementById('Empresa').innerHTML = data.Empresa.toProperCase();
//            buscarDatos();
//            //$('#tablaActivo').show();
//            //$('#Busqueda').hide();

//            //PresentarTabla();
//        });
//    }
//    };