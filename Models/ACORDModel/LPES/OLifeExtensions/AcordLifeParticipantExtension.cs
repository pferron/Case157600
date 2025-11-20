using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordLifeParticipantExtension : OLifEExtension
    {
        [XmlElement("FIPUWClass", Order = 1)]
        public FIP_UW_CLASS_TYPE UnderwritingClass { get; set; }
    }
}