class BaseLevel {
    constructor(properties) {
        this.Properties = properties;
    }
    /**
     * Save the agent to memeory by finding all values and finding the val class and getting the values,
     * then build a key-value pair.
     * @param {any} id The id of the div that holds the generated form
     */
    SaveToMemory(id) {
        var valid = true;
        console.log(`Saving to sessionStorage with id ${id}`);

        //start with the opening json part
        var json = "{";

        //loop through all of the values on the form.
        $(".val").each(function () {

            //the id of the object is the key
            var key = $(this).attr('id');

            //get the value
            var value = $(this).val();

            var type = $(this).attr('data-type');

            var prefix = '"'
            switch (type) {
                case "decimal":
                case "number":
                    prefix = "";
                    break;
            }

            if (!(this).validity.valid) {
                valid = false;
                $(this).addClass("is-invalid");
                document.forms["render-content"].reportValidity();
            }
            //build a key value pair
            json += `"${key}": ${prefix}${value}${prefix},`;
        });

        //remove the last , that is added
        json = json.slice(0, -1);

        //wrap up the json
        json += "}";

        if (!valid)
            throw "Invalid please catch!";

        //save the key-value pair to memory
        sessionStorage.setItem(id, json);
    }
    /**
    * Open the agent from memory and map it to the properties object.
    * @param {any} id The id of the key-value pair in sessionStorage
    */
    OpenFromMemory(id) {
        console.log(`Opening a new agent (${id}) from session storage `);

        //get the key-value pair from session storage
        var json = sessionStorage.getItem(id);

        //the parsed json
        json = JSON.parse(json);

        for (var i in this.Properties) {
            //Set the properties with the key to value at i.
            this.Properties[i].value = json[i];
        }
    }

    ImportFromJson(json) {
        for (var i in this.Properties) {
            if (json[i] == undefined) {
                return;
            }
            //Set the properties with the key to value at i.
            this.Properties[i].value = json[i];
        }
    }

}

class Helpers {
    /**
     * Get a list of states
     */
    GetStates() {
        return [['AL', 'Alabama'], ['AK', 'Alaska'], ['AZ', 'Arizona'], ['AR', 'Arkansas'], ['CA', 'California'], ['CO', 'Colorado'],
        ['CT', 'Connecticut'], ['DE', 'Delaware'], ['DC', 'District of Columbia'], ['FL', 'Florida'], ['GA', 'Georgia'], ['HI', 'Hawaii'],
        ['ID', 'Idaho'], ['IL', 'Illinois'], ['IN', 'Indiana'], ['IA', 'Iowa'], ['KS', 'Kansas'], ['KY', 'Kentucky'], ['LA', 'Louisiana'],
        ['ME', 'Maine'], ['MD', 'Maryland'], ['MA', 'Massachusetts'], ['MI', 'Michigan'], ['MN', 'Minnesota'], ['MS', 'Mississippi'],
        ['MO', 'Missouri'], ['MT', 'Montana'], ['NE', 'Nebraska'], ['NV', 'Nevada'], ['NH', 'New Hampshire'], ['NJ', 'New Jersey'],
        ['NM', 'New Mexico'], ['NY', 'New York'], ['NC', 'North Carolina'], ['ND', 'North Dakota'], ['OH', 'Ohio'], ['OK', 'Oklahoma'],
        ['OR', 'Oregon'], ['PA', 'Pennsylvania'], ['RI', 'Rhode Island'], ['SC', 'South Carolina'], ['SD', 'South Dakota'],
        ['TN', 'Tennessee'], ['TX', 'Texas'], ['UT', 'Utah'], ['VT', 'Vermont'], ['VA', 'Virginia'], ['WA', 'Washington'],
        ['WV', 'West Virginia'], ['WI', 'Wisconsin'], ['WY', 'Wyoming']]
    }

    /**
     * Get a list of plan id's that are possible 
     */
    GetPlanIds() {
        return [['TUINDEXN', 'IUL Adult Standard Non-Tobacco'], ['TUINDEXT', 'IUL Adult Standard Tobacco'], ['TUINDEXP', 'IUL Adult Pref Non-Tobacco'],
            ['TUINDEXR', 'IUL Adult Pref Tobacco'], ['TUINDEXU', 'IUL Adult Super Preferred'], ['TUINDEXC', 'IUL Youth Standard Composite']]
    }
}

class Agent extends BaseLevel {
    static get count() {
        return this._count || 0;
    }

    static set count(v) {
        this._count = v;
    }

    constructor() {
        var helper = new Helpers();
        var Properties = {
            FirstName: {
                type: "string",
                title: "First Name",
                value: "",
                rules: {
                    min: 1
                }
            },
            MiddleName: {
                type: "string",
                title: "Middle Name",
                value: ""
            },
            LastName: {
                type: "string",
                title: "Last Name",
                value: "",
                rules: {
                    min: 1
                }
            },
            AddressLine1: {
                type: "string",
                title: "Address Line 1",
                value: "",
                rules: {
                    min: 1
                }
            },
            AddressLine2: {
                type: "string",
                title: "Address Line 2",
                value: ""
            },
            AddressCity: {
                type: "string",
                title: "Address City",
                value: "",
                rules: {
                    min: 1
                }
            },
            AddressStateCode: {
                type: "list",
                title: "Address State Code",
                value: "",
                content: helper.GetStates(),
                rules: {
                    required: true
                }
            },
            AddressZip: {
                type: "string",
                title: "Zip Code",
                value: "",
                rules: {
                    min: 1,
                    max: 5
                }
            },
            PhoneNumber: {
                type: "string",
                title: "Phone Number",
                value: "",
                rules: {
                    min: 1,
                    max: 10
                }
            }
        };
        super(Properties);
        this.max = 1;
    }
    ExportToJson(id) {
        var json = sessionStorage.getItem(id);

        var formattedJson = `"Agent":` + json;

        return formattedJson;
    }
}

class Client extends BaseLevel {
    static get count() {
        return this._count || 0;
    }

    static set count(v) {
        this._count = v;
    }
    constructor() {
        var helper = new Helpers();

        var Properties = {
            FirstName: {
                type: "string",
                title: "First Name",
                value: "",
                rules: {
                    min: 1
                }
            },
            MiddleName: {
                type: "string",
                title: "Middle Name",
                value: ""
            },
            LastName: {
                type: "string",
                title: "Last Name",
                value: "",
                rules: {
                    min: 1
                }
            },
            NameSuffix: {
                type: "string",
                title: "Name Suffix",
                value: ""
            },
            BirthDate: {
                type: "date",
                title: "Birth Date",
                value: "",
                rules: {
                    required: true
                }
            },
            GenderCode: {
                type: "list",
                title: "Gender Code",
                value: "",
                content: [
                    ['MALE', 'Male'], ['FEMALE', 'Female']
                ],
                rules: {
                    required: true
                }
            },
            AddressStateCode: {
                type: "list",
                title: "Address State Code",
                value: "",
                content: helper.GetStates(),
                rules: {
                    required: true
                }
            },
            AddressCountryCode: {
                type: "string",
                title: "Adress Country Code",
                value: "",
                rules: {
                    min: 1
                }
            },
            Age: {
                type: "number",
                title: "Age",
                value: 0,
                rules: {
                    min: 0,
                    max: 85
                }
            }
        };
        super(Properties);
        this.max = 1;
    }

    ExportToJson(id) {
        var json = sessionStorage.getItem(id);

        var formattedJson = `"Client":` + json;

        return formattedJson;
    }
}

class Base extends BaseLevel {
    static get count() {
        return this._count || 0;
    }

    static set count(v) {
        this._count = v;
    }

    constructor() {
        var helper = new Helpers();
        var Properties = {
            ApplicationSignedStateCode: {
                type: "list",
                title: "Application Signed State Code",
                value: "",
                content: helper.GetStates(),
                rules: {
                    required: true
                }
            },
            BillingAmount: {
                type: "decimal",
                title: "Billing Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            BillingMethodCode: {
                type: "list",
                title: "Billing Method Code",
                value: "",
                content: [
                    ['REGBILL', 'Regular Billing'], ['PAC', 'Pre Authorized Check'], ['DirectBill', 'Direct Bill'], ['LISTBILL', 'List Bill'],
                ],
                rules: {
                    required: true
                }
            },
            BillingModeCode: {
                type: "list",
                title: "Billing Mode Code",
                value: "",
                content: [
                    ['MNTHLY', 'Monthly'], ['QUARTLY', 'Quarterly'], ['BIANNUAL', 'Semi-Annual'], ['ANNUAL', 'Annual']
                ],
                rules: {
                    required: true
                }
            },
            DeathBenefitOptionCode: {
                type: "list",
                title: "Death Benefit Option Code",
                value: "",
                content: [
                    ['LEVEL', 'Level'], ['INCR', 'Increasing']
                ]
            },
            Exchange1035Amount: {
                type: "decimal",
                title: "Exchange 1035 Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            SevenPayPremiumAmount: {
                type: "decimal",
                title: "Seven Pay Premium Amount",
                value: 0.0
            },
            FaceAmount: {
                type: "decimal",
                title: "Face Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            IllustrationReportType: {
                type: "list",
                title: "Illustration Report Type",
                value: "",
                content: [
                    ['COST', 'Cost of Benefit'], ['BASIC', 'Basic Illustration'], ['REVISED', 'Revised Illustration']
                ],
                rules: {
                    required: true
                }
            },
            IllustrationTypeCode: {
                type: "number",
                title: "Illustration Type Code",
                value: 0,
                rules: {
                    min: 0
                }
            },
            InitialPremium: {
                type: "decimal",
                title: "Initial Premium",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            IssueAge: {
                type: "number",
                title: "Issue Age",
                value: 0,
                rules: {
                    min: 0
                }
            },
            IssueDate: {
                type: "date",
                title: "Issue Date",
                value: "",
                rules: {
                    required: true
                }

            },
            MECAllowedIndicator: {
                type: "boolean",
                title: "MEC Allowed Indicator",
                value: false
            },
            PermanentTableRatingCode: {
                type: "list",
                title: "Permanent Table Rating Code",
                value: "",
                content: [
                    ['NONE', '1 (None)'], ['A', '2'], ['B', '4'], ['C', '6'], ['D', '7'], ['E', '8'], ['F', '9'], ['G', '10'], ['H', '11'], ['I', '12'],
                    ['J', '13'], ['K', '14'], ['L', '15'], ['M', '16']
                ],
                rules: {
                    required: true
                }
            },
            PlanId: {
                type: "list",
                title: "Plan Id",
                value: "",
                content: helper.GetPlanIds(),
                rules: {
                    required: true
                }
            },
            PolicyId: {
                type: "string",
                title: "Policy Id",
                value: "",
                rules: {
                    min: 1
                }
            },
            ProductTypeCode: {
                type: "list",
                title: "Product Type Code",
                value: "",
                content: [
                    ['INDXUL', 'Indexed Universal Life']
                ],
                rules: {
                    min: 1
                }
            },
            TemporaryFlatExtraRateAmount: {
                type: "decimal",
                title: "Temporary Flat Extra Rate Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            TemporaryFlatExtraEndDate: {
                type: "date",
                title: "Temporary Flat Extra End Date",
                value: ""
            },
            TemporaryFlatExtraAmount: {
                type: "decimal",
                title: "TemporaryFlatExtraAmount",
                value: 0,
                rules: {
                    required: true
                }
            }
        };
        super(Properties)
        this.max = 1;
    }
    ExportToJson(id) {
        var json = sessionStorage.getItem(id);

        var formattedJson = json;
        formattedJson = formattedJson.substring(1);
        formattedJson = formattedJson.slice(0, -1);
        return formattedJson;
    }
}

class Coverages {
    static get count() {
        return this._count || 0;
    }

    static set count(v) {
        this._count = v;
    }

    static get id() {
        return this._id === undefined ? -1 : this._id;
    }

    static set id(v) {
        this._id = v;
    }

    constructor() {
        this.max = 1;
        this.List = [];
        var helper = new Helpers();
        this.Properties = {
            PlanId: {
                type: "list",
                title: "Plan Id",
                value: "",
                content: helper.GetPlanIds(),
                rules: {
                    requried: true
                }
            },
            CoverageTypeCode: {
                type: "list",
                title: "Coverage Type Code",
                value: "",
                content: [
                    ['ABE', 'Accelerated Benefit Rider'], ['ADB', 'Accidental Death Benefit'], ['APPLWAIV', 'Applicant Waiver'],
                    ['OPAI', 'Guaranteed Insurability'], ['WMD', 'Waiver of Monthly Deduction']
                ],
                rules: {
                    requried: true
                }
            },
            CurrentAmt: {
                type: "decimal",
                title: "Current Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            IssueAge: {
                type: "number",
                title: "Issue Age",
                value: 0,
                rules: {
                    min: 0,
                    max: 85
                }
            },
            FaceAmount: {
                type: "decimal",
                title: "Face Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            TobaccoPremiumBasisCode: {
                type: "list",
                title: "Tobacco Premium Basis Code",
                value: "",
                content: [
                    ['UNKNOWN', 'Unkown'], ['NONSMOKER', 'Non-Tobacco'], ['SMOKER', 'Tobacco'], ['NONTOBACCO', 'Nicotine Non-Tobacco'],
                    ['TOBACCO', 'Tobacco Lower Risk'], ['BLENDED', 'Combined'], ['PRESMOKER', 'Preferred Tobacco'],
                    ['PRENONSMOKER', 'Preferred Non-Tobacco'], ['SUPERPRE', 'Super Preferred (Non-Tobacco)'], ['OTHER', 'Other']
                ],
                rules: {
                    required: true
                }
            },
            PermanentTableRating: {
                type: "number",
                title: "Permanent Table Rating",
                value: 0,
                rules: {
                    min: 0
                }
            },
            PermanentTableRatingEndDate: {
                type: "date",
                title: "Permanent Table Rating End Date",
                value: ""
            }
        };
    }

    SaveToMemory(containerId, parentId) {
        var valid = true;
        parentId = parseInt(parentId);

        if (this.constructor.id === -1) {
            //if the contructor id hasn't been set yet then create it and save it into memory
            this.constructor.id = containerId;
            sessionStorage.setItem(containerId, JSON.stringify(this.List));
            return;
        } else {
            var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
            this.List = [];

            for (var i in data)
                this.List.push(data[parseInt(i)]);
        }

        //find the coverage in the list and remove it
        for (var i = 0; i < this.List.length; i++) {
            if (this.List[i].CoverageId === parseInt(parentId)) {
                this.List.splice(i, 1);
            }
        }

        //start with the opening json part
        var json = "{";

        //loop through all of the values on the form.
        $(".val").each(function () {

            //the id of the object is the key
            var key = $(this).attr('id');

            //get the value
            var value = $(this).val();

            //console.log(this.Properties[0]);

            var prefix = '"'
            switch ($(this).attr('data-type')) {
                case "decimal":
                case "number":
                    prefix = "";
                    break;
            }

            if (!(this).validity.valid) {
                valid = false;
                $(this).addClass("is-invalid");
                document.forms["render-content"].reportValidity();
            }

            //build a key value pair
            json += `"${key}": ${prefix}${value}${prefix},`;
        });

        //remove the last , that is added
        json = json.slice(0, -1);

        if (json == "")
            return;

        //wrap up the json
        json += "}";

        if (!valid)
            throw "Invalid please catch!";

        var newObject = {
            Container: containerId,
            CoverageId: parentId,
            Json: json
        }

        this.List.push(newObject);

        sessionStorage.setItem(this.constructor.id, JSON.stringify(this.List));
    }

    OpenFromMemory(id, selected) {
        var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
        this.List = [];

        for (var i in data)
            this.List.push(data[parseInt(i)]);

        var coverage = null;

        for (var i = 0; i < this.List.length; i++) {
            if (this.List[i].CoverageId === parseInt(selected)) {
                coverage = this.List[i];
            }
        }

        var json = coverage.Json;

        json = JSON.parse(json);

        for (var i in this.Properties) {
            //Set the properties with the key to value at i.
            this.Properties[i].value = json[i];
        }
    }

    ExportToJson(id) {
        var json = `"Coverages":[`;

        var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
        this.List = [];

        for (var i in data)
            this.List.push(data[parseInt(i)]);

        for (var i = 0; i < this.List.length; i++) {
            var newJson = JSON.parse(this.List[i].Json);
            newJson = JSON.stringify(newJson, null, "\t");

            json += newJson + ",";
        }
        //remove the last , that is added
        if (json != `"Coverages":[`)
            json = json.slice(0, -1);

        json += "]"

        return json;
    }

    ImportFromJson(json) {

    }
}

class Coverage {

    constructor() {
        var helper = new Helpers();
        this.Properties = {
            PlanId: {
                type: "list",
                title: "Plan Id",
                value: "",
                content: helper.GetPlanIds(),
                rules: {
                    requried: true
                }
            },
            CoverageTypeCode: {
                type: "list",
                title: "Coverage Type Code",
                value: "",
                content: [
                    ['ABE', 'Accelerated Benefit Rider'], ['ADB', 'Accidental Death Benefit'], ['APPLWAIV', 'Applicant Waiver'],
                    ['OPAI', 'Guaranteed Insurability'], ['WMD', 'Waiver of Monthly Deduction']
                ],
                rules: {
                    requried: true
                }
            },
            CurrentAmt: {
                type: "decimal",
                title: "Current Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            IssueAge: {
                type: "number",
                title: "Issue Age",
                value: 0,
                rules: {
                    min: 0,
                    max: 85
                }
            },
            FaceAmount: {
                type: "decimal",
                title: "Face Amount",
                value: 0.0,
                rules: {
                    min: 0
                }
            },
            TobaccoPremiumBasisCode: {
                type: "list",
                title: "Tobacco Premium Basis Code",
                value: "",
                content: [
                    ['UNKNOWN', 'Unkown'], ['NONSMOKER', 'Non-Tobacco'], ['SMOKER', 'Tobacco'], ['NONTOBACCO', 'Nicotine Non-Tobacco'],
                    ['TOBACCO', 'Tobacco Lower Risk'], ['BLENDED', 'Combined'], ['PRESMOKER', 'Preferred Tobacco'],
                    ['PRENONSMOKER', 'Preferred Non-Tobacco'], ['SUPERPRE', 'Super Preferred (Non-Tobacco)'], ['OTHER', 'Other']
                ],
                rules: {
                    required: true
                }
            },
            PermanentTableRating: {
                type: "number",
                title: "Permanent Table Rating",
                value: 0,
                rules: {
                    min: 0
                }
            },
            PermanentTableRatingEndDate: {
                type: "date",
                title: "Permanent Table Rating End Date",
                value: ""
            }
        };
    }

    SaveToMemory(id, coverageId) {
        var coverage = new Coverages();
        coverage.SaveToMemory(coverage.constructor.id, coverageId);
    }
    ImportFromJson(json) {
        for (var i in this.Properties) {
            //Set the properties with the key to value at i.
            if (json[i] == undefined) {
                return;
            }

            this.Properties[i].value = json[i];
        }
    }
}

class Funds {
    static get count() {
        return this._count || 0;
    }

    static set count(v) {
        this._count = v;
    }

    static get id() {
        return this._id === undefined ? -1 : this._id;
    }

    static set id(v) {
        this._id = v;
    }
    constructor() {
        this.max = 1;
        this.List = [];
        this.Properties = {
            FundAccountId: {
                type: "string",
                title: "Fund Account Id",
                value: "",
                rules: {
                    min: 1
                }
            },
            FundAllocationPercent: {
                type: "decimal",
                title: "Fund Allocation Percent",
                value: 0.0,
                rules: {
                    min: 0
                }
            }
        };
    }

    SaveToMemory(containerId, parent) {
        var valid = true;
        parent = parseInt(parent);

        if (this.constructor.id === -1) {
            this.constructor.id = containerId;
            console.log(Coverages.id);
            sessionStorage.setItem(containerId, JSON.stringify(this.List));
            return;
        } else {
            var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
            this.List = [];

            for (var i in data)
                this.List.push(data[parseInt(i)]);
        }

        for (var i = 0; i < this.List.length; i++) {
            if (this.List[i].CoverageId === parseInt(parent)) {
                this.List.splice(i, 1);
            }
        }

        //start with the opening json part
        var json = "{";

        //loop through all of the values on the form.
        $(".val").each(function () {

            //the id of the object is the key
            var key = $(this).attr('id');

            //get the value
            var value = $(this).val();

            //console.log(this.Properties[0]);

            var prefix = '"'
            switch ($(this).attr('data-type')) {
                case "decimal":
                case "number":
                    prefix = "";
                    break;
            }

            if (!(this).validity.valid) {
                valid = false;
                $(this).addClass("is-invalid");
                document.forms["render-content"].reportValidity();
            }

            //build a key value pair
            json += `"${key}": ${prefix}${value}${prefix},`;
        });

        //remove the last , that is added
        json = json.slice(0, -1);

        if (json == "")
            return;

        //wrap up the json
        json += "}";

        if (!valid)
            throw "Invalid please catch!";

        var newObject = {
            Container: containerId,
            CoverageId: parent,
            Json: json
        }

        this.List.push(newObject);

        sessionStorage.setItem(this.constructor.id, JSON.stringify(this.List));
    }

    OpenFromMemory(id, selected) {
        var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
        this.List = [];

        for (var i in data)
            this.List.push(data[parseInt(i)]);

        var coverage = null;

        for (var i = 0; i < this.List.length; i++) {
            if (this.List[i].CoverageId === parseInt(selected)) {
                coverage = this.List[i];
            }
        }

        var json = coverage.Json;

        json = JSON.parse(json);

        for (var i in this.Properties) {
            //Set the properties with the key to value at i.
            this.Properties[i].value = json[i];
        }
    }

    ExportToJson(id) {
        var json = `"Funds":[`;

        var data = JSON.parse(sessionStorage.getItem(this.constructor.id));
        this.List = [];

        for (var i in data)
            this.List.push(data[parseInt(i)]);

        for (var i = 0; i < this.List.length; i++) {
            var newJson = JSON.parse(this.List[i].Json);
            newJson = JSON.stringify(newJson, null, "\t");

            json += newJson + ",";
        }
        //remove the last , that is added
        if (json != `"Funds":[`)
            json = json.slice(0, -1);

        json += "]"

        return json;
    }
}

class Fund {
    constructor() {
        this.Properties = {
            FundAccountId: {
                type: "string",
                title: "Fund Account Id",
                value: "",
                rules: {
                    min: 1
                }
            },
            FundAllocationPercent: {
                type: "decimal",
                title: "Fund Allocation Percent",
                value: 0.0,
                rules: {
                    min: 0
                }
            }
        };
    }

    SaveToMemory(id, fundId) {
        var fund = new Funds();
        fund.SaveToMemory(fund.constructor.id, fundId);
    }
    ImportFromJson(json) {
        for (var i in this.Properties) {
            if (json[i] == undefined) {
                return;
            }

            //Set the properties with the key to value at i.
            this.Properties[i].value = json[i];
        }
    }
}