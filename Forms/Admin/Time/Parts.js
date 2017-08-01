$(function () {

    $("input[type=submit], button")
        .button()

    // Autocomplete
    $("#txtPart").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../RBUPWebService.asmx/Parts_Find",
                data: "{ 'parts': '" + $("#txtPart").val() + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            id: item.id,
                            value: item.parts
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
    $("#btnFindPart").click(function () {
        $("#Panel3").removeClass("panelH");
        cekaj();
        alert("a");
        $.ajax({
            url: "../../RBUPWebService.asmx/PartsFind",
            data: "{ 'parts': '" + $("#txtPart").val() + "', 'descriptions': '" + $("#txtDescriptions").val() + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                alert("b");
                LoadLista(data.d); alert("c");
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
            var parts = fak.parts;
            var descriptions = fak.descriptions;

            $("#tby").append("<tr><td> <input text=" + parts + " style='width:20px' value=" + id + "  onclick='UzmiSelektovane(" + i + "," + id + "); ' type=checkbox id=Checkbox" + i + " /></td>" +
                "<td class=\"iEdit57x20\" onclick=\"$(location).attr('href', 'Parts.aspx?id=" + id + "')\">"
                + "</td><td>" + parts
                + "</td><td>" + descriptions + "</td><td></tr>");
        }
    }

});
