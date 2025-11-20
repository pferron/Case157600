using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class FileDetailViewModel : IViewModel
    {
        /// <summary>
        /// The friendly name of the file
        /// </summary>
        [Display(Name = "File Name")]
        public string FileName { get; set; }

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
        public string Summary { get; set; }
    }
}