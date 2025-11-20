function handleHiddenAjaxActionLink(id) {
    var actionLink = $(id);

    if (actionLink == undefined)
        throw new Error("actionlink could not be found");

    var stateObj = { foo: "bar" };
    var url = actionLink.attr("href");

    history.pushState(stateObj, "Title", url);

    actionLink.get(0).click();//.click();
}

function handleVisibleAjaxActionLink() {
    $(document).on("click", 'class', function (event) {
        var stateObj = { foo: "bar" };
        var url = actionLink.attr("href");

        history.pushState(stateObj, "Title", url);
    });
}