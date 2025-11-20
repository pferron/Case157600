var timeout = null;
function AddAlert(message, type) {
    clearTimeout(timeout);
    $("#alert").fadeOut(function () {
        $("#alert").removeClass("alert-danger");
        $("#alert").removeClass("alert-success");
        $("#alert").removeClass("alert-warning");
        $("#remove").remove();
        $("#alert").fadeIn();
        $("#alert").addClass("alert-" + type);
        $("#alert").addClass("text-center");
        timeout = setTimeout(RemoveAlert, 10000);
        var alertMessage = "<label id='remove' style='margin: 0;'> " + message + "</label>";
        $("#alert").append(alertMessage);
    });

}

function RemoveAlert() {
    $("#alert").fadeOut(function () {
        $("#alert").removeClass("alert-danger");
        $("#alert").removeClass("alert-success");
        $("#alert").removeClass("alert-warning");
        $("#remove").remove();
    });
}

function ShowDialog(title, content, yesMethod) {
    var modal = $("#modal");
    modal.modal('show');
    $('#modal-remove').remove()
    $("#modal-title").text(title);
    $("#modal-body").append("<p id='modal-remove'>"+content+"</p>");
    $("#modal-btn-yes").off('click').click(function () {
        modal.modal("hide");
        yesMethod();
    });
    $("#modal-btn-no").off('click').click(function () {
        modal.modal("hide");
    });
}