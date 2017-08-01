$(function () {

    // Selektovanje CheckBox-ova
    $("#selall").change(function () {

        $('input:checkbox').prop('checked', this.checked)

        $("INPUT[type='checkbox']").each(function (index) {
            if ($(this).val() != "-1") UzmiSelektovane(index - 1, $(this).val());
        });
    });

    // Upisivanje selektovanih CheckBox-ova u TextBox
    

});
function UzmiSelektovane(i, nr) {

    if (document.getElementById("Checkbox" + i).checked) {

        var nr = document.getElementById("Checkbox" + i).value;
        var array = new Array();

        if (document.getElementById("hfSelectedIndex").value != "") {
            array = document.getElementById("hfSelectedIndex").value.split(",");
        }

        if ($.inArray(nr, array) == -1) {
            array[array.length] = nr;
            document.getElementById("hfSelectedIndex").value = array.toString();
        }
    }
    else {
        var array = new Array();
        array = document.getElementById("hfSelectedIndex").value.split(",");
        var nr = document.getElementById("Checkbox" + i).value;

        if ($.inArray(nr, array) != -1) {
            array.splice($.inArray(nr, array), 1);
            document.getElementById("hfSelectedIndex").value = array.toString();
        }
    }
}