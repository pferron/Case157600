
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WOW.FipUtilities.Enums;
using WOW.Illustration.Model.Generation.Request;

namespace WOW.FipUtilities
{
    /// <summary>
    /// The FipParser is useful for converting the content of a FIP file to an object. The section headers are a property of a FipDataModel and the name/value
    /// pairs under that section are added to a dictionary. The section names and dictionary keys are converted to uppercase to increase tolerance to input variations.
    /// </summary>
    public static class FipParser
    {
        /// <summary>
        /// Converts a FIP file string into a IPolicy object.
        /// </summary>
        /// <param name="fipInput">String representing a single FIP request.</param>
        /// <returns>A policy object specific to the header code provided in the FIP data.</returns>
        public static Policy Parse(string fipInput)
        {
            try
            {
                // Check input parameter
                if (String.IsNullOrEmpty(fipInput))
                {
                    throw new ArgumentException("The FIP string cannot be null or empty.", "fipInput");
                }

                // Read FIP data into a list
                var fipData = GenerateFipList(fipInput);

                // Declare builder; assign will be based on header code
                PolicyMaster builder;

                // The expectation is that each FIP file will contain one request.
                // FIP files with multiple [Illustration] sections will need to be broken up and submitted individually.
                var item = fipData.Single(f => f.Section == "[SCENEPOINTERS]");

                // Extract header code so we can determine the policy object to use.
                // If the "HeaderCode" is missing, that is exceptional.
                // If the "HeaderCode" is not an int, that is exceptional.
                HeaderCode headerCode;
                Enum.TryParse(item.Data["HEADERCODE"], out headerCode);

                // Based on the header code, set the policy builder instance
                switch (headerCode)
                {
                    case HeaderCode.NoLapse:
                    case HeaderCode.NoLapseWorksite:
                    case HeaderCode.NoLapse2017:
                        builder = new PolicyMaster(new NoLapseGuaranteedUniversalLifePolicyBuilder(), fipData);
                        break;

                    case HeaderCode.AccumulatedUniversalLife:
                    case HeaderCode.AccumulatedUniversalLifeWorksite:
                        builder = new PolicyMaster(new AccumulationUniversalLifePolicyBuilder(), fipData);
                        break;
                    case HeaderCode.WholeLifeEZApp20Pay:
                    case HeaderCode.WholeLifeEZAppPaidUpAt100:
                    case HeaderCode.WholeLifeEZAppPaidUpAt65:
                    case HeaderCode.WholeLifeEZAppSinglePremium:
                    case HeaderCode.WholeLifeEZAppUnisexPaidUpAt100:
                    case HeaderCode.WholeLifeLP100ConversionApplication:
                    case HeaderCode.WholeLifeRegularApp20Pay:
                    case HeaderCode.WholeLifeRegularAppPaidUpAt65:
                    case HeaderCode.WholeLifeRegularAppPaidUpAtAge100:
                    case HeaderCode.WholeLifeRegularAppSinglePremium:
                    case HeaderCode.WholeLifeRegularAppUnisexPaidUpAt100:
                    case HeaderCode.WholeLifeUnisexLP100ConversionApplication:
                    case HeaderCode.RedPaidUpAt100:
                    case HeaderCode.RedUnisexPaidUpAt100:
                    case HeaderCode.WorksitePaidUpAt100:
                    case HeaderCode.WorksitePaidUpAt65:
                    case HeaderCode.BlueWhitePaidUpAt65:
                    case HeaderCode.BlueWhiteUnisexPaidUpAt100:
                    case HeaderCode.BlueWhitePaidUpAt100:
                    case HeaderCode.BlueWhiteSinglePremium:
                    case HeaderCode.BlueWhite20Pay:
                    // 2017 CSO Whole Life
                    case HeaderCode.WholeLifePaidUpAtAge100_2017:
                    case HeaderCode.WholeLifePaidUpAtAge65_2017:
                    case HeaderCode.WholeLife20PayWholeLife_2017:
                    case HeaderCode.WholeLife10PayWholeLife_2017:
                    case HeaderCode.WorkplaceWholeLifePaidUpAtAge100_2017:
                    case HeaderCode.WholeLifeEZPaidUpAtAge100_2017:
                    case HeaderCode.WholeLifeEZPaidUpAtAge65_2017:
                    case HeaderCode.WholeLifeEZ20Pay_2017:
                    case HeaderCode.WholeLifeEZ10Pay_2017:
                    case HeaderCode.WorkplaceWholeLifeEZPaidUpAtAge100_2017:
                    case HeaderCode.ConversionWholeLifePaidUpAtAge100_2017:
                    case HeaderCode.WorkplaceConversionWholeLifePaidUpAtAge100_2017:
                    case HeaderCode.GradedWholeLifeEZPaidUpAtAge100_2017:
                    case HeaderCode.WorkplaceGradedWholeLifeEZPaidUpAtAge100_2017:
                        builder = new PolicyMaster(new WholeLifePolicyBuilder(), fipData);
                        break;
                    case HeaderCode.TermBaseLevel10Year2016:
                    case HeaderCode.TermBaseLevel15Year2016:
                    case HeaderCode.TermBaseLevel20Year2016:
                    case HeaderCode.TermBaseLevel30Year2016:
                    case HeaderCode.TermWorksiteBaseLevel20Year2016:
                    case HeaderCode.TermWorksiteBaseLevel30Year2016:
                    case HeaderCode.FamilyTerm10Year2016:
                    case HeaderCode.FamilyTerm20Year2016:
                    case HeaderCode.TermBaseLevel10Year:
                    case HeaderCode.TermBaseLevel15Year:
                    case HeaderCode.TermBaseLevel20Year:
                    case HeaderCode.TermBaseLevel30Year:
                    case HeaderCode.TermBaseLevelYouthWithAcceleratedDeathBenefit:
                    case HeaderCode.TermWorksiteBaseLevel20Year:
                    case HeaderCode.TermWorksiteBaseLevel30Year:
                    case HeaderCode.FamilyTerm:
                        builder = new PolicyMaster(new TermLifePolicyBuilder(), fipData);
                        break;
                    case HeaderCode.FixedAnnuityFlexiblePremiumDeferredAnnuityBonus:
                    case HeaderCode.FixedAnnuityFlexiblePremiumDeferredAnnuityNonBonus:
                    case HeaderCode.FixedAnnuitySinglePremiumDeferredAnnuityBonus:
                    case HeaderCode.FixedAnnuitySinglePremiumDeferredAnnuityNonBonus:
                        builder = new PolicyMaster(new DeferredAnnuityPolicyBuilder(), fipData);
                        break;
                    default:
                        // Unexpected header code
                        throw new FipParseException(String.Format(CultureInfo.InvariantCulture, "Unexpected header code in FIP data. HeaderCode: {0} {1}.", (int)headerCode, headerCode));
                }

                // Return the policy object to the calling code
                return builder.GetPolicy();
            }
            catch (FipParseException ex)
            {
                // If I've already packaged an exceptional situation in my custom exception, let's not do it again needlessly.
                // Some methods can't see the fipInput, so let's add it on to the exception, if needed.
                if (String.IsNullOrEmpty(ex.FipInput))
                {
                    ex.FipInput = fipInput;
                }

                throw;
            }
            catch (Exception ex)
            {
                // If some other exception occurs, package it up in custom exception and throw.
                throw new FipParseException("An error occured while trying to parsing the FIP input.", ex) { FipInput = fipInput };
            }
        }

        public static Dictionary<string, Dictionary<string, string>> GenerateFipDictionary(string fipInput)
        {
            var list = GenerateFipList(fipInput);
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            foreach (var item in list)
            {
                if (item.Section == "[NONLEVELDATA]" || item.Section == "[NONLEVELPOLICYDATA]")
                {
                    string tempValue;
                    var newKey = item.Section;
                    var pairs = item.Data;

                    if (pairs.TryGetValue("DATATYPECODE", out tempValue))
                    {
                        newKey += "_DATATYPECODE_" + tempValue;
                    }

                    if (pairs.TryGetValue("LEVEL", out tempValue))
                    {
                        newKey += "_LEVEL_" + tempValue;
                    }

                    dictionary.Add(newKey, pairs);
                }
                else if (item.Section == "[REPORTS]")
                {
                    string tempValue;
                    var newKey = item.Section;
                    var pairs = item.Data;

                    if (pairs.TryGetValue("CODE", out tempValue))
                    {
                        newKey += "_CODE_" + tempValue;
                    }

                    dictionary.Add(newKey, pairs);
                }
                else if (item.Section == "[ALLRIDERDATA]")
                {
                    string tempValue;
                    var newKey = item.Section;
                    var pairs = item.Data;

                    if (pairs.TryGetValue("TYPE", out tempValue))
                    {
                        newKey += "_TYPE_" + tempValue;
                    }

                    if (pairs.TryGetValue("SUBTYPE", out tempValue))
                    {
                        newKey += "_SUBTYPE_" + tempValue;
                    }

                    if (pairs.TryGetValue("LEVEL", out tempValue))
                    {
                        newKey += "_LEVEL_" + tempValue;
                    }

                    dictionary.Add(newKey, pairs);
                }
                else if (item.Section == "[POLICYDATA]" && item.Data.Count == 1)
                {
                    // Skip the extra Bill Type pair.
                }
                else
                {
                    dictionary.Add(item.Section, item.Data);
                }
            }

            return dictionary;
        }

        /// <summary>
        /// First step in converting FIP to IPolicy. Extracts the sections and name/value pairs to objects and add the objects to a list.
        /// </summary>
        /// <param name="fipInput">FIP file as a string.</param>
        /// <returns>List of FipDataModel objects.</returns>
        private static List<FipDataModel> GenerateFipList(string fipInput)
        {
            // Collection for FIP data
            var fipData = new List<FipDataModel>();

            try
            {
                using (var sr = new StringReader(fipInput))
                {
                    string line;
                    FipDataModel model = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        // This is a new section header, create a new object and move to the next line
                        if (line.Contains("["))
                        {
                            model = new FipDataModel() { Section = line.Trim().ToUpperInvariant() };
                            fipData.Add(model);
                        }
                        else
                        {
                            if (model != null)
                            {
                                // There are dates and monetary values in the FIP file, so there can be more than 2 elements.
                                var lineElements = line.Split(',');

                                // Assign key to variable
                                var key = lineElements[0].Trim().ToUpperInvariant();

                                // Assemble the rest of the elements into the value
                                // Placeholder for re-assembled values
                                var value = String.Join(",", lineElements, 1, lineElements.Length - 1).Trim();

                                // Need to strip dollar signs from values, as well.
                                value = value.Replace("$", "");

                                // Sample row: 'Age, 35 '
                                // So, temp[0] should be 'Age' and temp[1] should be ' 35 '
                                // Riders throws a wrench in the works because they have one section and duplicate keys.
                                if (model.Data.ContainsKey(key))
                                {
                                    var isNewSection = "[ALLRIDERDATA]".Equals(model.Section) && "TYPE".Equals(key);

                                    isNewSection = isNewSection || ("[NONLEVELDATA]".Equals(model.Section) && "DATATYPECODE".Equals(key));
                                    isNewSection = isNewSection || ("[NONLEVELPOLICYDATA]".Equals(model.Section) && "DATATYPECODE".Equals(key));
                                    isNewSection = isNewSection || ("[REPORTS]".Equals(model.Section) && "CODE".Equals(key));

                                    if (isNewSection)
                                    {

                                        // Duplicate key detected for this section.
                                        // Copy section name to local variable
                                        string sectionName = model.Section;
                                        // Create a new object with the existing section name and continue loading.
                                        model = new FipDataModel() { Section = sectionName };
                                        fipData.Add(model);
                                    }
                                    else
                                    {
                                        //Temporary hack until we can remove the duplicate entry from MyWoodmen.
                                        if ("STDLOANBALANCE".Equals(key))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            var message = string.Format("Unexpected Duplicate key detected! Section: {0}, Key: {1}", model.Section, key);
                                            throw new FipParseException(message);
                                        }
                                    }
                                }
                                // Add name/value to dictionary
                                model.Data.Add(key, value);
                            }
                            else
                            {
                                throw new FipParseException("Data was encountered with no section header.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FipParseException("An error occured while trying to generate a FIP data list.", ex) { FipInput = fipInput };
            }

            return fipData;
        }

    }
}
