using System;
using System.Globalization;
using WOW.Illustration.Model.Generation.Request;
using WOW.Illustration.Model.Generation.Response;
using WOW.RaterUtilities.Enums;
using WOW.WoodmenIllustrationService.SharedModels;

namespace WOW.RaterUtilities
{
    public static class Parser
    {
        public static Policy Parse(RaterRequest request)
        {
            // Check input parameter
            if (request == null)
            {
                throw new ArgumentNullException("request", "The RaterRequest object cannot be null.");
            }

            // Declare builder; assign will be based on header code
            PolicyMaster builder;

            HeaderCode headerCode = (HeaderCode)request.HeaderCode;

            switch (headerCode)
            {
                //TODO: Get all the plan names from Brian and get their header codes added here
                case HeaderCode.NoLapse:
                case HeaderCode.NoLapseWorksite:
                    builder = new PolicyMaster(new NoLapseUniversalLifePolicyBuilder(), request);
                    break;
                case HeaderCode.AccumulatedUniversalLife:
                case HeaderCode.AccumulatedUniversalLifeWorksite:
                    builder = new PolicyMaster(new AccumulationUniversalLifePolicyBuilder(), request);
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
                    builder = new PolicyMaster(new WholeLifePolicyBuilder(), request);
                    break;
                case HeaderCode.TermBaseLevel10Year:
                case HeaderCode.TermBaseLevel15Year:
                case HeaderCode.TermBaseLevel20Year:
                case HeaderCode.TermBaseLevel30Year:
                case HeaderCode.TermBaseLevelYouthWithAcceleratedDeathBenefit:
                case HeaderCode.TermWorksiteBaseLevel20Year:
                case HeaderCode.TermWorksiteBaseLevel30Year:
                case HeaderCode.FamilyTerm:
                    builder = new PolicyMaster(new TermLifePolicyBuilder(), request);
                    break;
                default:
                    // Unexpected header code
                    throw new RaterParsingException(String.Format(CultureInfo.InvariantCulture, "Unexpected header code in FIP data. HeaderCode: {0} {1}.", (int)headerCode, headerCode));
            }

            // Return the policy object to the calling code
            return builder.GetPolicy();
        }

        public static RaterResponse ExtractValues(WoodmenIllustrationResponse wowResponse)
        {
            if (wowResponse.HasValuesFile)
            {
                try
                {
                    var response = new RaterResponse();

                    byte[] fileBytes = Convert.FromBase64String(wowResponse.ValuesFileAttachment);

                    string fileText = System.Text.Encoding.UTF8.GetString(fileBytes);

                    var lines = fileText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    // The rate data is on a line that starts with 1110
                    // We need to find that line, split it on commas and use the correct index value
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("1110,"))
                        {
                            var data = line.Split(new char[] { ',' }, StringSplitOptions.None);

                            decimal tempRate1;
                            decimal tempRate2;

                            if (Decimal.TryParse(data[1], out tempRate1))
                            {
                                response.Rate1 = tempRate1;
                            }

                            if (Decimal.TryParse(data[2], out tempRate2))
                            {
                                response.Rate2 = tempRate2;
                            }

                            break;
                        }
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    throw new RaterParsingException("There was an error parsing values from the illustration text.", ex);
                }
            }
            else
            {
                throw new RaterParsingException("The Woodmen Illustration Service response doesn't have any text data to parse.");
            }
        }
    }
}
