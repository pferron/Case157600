var counter = 0;
var selected = 0;
var selectedObject = "";
var selectedName = "";
var parentId = 0;
var addedBase = false;
var cim = "";
$(document).ready(function () {
    window.onbeforeunload = function () {
        return true;
    };
    interact.dynamicDrop(true);
    $('[data-toggle="tooltip"]').tooltip();
    if (cim != '')
        extract(cim);

    function addBase(json) {
        getSelectedObject("Base");
        selectedObject.ImportFromJson(json);
        selectedName = "Base";
        addCim();
        close();
        addedBase = true;
    }
    function extract(obj) {
        var json = {}
        for (const i in obj) {

            //if the json part is a one level nested object and not an array
            if (typeof obj[i] === 'object' && !Array.isArray(obj[i])) {
                if (!addedBase && json != {})
                    addBase(json);

                getSelectedObject(i);

                selectedObject.ImportFromJson(obj[i]);
                selectedName = i;

                addCim();
                close();
            }
            else if (Array.isArray(obj[i])) {
                if (!addedBase && json != {})
                    addBase(json)

                var name = "";

                switch (i) {
                    case "Coverages":
                        name = "Coverage-Container";
                        break;
                    case "Funds":
                        name = "Fund-Container";
                        break;
                }

                getSelectedObject(name);

                selectedName = name;

                addCim();
                close();

                for (var j = 0; j < obj[i].length; j++) {
                    if (name == "Coverage-Container") {
                        selectedName = "Coverage";
                        getSelectedObject("Coverage");
                        selectedObject.ImportFromJson(obj[i][j]);
                        addCoverage();
                        close();
                    } else if (name == "Fund-Container") {
                        selectedName = "Fund";
                        getSelectedObject("Fund");
                        selectedObject.ImportFromJson(obj[i][j]);
                        addFund();
                        close();
                    }

                }

            }
            else {
                json[i] = obj[i];
            }
        }
        if (!addedBase && json != {})
            addBase(json)
    }

    const startPos = { x: 0, y: 0 }
    const oldStart = { x: 0, y: 0 }

    interact('.cim').dropzone({
        accept: '.agent, .client, .coverage-container, .fund-container, .base',
        ondrop: addCim,
        ondragenter: dragEnter,
        ondragleave: dragLeave,
        ondropactivate: dropActivate,
        ondropdeactivate: dropDeactivate
    });

    interact('.cim-Coverage-Container').dropzone({
        accept: '.coverage',
        ondrop: addCoverage,
        ondragenter: dragEnter,
        ondragleave: dragLeave,
        ondropactivate: dropActivate,
        ondropdeactivate: dropDeactivate
    });

    interact('.cim-Fund-Container').dropzone({
        accept: '.fund',
        ondrop: addFund,
        ondragenter: dragEnter,
        ondragleave: dragLeave,
        ondropactivate: dropActivate,
        ondropdeactivate: dropDeactivate
    });

    interact(".draggable").draggable({
        inertia: true,
        modifiers: [
            interact.modifiers.snap({
                targets: [startPos],
                range: Infinity,
                relativePoints: [{ x: 0.5, y: 0.5 }],
                endOnly: true
            })
        ],
        onstart: dragStartListener,
        onmove: dragMoveListener,
        onend: onDrop
    });

    $('.delete').click(function () {
        console.log(selectedObject.constructor.count);

        if (selectedObject.constructor.count - 1 != -1) {
            selectedObject.constructor.count -= 1;
        }


        sessionStorage.removeItem(selected);
        $(".item-selected").removeClass("item-selected");
        $("#cim-" + selected).remove();
        $("#cim-container-" + selected).remove();
        $("#sidebar").show();
        $("#render").hide();
        $("#render-content").remove();
    });

    $('.close-edit').click(function () {
        close();
    });

    function dragEnter(event) {
        var rect = interact.getElementRect(event.target);
        event.target.classList.add('can-drag')
        oldStart.x = startPos.x;
        oldStart.y = startPos.y;

        // record center point when starting a drag
        startPos.x = rect.left + rect.width / 2;
        startPos.y = rect.top + rect.height / 2;
    }
    function dragLeave(event) {
        startPos.x = oldStart.x;
        startPos.y = oldStart.y;
        event.target.classList.remove('can-drag')
    }
    function dropActivate(event) {
        event.target.classList.add('can-drag-border');
    }
    function dropDeactivate(event) {
        event.target.classList.remove('can-drag-border');
    }
    function onDrop(event) {
        var target = event.target
        target.style.webkitTransform = target.style.transform = 'translate(' + 0 + 'px, ' + 0 + 'px)';
        target.setAttribute('data-x', 0);
        target.setAttribute('data-y', 0);
    }
    function dragStartListener(event) {
        var rect = interact.getElementRect(event.target);

        // record center point when starting a drag
        startPos.x = rect.left + rect.width / 2;
        startPos.y = rect.top + rect.height / 2;

        selectedName = $(event.currentTarget).attr("data-object");

        switch (selectedName) {
            case "Agent":
                selectedObject = new Agent();
                break;
            case "Client":
                selectedObject = new Client();
                break;
            case "Coverage-Container":
                selectedObject = new Coverages();
                break;
            case "Coverage":
                selectedObject = new Coverage();
                break;
            case "Fund":
                selectedObject = new Fund();
                break;
            case "Funds":
                selectedObject = new Funds();
                break;
        }

    }
    function dragMoveListener(event) {
        var target = event.target,
            // keep the dragged position in the data-x/data-y attributes
            x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
            y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

        // translate the element
        target.style.webkitTransform = target.style.transform
            = 'translate(' + x + 'px, ' + y + 'px)';
        // update the posiion attributes
        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);
    }

    function addCim(event) {
        if (event != undefined) {
            event.target.classList.remove('can-drag');
            startPos.x = oldStart.x;
            startPos.y = oldStart.y;

            selectedName = $(event.relatedTarget).attr("data-object");

            getSelectedObject(selectedName);
        }
        console.log(`${selectedName} count is ${selectedObject.constructor.count}`);

        selectedObject.constructor.count++;

        if (selectedObject.constructor.count > selectedObject.max) {
            selectedObject.constructor.count--;
            AddDismissableAlert(`The max has been reached for ${selectedName}.`, "warning");
            return;
        }

        console.log("Adding " + selectedName);
        selected = counter++;

        if (!selectedName.includes("Container")) {


            $(".cim").append(`<div id='cim-${selected}' class='cim-item expandable item-selected' data-object='${selectedName}`
                + `'data-id='${selected}' onclick='openCim("${selectedName}", ${selected})'>${selectedName}</div>`);

            var form = new FormBuilder();
            form.GenerateForm("#render", selectedObject);

            $("#sidebar").hide();
            $("#render").show();
        }
        else {
            $(".cim").append(`<div id='cim-container-${selected}' class='cim-container item-selected cim-${selectedName}' data-object='${selectedName}'`
                + `data-id='${selected}' onclick='openContainer("${selectedName}", ${selected})' >${selectedName}</div>`);

            $("#sidebar").hide();
            $("#render").show();
            //$(".cim").append("<div id='cim-container-" + selected + "' class='cim-container item-selected' data-object='" + selectedName
            //    + "'data-id='" + selected + "'>" + selectedName + "</div>");
        }
    }

    function addCoverage(event) {
        if (event != undefined) {
            event.target.classList.remove('can-drag')
            startPos.x = oldStart.x;
            startPos.y = oldStart.y;

            parentId = $(event.target).attr('data-id');
        }
        selectedObject.constructor.count++;
        parentId = $(".cim-Coverage-Container").attr('data-id');

        if (selectedObject.constructor.count > selectedObject.max) {
            selectedObject.constructor.count--;
            AddDismissableAlert(`The max has been reached for ${selectedName}.`, "warning");
            return;
        }

        console.log("Adding new coverage")
        selected = counter++;

        $(".cim-Coverage-Container").append(`<div id='cim-${selected}' class='cim-item expandable-in-container cim-in-container item-selected' data-object='${selectedName}'`
            + `data-id='${selected}' data-parent-id='${parentId}' onclick='openCimInContianer(event, "${selectedName}", ${selected})'>${selectedName}</div>`);

        var form = new FormBuilder();
        form.GenerateForm("#render", selectedObject);

        $("#sidebar").hide();
        $("#render").show();
    }

    function addFund(event) {
        if (event != undefined) {
            event.target.classList.remove('can-drag')
            startPos.x = oldStart.x;
            startPos.y = oldStart.y;

            parentId = $(event.target).attr('data-id');
        }

        selectedObject.constructor.count++;
        parentId = $(".cim-Fund-Container").attr('data-id');

        if (selectedObject.constructor.count > selectedObject.max) {
            selectedObject.constructor.count--;
            AddDismissableAlert(`The max has been reached for ${selectedName}.`, "warning");
            return;
        }

        console.log("Adding new coverage")
        selected = counter++;

        $(".cim-Fund-Container").append(`<div id='cim-${selected}' class='cim-item expandable-in-container cim-in-container item-selected' data-object='${selectedName}'`
            + `data-id='${selected}' data-parent-id='${parentId}' onclick='openCimInContianer(event,"${selectedName}", ${selected})'>${selectedName}</div>`);

        var form = new FormBuilder();
        form.GenerateForm("#render", selectedObject);

        $("#sidebar").hide();
        $("#render").show();
    }

    /**
     * turn all visiable objects into json used for saving / creating 
     */
    function PrepareJson() {
        var json = "{";

        $(".cim-item").each(function () {
            var object = $(this).attr('data-object');
            var hasParent = $(this).attr('data-parent-id');

            if (hasParent != undefined)
                return;

            getSelectedObject(object);
            var currentId = $(this).attr('data-id');

            json += selectedObject.ExportToJson(currentId) + ",";
        });

        $(".cim-container").each(function () {
            var object = $(this).attr('data-object');
            getSelectedObject(object);
            var currentId = $(this).attr('data-id');

            json += selectedObject.ExportToJson(currentId) + ",";
        });

        if (json != "{")
            //remove the last , that is added
            json = json.slice(0, -1);

        //wrap up the json
        json += "}";

        return json;
    }

    $('#Create').click(function () {
        ShowDialog("Create?", "Would you like to create a file? You can come back and edit it later!", function () {
            if ($("#render").is(":visible")) {
                AddDismissableAlert("Please close the sidebar before attempting to save!", "warning");
                return;
            }

            var json = PrepareJson();

            var input = {
                CimJson: json,
                TestGroupId: testGroupId,
                FileName: "Boo!",
                Creator: "NULL"
            }

            var DTO = JSON.stringify(input);

            console.log(DTO);

            $.ajax({
                type: "POST",
                url: apiCreateUrl,
                data: DTO,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                complete: function (data) {
                    console.log(data);
                    if (data.status == 200) {
                        window.onbeforeunload = null;
                        window.location.href = returnUrl;
                    }
                    else {
                        AddDismissableAlert("Unable to create the file", "danger")
                    }
                }
            });
        });
    });

    $('#Save').click(function () {
        ShowDialog("Save?", "Would you like to save the the modified file?", function () {
            if ($("#render").is(":visible")) {
                AddDismissableAlert("Please close the sidebar before attempting to save!", "warning");
                return;
            }

            var json = PrepareJson();

            var input = {
                CimJson: json,
                CimFileId: cimFileId
            }

            var DTO = JSON.stringify(input);

            console.log(DTO);

            $.ajax({
                type: "POST",
                url: apiEditUrl,
                data: DTO,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                complete: function (data) {
                    console.log(data);
                    if (data.status == 200) {
                        window.onbeforeunload = null;
                        window.location.href = returnUrl; 
                    }
                    else {
                        AddDismissableAlert("Unable to save the modified file.", "danger")
                    }
                }
            });

        });

    });
});

/**
 * Open a cim that is not inside of a container
 * @param {any} objectName The name of the object that is used to pass into getSelectedObject
 * @param {any} index The index of the cim
 */
function openCim(objectName, index) {
    var render = document.getElementById("render");
    var sidebar = document.getElementById("sidebar");

    if (render.style.display == "")
        close();

    selectedName = objectName;
    selected = index;

    getSelectedObject(objectName);

    sidebar.style.display = 'none';
    render.style.display = '';

    var element = document.querySelector(`#cim-${index}`);
    index = element.getAttribute('data-id');
    objectName = element.getAttribute('data-object');
    element.classList.add("item-selected");

    $(this).addClass("item-selected");

    console.log(objectName);

    selectedObject.OpenFromMemory(index);

    var form = new FormBuilder();
    form.GenerateForm("#render", selectedObject);
}

/**
 * Open a cim container
 * @param {any} objectName The name of the object
 * @param {any} index The index in sessionStorage of the object.
 */
function openContainer(objectName, index) {
    //get sidebar which houses the drag items and the render area
    var render = document.getElementById("render");
    var sidebar = document.getElementById("sidebar");

    if (render.style.display == "")
        close();

    //show the render area
    sidebar.style.display = 'none';
    render.style.display = '';

    //set the selected object
    getSelectedObject(objectName);

    //Get the cim item
    var element = document.querySelector(`#cim-container-${index}`);

    //get the index and object name
    index = element.getAttribute('data-id');
    objectName = element.getAttribute('data-object');

    selected = index;

    //add item selected
    element.classList.add("item-selected");
}

/**
 * Open a cim object that is inside of another object or container
 * @param {any} event The event that happens on click, needed to stop multiple opening
 * @param {any} objectName The name of the object used when calling getSelectedObject
 * @param {any} index the index that the cim is at
 */
function openCimInContianer(event, objectName, index) {
    event.stopPropagation();

    //get sidebar which houses the drag items and the render area
    var render = document.getElementById("render");
    var sidebar = document.getElementById("sidebar");

    if (render.style.display == "")
        close();

    //show the render area
    sidebar.style.display = 'none';
    render.style.display = '';

    //Get the cim item
    var element = document.querySelector(`#cim-${index}`);

    //get the index and object name
    index = element.getAttribute('data-id');
    objectName = element.getAttribute('data-object');
    parentId = element.getAttribute('data-parent-id');

    //set object
    switch (objectName) {
        case "Fund":
            selectedObject = new Funds();
            break;
        case "Coverage":
            selectedObject = new Coverages();
            break;
    }

    selected = index;
    selectedName = objectName;

    //add item selected
    element.classList.add("item-selected");

    selectedObject.OpenFromMemory(parentId, index);

    var form = new FormBuilder();
    form.GenerateForm("#render", selectedObject);
}

/**
 * Close the sidebar window and save the contents of the object.
 */
function close() {
    console.log(`Saving ${selectedName}`);

    var render = document.getElementById("render");
    var sidebar = document.getElementById("sidebar");
    
    try {
        switch (selectedName) {
            case "Base":
            case "Agent":
            case "Client":
            case "Fund-Container":
            case "Coverage-Container":
                selectedObject.SaveToMemory(selected);
                break;
            case "Coverage":
                selectedObject.SaveToMemory(parentId, selected);
                break;
            case "Fund":
                selectedObject.SaveToMemory(parentId, selected);
                break;
        }
        render.style.display = "none";
        sidebar.style.display = "";
        $("#render-content").remove();
        document.getElementsByClassName("item-selected")[0].classList.remove("item-selected");
    } catch (e) {
        AddAlert("The object is invalid, please fix the errors and try to save again!", "warning", 5000)
        throw "Can't open invalid!";
    }
    

    
}

/**
 * Delete the currenly selected object. 
 */
function Delete() {
    console.log(selectedObject.constructor.count);

    if (selectedObject.constructor.count - 1 != -1) {
        selectedObject.constructor.count -= 1;
    }
    sessionStorage.removeItem(selected);

    var render = document.getElementById("render");
    var sidebar = document.getElementById("sidebar");

    render.style.display = "none";
    sidebar.style.display = "";
    $("#render-content").remove();
    document.getElementsByClassName("item-selected")[0].classList.remove("item-selected");

  
    $("#cim-" + selected).remove();
    $("#cim-container-" + selected).remove();

}

/**
 * Turn the selected object global var into a new instance of the object that is passed in by string.
 * @param {any} objectName The name of the object to set the instance to
 */
function getSelectedObject(objectName) {
    switch (objectName) {
        case "Agent":
            selectedObject = new Agent();
            break;
        case "Client":
            selectedObject = new Client();
            break;
        case "Coverage-Container":
            selectedObject = new Coverages();
            break;
        case "Coverage":
            selectedObject = new Coverage();
            break;
        case "Fund-Container":
            selectedObject = new Funds();
            break;
        case "Fund":
            selectedObject = new Fund();
            break;
        case "Base":
            selectedObject = new Base();
            break;
    }
}

/**
 * Handle document key down events
 * @param {any} e The event containing the keycode
 */
document.onkeydown = function (e) {

    //the key code
    var code = (e.keyCode ? e.keyCode : e.which);
    switch (code) {
        case 27: //esc key
            var render = document.getElementById("render");
            if (render.style.display == "")
                close();
            break;
        case 13: //enter key
            var render = document.getElementById("render");
            if (render.style.display == "")
                close();
            break;
        case 46: //delete key
            var render = document.getElementById("render");
            if (render.style.display == "")
                Delete();
            break;
    }
}