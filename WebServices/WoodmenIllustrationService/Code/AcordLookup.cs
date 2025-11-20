using System.Globalization;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// This class represents an ACORD TC object, but without the strongly-typed TC enumeration type.
    /// </summary>
    public class AcordLookup
    {
        //private readonly static ILog logger = LogManager.GetLogger(typeof(AcordLookup));

        /// <summary>
        /// The ACORD Type Code value.
        /// </summary>
        public int TC { get; set; }

        /// <summary>
        /// A textual description of the Type Code.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Provides a textual representation of this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "TC: {0}, Value: {1}", TC, Value);
        }
    }
}