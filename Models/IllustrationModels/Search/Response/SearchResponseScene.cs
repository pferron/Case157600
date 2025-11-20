using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.Search.Response
{
    [XmlType("Scene")]
    public class SearchResponseScene
    {
        [XmlElement("SceneID")]
        public string sceneId { get; set; }

        [XmlElement("HeaderCode")]
        public int headerCode { get; set; }

        [XmlElement("HeaderDescription")]
        public string headerDescription { get; set; }

        [XmlElement("IllustrationName")]
        public string illustrationName { get; set; }

        [XmlElement("FaceAmount")]
        public decimal faceAmount { get; set; }

        [XmlElement("DeathBenefitOption")]
        public string deathBenefitOption { get; set; }

        [XmlElement("NLGULPremiumToAge")]
        public int nlgulPremiumToAge { get; set; }

        [XmlElement("NLGULDumpAmount")]
        public decimal nlgulDumpAmount { get; set; }

        [XmlElement("SignedState")]
        public string signedState { get; set; }

        [XmlElement("NumberOfOwners")]
        public int numberOfOwners { get; set; }

        [XmlElement("LodgeDues")]
        public decimal lodgeDues { get; set; }

        [XmlElement("AdvancePremium")]
        public decimal advancePremium { get; set; }

        [XmlElement("ModifiedEndowment")]
        public bool modifiedEndowment { get; set; }

        [XmlElement("RefundOption")]
        public int refundOption { get; set; }

        [XmlElement("RefundOptionDescription")]
        public string refundOptionDescription { get; set; }

        [XmlElement("TobaccoUse")]
        public bool tobaccoUse { get; set; }

        [XmlElement("BillFrequency")]
        public string billFrequency { get; set; }

        [XmlElement("BillType")]
        public int billType { get; set; }

        [XmlElement("PlannedPremium")]
        public decimal plannedPremium { get; set; }

        [XmlElement("ModalPremium")]
        public decimal modalPremium { get; set; }

        [XmlElement("InitialAmount")]
        public decimal initialAmount { get; set; }

        [XmlElement("IllustrationDate")]
        public DateTime illustrationDate { get; set; }

        [XmlElement("AdditionalInsuranceOptionRider")]
        public bool additionalInsuranceOptionRider { get; set; }

        [XmlElement("AdditionalInsuranceOptionAmount")]
        public decimal additionalInsuranceOptionAmount { get; set; }

        [XmlElement("AccidentalDeathBenefitRider")]
        public bool accidentalDeathBenefitRider { get; set; }

        [XmlElement("AccidentalDeathBenefitRiderAmount")]
        public decimal accidentalDeathBenefitAmount { get; set; }

        [XmlElement("AcceleratedBenefitRider")]
        public bool acceleratedBenefitRider { get; set; }

        [XmlElement("WaiverType")]
        public string waiverType { get; set; }

        [XmlElement("TermRiderType")]
        public string termRiderType { get; set; }

        [XmlElement("TermRiderAmount")]
        public decimal termRiderAmount { get; set; }

        [XmlElement("AdvancePremiumLoan")]
        public bool advancePremiumLoan { get; set; }

        [XmlElement("PremiumDepositAmount")]
        public decimal premiumDepositAmount { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}