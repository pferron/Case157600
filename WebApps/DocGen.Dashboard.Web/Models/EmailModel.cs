using System.Web.Script.Serialization;

namespace LPA.Dashboard.Web.Models
{
    /// <summary>
    /// The model used to create the deployment email template
    /// </summary>
    public class EmailModel
    {
        /// <summary>
        /// The full version of the deployment
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The Description of the update
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of result, at this time just "success" or "error"
        /// </summary>
        public string ResultType { get; set; }

        /// <summary>
        /// The result in words
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// The region that was deployed to.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The person who made the deployment.
        /// </summary>
        public string DeployedBy { get; set; }

        /// <summary>
        /// The promote path of the files.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The date that the email is being sent out
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// ToString.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString() => new JavaScriptSerializer().Serialize(this);
    }
}