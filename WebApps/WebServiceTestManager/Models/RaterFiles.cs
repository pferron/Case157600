using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    

    /// <summary>
    /// Rater files stored on the file system
    /// </summary>
    public class RaterFiles
    {
        /// <summary>
        /// The name of the rater to aviod name colisions
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// The friendly name of the file
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The date the rater file was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The original upload date, note: doesn't change on update but file does
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// One of four rater types required for endpoint
        /// </summary>
        public RaterType RaterType { get; set; }

    }
}