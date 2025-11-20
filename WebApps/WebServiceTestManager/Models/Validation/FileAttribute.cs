using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServiceTestManager.Models.Validation
{
    public class FileAttribute : ValidationAttribute, IClientValidatable
    {
        public FileAttribute()
        {

        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = "ERRRORRRROROR";
            rule.ValidationType = "exclude";
            yield return rule;
        }

        /// <summary>
        /// Check if our file is valid before submit
        /// </summary>
        /// <param name="value">The file</param>
        /// <param name="validationContext">The context that we are validating</param>
        /// <returns>Null if valid or ValidationResult error message.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (HttpPostedFileBase)value == null
                ? new ValidationResult("Hey! ERROR")
                : ValidationResult.Success;
        }

        //public override bool IsValid(object value)
        //{
        //    return false;
        //}
    }
}