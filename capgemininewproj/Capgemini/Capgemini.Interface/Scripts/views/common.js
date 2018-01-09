
function onSuccess(eval) {
    $("#alerta-div").empty().prepend("<div class='form-group'><div class='col-lg-8 col-lg-offset-2'><div class='alert alert-dismissible alert-success' id='div-alerta-on'><span id='text-alerta'>" + eval + "</span></div></div></div>");

    $('#alerta-div').hide(1000);
    $('#alerta-div').toggle(1000);
}

function onError(eval) {
    $("#alerta-div").empty().prepend("<div class='form-group'><div class='col-lg-8 col-lg-offset-2'><div class='alert alert-dismissible alert-danger' id='div-alerta-on'><span id='text-alerta'>" + eval + "</span></div></div></div>");

    $('#alerta-div').hide(1000);
    $('#alerta-div').toggle(1000);
}

function onWarning(eval) {
    $("#alerta-div").empty().prepend("<div class='form-group'><div class='col-lg-8 col-lg-offset-2'><div class='alert alert-dismissible alert-warning' id='div-alerta-on'><span id='text-alerta'>" + eval + "</span></div></div></div>");

    $('#alerta-div').hide(1000);
    $('#alerta-div').toggle(1000);
}

function onInfo(eval) {
    $("#alerta-div").empty().prepend("<div class='form-group'><div class='col-lg-8 col-lg-offset-2'><div class='alert alert-dismissible alert-info' id='div-alerta-on'><span id='text-alerta'>" + eval + "</span></div></div></div>");

    $('#alerta-div').hide(1000);
    $('#alerta-div').toggle(1000);
}

function onClose() {
    $('#alerta-div').css('display', 'none');
}