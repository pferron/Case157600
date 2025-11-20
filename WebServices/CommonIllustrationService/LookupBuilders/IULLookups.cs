using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wow.CommonIllustrationService.Exceptions;

namespace Wow.CommonIllustrationService.LookupBuilders
{
    public class IULLookups
    {
        internal int ConvertClass(string planId)
        {
            int insuredClass = 0;

            //IUL Youth   TUINDEXC IUL YTH C
            //IUL Standard Non - Tobacco    TUINDEXN IUL AD NT
            //IUL Standard Tobacco TUINDEXT    IUL AD T
            //IUL Preferred Non-Tobacco   TUINDEXP IUL AD PNT
            //IUL Preferred Tobacco TUINDEXR    IUL AD PT
            //IUL Super Preferred Non - Tobacco TUINDEXU IUL AD SP

            switch (planId.ToUpperInvariant())
            {
                case "TUINDEXC":
                    insuredClass = 12;
                    break;
                case "TUINDEXN":
                    insuredClass = 2;
                    break;
                case "TUINDEXT":
                    insuredClass = 4;
                    break;
                case "TUINDEXP":
                    insuredClass = 1;
                    break;
                case "TUINDEXR":
                    insuredClass = 3;
                    break;
                case "TUINDEXU":
                    insuredClass = 5;
                    break;
                default:
                    throw new PolicyConverterException($"ConvertClass failed to process invalid planId: {planId} while executing the Index UniversalLife Policy Converter.");
            }

            return insuredClass;
        }

        internal int ConvertBillingMode(string billingModeCode)
        {
            switch (billingModeCode)
            {
                case "QUARTLY":
                    return 3;
                case "BIANNUAL":
                case "SINGLEPAY":
                    return 2;
                case "MNTHLY":
                    return 6;
                default:
                    return 1; // Annual 'ANNUAL'
            }
        }

        internal string ConvertFundAccount(string fundAccountId)
        {
            //'IUFIXD' – WoodmenLife IUL -Fixed Account
            //'WLINDX' -S & P500 Point - to - Point with Cap Rate

            switch (fundAccountId.ToUpperInvariant())
            {
                case "IUFIXD":
                    return "100";
                case "WLINDX":
                    return "200";
                default:
                    throw new PolicyConverterException($"ConvertFundAccount failed to process invalid fundAccountId: {fundAccountId} while executing the Index UniversalLife Policy Converter.");
            }
        }

        internal int ConvertBillType(string billingMethodCode)
        {
            // { BillType.ListBill, 2 } does not apply to IUL
            switch (billingMethodCode.ToUpper())
            {
                case "REGBILL": //{ BillType.Direct, 1 },
                    return 1;

                case "PAC": //{ BillType.PAC, 3 }
                    return 3;

                default:
                    throw new PolicyConverterException($"ConvertBillType failed to process invalid billingMethodCode: {billingMethodCode} while executing the Index UniversalLife Policy Converter.");

            }

        }
    }
}