function DisplayCimJson(testResultId) {
    _Dialog.dialog("option", "title", "Cim Json");
    _Dialog.html("Loading...");

    _Dialog.dialog({
        width: 800,
        height: 650,
        open: function () {
            if ($(this).closest('.ui-dialog').offset().top < 200) {
                $(this).closest('.ui-dialog').css({ 'top': '200px' });
            }
            if ($(this).closest('.ui-dialog').offset().top > 200) {
                $(this).closest('.ui-dialog').css({ 'top': '200px' });
                $("html, body").animate({ scrollTop: 0 }, "200");
            }
        }
    });

    _Dialog.dialog("open");
    var displayCimUrl = baseUrl + "CisTestTool/DisplayCimJson";

    $.ajax({
        type: "POST",
        url: displayCimUrl,
        data: { testResultId: testResultId }
    }).done(function (msg) {
        _Dialog.html(msg);
    });

    return false;
}

function DisplayIllustration(testResultId) {
    _Dialog.dialog("option", "title", "Illustration");
    _Dialog.html("Loading...");

    _Dialog.dialog({
        width: 1050,
        height: 1165,
        open: function () {
            if ($(this).closest('.ui-dialog').offset().top < 5) {
                $(this).closest('.ui-dialog').css({ 'top': '5px' });
            }
            if ($(this).closest('.ui-dialog').offset().top > 5) {
                $(this).closest('.ui-dialog').css({ 'top': '5px' });
                $("html, body").animate({ scrollTop: 0 }, "5");
            }
        }
    });

    _Dialog.dialog("open");
    var displayIllustrationUrl = baseUrl + "CisTestTool/DisplayIllustration";

    $.ajax({
        type: "POST",
        url: displayIllustrationUrl,
        data: { testResultId: testResultId }
    }).done(function (msg) {
        _Dialog.html(msg);
    });

    return false;
}