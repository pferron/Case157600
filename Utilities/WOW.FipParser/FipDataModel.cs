using System.Collections.Generic;

namespace WOW.FipUtilities
{
    /// <summary>
    /// Class structure used to hold one section of a FIP file.
    /// </summary>
    public class FipDataModel
    {
        /// <summary>
        /// The name of the FIP file section. (e.g. [WLDATA])
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Dictionary that store the name/value pairs under a given FIP section.
        /// </summary>
        public Dictionary<string, string> Data { get; private set; }

        public FipDataModel()
        {
            Data = new Dictionary<string, string>();
        }
    }
}
