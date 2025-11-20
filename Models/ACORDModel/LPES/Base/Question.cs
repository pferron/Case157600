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
    [XmlType(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView")]
    [XmlRoot(Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Question
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string category { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string questionText { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string questionNumber { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public int questionSequence { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public int drilldownTriggerType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool drilldownTriggerTypeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int drilldownTriggerValue { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool drilldownTriggerValueSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public int childrenLayoutStyle { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool childrenLayoutStyleSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public string detailQuestionPageName { get; set; }

        /// <remarks/>
        [XmlArray(Order = 8)]
        [XmlArrayItem(IsNullable = false)]
        public Question[] childQuestions { get; set; }

        /// <remarks/>
        [XmlArray(Order = 9)]
        [XmlArrayItem(IsNullable = false)]
        public Question[] dependentQuestions { get; set; }

        /// <remarks/>
        [XmlArray(Order = 10)]
        [XmlArrayItem(IsNullable = false)]
        public Insured[] requiredInsured { get; set; }

        /// <remarks/>
        [XmlArray(Order = 11)]
        [XmlArrayItem(IsNullable = false)]
        public RequiredInsuredRole[] requiredInsuredRoles { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public string message { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        public string yesOptionText { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        public string noOptionText { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        public bool isRootQuestion { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int questionId { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool questionIdSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int questionType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool questionTypeSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int parentId { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool parentIdSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int promptType { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool promptTypeSpecified { get; set; }
    }
}
