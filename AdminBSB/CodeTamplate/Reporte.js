
$(function () {
    $(".select2").select2({
        placeholder: 'Seleccione... ',
        width: '100%',
        allowClear: true
    });

});



    $("#Tipo").change(function () {
        var url = $('#productos').data('request-url');
        $.get(url, { id: $("#Tipo").val() }, function (data) {
            $("#producto").empty();
            $.each(data, function (index, row) {
        
                $("#producto").append("<option value='" + row.id + "'>" + row.Nombre_producto + "</option>")
                $("#producto").val("");
            });

        });
    });
