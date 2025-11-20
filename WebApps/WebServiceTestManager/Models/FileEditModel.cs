using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServiceTestManager.Models
{
    public class FileEditModel : IViewModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name should be larger than three.")]
        [Display(Name = "File Name")]
        [Required(ErrorMessage = "Please enter a file name.")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "Please add an expected Value")]
        [DataType("ExpectedValuesFromList")]
        public List<ExpectedResultModel> ExpectedResults { get; set; }

        /// <summary>
        /// The id of the file
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public Guid FileId { get; set; }

        /// <summary>
        /// The file that we are uploading.
        /// </summary>
        [DataType("FileUpload")]
        [Display(Name = "Re Upload of a file.")]
        [Required(ErrorMessage = "Please attach a file.")]
        public HttpPostedFileBase File { get; set; }

    }
}