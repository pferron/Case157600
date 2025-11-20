
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
public partial class ArrayOfKeyValueOfstringstring
{

    private ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] keyValueOfstringstringField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("KeyValueOfstringstring")]
    public ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] KeyValueOfstringstring
    {
        get
        {
            return this.keyValueOfstringstringField;
        }
        set
        {
            this.keyValueOfstringstringField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
public partial class ArrayOfKeyValueOfstringstringKeyValueOfstringstring
{

    private string keyField;

    private string valueField;

    /// <remarks/>
    public string Key
    {
        get
        {
            return this.keyField;
        }
        set
        {
            this.keyField = value;
        }
    }

    /// <remarks/>
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

