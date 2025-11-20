using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_NATION_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>United States of America</summary>
        [XmlEnum("1")]
        OLI_NATION_USA = 1,

        /// <summary>Canada</summary>
        [XmlEnum("2")]
        OLI_NATION_CANADA = 2,

        /// <summary>Russian Federation</summary>
        [XmlEnum("7")]
        OLI_NATION_RUSSIA = 7,

        /// <summary>Egypt</summary>
        [XmlEnum("20")]
        OLI_NATION_EGYPT = 20,

        /// <summary>South Africa</summary>
        [XmlEnum("27")]
        OLI_NATION_SOUTHAFRICA = 27,

        /// <summary>Greece</summary>
        [XmlEnum("30")]
        OLI_NATION_GREECE = 30,

        /// <summary>Netherlands</summary>
        [XmlEnum("31")]
        OLI_NATION_NETHERLANDS = 31,

        /// <summary>Belgium</summary>
        [XmlEnum("32")]
        OLI_NATION_BELGIUM = 32,

        /// <summary>France</summary>
        [XmlEnum("33")]
        OLI_NATION_FRANCE = 33,

        /// <summary>Spain</summary>
        [XmlEnum("34")]
        OLI_NATION_SPAIN = 34,

        /// <summary>Hungary</summary>
        [XmlEnum("36")]
        OLI_NATION_HUNGARY = 36,

        /// <summary>Yugoslavia</summary>
        /// <remarks>Yugoslavia devolved in 1992 into independent constituents: Slovenia, Croatia, Bosnia and Herzegovina, Serbia and Montenegro, and The Former Yugoslav Republic of Macedonia.</remarks>
        [XmlEnum("38")]
        OLI_NATION_YUGOSLAVIA = 38,

        /// <summary>Italy</summary>
        [XmlEnum("39")]
        OLI_NATION_ITALY = 39,

        /// <summary>Romania</summary>
        [XmlEnum("40")]
        OLI_NATION_ROMANIA = 40,

        /// <summary>Switzerland</summary>
        [XmlEnum("41")]
        OLI_NATION_SWITZERLAND = 41,

        /// <summary>Czechloslovakia</summary>
        [XmlEnum("42")]
        OLI_NATION_CZECHLOSLOVAKIA = 42,

        /// <summary>Austria</summary>
        [XmlEnum("43")]
        OLI_NATION_AUSTRIA = 43,

        /// <summary>United Kingdom</summary>
        [XmlEnum("44")]
        OLI_NATION_UK = 44,

        /// <summary>Denmark</summary>
        [XmlEnum("45")]
        OLI_NATION_DENMARK = 45,

        /// <summary>Sweden</summary>
        [XmlEnum("46")]
        OLI_NATION_SWEDEN = 46,

        /// <summary>Norway</summary>
        [XmlEnum("47")]
        OLI_NATION_NORWAY = 47,

        /// <summary>Poland</summary>
        [XmlEnum("48")]
        OLI_NATION_POLAND = 48,

        /// <summary>Germany</summary>
        [XmlEnum("49")]
        OLI_NATION_GERMANY = 49,

        /// <summary>Peru</summary>
        [XmlEnum("51")]
        OLI_NATION_PERU = 51,

        /// <summary>Mexico</summary>
        [XmlEnum("52")]
        OLI_NATION_MEXICO = 52,

        /// <summary>Cuba</summary>
        [XmlEnum("53")]
        OLI_NATION_CUBA = 53,

        /// <summary>Argentina</summary>
        [XmlEnum("54")]
        OLI_NATION_ARGENTINA = 54,

        /// <summary>Brazil</summary>
        [XmlEnum("55")]
        OLI_NATION_BRAZIL = 55,

        /// <summary>Chile</summary>
        [XmlEnum("56")]
        OLI_NATION_CHILE = 56,

        /// <summary>Colombia</summary>
        [XmlEnum("57")]
        OLI_NATION_COLUMBIA = 57,

        /// <summary>Venezuela</summary>
        [XmlEnum("58")]
        OLI_NATION_VENEZUELA = 58,

        /// <summary>Malaysia</summary>
        [XmlEnum("60")]
        OLI_NATION_MALAYSIA = 60,

        /// <summary>Australia</summary>
        [XmlEnum("61")]
        OLI_NATION_AUSTRALIA = 61,

        /// <summary>Indonesia</summary>
        [XmlEnum("62")]
        OLI_NATION_INDONESIA = 62,

        /// <summary>Philippines</summary>
        [XmlEnum("63")]
        OLI_NATION_PHILIPPINES = 63,

        /// <summary>New Zealand</summary>
        [XmlEnum("64")]
        OLI_NATION_NEWZEALAND = 64,

        /// <summary>Singapore</summary>
        [XmlEnum("65")]
        OLI_NATION_SINGAPORE = 65,

        /// <summary>Thailand</summary>
        [XmlEnum("66")]
        OLI_NATION_THAILAND = 66,

        /// <summary>Japan</summary>
        [XmlEnum("81")]
        OLI_NATION_JAPAN = 81,

        /// <summary>Korea</summary>
        [XmlEnum("82")]
        OLI_NATION_KOREA = 82,

        /// <summary>Viet Nam</summary>
        [XmlEnum("84")]
        OLI_NATION_VIETNAM = 84,

        /// <summary>China</summary>
        [XmlEnum("86")]
        OLI_NATION_CHINA = 86,

        /// <summary>Turkey</summary>
        [XmlEnum("90")]
        OLI_NATION_TURKEY = 90,

        /// <summary>India</summary>
        [XmlEnum("91")]
        OLI_NATION_INDIA = 91,

        /// <summary>Pakistan</summary>
        [XmlEnum("92")]
        OLI_NATION_PAKISTAN = 92,

        /// <summary>Afghanistan</summary>
        [XmlEnum("93")]
        OLI_NATION_AFGHANISTAN = 93,

        /// <summary>Sri Lanka</summary>
        [XmlEnum("94")]
        OLI_NATION_SRILANKA = 94,

        /// <summary>Burma (Union Of Myanmar)</summary>
        [XmlEnum("95")]
        OLI_NATION_BURMA = 95,

        /// <summary>Iran, Islamic Republic of</summary>
        [XmlEnum("98")]
        OLI_NATION_IRAN = 98,

        /// <summary>Morocco</summary>
        [XmlEnum("212")]
        OLI_NATION_MOROCCO = 212,

        /// <summary>Algeria</summary>
        [XmlEnum("213")]
        OLI_NATION_ALGERIA = 213,

        /// <summary>Tunisia</summary>
        [XmlEnum("216")]
        OLI_NATION_TUNISIA = 216,

        /// <summary>Libyan Arab Jamahiriya</summary>
        [XmlEnum("218")]
        OLI_NATION_LIBYA = 218,

        /// <summary>Gambia</summary>
        [XmlEnum("220")]
        OLI_NATION_GAMBIA = 220,

        /// <summary>Senegal</summary>
        [XmlEnum("221")]
        OLI_NATION_SENEGAL = 221,

        /// <summary>Mauritania</summary>
        [XmlEnum("222")]
        OLI_NATION_MAURITANIA = 222,

        /// <summary>Mali</summary>
        [XmlEnum("223")]
        OLI_NATION_MALI = 223,

        /// <summary>Guinea</summary>
        [XmlEnum("224")]
        OLI_NATION_GUINEA = 224,

        /// <summary>Ivory Coast, Republic Of</summary>
        [XmlEnum("225")]
        OLI_NATION_IVORYCOAST = 225,

        /// <summary>Burkina Faso</summary>
        [XmlEnum("226")]
        OLI_NATION_BURKINAFASO = 226,

        /// <summary>Niger</summary>
        [XmlEnum("227")]
        OLI_NATION_NIGER = 227,

        /// <summary>Togo</summary>
        [XmlEnum("228")]
        OLI_NATION_TOGO = 228,

        /// <summary>Benin</summary>
        [XmlEnum("229")]
        OLI_NATION_BENIN = 229,

        /// <summary>Mauritius</summary>
        [XmlEnum("230")]
        OLI_NATION_MAURITIUS = 230,

        /// <summary>Liberia</summary>
        [XmlEnum("231")]
        OLI_NATION_LIBERIA = 231,

        /// <summary>Sierra Leone</summary>
        [XmlEnum("232")]
        OLI_NATION_SIERRALEONE = 232,

        /// <summary>Ghana</summary>
        [XmlEnum("233")]
        OLI_NATION_GHANA = 233,

        /// <summary>Nigeria</summary>
        [XmlEnum("234")]
        OLI_NATION_NIGERIA = 234,

        /// <summary>Chad</summary>
        [XmlEnum("235")]
        OLI_NATION_CHAD = 235,

        /// <summary>Central African Republic</summary>
        [XmlEnum("236")]
        OLI_NATION_CENTRALAFRICANREP = 236,

        /// <summary>Cameroon</summary>
        [XmlEnum("237")]
        OLI_NATION_CAMEROON = 237,

        /// <summary>Cape Verde</summary>
        [XmlEnum("238")]
        OLI_NATION_CAPEVERDEISLAND = 238,

        /// <summary>Sao Tome and Principe</summary>
        [XmlEnum("239")]
        OLI_NATION_SAOTOME = 239,

        /// <summary>Equatorial Guinea</summary>
        [XmlEnum("240")]
        OLI_NATION_EQUATORIALGUINEA = 240,

        /// <summary>Gabon</summary>
        [XmlEnum("241")]
        OLI_NATION_GABON = 241,

        /// <summary>Bahamas</summary>
        [XmlEnum("242")]
        OLI_NATION_BAHAMAS = 242,

        /// <summary>Zaire</summary>
        [XmlEnum("243")]
        OLI_NATION_ZAIRE = 243,

        /// <summary>Angola</summary>
        [XmlEnum("244")]
        OLI_NATION_ANGOLA = 244,

        /// <summary>Barbados</summary>
        [XmlEnum("246")]
        OLI_NATION_BARBADOS = 246,

        /// <summary>Ascension Islands</summary>
        [XmlEnum("247")]
        OLI_NATION_ASCENSIONISLANDS = 247,

        /// <summary>Sudan</summary>
        [XmlEnum("249")]
        OLI_NATION_SUDAN = 249,

        /// <summary>Rwanda</summary>
        [XmlEnum("250")]
        OLI_NATION_RWANDA = 250,

        /// <summary>Ethiopia</summary>
        [XmlEnum("251")]
        OLI_NATION_ETHIOPIA = 251,

        /// <summary>Somalia</summary>
        [XmlEnum("252")]
        OLI_NATION_SOMALIA = 252,

        /// <summary>Djibouti</summary>
        [XmlEnum("253")]
        OLI_NATION_DJIBOUTI = 253,

        /// <summary>Kenya</summary>
        [XmlEnum("254")]
        OLI_NATION_KENYA = 254,

        /// <summary>Tanzania, United Republic of</summary>
        [XmlEnum("255")]
        OLI_NATION_TANZANIA = 255,

        /// <summary>Uganda</summary>
        [XmlEnum("256")]
        OLI_NATION_UGANDA = 256,

        /// <summary>Burundi</summary>
        [XmlEnum("257")]
        OLI_NATION_BURUNDI = 257,

        /// <summary>Mozambique</summary>
        [XmlEnum("258")]
        OLI_NATION_MOZAMBIQUE = 258,

        /// <summary>Zambia</summary>
        [XmlEnum("260")]
        OLI_NATION_ZAMBIA = 260,

        /// <summary>Madagascar</summary>
        [XmlEnum("261")]
        OLI_NATION_MADAGASCAR = 261,

        /// <summary>Reunion</summary>
        [XmlEnum("262")]
        OLI_NATION_REUNIONISLAND = 262,

        /// <summary>Zimbabwe</summary>
        [XmlEnum("263")]
        OLI_NATION_ZIMBABWE = 263,

        /// <summary>Namibia</summary>
        [XmlEnum("264")]
        OLI_NATION_NAMIBIA = 264,

        /// <summary>Malawi</summary>
        [XmlEnum("265")]
        OLI_NATION_MALAWI = 265,

        /// <summary>Lesotho</summary>
        [XmlEnum("266")]
        OLI_NATION_LESOTHO = 266,

        /// <summary>Botswana</summary>
        [XmlEnum("267")]
        OLI_NATION_BOTSWANA = 267,

        /// <summary>Antigua and Barbuda</summary>
        [XmlEnum("268")]
        OLI_NATION_ANTIGUABARBUDA = 268,

        /// <summary>Comoros</summary>
        [XmlEnum("269")]
        OLI_NATION_COMOROS = 269,

        /// <summary>Guinea-Bissau</summary>
        [XmlEnum("270")]
        OLI_NATION_GUINEABISSAU = 270,

        /// <summary>Congo, the Democratic Republic of the</summary>
        [XmlEnum("271")]
        OLI_NATION_CONGODEMREP = 271,

        /// <summary>Virgin Islands, British</summary>
        [XmlEnum("284")]
        OLI_NATION_BRITISHVIRGINIS = 284,

        /// <summary>Saint Helena</summary>
        [XmlEnum("290")]
        OLI_NATION_STHELENA = 290,

        /// <summary>Aruba</summary>
        [XmlEnum("297")]
        OLI_NATION_ARUBA = 297,

        /// <summary>Faroe Islands</summary>
        [XmlEnum("298")]
        OLI_NATION_FAEROEISLANDS = 298,

        /// <summary>Greenland</summary>
        [XmlEnum("299")]
        OLI_NATION_GREENLAND = 299,

        /// <summary>Cayman Islands</summary>
        [XmlEnum("345")]
        OLI_NATION_CAYMANIS = 345,

        /// <summary>Gilbratar</summary>
        [XmlEnum("350")]
        OLI_NATION_GIBRALTAR = 350,

        /// <summary>Portugal</summary>
        [XmlEnum("351")]
        OLI_NATION_PORTUGAL = 351,

        /// <summary>Luxembourg</summary>
        [XmlEnum("352")]
        OLI_NATION_LUXEMBOURG = 352,

        /// <summary>Ireland</summary>
        [XmlEnum("353")]
        OLI_NATION_IRELAND = 353,

        /// <summary>Iceland</summary>
        [XmlEnum("354")]
        OLI_NATION_ICELAND = 354,

        /// <summary>Albania</summary>
        [XmlEnum("355")]
        OLI_NATION_ALBANIA = 355,

        /// <summary>Malta</summary>
        [XmlEnum("356")]
        OLI_NATION_MALTA = 356,

        /// <summary>Cyprus</summary>
        [XmlEnum("357")]
        OLI_NATION_CYPRUS = 357,

        /// <summary>Finland</summary>
        [XmlEnum("358")]
        OLI_NATION_FINLAND = 358,

        /// <summary>Bulgaria</summary>
        [XmlEnum("359")]
        OLI_NATION_BULGARIA = 359,

        /// <summary>Guernsey</summary>
        [XmlEnum("360")]
        OLI_NATION_GUERNSEY = 360,

        /// <summary>Lithuania</summary>
        [XmlEnum("370")]
        OLI_NATION_LITHUANIA = 370,

        /// <summary>Latvia</summary>
        [XmlEnum("371")]
        OLI_NATION_LATVIA = 371,

        /// <summary>Estonia</summary>
        [XmlEnum("372")]
        OLI_NATION_ESTONIA = 372,

        /// <summary>Moldova, Republic of</summary>
        [XmlEnum("373")]
        OLI_NATION_MOLDOVA = 373,

        /// <summary>Armenia</summary>
        [XmlEnum("374")]
        OLI_NATION_ARMENIA = 374,

        /// <summary>Belarus</summary>
        [XmlEnum("375")]
        OLI_NATION_BELARUS = 375,

        /// <summary>Andorra</summary>
        [XmlEnum("376")]
        OLI_NATION_ANDORRA = 376,

        /// <summary>San Marino</summary>
        [XmlEnum("378")]
        OLI_NATION_SANMARINO = 378,

        /// <summary>Ukraine</summary>
        [XmlEnum("380")]
        OLI_NATION_UKRAINE = 380,

        /// <summary>Croatia</summary>
        [XmlEnum("385")]
        OLI_NATION_CROATIA = 385,

        /// <summary>Slovenia</summary>
        [XmlEnum("386")]
        OLI_NATION_SLOVENIA = 386,

        /// <summary>Bosnia and Herzegovina</summary>
        [XmlEnum("387")]
        OLI_NATION_BOSNIAHERZEGOVINA = 387,

        /// <summary>Macedonia, The Former Yugoslav Republic of</summary>
        [XmlEnum("389")]
        OLI_NATION_MACEDONIA = 389,

        /// <summary>Kosovo</summary>
        /// <remarks>A former province of Serbia which declared independence in 2008.  Formally known as the Republic of Kosovo.</remarks>
        [XmlEnum("390")]
        OLI_NATION_KOSOVO = 390,

        /// <summary>Czech Republic</summary>
        [XmlEnum("420")]
        OLI_NATION_CZECHREPUBLIC = 420,

        /// <summary>Slovakia</summary>
        [XmlEnum("421")]
        OLI_NATION_SLOVAKIA = 421,

        /// <summary>Liechtenstein</summary>
        [XmlEnum("423")]
        OLI_NATION_LIECHTENSTEIN = 423,

        /// <summary>Bermuda</summary>
        [XmlEnum("441")]
        OLI_NATION_BERMUDA = 441,

        /// <summary>Grenada</summary>
        [XmlEnum("473")]
        OLI_NATION_CRENADA = 473,

        /// <summary>Falkland Islands (Malvinas)</summary>
        [XmlEnum("500")]
        OLI_NATION_FALKLANDISLANDS = 500,

        /// <summary>Belize</summary>
        [XmlEnum("501")]
        OLI_NATION_BELIZE = 501,

        /// <summary>Guatemala</summary>
        [XmlEnum("502")]
        OLI_NATION_GUATEMALA = 502,

        /// <summary>El Salvador</summary>
        [XmlEnum("503")]
        OLI_NATION_ELSALVADOR = 503,

        /// <summary>Honduras</summary>
        [XmlEnum("504")]
        OLI_NATION_HONDURAS = 504,

        /// <summary>Nicaragua</summary>
        [XmlEnum("505")]
        OLI_NATION_NICARAGUA = 505,

        /// <summary>Costa Rica</summary>
        [XmlEnum("506")]
        OLI_NATION_COSTARICA = 506,

        /// <summary>Saint Pierre and Miquelon</summary>
        [XmlEnum("508")]
        OLI_NATION_STPIERRE = 508,

        /// <summary>Haiti</summary>
        [XmlEnum("509")]
        OLI_NATION_HAITI = 509,

        /// <summary>Puerto Rico</summary>
        [XmlEnum("510")]
        OLI_NATION_PUERTORICO = 510,

        /// <summary>Virgin Islands, US</summary>
        [XmlEnum("511")]
        OLI_NATION_VIRGINISLANDSUS = 511,

        /// <summary>South Georgia and the South Sandwich Islands</summary>
        /// <remarks>Collection of Islands in South Atlantic</remarks>
        [XmlEnum("512")]
        OLI_NATION_SOUTHGEORGIASANDWICH = 512,

        /// <summary>Guadeloupe</summary>
        [XmlEnum("590")]
        OLI_NATION_GUADALOUPE = 590,

        /// <summary>Bolivia</summary>
        [XmlEnum("591")]
        OLI_NATION_BOLIVIA = 591,

        /// <summary>Guyana</summary>
        [XmlEnum("592")]
        OLI_NATION_GUYANA = 592,

        /// <summary>Ecuador</summary>
        [XmlEnum("593")]
        OLI_NATION_ECUADOR = 593,

        /// <summary>French Guiana</summary>
        [XmlEnum("594")]
        OLI_NATION_FRENCHGUIANA = 594,

        /// <summary>Paraguay</summary>
        [XmlEnum("595")]
        OLI_NATION_PARAGUAY = 595,

        /// <summary>Martinique</summary>
        /// <remarks>French Antilles</remarks>
        [XmlEnum("596")]
        OLI_NATION_MARTINIQUE = 596,

        /// <summary>Suriname</summary>
        [XmlEnum("597")]
        OLI_NATION_SURINAME = 597,

        /// <summary>Uruguay</summary>
        [XmlEnum("598")]
        OLI_NATION_URUGUAY = 598,

        /// <summary>Netherlands Antilles</summary>
        [XmlEnum("599")]
        OLI_NATION_NETHERLANDSANTILLES = 599,

        /// <summary>Turks and Caicos Islands</summary>
        [XmlEnum("649")]
        OLI_NATION_TURKSCAICOSIS = 649,

        /// <summary>Montserrat</summary>
        [XmlEnum("664")]
        OLI_NATION_MONTSERRAT = 664,

        /// <summary>Saipan</summary>
        [XmlEnum("670")]
        OLI_NATION_SAIPAN = 670,

        /// <summary>Guam</summary>
        [XmlEnum("671")]
        OLI_NATION_GUAM = 671,

        /// <summary>Antarctica</summary>
        [XmlEnum("672")]
        OLI_NATION_ANTARCTICA = 672,

        /// <summary>Brunei Darussalam</summary>
        [XmlEnum("673")]
        OLI_NATION_BRUNEI = 673,

        /// <summary>Nauru</summary>
        [XmlEnum("674")]
        OLI_NATION_NAURU = 674,

        /// <summary>Papua New Guinea</summary>
        [XmlEnum("675")]
        OLI_NATION_PAPUANEWGUINEA = 675,

        /// <summary>Tonga</summary>
        [XmlEnum("676")]
        OLI_NATION_TONGAISLANDS = 676,

        /// <summary>Solomon Islands</summary>
        [XmlEnum("677")]
        OLI_NATION_SOLOMONISLANDS = 677,

        /// <summary>Vanuatu</summary>
        [XmlEnum("678")]
        OLI_NATION_VANUATU = 678,

        /// <summary>Fiji</summary>
        [XmlEnum("679")]
        OLI_NATION_FIJI = 679,

        /// <summary>Wallis and Futuna</summary>
        [XmlEnum("681")]
        OLI_NATION_WALLISISLANDS = 681,

        /// <summary>Cook Islands</summary>
        [XmlEnum("682")]
        OLI_NATION_COOKISLANDS = 682,

        /// <summary>Niue</summary>
        [XmlEnum("683")]
        OLI_NATION_NIUE = 683,

        /// <summary>American Samoa</summary>
        [XmlEnum("684")]
        OLI_NATION_AMERICANSAMOA = 684,

        /// <summary>Western Samoa</summary>
        [XmlEnum("685")]
        OLI_NATION_WESTERNSAMOA = 685,

        /// <summary>Kiribati</summary>
        [XmlEnum("686")]
        OLI_NATION_KIRIBATI = 686,

        /// <summary>New Caledonia</summary>
        [XmlEnum("687")]
        OLI_NATION_NEWCALEDONIA = 687,

        /// <summary>Tuvalu</summary>
        [XmlEnum("688")]
        OLI_NATION_TUVALU = 688,

        /// <summary>French Polynesia</summary>
        [XmlEnum("689")]
        OLI_NATION_FRENCHPOLYNESIA = 689,

        /// <summary>Northern Mariana Islands</summary>
        /// <remarks>A commonwealth in political union with the US, located in N Pacific</remarks>
        [XmlEnum("691")]
        OLI_NATION_NORTHMARIANAISLANDS = 691,

        /// <summary>Palau</summary>
        [XmlEnum("693")]
        OLI_NATION_PALAU = 693,

        /// <summary>Marshall Islands</summary>
        [XmlEnum("694")]
        OLI_NATION_MARSHALLISLANDS = 694,

        /// <summary>Micronesia, Federated States of</summary>
        [XmlEnum("695")]
        OLI_NATION_MICRONESIA = 695,

        /// <summary>Saint Lucia</summary>
        [XmlEnum("758")]
        OLI_NATION_STLUCIA = 758,

        /// <summary>Dominica</summary>
        [XmlEnum("767")]
        OLI_NATION_DOMINICA = 767,

        /// <summary>Saint Vincent and the Grenadines</summary>
        [XmlEnum("784")]
        OLI_NATION_STVINCENT = 784,

        /// <summary>Dominican Republic</summary>
        [XmlEnum("809")]
        OLI_NATION_DOMINICANREPUBLIC = 809,

        /// <summary>Hong Kong</summary>
        [XmlEnum("852")]
        OLI_NATION_HONGKONG = 852,

        /// <summary>Macao</summary>
        [XmlEnum("853")]
        OLI_NATION_MACAO = 853,

        /// <summary>Cambodia</summary>
        [XmlEnum("855")]
        OLI_NATION_CAMBODIA = 855,

        /// <summary>Lao People's Democratic Republic</summary>
        [XmlEnum("856")]
        OLI_NATION_LAOS = 856,

        /// <summary>Trinidad and Tobago</summary>
        [XmlEnum("868")]
        OLI_NATION_TRINIDADTOBAGO = 868,

        /// <summary>Saint Kitts and Nevis</summary>
        [XmlEnum("869")]
        OLI_NATION_STKITTSNEVIS = 869,

        /// <summary>Jamaica</summary>
        [XmlEnum("876")]
        OLI_NATION_JAMAICA = 876,

        /// <summary>Bangladesh</summary>
        [XmlEnum("880")]
        OLI_NATION_BANGLADESH = 880,

        /// <summary>Taiwan, Province of China</summary>
        [XmlEnum("886")]
        OLI_NATION_TAIWAN = 886,

        /// <summary>Myanmar</summary>
        /// <remarks>Formerly Burma</remarks>
        [XmlEnum("950")]
        OLI_NATION_MYANMAR = 950,

        /// <summary>Korea, Republic of</summary>
        /// <remarks>South Korea</remarks>
        [XmlEnum("951")]
        OLI_NATION_KOREAREPUBLIC = 951,

        /// <summary>Korea, Democratic People's Republic of</summary>
        /// <remarks>North Korea</remarks>
        [XmlEnum("952")]
        OLI_NATION_KOREADEMPEOPLEREP = 952,

        /// <summary>Lebanon</summary>
        [XmlEnum("961")]
        OLI_NATION_LEBANON = 961,

        /// <summary>Jordan</summary>
        [XmlEnum("962")]
        OLI_NATION_JORDAN = 962,

        /// <summary>Syrian Arab Republic</summary>
        [XmlEnum("963")]
        OLI_NATION_SYRIA = 963,

        /// <summary>Iraq</summary>
        [XmlEnum("964")]
        OLI_NATION_IRAQ = 964,

        /// <summary>Kuwait</summary>
        [XmlEnum("965")]
        OLI_NATION_KUWAIT = 965,

        /// <summary>Saudi Arabia</summary>
        [XmlEnum("966")]
        OLI_NATION_SAUDIARABIA = 966,

        /// <summary>Yemen</summary>
        [XmlEnum("967")]
        OLI_NATION_YEMEN = 967,

        /// <summary>Oman</summary>
        [XmlEnum("968")]
        OLI_NATION_OMAN = 968,

        /// <summary>United Arab Emirates</summary>
        [XmlEnum("971")]
        OLI_NATION_UNITEDARABEMIRATES = 971,

        /// <summary>Israel</summary>
        [XmlEnum("972")]
        OLI_NATION_ISRAEL = 972,

        /// <summary>Bahrain</summary>
        [XmlEnum("973")]
        OLI_NATION_BAHRAIN = 973,

        /// <summary>Qatar</summary>
        [XmlEnum("974")]
        OLI_NATION_QATAR = 974,

        /// <summary>Bhutan</summary>
        [XmlEnum("975")]
        OLI_NATION_BHUTAN = 975,

        /// <summary>Nepal</summary>
        [XmlEnum("977")]
        OLI_NATION_NEPAL = 977,

        /// <summary>Tajikistan</summary>
        [XmlEnum("992")]
        OLI_NATION_TAJIKISTAN = 992,

        /// <summary>Turkmenistan</summary>
        [XmlEnum("993")]
        OLI_NATION_TURKMENISTAN = 993,

        /// <summary>Azerbaijan</summary>
        [XmlEnum("994")]
        OLI_NATION_AZERBAIJAN = 994,

        /// <summary>Georgia</summary>
        [XmlEnum("995")]
        OLI_NATION_GEORGIA = 995,

        /// <summary>Uzbekistan</summary>
        [XmlEnum("998")]
        OLI_NATION_UZBEKISTAN = 998,

        /// <summary>Anguilla</summary>
        [XmlEnum("1001")]
        OLI_NATION_ANGUILLA = 1001,

        /// <summary>Panama (also known as Canal Zone)</summary>
        [XmlEnum("1002")]
        OLI_NATION_PANAMA = 1002,

        /// <summary>Cote d'Ivoire</summary>
        [XmlEnum("1003")]
        OLI_NATION_COTEDIVORIE = 1003,

        /// <summary>Eritrea</summary>
        [XmlEnum("1004")]
        OLI_NATION_ERITREA = 1004,

        /// <summary>Kazakhstan</summary>
        [XmlEnum("1005")]
        OLI_NATION_KAZAKHSTAN = 1005,

        /// <summary>Kyrgyzstan</summary>
        [XmlEnum("1006")]
        OLI_NATION_KYRGYZSTAN = 1006,

        /// <summary>Cocos (Keeling) Islands</summary>
        [XmlEnum("1007")]
        OLI_NATION_COCOS = 1007,

        /// <summary>Mongolia</summary>
        [XmlEnum("1008")]
        OLI_NATION_MONGOLIA = 1008,

        /// <summary>Bouvet Island</summary>
        [XmlEnum("1009")]
        OLI_NATION_BOUVETISLAND = 1009,

        /// <summary>Seychelles</summary>
        [XmlEnum("1010")]
        OLI_NATION_SEYCHELLES = 1010,

        /// <summary>British Indian Ocean Territory</summary>
        [XmlEnum("1011")]
        OLI_NATION_BRITISHINDIANOCNTERR = 1011,

        /// <summary>Cocoa Islands</summary>
        [XmlEnum("1012")]
        OLI_NATION_COCOAISLANDS = 1012,

        /// <summary>Samoa</summary>
        [XmlEnum("1013")]
        OLI_NATION_SAMOA = 1013,

        /// <summary>Timor-Leste</summary>
        [XmlEnum("1014")]
        OLI_NATION_EASTTIMOR = 1014,

        /// <summary>French Southern Territories</summary>
        [XmlEnum("1015")]
        OLI_NATION_FRENCHSOUTHERNTERRITIOIES = 1015,

        /// <summary>Heard Island and McDonald Islands</summary>
        [XmlEnum("1016")]
        OLI_NATION_HEARDISLISLAND = 1016,

        /// <summary>Mayotte</summary>
        [XmlEnum("1017")]
        OLI_NATION_MAYOTTEISLAND = 1017,

        /// <summary>Pitcairn</summary>
        [XmlEnum("1018")]
        OLI_NATION_PITCARINISLANDS = 1018,

        /// <summary>Svalbard and Jan Mayen</summary>
        [XmlEnum("1019")]
        OLI_NATION_SVALBARDISLAND = 1019,

        /// <summary>Tokelau</summary>
        [XmlEnum("1020")]
        OLI_NATION_TOKELAU = 1020,

        /// <summary>United States Minor Outlying Islands</summary>
        [XmlEnum("1021")]
        OLI_NATION_USMINOROUTLYINGISLANDS = 1021,

        /// <summary>Western Sahara</summary>
        [XmlEnum("1022")]
        OLI_NATION_WESTERNSARAHA = 1022,

        /// <summary>Maldives</summary>
        [XmlEnum("1023")]
        OLI_NATION_MALDIVES = 1023,

        /// <summary>Christmas Island</summary>
        [XmlEnum("1024")]
        OLI_NATION_CHRISTMASISLANDS = 1024,

        /// <summary>Norfolk Island</summary>
        [XmlEnum("1025")]
        OLI_NATION_NORFOLKISLAND = 1025,

        /// <summary>Curacao</summary>
        [XmlEnum("1026")]
        OLI_NATION_CURACAO = 1026,

        /// <summary>Congo</summary>
        [XmlEnum("1027")]
        OLI_NATION_CONGO = 1027,

        /// <summary>Monaco</summary>
        [XmlEnum("1028")]
        OLI_NATION_MONACO = 1028,

        /// <summary>Holy See (Vatican City State)</summary>
        [XmlEnum("1029")]
        OLI_NATION_HOLYSEE = 1029,

        /// <summary>Diego Garcia</summary>
        [XmlEnum("1030")]
        OLI_NATION_DIEGOGARCIA = 1030,

        /// <summary>Swaziland</summary>
        [XmlEnum("1031")]
        OLI_NATION_SWAZILAND = 1031,

        /// <summary>Palestinian Territory, Occupied</summary>
        [XmlEnum("1032")]
        OLI_NATION_PALESTINE = 1032,

        /// <summary>Jersey</summary>
        /// <remarks>Jersey is a British crown dependency which functions in some respects as an independent country.</remarks>
        [XmlEnum("1034")]
        OLI_NATION_JERSEY = 1034,

        /// <summary>Isle of Man</summary>
        /// <remarks>Isle of Man is a British crown dependency which functions in some respects as an independent country.</remarks>
        [XmlEnum("1035")]
        OLI_NATION_ISLEOFMAN = 1035,

        /// <summary>Serbia</summary>
        /// <remarks>Serbia is an independent country derived from the old Socialist Republic of Yugoslavia.</remarks>
        [XmlEnum("1036")]
        OLI_NATION_SERBIA = 1036,

        /// <summary>Montenegro</summary>
        /// <remarks>Montenegro is an independent country since June 3 2006.  it was formerly part of Serbia and Montenegro and before that part of Yugoslavia</remarks>
        [XmlEnum("1037")]
        OLI_NATION_MONTENEGRO = 1037,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
