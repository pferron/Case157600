using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.ChildObject
{
    // Validation result object used with the CompositeObjectValidationAttribute
    public class CompositeObjectValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }

        public CompositeObjectValidationResult(string errorMessage) : base(errorMessage) { }
        public CompositeObjectValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
        protected CompositeObjectValidationResult(ValidationResult validationResult) : base(validationResult) { }

        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}
