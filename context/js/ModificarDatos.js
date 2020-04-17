$(window).on('load', function () {
    if ($('#txtDescripcion').val() != "") {
        console.log("Contiene");
        $('#ventana1').modal('show');
        //$("#linkButton").css({ "color": "red" });
    } else {
        console.log("No Contiene");
    }
    console.log($('#txtDescripcion').val());

});