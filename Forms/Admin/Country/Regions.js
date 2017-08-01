$(function () {

    $("input[type=submit], button")
        .button()

    // Autocomplete
    $("#txtRegion").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../RBUPWebService.asmx/RegionsFind",
                data: "{ 'region': '" + $("#txtRegion").val() + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            id: item.id,
                            value: item.region
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#hfSelectedIndex").val(ui.item.id);
        }
    });

    //Pretraga po zadatim filterima
    $("#btnFindRegion").click(function () {
        $("#Panel3").removeClass("panelH");
        cekaj();
        $.ajax({
            url: "../../RBUPWebService.asmx/RegionsFind",
            data: "{ 'region': '" + $("#txtRegion").val() + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                LoadLista(data.d);
                $("#cekanje").css("display", "none");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
        return false;
    });

    //Ispisivanje rezultata dobijenih u pretrazi
    function LoadLista(data) {
        $("#tby").html("");
        for (var i = 0; i < data.length; i++) {
            var fak = data[i];
            var id = fak.id;
            var region = fak.region;

            $("#tby").append("<tr><td> <input text=" + region + " style='width:20px' value=" + id + "  onclick='UzmiSelektovane(" + i + "," + id + "); ' type=checkbox id=Checkbox" + i + " /></td>" +
                "<td class=\"iEdit57x20\" onclick=\"$(location).attr('href', 'Regions.aspx?id=" + id + "')\">"
                + "</td><td>" + region + "</td><td></tr>");
        }
    }

});
