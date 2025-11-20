using System.Collections.Generic;

namespace WOW.FipUtilities
{
    class FipSectionModel
    {
        public string SectionName { get; set; }
        public Dictionary<string, string> SectionValues { get; private set; }

        public FipSectionModel()
        {
            SectionValues = new Dictionary<string, string>();
        }
    }
}
