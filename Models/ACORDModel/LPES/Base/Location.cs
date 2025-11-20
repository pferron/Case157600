using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using WOW.Illustration.Model.ACORD;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Location
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string LocationLinkKey { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string CensusCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string LocationDescription { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int GroupID { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GroupIDSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string SAGUID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string CompanyName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string Comments { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public int LocationType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LocationTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string ImportID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public int LocationStatus { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LocationStatusSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public string ERLocationID { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 11)]
        public DateTime LocationModifyDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LocationModifyDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int ModifiedAfterSync { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ModifiedAfterSyncSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public double SyncTime { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SyncTimeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public int RemoveLocal { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool RemoveLocalSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public double LocEESyncTime { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LocEESyncTimeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public double LocSyncStamp { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool LocSyncStampSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        [CLSCompliant(false)]
        public sbyte IsOnHold { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsOnHoldSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        public double EnrollmentBeginDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentBeginDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        public double EnrollmentEndDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EnrollmentEndDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        public string LocationCity { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        public OLI_LU_STATE LocationState { get; set; }

        /// <remarks/>
        [XmlElement("LocationEE", Order = 22)]
        public LocationEE[] LocationEE { get; set; }

        /// <remarks/>
        [XmlElement("LocationWritingAgents", Order = 23)]
        public LocationWritingAgents[] LocationWritingAgents { get; set; }

        /// <remarks/>
        [XmlElement("Address", Namespace = "http://ACORD.org/Standards/Life/2", Order = 24)]
        public Address[] Address { get; set; }
    }
}
