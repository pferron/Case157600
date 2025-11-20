$(document).ready(function () {
    InitDialog();
});

var _Dialog;
function InitDialog() {
    _Dialog = jQuery("#Dialog");
    _Dialog.dialog(
        {
            autoOpen: false, // This dialog does not show until invoking Dialog.dialog('open')
            resizable: false,
            width: 550,
            modal: true
        });
}

function DialogClose() {
    _Dialog.dialog("close");
}

function SubmitForm(formName) {
    _Dialog.dialog("option", "title", "Searching");
    _Dialog.html("<div>Querying for updated results, please wait...</div>");
    _Dialog.dialog("open");

    // Submit form
    $(formName).submit();
}

function ShowScanning() {
    _Dialog.dialog("option", "title", "Querying");
    _Dialog.html("<div>Querying for updated results, please wait...</div>");
    _Dialog.dialog("open");
}

function GetNewVersion(regionVersion) {
    var versionParts = regionVersion.split('-')[1].trim().split('.');
    var newVersion = parseInt(versionParts[1]) + 1;
    versionParts[1] = newVersion.toString();
    return versionParts.join(".");
}