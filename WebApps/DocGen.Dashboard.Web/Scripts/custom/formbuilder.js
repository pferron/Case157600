class FormBuilder {
    constructor(jsonObject) {
        this.jsonObject = jsonObject;
    }

    GenerateForm(id, templateClass) {
        var properties = templateClass.Properties;

        var form = "<form id='render-content'>";
        for (var i in properties) {
            var name = i;
            var type = properties[i].type;
            var title = properties[i].title;
            var value = properties[i].value;
            var rules = properties[i].rules;

            var rulesString = "";
            if (rules != undefined) {
                var entries = Object.entries(rules)

                for (const [rule, ruleValue] of entries) {
                    if (type === "number") {
                        switch (rule) {
                            case "min":
                                rulesString += `min='${ruleValue}' `;
                                break;
                            case "max":
                                rulesString += `max='${ruleValue}' `;
                                break;
                        }
                    }
                    if (type == "string") {
                        switch (rule) {
                            case "min":
                                rulesString += `required minlength=${ruleValue} `;
                                break;
                            case "max":
                                rulesString += `maxlength=${ruleValue} `;
                                break;
                        }
                    }
                    if (type == "date") {
                        switch (rule) {
                            case "required":
                                rulesString += `required `;
                                break;
                        }
                    }
                    if (type == "list") {
                        switch (rule) {
                            case "required":
                                rulesString += `required `;
                                break;
                        }
                    }

                }
            }

            form += "<div class='col-12'>"
            form += "<div class='form-group'>"
            form += `<label for='${name}'>${title}</label>`;

            var tag = "";

            if (type === "string")
                tag = "text"
            else if (type === "number")
                tag = "number"
            else if (type === "boolean") {
                tag = "checkbox";
                //value = "";
                if (value == true)
                    rulesString += "checked "
            }
            else if (type === "date") {
                tag = "date";
                //rulesString += "required "

            }


            if (type == "list") {
                form += `<select class="form-control val" data-type="${type}" id='${name}' ${rulesString}>`
                var options = "";
                var content = properties[i].content;
                for (var i = 0; i < content.length; i += 1) {
                    var selected = value === content[i][0] ? "selected" : ""; 
                    options = options + `<option ${selected} value="${content[i][0]}">${content[i][1]}</option>`;
                };
                form += options;
                form += "</select>"
            }
            else {
                form += `<input class='form-control val'  data-type="${type}" value='${value}' id='${name}' type='${tag}' ${rulesString} >`;
            }

            form += "</div>"
            form += "</div>"
        }
        form += "</form>"

        $(id).append(form);
    }
}