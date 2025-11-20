using WOW.Illustration.Model.ACORD;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// This is only for the test file. The actual response will be an ACORD message.
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class GatewayServiceResponse
    {

        private bool hasErrorField;

        private byte errorCodeField;

        private GatewayServiceResponseGatewayServiceResponseElement gatewayServiceResponseElementField;

        /// <remarks/>
        public bool HasError
        {
            get
            {
                return this.hasErrorField;
            }
            set
            {
                this.hasErrorField = value;
            }
        }

        /// <remarks/>
        public byte ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        public GatewayServiceResponseGatewayServiceResponseElement GatewayServiceResponseElement
        {
            get
            {
                return this.gatewayServiceResponseElementField;
            }
            set
            {
                this.gatewayServiceResponseElementField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GatewayServiceResponseGatewayServiceResponseElement
    {

        private TXLife tXLifeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://ACORD.org/Standards/Life/2")]
        public TXLife TXLife
        {
            get
            {
                return this.tXLifeField;
            }
            set
            {
                this.tXLifeField = value;
            }
        }
    }
}