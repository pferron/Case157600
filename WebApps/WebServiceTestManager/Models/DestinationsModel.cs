using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServiceTestManager.Models
{
    /// <summary>
    /// The model for the destinations view
    /// </summary>
    public class DestinationViewModel : IViewModel
    {
        /// <summary>
        /// Id given to each of the destinations
        /// </summary>
        [HiddenInput(DisplayValue =false)]
        public int  Id { get; set; }

        /// <summary>
        /// The name that the destination was given
        /// </summary>
        [StringLength(50, MinimumLength =3, ErrorMessage ="The name should be larger than three.")]
        [Required(ErrorMessage ="Please enter a name.")]
        public string Name { get; set; }
        /// <summary>
        /// The url that the test will hit
        /// </summary>       
        [Required(ErrorMessage ="Please fill the url feild.")]
        public string Url { get; set; }
    }
}