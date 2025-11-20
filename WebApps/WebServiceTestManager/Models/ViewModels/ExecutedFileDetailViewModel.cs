using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class ExecutedFileDetailViewModel : IViewModel
    {
        /// <summary>
        /// All expected results for the file
        /// </summary>
        [Display(Name = "Expected Values")]
        [DataType("ExpectedValues")]
        public List<ExpectedValue> Expected { get; set; }

        /// <summary>
        /// The detailed summary of what happend.
        /// </summary>
        [Display(Name = "Summary of events")]
        [DataType("Summary")]
        public string Summary { get; set; }
    }
}