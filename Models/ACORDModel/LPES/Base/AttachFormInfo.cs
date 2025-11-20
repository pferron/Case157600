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
    public partial class AttachFormInfo
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string FormFile { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string FormId { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int FormCode { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int FormOrder { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public bool IsMainForm { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int PrintCopies { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int EditType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public bool IsRuleInvolved { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsRuleInvolvedSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string RootDataObjId { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public string AttachRootId { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public string AttachRootClassName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public string AttachObjectId { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public string AttachObjectClassName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public string AttachObjectValue { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public string AttachDataPath { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public string DataPropertyName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        public string DataPropertyValue { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        public string EditTemplateName { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "IDREF")]
        public string AttachPartyID { get; set; }
    }
}
