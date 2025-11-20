using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_CLIENTLANGUAGES_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Arabic</summary>
        [XmlEnum("1")]
        OLI_LANG_ARABIC = 1,

        /// <summary>Bulgarian</summary>
        [XmlEnum("2")]
        OLI_LANG_BULGARIAN = 2,

        /// <summary>Catalan</summary>
        [XmlEnum("3")]
        OLI_LANG_CATALAN = 3,

        /// <summary>Chinese (Mandarin)</summary>
        [XmlEnum("4")]
        OLI_LANG_CHINESE = 4,

        /// <summary>Czech</summary>
        [XmlEnum("5")]
        OLI_LANG_CZECH = 5,

        /// <summary>Danish</summary>
        [XmlEnum("6")]
        OLI_LANG_DANISH = 6,

        /// <summary>German</summary>
        [XmlEnum("7")]
        OLI_LANG_GERMAN = 7,

        /// <summary>Greek</summary>
        [XmlEnum("8")]
        OLI_LANG_GREEK = 8,

        /// <summary>English</summary>
        [XmlEnum("9")]
        OLI_LANG_ENGLISH = 9,

        /// <summary>Spanish</summary>
        [XmlEnum("10")]
        OLI_LANG_SPANISH = 10,

        /// <summary>Finnish</summary>
        [XmlEnum("11")]
        OLI_LANG_FINNISH = 11,

        /// <summary>French</summary>
        [XmlEnum("12")]
        OLI_LANG_FRENCH = 12,

        /// <summary>Hebrew</summary>
        [XmlEnum("13")]
        OLI_LANG_HEBREW = 13,

        /// <summary>Hungarian</summary>
        [XmlEnum("14")]
        OLI_LANG_HUNGARIAN = 14,

        /// <summary>Icelandic</summary>
        [XmlEnum("15")]
        OLI_LANG_ICELANDIC = 15,

        /// <summary>Italian</summary>
        [XmlEnum("16")]
        OLI_LANG_ITALIAN = 16,

        /// <summary>Japanese</summary>
        [XmlEnum("17")]
        OLI_LANG_JAPANESE = 17,

        /// <summary>Korean</summary>
        [XmlEnum("18")]
        OLI_LANG_KOREAN = 18,

        /// <summary>Dutch</summary>
        [XmlEnum("19")]
        OLI_LANG_DUTCH = 19,

        /// <summary>Norwegian</summary>
        [XmlEnum("20")]
        OLI_LANG_NORWEGIAN = 20,

        /// <summary>Polish</summary>
        [XmlEnum("21")]
        OLI_LANG_POLISH = 21,

        /// <summary>Portuguese</summary>
        [XmlEnum("22")]
        OLI_LANG_PORTUGUESE = 22,

        /// <summary>Romanian</summary>
        [XmlEnum("24")]
        OLI_LANG_ROMANIAN = 24,

        /// <summary>Russian</summary>
        [XmlEnum("25")]
        OLI_LANG_RUSSIAN = 25,

        /// <summary>Croatian</summary>
        [XmlEnum("26")]
        OLI_LANG_CROATIAN = 26,

        /// <summary>Slovak</summary>
        [XmlEnum("27")]
        OLI_LANG_SLOVAK = 27,

        /// <summary>Albanian</summary>
        [XmlEnum("28")]
        OLI_LANG_ALBANIAN = 28,

        /// <summary>Swedish</summary>
        [XmlEnum("29")]
        OLI_LANG_SWEDISH = 29,

        /// <summary>Thai</summary>
        [XmlEnum("30")]
        OLI_LANG_THAI = 30,

        /// <summary>Turkish</summary>
        [XmlEnum("31")]
        OLI_LANG_TURKISH = 31,

        /// <summary>Urdu</summary>
        [XmlEnum("32")]
        OLI_LANG_URDU = 32,

        /// <summary>Indonesian</summary>
        [XmlEnum("33")]
        OLI_LANG_INDONESIAN = 33,

        /// <summary>Ukrainian</summary>
        [XmlEnum("34")]
        OLI_LANG_UKRAINIAN = 34,

        /// <summary>Belarusian</summary>
        [XmlEnum("35")]
        OLI_LANG_BELARUSIAN = 35,

        /// <summary>Slovenian</summary>
        [XmlEnum("36")]
        OLI_LANG_SLOVENIAN = 36,

        /// <summary>Estonian</summary>
        [XmlEnum("37")]
        OLI_LANG_ESTONIAN = 37,

        /// <summary>Latvian</summary>
        [XmlEnum("38")]
        OLI_LANG_LATVIAN = 38,

        /// <summary>Lithuanian</summary>
        [XmlEnum("39")]
        OLI_LANG_LITHUANIAN = 39,

        /// <summary>Farsi</summary>
        [XmlEnum("41")]
        OLI_LANG_FARSI = 41,

        /// <summary>Vietnamese</summary>
        [XmlEnum("42")]
        OLI_LANG_VIETNAMESE = 42,

        /// <summary>Armenian</summary>
        [XmlEnum("43")]
        OLI_LANG_ARMENIAN = 43,

        /// <summary>Azerbaijani</summary>
        [XmlEnum("44")]
        OLI_LANG_AZERBAIJANI = 44,

        /// <summary>Basque</summary>
        [XmlEnum("45")]
        OLI_LANG_BASQUE = 45,

        /// <summary>Serbian</summary>
        [XmlEnum("46")]
        OLI_LANG_SERBIAN = 46,

        /// <summary>Macedonian</summary>
        [XmlEnum("47")]
        OLI_LANG_MACEDONIAN = 47,

        /// <summary>Afrikaans</summary>
        [XmlEnum("54")]
        OLI_LANG_AFRIKAANS = 54,

        /// <summary>Georgian</summary>
        [XmlEnum("55")]
        OLI_LANG_GEORGIAN = 55,

        /// <summary>Hindi</summary>
        [XmlEnum("57")]
        OLI_LANG_HINDI = 57,

        /// <summary>Chinese (Malay)</summary>
        [XmlEnum("62")]
        OLI_LANG_MALAY = 62,

        /// <summary>Kazakh</summary>
        [XmlEnum("63")]
        OLI_LANG_KAZAKH = 63,

        /// <summary>Swahili</summary>
        [XmlEnum("64")]
        OLI_LANG_SWAHILI = 64,

        /// <summary>Faeroese</summary>
        [XmlEnum("65")]
        OLI_LANG_FAEROESE = 65,

        /// <summary>Uzbek</summary>
        [XmlEnum("67")]
        OLI_LANG_UZBEK = 67,

        /// <summary>Tatar</summary>
        [XmlEnum("68")]
        OLI_LANG_TATAR = 68,

        /// <summary>Bengali, Bangla</summary>
        [XmlEnum("69")]
        OLI_LANG_BENGALI = 69,

        /// <summary>Punjabi</summary>
        [XmlEnum("70")]
        OLI_LANG_PUNJABI = 70,

        /// <summary>Gujarati</summary>
        [XmlEnum("71")]
        OLI_LANG_GUJARATI = 71,

        /// <summary>Oriya</summary>
        [XmlEnum("72")]
        OLI_LANG_ORIYA = 72,

        /// <summary>Tamil</summary>
        [XmlEnum("73")]
        OLI_LANG_TAMIL = 73,

        /// <summary>Telugu</summary>
        [XmlEnum("74")]
        OLI_LANG_TELUGU = 74,

        /// <summary>Kannada</summary>
        [XmlEnum("75")]
        OLI_LANG_KANNADA = 75,

        /// <summary>Malayalam</summary>
        [XmlEnum("76")]
        OLI_LANG_MALAYALAM = 76,

        /// <summary>Assamese</summary>
        [XmlEnum("77")]
        OLI_LANG_ASSAMESE = 77,

        /// <summary>Marathi</summary>
        [XmlEnum("78")]
        OLI_LANG_MARATHI = 78,

        /// <summary>Sanskirt</summary>
        [XmlEnum("79")]
        OLI_LANG_SANSKIRT = 79,

        /// <summary>Konkani</summary>
        [XmlEnum("87")]
        OLI_LANG_KONKANI = 87,

        /// <summary>Manipuri</summary>
        [XmlEnum("88")]
        OLI_LANG_MANIPURI = 88,

        /// <summary>Sindhi</summary>
        [XmlEnum("89")]
        OLI_LANG_SINDHI = 89,

        /// <summary>Kashmiri</summary>
        [XmlEnum("96")]
        OLI_LANG_KASHMIRI = 96,

        /// <summary>Nepali</summary>
        [XmlEnum("97")]
        OLI_LANG_NEPALI = 97,

        /// <summary>Abkhazian</summary>
        [XmlEnum("513")]
        OLI_LANG_ABKHAZIAN = 513,

        /// <summary>Afar</summary>
        [XmlEnum("514")]
        OLI_LANG_AFAR = 514,

        /// <summary>Amharic</summary>
        [XmlEnum("515")]
        OLI_LANG_AMHARIC = 515,

        /// <summary>Aymara</summary>
        [XmlEnum("516")]
        OLI_LANG_AYMARA = 516,

        /// <summary>Bashkir</summary>
        [XmlEnum("517")]
        OLI_LANG_BASHKIR = 517,

        /// <summary>Bihari</summary>
        [XmlEnum("518")]
        OLI_LANG_BIHARI = 518,

        /// <summary>Bislama</summary>
        [XmlEnum("519")]
        OLI_LANG_BISLAMA = 519,

        /// <summary>Breton</summary>
        [XmlEnum("520")]
        OLI_LANG_BRETON = 520,

        /// <summary>Burmese</summary>
        [XmlEnum("521")]
        OLI_LANG_BURMESE = 521,

        /// <summary>Cambodian</summary>
        [XmlEnum("522")]
        OLI_LANG_CAMBODIAN = 522,

        /// <summary>Chinese (Cantonese)</summary>
        [XmlEnum("523")]
        OLI_LANG_CANTONESE = 523,

        /// <summary>Corsican</summary>
        [XmlEnum("524")]
        OLI_LANG_CORSICAN = 524,

        /// <summary>Esperanto</summary>
        [XmlEnum("525")]
        OLI_LANG_ESPERANTO = 525,

        /// <summary>Fiji</summary>
        [XmlEnum("526")]
        OLI_LANG_FIJI = 526,

        /// <summary>Frisian</summary>
        [XmlEnum("527")]
        OLI_LANG_FRISIAN = 527,

        /// <summary>Galician</summary>
        [XmlEnum("528")]
        OLI_LANG_GALICIAN = 528,

        /// <summary>Greenlandic</summary>
        [XmlEnum("529")]
        OLI_LANG_GREENLANDIC = 529,

        /// <summary>Guarani</summary>
        [XmlEnum("530")]
        OLI_LANG_GUARANI = 530,

        /// <summary>Interlinqua</summary>
        [XmlEnum("531")]
        OLI_LANG_INTERLINQUA = 531,

        /// <summary>Interlinque</summary>
        [XmlEnum("532")]
        OLI_LANG_INTERLINQUE = 532,

        /// <summary>Inupiak</summary>
        [XmlEnum("533")]
        OLI_LANG_INUPIAK = 533,

        /// <summary>Javanese</summary>
        [XmlEnum("534")]
        OLI_LANG_JAVANESE = 534,

        /// <summary>Kinyarwanda</summary>
        [XmlEnum("535")]
        OLI_LANG_KINYARWANDA = 535,

        /// <summary>Kirghiz</summary>
        [XmlEnum("536")]
        OLI_LANG_KIRGHIZ = 536,

        /// <summary>Kirundi</summary>
        [XmlEnum("537")]
        OLI_LANG_KIRUNDI = 537,

        /// <summary>Kurdish</summary>
        [XmlEnum("538")]
        OLI_LANG_KURDISH = 538,

        /// <summary>Laothian</summary>
        [XmlEnum("539")]
        OLI_LANG_LAOTHIAN = 539,

        /// <summary>Latin</summary>
        [XmlEnum("540")]
        OLI_LANG_LATIN = 540,

        /// <summary>Lingala</summary>
        [XmlEnum("541")]
        OLI_LANG_LINGALA = 541,

        /// <summary>Malagasy</summary>
        [XmlEnum("542")]
        OLI_LANG_MALAGASY = 542,

        /// <summary>Maltese</summary>
        [XmlEnum("543")]
        OLI_LANG_MALTESE = 543,

        /// <summary>Maori</summary>
        [XmlEnum("544")]
        OLI_LANG_MAORI = 544,

        /// <summary>Moldavian</summary>
        [XmlEnum("545")]
        OLI_LANG_MOLDAVIAN = 545,

        /// <summary>Mongolian</summary>
        [XmlEnum("546")]
        OLI_LANG_MONGOLIAN = 546,

        /// <summary>Nauru</summary>
        [XmlEnum("547")]
        OLI_LANG_NAURU = 547,

        /// <summary>Ndebele - North</summary>
        [XmlEnum("548")]
        OLI_LANG_NDEBELEN = 548,

        /// <summary>Ndebele - South</summary>
        [XmlEnum("549")]
        OLI_LANG_NDEBELES = 549,

        /// <summary>Occitan</summary>
        [XmlEnum("550")]
        OLI_LANG_OCCITAN = 550,

        /// <summary>Oromo (Afan)</summary>
        [XmlEnum("551")]
        OLI_LANG_OROMO = 551,

        /// <summary>Pashto, Pushto</summary>
        [XmlEnum("552")]
        OLI_LANG_PASHTO = 552,

        /// <summary>Persian</summary>
        [XmlEnum("553")]
        OLI_LANG_PERSIAN = 553,

        /// <summary>Quechua</summary>
        [XmlEnum("554")]
        OLI_LANG_QUECHUA = 554,

        /// <summary>Rhaeto-Romance</summary>
        [XmlEnum("555")]
        OLI_LANG_RHAETO = 555,

        /// <summary>Samoan</summary>
        [XmlEnum("556")]
        OLI_LANG_SAMOAN = 556,

        /// <summary>Sangro</summary>
        [XmlEnum("557")]
        OLI_LANG_SANGRO = 557,

        /// <summary>Scottish Gaelic</summary>
        [XmlEnum("558")]
        OLI_LANG_SCOTGAELIC = 558,

        /// <summary>Serbo-Croatian</summary>
        /// <remarks>Includes Bosnian.</remarks>
        [XmlEnum("559")]
        OLI_LANG_SERBOCROATIAN = 559,

        /// <summary>Sesotho</summary>
        [XmlEnum("560")]
        OLI_LANG_SESOTHO = 560,

        /// <summary>Shona</summary>
        [XmlEnum("561")]
        OLI_LANG_SHONA = 561,

        /// <summary>Singhalese</summary>
        [XmlEnum("562")]
        OLI_LANG_SINGHALESE = 562,

        /// <summary>Siswati</summary>
        [XmlEnum("563")]
        OLI_LANG_SISWATI = 563,

        /// <summary>Somali</summary>
        [XmlEnum("564")]
        OLI_LANG_SOMALI = 564,

        /// <summary>Sotho - North</summary>
        [XmlEnum("565")]
        OLI_LANG_SOTHON = 565,

        /// <summary>Sotho - South</summary>
        [XmlEnum("566")]
        OLI_LANG_SOTHOS = 566,

        /// <summary>Sundanese</summary>
        [XmlEnum("567")]
        OLI_LANG_SUNDANESE = 567,

        /// <summary>Swati</summary>
        [XmlEnum("568")]
        OLI_LANG_SWATI = 568,

        /// <summary>Tagalog</summary>
        [XmlEnum("569")]
        OLI_LANG_TAGALOG = 569,

        /// <summary>Tajik</summary>
        [XmlEnum("570")]
        OLI_LANG_TAJIK = 570,

        /// <summary>Tibetan</summary>
        [XmlEnum("571")]
        OLI_LANG_TIBETAN = 571,

        /// <summary>Tigrinya</summary>
        [XmlEnum("572")]
        OLI_LANG_TIGRINYA = 572,

        /// <summary>Tonga</summary>
        /// <remarks>Tonga (Nyasa)</remarks>
        [XmlEnum("573")]
        OLI_LANG_TONGA = 573,

        /// <summary>Tsonga</summary>
        [XmlEnum("574")]
        OLI_LANG_TSONGA = 574,

        /// <summary>Tswana</summary>
        [XmlEnum("575")]
        OLI_LANG_TSWANA = 575,

        /// <summary>Turkmen</summary>
        [XmlEnum("576")]
        OLI_LANG_TURKMEN = 576,

        /// <summary>Twi</summary>
        [XmlEnum("577")]
        OLI_LANG_TWI = 577,

        /// <summary>Venda</summary>
        [XmlEnum("578")]
        OLI_LANG_VENDA = 578,

        /// <summary>Volapuk</summary>
        [XmlEnum("579")]
        OLI_LANG_VOLAPUK = 579,

        /// <summary>Wolof</summary>
        [XmlEnum("580")]
        OLI_LANG_WOLOF = 580,

        /// <summary>Xhosa</summary>
        [XmlEnum("581")]
        OLI_LANG_XHOSA = 581,

        /// <summary>Yiddish</summary>
        [XmlEnum("582")]
        OLI_LANG_YIDDISH = 582,

        /// <summary>Yoruba</summary>
        [XmlEnum("583")]
        OLI_LANG_YORUBA = 583,

        /// <summary>Zulu</summary>
        [XmlEnum("584")]
        OLI_LANG_ZULU = 584,

        /// <summary>Pedi</summary>
        [XmlEnum("585")]
        OLI_LANG_PEDI = 585,

        /// <summary>Chinese (Fukienese)</summary>
        /// <remarks>Spoken in the province of Fujian in China</remarks>
        [XmlEnum("586")]
        OLI_LANG_FUKIENESE = 586,

        /// <summary>Chinese (Fuzhou)</summary>
        /// <remarks>Spoken in and around the city of Fuzhou  in China</remarks>
        [XmlEnum("587")]
        OLI_LANG_FUZHOU = 587,

        /// <summary>Chinese (Hakka)</summary>
        /// <remarks>Spoken in the province of Guangdong in Taiwan (Chinese Dialect)</remarks>
        [XmlEnum("588")]
        OLI_LANG_HAKKA = 588,

        /// <summary>Chinese (Taiwanese)</summary>
        /// <remarks>Spoken in Taiwan</remarks>
        [XmlEnum("589")]
        OLI_LANG_TAIWANESE = 589,

        /// <summary>Chinese (Chau Chow)</summary>
        [XmlEnum("590")]
        OLI_LANG_CHAUCHOW = 590,

        /// <summary>Chinese (Chiu Chow)</summary>
        [XmlEnum("591")]
        OLI_LANG_CHIUCHOW = 591,

        /// <summary>Ilocano</summary>
        [XmlEnum("593")]
        OLI_LANG_ILOCANO = 593,

        /// <summary>Lao</summary>
        [XmlEnum("594")]
        OLI_LANG_LAO = 594,

        /// <summary>Chinese (Shanghainese)</summary>
        [XmlEnum("595")]
        OLI_LANG_SHANGHAINESE = 595,

        /// <summary>Aleut</summary>
        [XmlEnum("596")]
        OLI_LANG_ALEUT = 596,

        /// <summary>American Sign Language</summary>
        [XmlEnum("597")]
        OLI_LANG_ASL = 597,

        /// <summary>Aramaic</summary>
        [XmlEnum("598")]
        OLI_LANG_ARAMAIC = 598,

        /// <summary>Arawak</summary>
        [XmlEnum("599")]
        OLI_LANG_ARAWAK = 599,

        /// <summary>Bicol</summary>
        /// <remarks>This is a language of the Phillippines. It is also known as Bikol and "Bicolano, Central"</remarks>
        [XmlEnum("600")]
        OLI_LANG_BIKOL = 600,

        /// <summary>Edo</summary>
        /// <remarks>This is a language of Nigeria. It is also known as Bini</remarks>
        [XmlEnum("601")]
        OLI_LANG_EDO = 601,

        /// <summary>Flemish</summary>
        /// <remarks>This is a language of Belgium. It is also known as Vlaams, Flamand, Vlaemsch</remarks>
        [XmlEnum("602")]
        OLI_LANG_FLEMISH = 602,

        /// <summary>Haitian Creole</summary>
        [XmlEnum("603")]
        OLI_LANG_HAITIANCREOLE = 603,

        /// <summary>Chinese (Hmong)</summary>
        [XmlEnum("604")]
        OLI_LANG_HMONG = 604,

        /// <summary>Igbo</summary>
        /// <remarks>This is a language of Nigeria.</remarks>
        [XmlEnum("605")]
        OLI_LANG_IGBO = 605,

        /// <summary>Khmer</summary>
        /// <remarks>This is a language of Cambodia and VietNam.</remarks>
        [XmlEnum("606")]
        OLI_LANG_KHMER = 606,

        /// <summary>Marwari</summary>
        /// <remarks>This is a language of India.</remarks>
        [XmlEnum("607")]
        OLI_LANG_MARWARI = 607,

        /// <summary>Pampango</summary>
        /// <remarks>This is a language of the Philippines. It is also known as Pampanga, Pampangan, Kapampangan</remarks>
        [XmlEnum("608")]
        OLI_LANG_PAMPANGO = 608,

        /// <summary>Sicilian</summary>
        /// <remarks>A language of Italy that is distinct enough from Italian to be considered a separate language</remarks>
        [XmlEnum("609")]
        OLI_LANG_SICILIAN = 609,

        /// <summary>Tongan</summary>
        /// <remarks>Tonga (Tonga Islands)</remarks>
        [XmlEnum("610")]
        OLI_LANG_TONGAN = 610,

        /// <summary>Visayan</summary>
        /// <remarks>This is a language of the Phillippines.</remarks>
        [XmlEnum("611")]
        OLI_LANG_VISAYAN = 611,

        /// <summary>Irish</summary>
        [XmlEnum("6153")]
        OLI_LANG_IRISH = 6153,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
