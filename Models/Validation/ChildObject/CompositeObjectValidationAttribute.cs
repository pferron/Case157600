using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.ChildObject
{
    // Special attribute to apply to child class objects
    // Example of usage:
    // public class Customer
    // {
    //    public Customer()
    //    {
    //        Orders = new List<Order>();
    //    }
    //
    //    [Required(ErrorMessage = "FirstName cannot be empty.")]
    //    public string FirstName { get; set; }
    //
    //    [Required, ValidateObject]
    //    public Address Address { get; set; }
    // }
    //
    // var context = new ValidationContext(customer, null, null);
    // var results = new List<ValidationResult>();
    //
    // Validator.TryValidateObject(customer, context, results, true);
    //
    // foreach (var validationResult in results)
    // {
    //    // Add code to add list of validation errors to return
    //    // Note: Main error result will indicate error within child class
    //    // Note: You will then have to iterate through the child error results
    // }
    public class CompositeObjectValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            Validator.TryValidateObject(value, context, results, true);

            if (results.Count != 0)
            {
                var compositeResults = new CompositeObjectValidationResult(String.Format("Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);

                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }
}
