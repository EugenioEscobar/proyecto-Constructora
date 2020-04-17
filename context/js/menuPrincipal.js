function funcion1() {
    console.log("it's Working bitch");
    var accesos = document.getElementsByClassName("nav-acceso1");
    for (var i = 0; i < accesos.length; i++) {
        accesos[i].classList.toggle('hide');
    }
};
function funcion2() {
    var accesos = document.getElementsByClassName("nav-acceso2");
    for (var i = 0; i < accesos.length; i++) {
        accesos[i].classList.toggle('hide');
    }
};
function funcion3() {
    var accesos = document.getElementsByClassName("nav-acceso3");
    for (var i = 0; i < accesos.length; i++) {
        accesos[i].classList.toggle('hide');
    }
};  