using System;
using System.Collections.Generic;
using System.Linq;
using WOW.Illustration.Model.Generation.Request;
using WoodmenLife.Enterprise.Illustration.Models.Titanium;

namespace WOW.WoodmenIllustrationService.Code
{
    public class FundHelper
    {
        public WoodmenLife.Enterprise.Illustration.Models.Titanium.SubAccount GetIndexedFund(Investment Funds)
        {
            return Funds.SubAccounts.First(f => f.FundAccountId == "WLINDX");
        }

        public WoodmenLife.Enterprise.Illustration.Models.Titanium.SubAccount GetFixedFund(Investment Funds)
        {
            return Funds.SubAccounts.First(f => f.FundAccountId == "IUFIXD");
        }
    }
}