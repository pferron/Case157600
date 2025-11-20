using System;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.LPES.Base;

namespace WOW.Illustration.Model.LPES.OLifeExtensions
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public class AcordCoverageExtension : OLifEExtension
    {
        [XmlElement("FIPRiderType", Order = 1)]
        public AWD_LU_RIDERTYPE RiderType { get; set; }		

		[XmlElement("RiderDate", Order = 2, DataType = "date")]
        public DateTime RiderDate { get; set; }

		[XmlElement(Order = 3)]
		public AWD_LU_SUBRIDERTYPE FIPRiderSubType { get; set; }

		[XmlIgnore()]
        public bool RiderDateSpecified { get { return !RiderDate.Equals(DateTime.MinValue); } }
    }
}