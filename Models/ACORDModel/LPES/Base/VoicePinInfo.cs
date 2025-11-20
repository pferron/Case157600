using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Base
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class VoicePinInfo
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public bool UseCallCenter { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public VoicePinChoiceList VoicePin { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VoicePinSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public VoiceTypeList VoiceType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VoiceTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string AgentPin { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool WillSendFile { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool WillSendFileSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string CallCenterID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        [CLSCompliant(false)]
        public sbyte SignatureType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool SignatureTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 7)]
        public DateTime VoiceStart { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VoiceStartSpecified { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 8)]
        public DateTime VoiceEnd { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool VoiceEndSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public string OperatorID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public string VoiceFileID { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public string FileSize { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 12)]
        public DateTime FileModifyTime { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool FileModifyTimeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public string PinNumber { get; set; }
    }
}
