$(function () {

    $("input[type=submit], button")
        .button()

    // Autocomplete
    $("#txtTeam").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../RBUPWebService.asmx/TeamsFind",
                data: "{ 'team': '" + $("#txtTeam").val() + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            id: item.id,
                            value: item.team
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
    $("#btnFindTeam").click(function () {
        $("#Panel3").removeClass("panelH");
        cekaj();
        $.ajax({
            url: "../../RBUPWebService.asmx/TeamsFind",
            data: "{ 'team': '" + $("#txtTeam").val() + "' }",
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
            var team = fak.team;

            $("#tby").append("<tr><td> <input text=" + team + " style='width:20px' value=" + id + "  onclick='UzmiSelektovane(" + i + "," + id + "); ' type=checkbox id=Checkbox" + i + " /></td>" +
                "<td class=\"iEdit57x20\" onclick=\"$(location).attr('href', 'Teams.aspx?id=" + id + "')\">"
                + "</td><td>" + team + "</td><td></tr>");
        }
    }

});
