using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using Validation.ChildObject;
using Validation.ChildObjectList;
using Wow.CommonIllustrationService.Builders;
using Wow.IllustrationCommonModels.Request;

namespace Wow.CommonIllustrationService.Code
{
    public class RequestValidator
    {
        internal static void Validate(IllustrationRequest illustrationRequest)
        {
            StringBuilder sb = new StringBuilder();

            var context = new ValidationContext(illustrationRequest, null, null);
            var results = new List<ValidationResult>();

            try
            {
                Validator.TryValidateObject(illustrationRequest, context, results, true);

                foreach (var validationResult in results)
                {
                    //check if child object
                    var childResult = validationResult as CompositeObjectValidationResult;
                    if (childResult != null)
                    {
                        foreach (var childValidationResult in childResult.Results)
                        {
                            sb.Append(childValidationResult.ErrorMessage);
                            sb.Append(" ");
                        }
                    }
                    else
                    {
                        //check if child object list
                        var childResultList = validationResult as CompositeValidateEachItemResult;
                        if (childResultList != null)
                        {
                            foreach (var childValidationListResult in childResultList.Results)
                            {
                                sb.Append(childValidationListResult.ErrorMessage);
                                sb.Append(" ");
                            }
                        }
                        else
                        {
                            var parentResult = validationResult as ValidationResult;
                            if (parentResult != null)
                            {
                                //main property
                                sb.Append(parentResult.ErrorMessage);
                                sb.Append(" ");
                            }
                            else
                            {
                                throw new Exception("Invalid validation result found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IllustrationRequestValidationException($"There was an error validating illustrationRequest: {illustrationRequest}.", ex);
            }

            var validationError = sb.ToString();

            if(validationError.Trim().Length > 0)
            {
                throw new IllustrationRequestValidationException($"Submitted illustrationRequest is invalid. validationError: {validationError}.");
            }
        }
    }
}