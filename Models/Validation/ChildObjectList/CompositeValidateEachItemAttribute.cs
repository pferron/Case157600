using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.ChildObjectList
{
    // Special attribute to apply to child object lists
    // Example of usage of validating List<Order>
    //public class Customer
    //{
    //    public Customer()
    //    {
    //        Orders = new List<Order>();
    //    }
    // 
    //    [Required(ErrorMessage = "FirstName cannot be empty.")]
    //    public string FirstName { get; set; }
    // 
    //    [ValidateEachItem]
    //    public List<Order> Orders { get; set; }
    //}
    //
    // var context = new ValidationContext(customer, null, null);
    // var results = new List<ValidationResult>();
    //
    // Validator.TryValidateObject(customer, context, results, true);
    //
    // foreach (var validationResult in results)
    // {
    //    // Add code to add list of validation errors to return
    //    // Note: Main error result will indicate error within list
    //    // Note: You will then have to iterate through each item's error results
    // }
    public class CompositeValidateEachItemAttribute : ValidationAttribute
    {
        protected CompositeValidateEachItemResult compositeResults;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IEnumerable;
            if (list == null) return ValidationResult.Success;

            var index = 0;

            foreach (var item in list)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(item, null, null);

                Validator.TryValidateObject(item, context, results, true);

                if (results.Count != 0)
                {
                    if (compositeResults == null)
                    {
                        compositeResults = new CompositeValidateEachItemResult(String.Format("Validation for {0} failed!", validationContext.DisplayName));
                    }

                    // Add result details for current item in list
                    foreach (var result in results)
                    {
                        result.ErrorMessage = $"Item idx: {index} " + result.ErrorMessage;
                        compositeResults.AddResult(result);
                    }
                }

                index++;
            }

            if (compositeResults != null)
            {
                return compositeResults;
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
