using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordIllustrationRequestExtension : OLifEExtension
    {
        [XmlElement("SolveParameters", Order = 1)]
        public Solve_Parameters SolveParameters { get; set; }

        [XmlElement("IllustrationValuesPageRequest", Order = 2)]
        public OLI_LU_BOOLEAN IllustrationValuesPageRequest { get; set; }

        [XmlElement("BatchMode", Order = 3)]
        public OLI_LU_BOOLEAN BatchMode { get; set; }
    }
}