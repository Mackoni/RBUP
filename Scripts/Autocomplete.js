$(function () {

    // Autocomplete - Poklon
    $("#txtPoklon").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "PLWebService.asmx/GetPoklon",
                data: "{ 'poklon': '" + $("#txtPoklon").val() + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.naziv,
                            id: item.id
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            $("#selectedIndexPoklon").val(ui.item.id);
        }
    });

    $("#txtPorodica").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "PLWebService.asmx/GetPorodica",
                data: "{ 'porodica': '" + $("#txtPorodica").val() + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            id: item.id,
                            value: item.naziv
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            $("#selectedIndexPorodica").val(ui.item.id);
        }
    });

});

function ProveraPorodica() {
    if ($("#txtPorodica").val() == "")
        $("#selectedIndexPorodica").val(null);
}