$("#LinkButton1").click(function () {
    //$('#ventana1').modal('show');
    //$("#textoPop").val($("#txt").val());
    //$("#linkButton").css({ "color": "red" });
    //__doPostBack('btnSave', 'carga');

})


$(window).on('load', function () {
    if ($('#textoPop').val() != "") {
        console.log("Contiene");
        $('#ventana1').modal('show');
        //$("#linkButton").css({ "color": "red" });
    } else {
        console.log("No Contiene");
    }
    console.log($('#textoPop').val());
    
});