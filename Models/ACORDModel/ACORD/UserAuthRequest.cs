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
    public partial class UserAuthRequest
    {
        /// <remarks/>
        [XmlElement("UserLoginName", typeof(string), Order = 0)]
        [XmlElement("UserPswd", typeof(UserPswd), Order = 0)]
        [XmlElement("UserSessionKey", typeof(string), Order = 0)]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }

        /// <remarks/>
        [XmlElement("ItemsElementName", Order = 1)]
        [XmlIgnore()]
        public ItemsChoiceType[] ItemsElementName { get; set; }
    }
}
