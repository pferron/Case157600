using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.LPES.Form
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.fiservinsurance.com/LPES/Form")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Form", IsNullable = false)]
    public partial class form
    {
        /// <remarks/>
        [XmlArray(Order = 0)]
        [XmlArrayItem("page", IsNullable = false)]
        [XmlArrayItem("dataField", typeof(dataField), IsNullable = false, NestingLevel = 1)]
        [XmlArrayItem("dataFieldGroup", typeof(dataFieldGroup), IsNullable = false, NestingLevel = 1)]
        public object[] pages { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FormName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachPartyID { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FileName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public bool IsMainForm { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string FormType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string FormId { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string FormCode { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string FormOrder { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachDataPath { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string DataPropertyName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string DataPropertyValue { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public bool IsRuleInvolved { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string PrintCopies { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string EditType { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string EditTemplateName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string RootDataObjId { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachRootId { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachRootClassName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachObjectId { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachObjectClassName { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string AttachObjectValue { get; set; }
    }
}
