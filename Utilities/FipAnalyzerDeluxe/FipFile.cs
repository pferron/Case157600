using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WOW.FipUtilities;

namespace FipAnalyzerDeluxe
{
    class FipFile
    {
        private Dictionary<string, Dictionary<string, string>> _fipModel;

        private List<bool> _matches;
        private SearchConfig _config;

        public FipFile(FileInfo fileInfo)
        {
            _matches = new List<bool>();

            var content = File.ReadAllText(fileInfo.FullName);
            _fipModel = FipParser.GenerateFipDictionary(content);
        }

        public bool Matches(SearchConfig config)
        {
            if (config == null)
            {
                return false;
            }

            _config = config;

            CheckForMatches();

            if (_matches.Count == 0)
            {
                return false;
            }
            else
            {
                return _matches.All(m => m == true);
            }
        }

        private void CheckForMatches()
        {
            // General options
            _matches.Add(CheckIllustrationType());
            _matches.Add(CheckRatingClass());
            _matches.Add(CheckBillType());
            _matches.Add(CheckBillMode());
            _matches.Add(CheckProductType());
            _matches.Add(CheckSignedState());
            _matches.Add(CheckAgeGroup());

            // Substandard
            if (_config.IncludeTableRated)
            {
                _matches.Add(CheckTableRating());
            }

            if (_config.IncludeFlatExtra)
            {
                _matches.Add(CheckFlatExtra());
            }

            // C&B request
            if (_config.IncludeCostBenefit)
            {
                _matches.Add(CheckCostBenefit());
            }

            // Riders
            if (_config.IncludeAcceleratedBenefit)
            {
                _matches.Add(CheckAcceleratedBenefit());
            }

            if (_config.IncludeAccidentalDeath)
            {
                _matches.Add(CheckAccidentalDeath());
            }

            if (_config.IncludeApplicantWaiver)
            {
                _matches.Add(CheckApplicantWaiver());
            }

            if (_config.IncludeWaiverOfPremium)
            {
                _matches.Add(CheckWaiverOfPremium());
            }

            // Dividend Options
            if (_config.IncludeDividendOptionCash)
            {
                _matches.Add(CheckDividendOptionCash());
            }

            if (_config.IncludeDividendOptionLeftWithWoodmen)
            {
                _matches.Add(CheckDividendOptionLeftWithWoodmen());
            }

            if (_config.IncludeDividendOptionPaidUpAdditional)
            {
                _matches.Add(CheckDividendOptionPaidUpAdditional());
            }

            if (_config.IncludeDividendOptionReducePremiums)
            {
                _matches.Add(CheckDividendOptionReducePremiums());
            }
        }

        private bool CheckDividendOptionCash()
        {
            var key = _fipModel.Keys.FirstOrDefault(k => k.Contains(String.Format("[NONLEVELDATA]_DATATYPECODE_{0}_", 9)));

            if (key != null)
            {
                string tempString;
                int tempInt;

                if (_fipModel[key].TryGetValue("NLCODE_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt == 104)
                        return true;
                }
            }

            return false;
        }

        private bool CheckDividendOptionLeftWithWoodmen()
        {
            var key = _fipModel.Keys.FirstOrDefault(k => k.Contains(String.Format("[NONLEVELDATA]_DATATYPECODE_{0}_", 2)));

            if (key != null)
            {
                string tempString;
                int tempInt;

                if (_fipModel[key].TryGetValue("NLCODE_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt == 107)
                        return true;
                }
            }

            return false;
        }

        private bool CheckDividendOptionPaidUpAdditional()
        {
            var key = _fipModel.Keys.FirstOrDefault(k => k.Contains(String.Format("[NONLEVELDATA]_DATATYPECODE_{0}_", 9)));

            if (key != null)
            {
                string tempString;
                int tempInt;

                if (_fipModel[key].TryGetValue("NLCODE_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt == 101)
                        return true;
                }
            }

            return false;
        }

        private bool CheckDividendOptionReducePremiums()
        {
            var key = _fipModel.Keys.FirstOrDefault(k => k.Contains(String.Format("[NONLEVELDATA]_DATATYPECODE_{0}_", 9)));

            if (key != null)
            {
                string tempString;
                int tempInt;

                if (_fipModel[key].TryGetValue("NLCODE_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt == 103)
                        return true;
                }
            }

            return false;
        }

        private bool CheckApplicantWaiver()
        {
            //ApplicantWaiver	12
            var riderKeys = _fipModel.Keys.Where(k => k.Contains("[ALLRIDERDATA]"));

            foreach (var key in riderKeys)
            {
                if (key.Contains(String.Format("_TYPE_{0}_", 12)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckAcceleratedBenefit()
        {
            //AcceleratedBenefit	105
            var riderKeys = _fipModel.Keys.Where(k => k.Contains("[ALLRIDERDATA]"));

            foreach (var key in riderKeys)
            {
                if (key.Contains(String.Format("_TYPE_{0}_", 105)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckWaiverOfPremium()
        {
            //OLI_COVTYPE_WAIVSCHED	1
            var riderKeys = _fipModel.Keys.Where(k => k.Contains("[ALLRIDERDATA]"));

            foreach (var key in riderKeys)
            {
                if (key.Contains(String.Format("_TYPE_{0}_", 1)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckAccidentalDeath()
        {
            //OLI_COVTYPE_ACCDTHBENE	2
            var riderKeys = _fipModel.Keys.Where(k => k.Contains("[ALLRIDERDATA]"));

            foreach (var key in riderKeys)
            {
                if (key.Contains(String.Format("_TYPE_{0}_", 2)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckCostBenefit()
        {
            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
            {
                if (tempSection.TryGetValue("COSTBENEFIT", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt == 1)
                        return true;
                }
            }

            return false;
        }

        private bool CheckAgeGroup()
        {
            if (_config.AgeGroup == IllustrationOptions.AgeGroup.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[CONTACTBASICDATA]", out tempSection))
            {
                if (tempSection.TryGetValue("AGE", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (_config.AgeGroup == IllustrationOptions.AgeGroup.Adult && tempInt >= 18)
                        return true;

                    if (_config.AgeGroup == IllustrationOptions.AgeGroup.Under18 && tempInt < 18)
                        return true;
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckSignedState()
        {
            if (_config.SignedState == IllustrationOptions.SignedState.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            IllustrationOptions.SignedState tempState;

            if (_fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
            {
                if (tempSection.TryGetValue("WOWSTATE", out tempString))
                {
                    if (Enum.TryParse(tempString, out tempState))
                    {
                        if (_config.SignedState == tempState)
                            return true;
                    }
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckFlatExtra()
        {
            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[COMMONDATA]", out tempSection))
            {
                if (tempSection.TryGetValue("RTGEXTRA_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt > 0)
                        return true;
                }
            }

            if (_fipModel.TryGetValue("[POLICYDATA]", out tempSection))
            {
                if (tempSection.TryGetValue("RTGEXTRA_1", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt > 0)
                        return true;
                }
            }

            return false;
        }

        private bool CheckTableRating()
        {
            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[COMMONDATA]", out tempSection))
            {
                if (tempSection.TryGetValue("RTGAMT", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt > 0)
                        return true;
                }
            }

            if (_fipModel.TryGetValue("[POLICYDATA]", out tempSection))
            {
                if (tempSection.TryGetValue("RTGAMT", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (tempInt > 0)
                        return true;
                }
            }

            return false;
        }

        private bool CheckProductType()
        {
            if (_config.ProductType == IllustrationOptions.ProductType.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempCategoryCode;
            int tempHeaderCode;

            if (_fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
            {
                if (tempSection.TryGetValue("CATEGORYCODE", out tempString) && int.TryParse(tempString, out tempCategoryCode))
                {
                    if (_config.ProductType == IllustrationOptions.ProductType.FamilyTerm)
                    {
                        // Extract header code
                        if (tempSection.TryGetValue("HEADERCODE", out tempString) && int.TryParse(tempString, out tempHeaderCode))
                        {
                            if (tempHeaderCode == 780)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (IllustrationOptions.FipProductTypeValues[_config.ProductType].Contains(tempCategoryCode))
                        {
                            return true;
                        }
                    }
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckBillMode()
        {
            if (_config.BillMode == IllustrationOptions.BillMode.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_config.ProductType == IllustrationOptions.ProductType.Term || _config.ProductType == IllustrationOptions.ProductType.Whole)
            {
                if (_fipModel.TryGetValue("[WLDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("PREMMODE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (IllustrationOptions.FipBillModeValues[_config.BillMode].Contains(tempInt))
                            return true;
                    }
                }
            }

            if (_config.ProductType == IllustrationOptions.ProductType.Universal)
            {
                if (_fipModel.TryGetValue("[ULDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("PREMMODE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (IllustrationOptions.FipBillModeValues[_config.BillMode].Contains(tempInt))
                            return true;
                    }
                }
            }

            if (_config.ProductType == IllustrationOptions.ProductType.Annuity)
            {
                if (_fipModel.TryGetValue("[NONLEVELDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("NLCODE_2", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (IllustrationOptions.FipBillModeValues[_config.BillMode].Contains(tempInt))
                            return true;
                    }
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckBillType()
        {
            if (_config.BillType == IllustrationOptions.BillType.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_config.ProductType == IllustrationOptions.ProductType.Term || _config.ProductType == IllustrationOptions.ProductType.Whole)
            {
                if (_fipModel.TryGetValue("[WLDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("BILLTYPE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (IllustrationOptions.FipBillTypeValues[_config.BillType] == tempInt)
                            return true;
                    }
                }
            }

            if (_config.ProductType == IllustrationOptions.ProductType.Universal)
            {
                if (_fipModel.TryGetValue("[ULDATA]", out tempSection))
                {
                    if (tempSection.TryGetValue("BILLTYPE", out tempString) && int.TryParse(tempString, out tempInt))
                    {
                        if (IllustrationOptions.FipBillTypeValues[_config.BillType] == tempInt)
                            return true;
                    }
                }
            }

            if (_config.ProductType == IllustrationOptions.ProductType.Annuity)
            {
                if (IllustrationOptions.FipBillTypeValues[_config.BillType] == 1) // Annuity only supports regular billing (FIP value 1)
                    return true;
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckRatingClass()
        {
            if (_config.RatingClass == IllustrationOptions.RatingClass.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
            {
                if (tempSection.TryGetValue("CLASSTYPE", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (IllustrationOptions.FipRatingClassValues[_config.RatingClass].Contains(tempInt))
                        return true;
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }

        private bool CheckIllustrationType()
        {
            if (_config.IllustrationType == IllustrationOptions.IllustrationType.Any)
            {
                return true;
            }

            Dictionary<string, string> tempSection;
            string tempString;
            int tempInt;

            if (_fipModel.TryGetValue("[SCENEPOINTERS]", out tempSection))
            {
                if (tempSection.TryGetValue("CONCEPTCODE", out tempString) && int.TryParse(tempString, out tempInt))
                {
                    if (IllustrationOptions.FipIllustrationTypeValues[_config.IllustrationType] == tempInt)
                        return true;
                }
            }

            // If section is missing, key is not found or data doesn't match expected values, return false.
            return false;
        }
    }
}
