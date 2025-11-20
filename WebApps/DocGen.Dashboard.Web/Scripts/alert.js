var timeout = 0;

function AddAlert(message, type, timeout) {
    clearTimeout(timeout);
    CleanUpRemovableAlert();
    $("#alert").fadeOut(function () {
        $("#alert").removeClass("alert-danger");
        $("#alert").removeClass("alert-success");
        $("#alert").removeClass("alert-warning");
        $("#remove").remove();

        if (type == undefined)
            type = "danger";

        if (timeout == undefined)
            timeout = 6000;

        $("#alert").addClass("alert-" + type);
        $("#alert").addClass("text-center");
        timeout = setTimeout(RemoveAlert, timeout);
        var alertMessage = "<label id='remove' class='g_font-weight-bold' style='margin: 0;'> " + message + "</label>";
        $("#alert").append(alertMessage);
    });

    $("#alert").fadeIn();
}

function AddDismissableAlert(message, type) {
    clearTimeout(timeout);
    CleanUpRemovableAlert();
    $("#alert").fadeOut(function () {
        $("#alert").removeClass("alert-danger");
        $("#alert").removeClass("alert-success");
        $("#alert").removeClass("alert-warning");
        $("#remove").remove();
        $("#alert").fadeIn();

        if (type == undefined)
            type = "danger";

        $("#alert").addClass("alert-" + type);
        $("#alert").addClass("text-center");
        $("#alert").addClass("alert-dismissible");
        var alertMessage = "<label id='remove' class='g_font-weight-bold' style='margin: 0;'> " + message + "</label>";
        var removeButton = "<div id='removeableAlertContent'> <button type='button' class='close' data-dismiss='' onclick='RemoveAlert()' aria-label='Close'> " +
            "<span aria-hidden='true'>&times;</span ></button></div> "
        $("#alert").append(alertMessage);
        $("#alert").append(removeButton);
    });

}

function CleanUpRemovableAlert() {
    clearTimeout(timeout);
    $("#alert").removeClass("alert-dismissible");
    $("#removeableAlertContent").remove();
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
    $('.modal-remove').remove()
    $('#modal-remove').remove()
    $("#modal-title").text(title);
    $("#modal-body").append("<p id='modal-remove'>" + content + "</p>");
    $("#modal-btn-yes").off('click').click(function () {
        modal.modal("hide");
        yesMethod();
    });
    $("#modal-btn-no").off('click').click(function () {
        modal.modal("hide");
    });
}