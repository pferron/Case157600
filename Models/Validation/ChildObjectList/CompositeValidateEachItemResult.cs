using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.ChildObjectList
{
    public class CompositeValidateEachItemResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }

        public CompositeValidateEachItemResult(string errorMessage) : base(errorMessage) { }
        public CompositeValidateEachItemResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
        protected CompositeValidateEachItemResult(ValidationResult validationResult) : base(validationResult) { }

        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}
