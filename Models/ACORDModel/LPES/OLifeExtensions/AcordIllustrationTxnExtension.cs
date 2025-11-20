using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordIllustrationTxnExtension : OLifEExtension
    {
        [XmlElement("FIPIllusTxnSecondaryType", Order = 1)]
        public FIP_ILLUS_TXN_SECONDARY_TYPE IllustrationTxnSecondaryType { get; set; }

        [XmlElement("FIPIllusTxnTertiaryType", Order = 2)]
        public FIP_ILLUS_TXN_TERTIARY_TYPE IllustrationTxnTertiaryType { get; set; }

        [XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 3)]
        public OLI_LU_RATINGS TempTableRating { get; set; }

		[XmlElement(Namespace = "http://ACORD.org/Standards/Life/2", Order = 4)]
		public OLI_LU_RATINGS PermTableRating { get; set; }
	}
}