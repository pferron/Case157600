## UNIT-Illustrations
### Clients\MyWoodmenIllustrationClient
Windows Service that polls a DB2 table for illustration requests from Ingenium/MyWoodmen.  Requests are in .fip file format and are sent to the GenerateIllustrationViaFip endpoint in Woodmen Illustration Service (WIS).  WIS returns a pdf file that is saved to the same DB2 table.

#### DB2 Query
```SQL
SELECT CAST(PIRQ_REQ_TS AS CHAR(26)) AS PIRQ_REQ_TS, PIRQ_REQ_USER_ID, PIRQ_POL_ID, PIRQ_FIP_FILE 
FROM WOWTB.PORTAL_ILLUS_REQ 
WHERE PIRQ_STATUS = 'SUBMITTED' and PIRQ_ADMIN_SYS_ID = 'I'
```

#### Deployment Locations
* **TEST:** tst-lpa-mw-1\MyWoodmen Illustration Client
* **UAT:** uat-lpa-mw-1\MyWoodmen Illustration Client
* **MODL:** mdl-lpa-mw-1\MyWoodmen Illustration Client
* **PROD:** prd-lpa-mw-1\MyWoodmen Illustration Client

### Installers\ProductPremiumCollectorServiceInstaller
Wix project to build msi for Product Premium Service Windows Service.  Deployed via Puppet.

### Installers\WoodmenIllustrationServiceInstaller
Wix project to build msi for Woodmen Illustrations Service (WIS) Windows Service.  Deployed via ADO pipelines.

### Installers\WoodmenReconClientInstaller
Wix project to build msi for Woodmen Recon Client Windows Service.  Deployed via SCCM to Sales Laptops.

### Utilities\LpaDataFix
Console application used by Help Desk to fix known offline IllustrationPro database issues such as "No Row for Given Identifier" and "Object Reference" errors when attempting Quick Quote.

### Utilities\ProductPremiumCollector
Windows Service that polls a SQL table for requests to update the rates in the SQL table used by the Premium Input Rater on Mobile Rater.

### Utilities\ResetUpdates
Windows Desktop application used by Help Desk to clear out cache used by IllustrationPro Remote System Update (RSU).  Used when sales reps have activation errors on RSU packages.

### WebServices\CommonIllustrationService
Web API that takes Titanium new business illustration requests from CCHub in the Common Illustration Model (CIM).  It converts the CIM JSON into the Woodmen Illustration Model (WIM) JSON format and passes them to the WIS using the GenerateIllustration endpoint receiving a Woodmen Illustration Response JSON file with the pdf illustration in the PdfFileAttachment property in return.

### File Formats
#### FIP
```TXT
[Illustration]
AgentId, 0
GroupId, -1
ProspectId, 0
SceneID, 0
[Agent]
[AgentData]
AgtFirstName, STEVEN
AgtMiddleInitial, L
AgtLastName, KENT
AgtAddr_1, 1010 CENTENNIAL POST
AgtAddr_2, 
AgtCity, GREENSBORO
AgtState, GA
AgtZip, 30642
AgtPhone, 706-473-7680
[Group]
[Prospect]
[ContactBasicData]
FirstName, Kathy
MiddleInitial, A
LastName, Kendrick
NameSuffix, 
Age, 44
Birthdate, 1977-07-31
Sex, 1
State, GA
Country, USA
[Scene]
[ScenePointers]
CategoryCode, 3
ConceptCode, 5
HeaderCode, 119
ClassCode, 193
ClassType, 2
revisedComment, 
CostBenefit, 0
SceneModifyDate, 07/13/2016
WOWState, GA
[CommonData]
PlanUnisex, 0
RtgAmt, 5
RtgAmtToAge, 57
RtgExtra_1, 0.00
RtgExtraToAge_1, 38
Lump1035Amt, 0
loanIntUsage, 0
wdrlToLoan, 0
printToAge, 0
PolicyNumber, 007400000
StateNAICApproved, 0
NumberOfOwners, 1
[PolicyData]
IssueDate, 2016-07-13
IssueDateEntered, 1
IssueAge, 38
PolicyNumber, 007400000
Class, 193
RtgAmt, 5
RtgAmtToAge, 57
RtgExtra_1, 0
RtgExtraToAge_1, 120
RtgExtra_2, 0
RtgExtraToAge_2, 120
DataDate, 2022-02-14
Year, 7
Month, 8
AccountValue, 1352.16
SurrCharge, $871.00
CumPremium, $309.19
CumWdrl, 0
StdLoanBalance, 0
StdLoanBalance, 0
PrfLoanBalance, 0
GSP, 0
CumGLP, 0
GLP, 0
MEC, 0
G7P, 0
G7Pyear, 1
G7PPremium, 0
DivAccums, 0
PUA, 0
PUACashValue, 0
PUARider, 0
PUARiderCashValue, 0
repAddInsFromRefunds, 0
repAddInsOnDeposit, 0
repPuaInsurance, 0
RepoRtgAmtPerm, 0
RepoRtgAmtPerm_ToAge, 35
StatKind, 
WLPDFB, 0
RefundLast, 0
AvgLoanBal, 0
AvgPDFBal, 0
AvgRefDepBal, 0
CCVPUA, 0
BaseCV, 0
LoanBalWithInt, 0
PDFBalWithInt, 0
RefDepWithInt, 0
RefDepIntRate, 0
PDFIntRate, 0
NLGAccount, $2,300.53
TargetPrem, $541.20
[AllRiderData]
type, 105
code, 10
Level, 1
subType, 1
name, 
age, 0
sex, 0
toggle, 0
toggle2, 0
amount, 0
amount2, 0
issAge, 38
ToAge, 95
Class, 0
rtgAmt, 0
rtgAmtToAge, 0
rtgExtra, 0
rtgExtraToAge, 0
planCode, 
insured, 0
joint, 0
[NonLevelData]
DataTypeCode, 1
Level, 1
NLCode_1, 1
NLCode_2, 0
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 50000
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
DataTypeCode, 2
Level, 1
NLCode_1, 1
NLCode_2, 6
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 44.17
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
DataTypeCode, 2
Level, 2
NLCode_1, 1
NLCode_2, 1
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 0
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
DataTypeCode, 6
Level, 1
NLCode_1, 1
NLCode_2, 0
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 0
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
DataTypeCode, 7
Level, 1
NLCode_1, 1
NLCode_2, 0
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 4.75
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
DataTypeCode, 8
Level, 1
NLCode_1, 1
NLCode_2, 0
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 0
NLAmt_2, 0
NlGradePct, 0
NLAge, 44
DataTypeCode, 8
Level, 2
NLCode_1, 1
NLCode_2, 0
NLCode_3, 0
NLCode_4, 0
NLRate_1, 0
NLRate_2, 0
NLAmt_1, 0
NLAmt_2, 0
NlGradePct, 0
NLAge, 101
[NonLevelPolicyData]
DataTypeCode, 0
Level, 1
EffectiveDate, 07/13/2021
EffectiveAge, 43
EffectiveYear, 7
EffectiveMonth, 8
NLAmount_1, 50000
NLAmount_2, 0
NLAmount_3, 0
NLAmount_4, 0
NLAmount_5, 0
NLAmount_6, 0
[Reports]
Code, 203004
level, 1
interestRate, 0
salesCharge, 0
termRates, 0
includeGraph, 0
Code, 203005
level, 2
interestRate, 0
salesCharge, 0
termRates, 0
includeGraph, 0
Code, 203006
level, 3
interestRate, 0
salesCharge, 0
termRates, 0
includeGraph, 0
[UlDATA]
LumpSumUsage, 0
RefundOpt, 1
FrDues, 0
ULTamra, 0
RtgAmtPerm, 5
RtgAmtPerm_ToAge, 64
AdvPremFund, 0
BillType, 2
NLGInt, 4.75
[Batch]
output, 1
outputName, 007400000_2022-02-14-15.51.59.484000.fip
outputPath, D:\programfiles\WoodmenLife\MyWoodmen Illustration Client\Input
outputValues, 0
saveData, 0
```

#### CIM
```JSON
{
    "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.IllustrationRequest, WOW.Correspondence.Common",
    "ApplicationSignedStateCode": "AR",
    "BillingAmount": 14.25,
    "BillingMethodCode": "PAC",
    "BillingModeCode": "MNTHLY",
    "DeathBenefitOptionCode": "LEVEL",
    "Exchange1035Amount": 0.0,
    "SevenPayPremiumAmount": 1240.66,
    "FaceAmount": 25000.00,
    "IllustrationReportType": "COST",
    "IllustrationTypeCode": 0,
    "InitialPremium": 14.25,
    "IssueAge": 20,
    "IssueDate": "2021-12-21T00:00:00",
    "MECAllowedIndicator": false,
    "PermanentTableRatingCode": "",
    "PlanId": "TUINDEXN",
    "PolicyId": "3565476858",
    "ProductTypeCode": "INDXUL",
    "TemporaryFlatExtraRateAmount": 0.00000,
    "TemporaryFlatExtraEndDate": null,
    "TemporaryFlatExtraAmount": 0.0,
    "Agent":  {
        "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.AgentPerson, WOW.Correspondence.Common",
        "FirstName": "Lynnette",
        "MiddleName": "Marie",
        "LastName": "Buck",
        "AddressLine1": "PO Box 1017",
        "AddressLine2": "",
        "AddressCity": "Fort Smith",
        "AddressStateCode": "AR",
        "AddressZip": "72902",
        "PhoneNumber": "4793229656"
    },
    "Client": {
        "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.ClientPerson, WOW.Correspondence.Common",
        "FirstName": "Ricardo",
        "MiddleName": "",
        "LastName": "Savoy",
        "NameSuffix": "",
        "BirthDate": "2001-01-13T00:00:00",
        "GenderCode": "MALE",
        "AddressStateCode": "UNKNOWN",
        "AddressCountryCode": "USA",
        "Age": 20
    },
    "Coverages": {
        "$type": "System.Collections.Generic.List`1[[WOW.Correspondence.Common.Models.CommonIllustrationModel.Coverage, WOW.Correspondence.Common]], mscorlib",
        "$values": [
            {
                "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.Coverage, WOW.Correspondence.Common",
                "PlanId": "TUINDEXN",
                "CoverageTypeCode": "ADBCHRONILL",
                "CurrentAmt": 1000.00,
                "IssueAge": 20,
                "FaceAmount": 1000.00,
                "TobaccoPremiumBasisCode": "NONSMOKER",
                "PermanentTableRating": 100,
                "PermanentTableRatingEndDate": null
            }, {
                "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.Coverage, WOW.Correspondence.Common",
                "PlanId": "TUINDEXN",
                "CoverageTypeCode": "ADB",
                "CurrentAmt": 25000.00,
                "IssueAge": 20,
                "FaceAmount": 25000.00,
                "TobaccoPremiumBasisCode": "NONSMOKER",
                "PermanentTableRating": 100,
                "PermanentTableRatingEndDate": null
            }
        ]
    },
    "Funds": {
        "$type": "System.Collections.Generic.List`1[[WOW.Correspondence.Common.Models.CommonIllustrationModel.FundAccount, WOW.Correspondence.Common]], mscorlib",
        "$values": [
            {
                "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.FundAccount, WOW.Correspondence.Common",
                "FundAccountId": "WLINDX",
                "FundAllocationPercent": 100.0
            }, {
                "$type": "WOW.Correspondence.Common.Models.CommonIllustrationModel.FundAccount, WOW.Correspondence.Common",
                "FundAccountId": "IUFIXD",
                "FundAllocationPercent": 0.0
            }
        ]
    }
}

```