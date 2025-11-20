using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        /// <remarks/>
        UserLoginName,

        /// <remarks/>
        UserPswd,

        /// <remarks/>
        UserSessionKey,
    }
}
