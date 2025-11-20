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
    public partial class EmployerPriorInsurer
    {
        /// <remarks/>
        [XmlElement(Order = 0)]
        [CLSCompliant(false)]
        public sbyte IsDiscontinuePrevInsurance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool IsDiscontinuePrevInsuranceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 1)]
        [CLSCompliant(false)]
        public sbyte AetnaSRC { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AetnaSRCSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 2)]
        [CLSCompliant(false)]
        public sbyte Aflac { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AflacSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 3)]
        [CLSCompliant(false)]
        public sbyte AIG { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AIGSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 4)]
        [CLSCompliant(false)]
        public sbyte AmericanFidelity { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool AmericanFidelitySpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 5)]
        [CLSCompliant(false)]
        public sbyte CIGNAStarbridge { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CIGNAStarbridgeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 6)]
        [CLSCompliant(false)]
        public sbyte ColonialLife { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ColonialLifeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 7)]
        [CLSCompliant(false)]
        public sbyte CombinedInsurance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool CombinedInsuranceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 8)]
        [CLSCompliant(false)]
        public sbyte ContinentalAmerican { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool ContinentalAmericanSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 9)]
        [CLSCompliant(false)]
        public sbyte DentalNetworkAmerica { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool DentalNetworkAmericaSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 10)]
        [CLSCompliant(false)]
        public sbyte EssentialStaffCARE { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool EssentialStaffCARESpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 11)]
        [CLSCompliant(false)]
        public sbyte GuardianLifeofAmerica { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool GuardianLifeofAmericaSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 12)]
        [CLSCompliant(false)]
        public sbyte HumanaDental { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool HumanaDentalSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 13)]
        [CLSCompliant(false)]
        public sbyte JeffersonPolitLife { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool JeffersonPolitLifeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 14)]
        [CLSCompliant(false)]
        public sbyte KanawhaInsurance { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool KanawhaInsuranceSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 15)]
        [CLSCompliant(false)]
        public sbyte PrincipalFinancialGroup { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool PrincipalFinancialGroupSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 16)]
        [CLSCompliant(false)]
        public sbyte TransamericaLife { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TransamericaLifeSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 17)]
        [CLSCompliant(false)]
        public sbyte Trustmark { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool TrustmarkSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 18)]
        [CLSCompliant(false)]
        public sbyte UnitedConcordia { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UnitedConcordiaSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 19)]
        [CLSCompliant(false)]
        public sbyte UnitedHealthcare { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UnitedHealthcareSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 20)]
        [CLSCompliant(false)]
        public sbyte UnumGroup { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool UnumGroupSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 21)]
        [CLSCompliant(false)]
        public sbyte Other { get; set; }

        /// <remarks/>
        [XmlIgnore()]
        public bool OtherSpecified { get; set; }

        /// <remarks/>
        [XmlElement(Order = 22)]
        public string Products { get; set; }
    }
}
