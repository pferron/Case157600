using System.ComponentModel;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The enumerations.
    /// </summary>
    public class Enumerations
    {
        /// <summary>
        /// The deployment status.
        /// </summary>
        public enum DeploymentStatus
        {
            [Description("Current")]
            Current,
            [Description("SccmError")]
            SccmError,
            [Description("RsuError")]
            RsuError
        }
    }
}