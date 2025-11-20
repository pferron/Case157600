using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceTestManager.Models.Validation;

namespace WebServiceTestManager.Models
{
    /// <summary>
    /// The four type of raters
    /// </summary>
    public enum RaterType
    {
        [Display(Name = "Family Term Rater")]
        FamilyTermRater,
        
        [Display(Name = "Independence Rater")]
        IndependenceRater,

        [Display(Name = "Life Rater")]
        LifeRater,

        [Display(Name = "Patriot Rater")]
        PatriotRater

    }

    public enum Status
    {
        InProgress,
        Passed,
        Failed
    }

    /// <summary>
    /// The rater file model for all rater files.
    /// Essentially the info for each file.
    /// </summary>
    public class RaterModel : IViewModel
    {
        /// <summary>
        /// The GUID for the file will also be it's name
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public Guid FileId { get; set; }

        /// <summary>
        /// The orignal name of the file
        /// </summary>
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name should be larger than three.")]
        [Display(Name = "File Name")]
        [Required(ErrorMessage = "Please enter a file name.")]
        public string FileName { get; set; }

        ///// <summary>
        ///// The expected result of the run, note the actual result may not be the same.
        ///// </summary>
        //[RegularExpression(@"(?<=^| )\d+(\.\d+)?(?=$| )", ErrorMessage = "Please remove any commas or non digits")]
        //[Display(Name = "Expected Result")]
        //[Required(ErrorMessage = "Please enter an expected result")]
        //public decimal ExpectedResult { get; set; }

        [Required(ErrorMessage = "Please add an expected Value")]
        [DataType("ExpectedValue")]
        public List<ExpectedResultModel> Expected { get; set; }

        /// <summary>
        /// The file that we are uploading.
        /// </summary>
        [DataType("FileUpload")]
        [Display(Name = "Formatted Data File")]
        [Required(ErrorMessage ="Please attach a file.")]
        public HttpPostedFileBase File { get; set; }



        [HiddenInput(DisplayValue = false)]
        /// <summary>
        /// The test set id for the rater
        /// </summary>
        public int TestSetId { get; set; }

        [HiddenInput(DisplayValue = false)]
        /// <summary>
        /// The enum for the status of the file.
        /// </summary>
        public Status Passed { get; set; }

        /// <summary>
        /// The summary of the file, if ther's an error it will show here.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string Summary { get; set; }

        /// <summary>
        /// Determines if the user wants to add another model
        /// </summary>
        [DataType("Boolean")]
        [Display(Name ="Add another?")]
        public bool AddAnother { get; set; }
    }
}