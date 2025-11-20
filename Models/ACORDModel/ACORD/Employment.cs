using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://ACORD.org/Standards/Life/2")]
    [XmlRoot(Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public partial class Employment
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public string EmployeeID { get; set; }

        /// <remarks/>
        [XmlElement(DataType = "date", Order = 1)]
        public DateTime HireDate { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HireDateSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public decimal AnnualSalary { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AnnualSalarySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string EmployerName { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public OLI_LU_EMPLOYMENTTYPE EmployeeType { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string EmploymentDuties { get; set; }

        /// <remarks/>
        [XmlElement("OLifEExtension", Order = 6)]
        public OLifEExtension[] OLifEExtension { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "ID")]
        public string id { get; set; }
    }
}
