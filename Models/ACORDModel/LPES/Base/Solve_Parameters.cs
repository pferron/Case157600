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
    [XmlRoot("SolveParameters", Namespace = "http://www.fiservinsurance.com/LPES/Base/OneView", IsNullable = false)]
    public partial class Solve_Parameters
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        public SOLVE_FOR SolveFor { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public SOLVE_CRITERIA SolveCriteria { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public SOLVE_INTEREST_BASIS SolveInterestBasis { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public double SolveCashValue { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public double SolvePremium { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public int SolveTargetAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public double SolvePctOfCost { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public double SolvePctOfCostIntRate { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public int SolvePctOfCostAtAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public int SolveCashFlowFromAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public int SolveCashFlowToAge { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        public SOLVE_START_WHEN SolveStartWhen { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        public int SolveStartAge { get; set; }
    }
}
