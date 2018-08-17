


$(':checkbox[type=checkbox]').change(function (event) {
    var l = $("#despachar").val();
    if (document.getElementById("despacho").checked) {
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
