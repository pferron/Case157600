using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace WOW.Illustration.Model.ACORD
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.33440")]
    [Serializable()]
    [XmlType(Namespace = "http://ACORD.org/Standards/Life/2")]
    public enum OLI_LU_EMPLOYMENTTYPE_TC
    {
        /// <summary>Unknown</summary>
        [XmlEnum("0")]
        OLI_UNKNOWN = 0,

        /// <summary>Abrasives Industry, Foreman (Supervising Only)</summary>
        [XmlEnum("1")]
        OLI_EMPTYPE_ABRFOR = 1,

        /// <summary>Abrasives Industry, Superintendent Only</summary>
        [XmlEnum("2")]
        OLI_EMPTYPE_AVRSUP = 2,

        /// <summary>Accountants, Certified Public Accountants</summary>
        [XmlEnum("3")]
        OLI_EMPTYPE_ACPA = 3,

        /// <summary>Accountants, Others</summary>
        [XmlEnum("4")]
        OLI_EMPTYPE_AOTH = 4,

        /// <summary>Actuaries, ASA Or FSA</summary>
        [XmlEnum("5")]
        OLI_EMPTYPE_ACTUARY = 5,

        /// <summary>Actuary, Others</summary>
        [XmlEnum("6")]
        OLI_EMPTYPE_ACTUARIAL = 6,

        /// <summary>Acupuncturists</summary>
        [XmlEnum("7")]
        OLI_EMPTYPE_ACUPUNCT = 7,

        /// <summary>Adjusters, Fire And Marine</summary>
        [XmlEnum("8")]
        OLI_EMPTYPE_ADJFIRE = 8,

        /// <summary>Adjusters, Insurance (Not Fire Or Marine)</summary>
        [XmlEnum("9")]
        OLI_EMPTYPE_ADJINS = 9,

        /// <summary>Advertising (Agency Staff, Not Free Lance)</summary>
        [XmlEnum("10")]
        OLI_EMPTYPE_ADVER = 10,

        /// <summary>Agriculture (Farm/Orchard/Ranch) Hired Hand</summary>
        [XmlEnum("11")]
        OLI_EMPTYPE_AGRIHH = 11,

        /// <summary>Agriculture (Farm/Orchard/Ranch)Foreman/Other Skilled Workers)</summary>
        [XmlEnum("12")]
        OLI_EMPTYPE_AGRIOS = 12,

        /// <summary>Agriculture (Farm/Orchard/Ranch/Nursery/Dairy/Hatchery/Proprietor)</summary>
        [XmlEnum("13")]
        OLI_EMPTYPE_AGRIGN = 13,

        /// <summary>Air Conditioning, Engineer (Superintending/Inspector)</summary>
        [XmlEnum("14")]
        OLI_EMPTYPE_ACENG = 14,

        /// <summary>Air Conditioning, Installer/Repairer/Servicemen</summary>
        [XmlEnum("15")]
        OLI_EMPTYPE_ACINST = 15,

        /// <summary>Air Conditioning,Engineer(Office&Consult Duties Only</summary>
        [XmlEnum("16")]
        OLI_EMPTYPE_ACOFF = 16,

        /// <summary>Air Drill Operators</summary>
        [XmlEnum("17")]
        OLI_EMPTYPE_ADRILLO = 17,

        /// <summary>Air Traffic Controllers</summary>
        [XmlEnum("18")]
        OLI_EMPTYPE_ATC = 18,

        /// <summary>Airport Personnel, Baggage Handler/Porter/Freight</summary>
        [XmlEnum("19")]
        OLI_EMPTYPE_AIRBAG = 19,

        /// <summary>Airport Personnel, Dispatchers On Line</summary>
        [XmlEnum("20")]
        OLI_EMPTYPE_AIRDISPO = 20,

        /// <summary>Airport Personnel, Dispatchers(Office), Operations</summary>
        [XmlEnum("21")]
        OLI_EMPTYPE_AIRDISPP = 21,

        /// <summary>Airport Personnel, Instrument Installers</summary>
        [XmlEnum("22")]
        OLI_EMPTYPE_AIRINST = 22,

        /// <summary>Airport Personnel, Manager, Office&Supervision Duties</summary>
        [XmlEnum("23")]
        OLI_EMPTYPE_AIRMGR = 23,

        /// <summary>Allergist</summary>
        [XmlEnum("24")]
        OLI_EMPTYPE_ALLERGIST = 24,

        /// <summary>Ambulance Drivers</summary>
        [XmlEnum("25")]
        OLI_EMPTYPE_AMBDRV = 25,

        /// <summary>Anesthesiologists</summary>
        [XmlEnum("26")]
        OLI_EMPTYPE_PHYANESTH = 26,

        /// <summary>Anesthetist--Other Than Physician</summary>
        [XmlEnum("27")]
        OLI_EMPTYPE_ANTHES = 27,

        /// <summary>Antique Dealer, Purchase/Repair/Collect/Delivery</summary>
        [XmlEnum("28")]
        OLI_EMPTYPE_ANTDEAL = 28,

        /// <summary>Antique Dealers, Sales Only</summary>
        [XmlEnum("29")]
        OLI_EMPTYPE_ANTSALES = 29,

        /// <summary>Appraisers</summary>
        [XmlEnum("30")]
        OLI_EMPTYPE_APPRAISER = 30,

        /// <summary>Arbitrager</summary>
        [XmlEnum("31")]
        OLI_EMPTYPE_ARBITRAGER = 31,

        /// <summary>Architects</summary>
        [XmlEnum("32")]
        OLI_EMPTYPE_ARCHITECT = 32,

        /// <summary>Art Glass, Assemblers (No Erecting Or Setting)</summary>
        [XmlEnum("33")]
        OLI_EMPTYPE_ARTGLAASM = 33,

        /// <summary>Art Glass, Erectors Or Setters</summary>
        [XmlEnum("34")]
        OLI_EMPTYPE_ARTGLAERR = 34,

        /// <summary>Artificial Flower Makers</summary>
        [XmlEnum("35")]
        OLI_EMPTYPE_ARTFLWMKR = 35,

        /// <summary>Artificial Gas--See Gas Manufacture</summary>
        [XmlEnum("36")]
        OLI_EMPTYPE_ARTGASMFG = 36,

        /// <summary>Artificial Limb Manuf, Dealer (Not Maker Or Repairer)</summary>
        [XmlEnum("37")]
        OLI_EMPTYPE_ARTLMBMFGS = 37,

        /// <summary>Artificial Limb Manufacture, Makers Or Repairers</summary>
        [XmlEnum("38")]
        OLI_EMPTYPE_ARTMFGM = 38,

        /// <summary>Artist, Commercial (Cartoon, Illust) Not Free Lance</summary>
        [XmlEnum("39")]
        OLI_EMPTYPE_ARTISTCOM = 39,

        /// <summary>Asbestos Mill (& Concentrating Mill), Skilled Worker</summary>
        [XmlEnum("40")]
        OLI_EMPTYPE_ASBSW = 40,

        /// <summary>Asbestos Mill (& Concentrating Mill), Supervisors</summary>
        [XmlEnum("41")]
        OLI_EMPTYPE_ASBSUP = 41,

        /// <summary>Asphalt Refining, Foreman (Supervise Only), Inspector</summary>
        [XmlEnum("42")]
        OLI_EMPTYPE_ASPSUP = 42,

        /// <summary>Asphalt Refining, Others</summary>
        [XmlEnum("43")]
        OLI_EMPTYPE_ASPOTH = 43,

        /// <summary>Assayers (Not Working In Mine)</summary>
        [XmlEnum("44")]
        OLI_EMPTYPE_ASSAYERS = 44,

        /// <summary>Assessors</summary>
        [XmlEnum("45")]
        OLI_EMPTYPE_ASSESSORS = 45,

        /// <summary>Attorneys</summary>
        /// <remarks>One who is legally appointed to transact business on another's behalf; specifically : a legal agent qualified to act for suitors and defendants in legal proceedings</remarks>
        [XmlEnum("46")]
        OLI_EMPTYPE_ATY = 46,

        /// <summary>Auctioneers, Livestock</summary>
        [XmlEnum("47")]
        OLI_EMPTYPE_AUCTLIVE = 47,

        /// <summary>Auctioneers, Others</summary>
        [XmlEnum("48")]
        OLI_EMPTYPE_AUCTOTHY = 48,

        /// <summary>Audiologists</summary>
        [XmlEnum("49")]
        OLI_EMPTYPE_AUDIO = 49,

        /// <summary>Auditor</summary>
        [XmlEnum("50")]
        OLI_EMPTYPE_AUDITOR = 50,

        /// <summary>Automobile Industry Dealer/Owner, Sales,-New Vehicles</summary>
        [XmlEnum("51")]
        OLI_EMPTYPE_AUTISALES = 51,

        /// <summary>Automobile Industry Manufacturing,Assembler/Machinist</summary>
        [XmlEnum("52")]
        OLI_EMPTYPE_AUTOMFGMAC = 52,

        /// <summary>Automobile Industry Dealer/Salesmen New Vehicle</summary>
        [XmlEnum("53")]
        OLI_EMPTYPE_AUTOSAMESMAN = 53,

        /// <summary>Automobile Industry Dealer/Salesmen, Used Vehicles</summary>
        [XmlEnum("54")]
        OLI_EMPTYPE_AUTOUSEDMAN = 54,

        /// <summary>Automobile Industry Garage/Filling&Service, Manager</summary>
        [XmlEnum("55")]
        OLI_EMPTYPE_AUTOSM = 55,

        /// <summary>Automobile Industry Garage/Filling&Service,Other Duties</summary>
        [XmlEnum("56")]
        OLI_EMPTYPE_AUTOFILL = 56,

        /// <summary>Automobile Industry Manufacturing, (Supervisory Only)</summary>
        [XmlEnum("57")]
        OLI_EMPTYPE_AUTOMFGSUP = 57,

        /// <summary>Automobile Industry Manufacturing, Foreman</summary>
        [XmlEnum("58")]
        OLI_EMPTYPE_AUTOMFGFOR = 58,

        /// <summary>Automobile Industry Testers, Shop</summary>
        [XmlEnum("59")]
        OLI_EMPTYPE_AUTOTEST = 59,

        /// <summary>Awning Industry, Erector, Hanger, Installer</summary>
        [XmlEnum("60")]
        OLI_EMPTYPE_AWNERECT = 60,

        /// <summary>Awning Industry, Maker</summary>
        [XmlEnum("61")]
        OLI_EMPTYPE_AWMMFG = 61,

        /// <summary>Bacteriologists</summary>
        [XmlEnum("62")]
        OLI_EMPTYPE_BACTER = 62,

        /// <summary>Bailiffs, Court Duties</summary>
        [XmlEnum("63")]
        OLI_EMPTYPE_BALIFF = 63,

        /// <summary>Bakeries (Shops And Factories), All Others</summary>
        [XmlEnum("64")]
        OLI_EMPTYPE_BAKEROTH = 64,

        /// <summary>Bakery (Shop/Factory), Superintendent/Foremen/Manager</summary>
        [XmlEnum("65")]
        OLI_EMPTYPE_BAKERSUP = 65,

        /// <summary>Bank, Armored Car Guard/Other Armed Personnel, Collector</summary>
        [XmlEnum("66")]
        OLI_EMPTYPE_BANKARMED = 66,

        /// <summary>Banks, Messengers (Unarmed)</summary>
        [XmlEnum("67")]
        OLI_EMPTYPE_BANKMSG = 67,

        /// <summary>Banks, Officers</summary>
        [XmlEnum("68")]
        OLI_EMPTYPE_BANKOFF = 68,

        /// <summary>Banks, Tellers, Clerks</summary>
        [XmlEnum("69")]
        OLI_EMPTYPE_BANKTEL = 69,

        /// <summary>Barbers, Proprietors And Journeymen</summary>
        [XmlEnum("70")]
        OLI_EMPTYPE_BARBER = 70,

        /// <summary>Beauty Parlors, Away From Home</summary>
        [XmlEnum("71")]
        OLI_EMPTYPE_BEAUTYPAR = 71,

        /// <summary>Beverage Manufacture Non-Alcoholic, Skilled Worker</summary>
        [XmlEnum("72")]
        OLI_EMPTYPE_BEVMFGSW = 72,

        /// <summary>Beverage Manufacture Non-Alcoholic, Superintendent</summary>
        [XmlEnum("73")]
        OLI_EMPTYPE_BEVMFGSUP = 73,

        /// <summary>Beverage Manufacture Non-Alcoholic, Unskilled Worker</summary>
        [XmlEnum("74")]
        OLI_EMPTYPE_BEVMFGUW = 74,

        /// <summary>Bicycle Industry, All Others</summary>
        [XmlEnum("75")]
        OLI_EMPTYPE_BICOTH = 75,

        /// <summary>Bicycle Industry, Dealer, Sales-No Assembly Or Repair</summary>
        [XmlEnum("76")]
        OLI_EMPTYPE_BICDEAL = 76,

        /// <summary>Bill Poster</summary>
        [XmlEnum("77")]
        OLI_EMPTYPE_BILLPOST = 77,

        /// <summary>Biochemists, Office Duties Only</summary>
        [XmlEnum("78")]
        OLI_EMPTYPE_BIOCHEMOD = 78,

        /// <summary>Biochemists, Others</summary>
        [XmlEnum("79")]
        OLI_EMPTYPE_BIOCHEMOT = 79,

        /// <summary>Biologists, Office Duties Only</summary>
        [XmlEnum("80")]
        OLI_EMPTYPE_BIOLOF = 80,

        /// <summary>Biologists, Others</summary>
        [XmlEnum("81")]
        OLI_EMPTYPE_BIOLOTH = 81,

        /// <summary>Blacksmiths (No Unusual Hazard)</summary>
        [XmlEnum("82")]
        OLI_EMPTYPE_BLACKSMTH = 82,

        /// <summary>Boiler Manufacture, Installation/Maintenance, Inspector</summary>
        [XmlEnum("83")]
        OLI_EMPTYPE_BLRMFGINS = 83,

        /// <summary>Boiler Manufacture/Installation/Maintenance, Cleaner</summary>
        [XmlEnum("84")]
        OLI_EMPTYPE_BLRMFGINSCLK = 84,

        /// <summary>Boiler Manufacture/Installation/Maintenance, Foremen</summary>
        [XmlEnum("85")]
        OLI_EMPTYPE_BLRMFGSUP = 85,

        /// <summary>Bond Brokers Or Salesmen</summary>
        [XmlEnum("86")]
        OLI_EMPTYPE_BONDBROKER = 86,

        /// <summary>Booking Agents (Full-Time & Working Out Of Office)</summary>
        [XmlEnum("87")]
        OLI_EMPTYPE_BOOKINGAGENT = 87,

        /// <summary>Bookkeepers</summary>
        [XmlEnum("88")]
        OLI_EMPTYPE_BOOKEEPER = 88,

        /// <summary>Borax Mill (Employees Not In Mines), Superintendent</summary>
        [XmlEnum("89")]
        OLI_EMPTYPE_BORAXSUP = 89,

        /// <summary>Borax Mill (Not In Mine), All Other Mill Employees</summary>
        [XmlEnum("90")]
        OLI_EMPTYPE_BORAXOTH = 90,

        /// <summary>Borax Mill(Not In Mines) Superintendent/Foremen Mill Employee</summary>
        [XmlEnum("91")]
        OLI_EMPTYPE_BORAXMILL = 91,

        /// <summary>Botanists, Office Duties Only</summary>
        [XmlEnum("92")]
        OLI_EMPTYPE_BOTANISTOF = 92,

        /// <summary>Botanists, Others</summary>
        [XmlEnum("93")]
        OLI_EMPTYPE_BOTANISTOTH = 93,

        /// <summary>Brick Manufacture, Foremen And Skilled Workers</summary>
        [XmlEnum("94")]
        OLI_EMPTYPE_BRICKMFGSUP = 94,

        /// <summary>Brick Manufacture, Stacker/Brick&Clay Wheeler/Other Laborer</summary>
        [XmlEnum("95")]
        OLI_EMPTYPE_BRICKMFGLB = 95,

        /// <summary>Bricklayer/Masons (No Unusual Hazard)</summary>
        [XmlEnum("96")]
        OLI_EMPTYPE_BRICKLAYER = 96,

        /// <summary>Briquette Manufacture, All Others</summary>
        [XmlEnum("97")]
        OLI_EMPTYPE_BRIQMFGOTH = 97,

        /// <summary>Briquette Manufacture, Foremen</summary>
        [XmlEnum("98")]
        OLI_EMPTYPE_BGIQMFGSUP = 98,

        /// <summary>Broker, Commodity, Futures, Options--Individual Consultant</summary>
        [XmlEnum("99")]
        OLI_EMPTYPE_BROKCOMCONS = 99,

        /// <summary>Broker, Commodity/Future/Option,Medium/Large-Size</summary>
        [XmlEnum("100")]
        OLI_EMPTYPE_BROKCOMLARGE = 100,

        /// <summary>Brokers, Produce Broker, Not Visiting Market&Handling Goods</summary>
        [XmlEnum("101")]
        OLI_EMPTYPE_BROKPROD = 101,

        /// <summary>Brokers, Real Estate Broker, Principal/Owner, Working F/T</summary>
        [XmlEnum("102")]
        OLI_EMPTYPE_BROKREALEST = 102,

        /// <summary>Broker, Stock/Bond (Not Commodities) Floor Self-Employed</summary>
        [XmlEnum("103")]
        OLI_EMPTYPE_BROKSBFLOORSELF = 103,

        /// <summary>Broker, Stock/Bond (Not Commodities) Floor Trader</summary>
        [XmlEnum("104")]
        OLI_EMPTYPE_BROKSBFLOOR = 104,

        /// <summary>Broker, Stock/Bond (Not Commodities) Office Duties</summary>
        [XmlEnum("105")]
        OLI_EMPTYPE_BROKSBOFFICE = 105,

        /// <summary>Brokers, Mortgage Broker, Office Duties Only</summary>
        [XmlEnum("106")]
        OLI_EMPTYPE_BROKMORTOFFICE = 106,

        /// <summary>Brokers, Produce Broker, Others</summary>
        [XmlEnum("107")]
        OLI_EMPTYPE_BROKPRODUCEOTHERS = 107,

        /// <summary>Brokers, Real Estate Broker, Others Working Full-Time</summary>
        [XmlEnum("108")]
        OLI_EMPTYPE_BROKREALESTFT = 108,

        /// <summary>Brokers, Stocks Or Bonds (Not Commodities) Pawn</summary>
        [XmlEnum("109")]
        OLI_EMPTYPE_BROKPAWN = 109,

        /// <summary>Broom And Brush Factories, All Others</summary>
        [XmlEnum("110")]
        OLI_EMPTYPE_BRMBRSHOTH = 110,

        /// <summary>Broom/Brush Factories, Superintendents And Foremen</summary>
        [XmlEnum("111")]
        OLI_EMPTYPE_BRMBRSHSUP = 111,

        /// <summary>Broom/Brush Factory, Assembler/Tier/Trimmer/Skilled</summary>
        [XmlEnum("112")]
        OLI_EMPTYPE_BRMBRSHSKILLED = 112,

        /// <summary>Buffer, Metal</summary>
        [XmlEnum("113")]
        OLI_EMPTYPE_BUFFERMETAL = 113,

        /// <summary>Building & Construction, Civil Engineer</summary>
        [XmlEnum("114")]
        OLI_EMPTYPE_BLDCONCIVENG = 114,

        /// <summary>Building & Construction, Estimator Not At Building</summary>
        [XmlEnum("115")]
        OLI_EMPTYPE_BLDCONESTIM = 115,

        /// <summary>Building And Construction, Architects</summary>
        [XmlEnum("116")]
        OLI_EMPTYPE_BLDCONARCHITECT = 116,

        /// <summary>Building And Construction, Other Skilled Workers</summary>
        [XmlEnum("117")]
        OLI_EMPTYPE_BLDCONOTHSKILLED = 117,

        /// <summary>Building And Construction, Project Managers</summary>
        [XmlEnum("118")]
        OLI_EMPTYPE_BLDCONPROJMGR = 118,

        /// <summary>Building Maintenance, Building Cleaner/Elevator Installer</summary>
        [XmlEnum("119")]
        OLI_EMPTYPE_BLDMAINTELEVATOR = 119,

        /// <summary>Building Maintenance, Elevator Operator/Starter Door</summary>
        [XmlEnum("120")]
        OLI_EMPTYPE_BLDMAINTSTARTERDOOR = 120,

        /// <summary>Building Maintenance, Super (Supervising Only)</summary>
        [XmlEnum("121")]
        OLI_EMPTYPE_BLDMAINTSUP = 121,

        /// <summary>Building Mover/Wrecker, Superintendent/Foremen/Manager</summary>
        [XmlEnum("122")]
        OLI_EMPTYPE_BLDMAINTFOR = 122,

        /// <summary>Building/Construction, Contractor/Super Not At Site</summary>
        [XmlEnum("123")]
        OLI_EMPTYPE_BLDMAINTSUPOFFSITE = 123,

        /// <summary>Building/Construction, Contractor/Superintendent Site</summary>
        [XmlEnum("124")]
        OLI_EMPTYPE_BLDMAINTSUPONSITE = 124,

        /// <summary>Building/Construction, Electricians And Plumbers</summary>
        [XmlEnum("125")]
        OLI_EMPTYPE_BLDMAINTELECPLUMB = 125,

        /// <summary>Bus Drivers</summary>
        [XmlEnum("126")]
        OLI_EMPTYPE_BUSDRIVER = 126,

        /// <summary>Business Machine Sales & Service, Manager & Sales</summary>
        [XmlEnum("127")]
        OLI_EMPTYPE_BUSMACSALES = 127,

        /// <summary>Business Machine Sales/Service, Servicemen/All Other</summary>
        [XmlEnum("128")]
        OLI_EMPTYPE_BUSMACOTH = 128,

        /// <summary>Business Owners;Small, Administrative, Minimal Duties</summary>
        [XmlEnum("129")]
        OLI_EMPTYPE_OWNERADM = 129,

        /// <summary>Business Owners;Small, Some Travel &/Or Retail Sales</summary>
        [XmlEnum("130")]
        OLI_EMPTYPE_OWNERRETAIL = 130,

        /// <summary>Business Owners;Small, Supervising Blue Collar Employee</summary>
        [XmlEnum("131")]
        OLI_EMPTYPE_OWNERBLUECOLLAR = 131,

        /// <summary>Butchers, Others</summary>
        [XmlEnum("132")]
        OLI_EMPTYPE_BUTCHEROTH = 132,

        /// <summary>Butchers, Proprietor And Retail Store</summary>
        [XmlEnum("133")]
        OLI_EMPTYPE_OWNERBUTCHER = 133,

        /// <summary>Butlers, Not Living On Premises</summary>
        [XmlEnum("134")]
        OLI_EMPTYPE_BUTLER = 134,

        /// <summary>Button Manufacture, Foremen</summary>
        [XmlEnum("135")]
        OLI_EMPTYPE_BUTTONMFGFOR = 135,

        /// <summary>Button Manufacture, Others</summary>
        [XmlEnum("136")]
        OLI_EMPTYPE_BUTTONMFGOTH = 136,

        /// <summary>Button Manufacture, Superintendents</summary>
        [XmlEnum("137")]
        OLI_EMPTYPE_BUTTONMFGSUP = 137,

        /// <summary>Buyer Department Store, Office Duties Only</summary>
        [XmlEnum("138")]
        OLI_EMPTYPE_BUYEROFFICE = 138,

        /// <summary>Buyers Department Store, Others</summary>
        [XmlEnum("139")]
        OLI_EMPTYPE_BUYEROTH = 139,

        /// <summary>Buyers, Cotton, Grain, Poultry, Tobacco, Wool</summary>
        [XmlEnum("140")]
        OLI_EMPTYPE_BUYERCOMMODITIES = 140,

        /// <summary>Buyers, Ore, Livestock, Lumber, Fur</summary>
        [XmlEnum("141")]
        OLI_EMPTYPE_BUYERLIVESTOCK = 141,

        /// <summary>Cabinet Makers</summary>
        [XmlEnum("142")]
        OLI_EMPTYPE_CABMFG = 142,

        /// <summary>Calcium Carbide/Cyanamide Manufacture, All Other Emp</summary>
        [XmlEnum("143")]
        OLI_EMPTYPE_CALCARBMFGOTH = 143,

        /// <summary>Calcium Carbide/Cyanamide Manufacture, Foremen/Packers</summary>
        [XmlEnum("144")]
        OLI_EMPTYPE_CALCARBMFGFOR = 144,

        /// <summary>Camera Manufacture, Assembler/Finisher/Lens Grinders</summary>
        [XmlEnum("145")]
        OLI_EMPTYPE_CAMMFGGRINDER = 145,

        /// <summary>Camera Manufacture, Engineer/Superintendent/Foremen</summary>
        [XmlEnum("146")]
        OLI_EMPTYPE_CAMMFGSUP = 146,

        /// <summary>Camera Manufacture, Others</summary>
        [XmlEnum("147")]
        OLI_EMPTYPE_CAMMFGOTH = 147,

        /// <summary>Camps/Park (Year Round), Proprietor/Manager/Director</summary>
        [XmlEnum("148")]
        OLI_EMPTYPE_CAMPMGR = 148,

        /// <summary>Can Manufacturing, Others</summary>
        [XmlEnum("149")]
        OLI_EMPTYPE_CANMFGOTH = 149,

        /// <summary>Can Manufacturing, Superintendents, Foremen</summary>
        [XmlEnum("150")]
        OLI_EMPTYPE_CANMFGSUP = 150,

        /// <summary>Canal Worker, Dockmaster/Superintendent/Inspector</summary>
        [XmlEnum("151")]
        OLI_EMPTYPE_CANALDOCK = 151,

        /// <summary>Canal Workers, Bridge, Lock Or Buoy Tenders</summary>
        [XmlEnum("152")]
        OLI_EMPTYPE_CANALTENDER = 152,

        /// <summary>Canning/Pickling/Preserving Factories, Foremen</summary>
        [XmlEnum("153")]
        OLI_EMPTYPE_CANPREFOR = 153,

        /// <summary>Canning/Pickling/Preserving Factory, All Others</summary>
        [XmlEnum("154")]
        OLI_EMPTYPE_CANPREOTH = 154,

        /// <summary>Canning/Pickling/Preserving Factory, Superintendents</summary>
        [XmlEnum("155")]
        OLI_EMPTYPE_CANPRESUP = 155,

        /// <summary>Cantors</summary>
        [XmlEnum("156")]
        OLI_EMPTYPE_CANTOR = 156,

        /// <summary>Carbon Electrode/Graphite Manufacture, Foremen</summary>
        [XmlEnum("157")]
        OLI_EMPTYPE_CARBELECMFGFOR = 157,

        /// <summary>Carbon Electrode/Graphite Manufacture, Superintendent</summary>
        [XmlEnum("158")]
        OLI_EMPTYPE_CARBELECMFGSUP = 158,

        /// <summary>Cardiac Surgeons</summary>
        [XmlEnum("159")]
        OLI_EMPTYPE_SURGCARDIO = 159,

        /// <summary>Cardiologists</summary>
        [XmlEnum("160")]
        OLI_EMPTYPE_CARDIO = 160,

        /// <summary>Caretaker (Not On Premises) Private House & Grounds</summary>
        [XmlEnum("161")]
        OLI_EMPTYPE_GARDNER_PVT = 161,

        /// <summary>Carpenters</summary>
        [XmlEnum("162")]
        OLI_EMPTYPE_CARPENTER = 162,

        /// <summary>Carpet Installers</summary>
        [XmlEnum("163")]
        OLI_EMPTYPE_CARPETINSTALLER = 163,

        /// <summary>Cattle Dealers, Handling Livestock</summary>
        [XmlEnum("164")]
        OLI_EMPTYPE_CATTLEDEALERHANDLER = 164,

        /// <summary>Cattle Dealers, Not Handling Livestock</summary>
        [XmlEnum("165")]
        OLI_EMPTYPE_CATTLEDEALERNONHANDLER = 165,

        /// <summary>Cement, Lime And Gypsum Manufacture, Foremen</summary>
        [XmlEnum("166")]
        OLI_EMPTYPE_CEMENTMFGFOR = 166,

        /// <summary>Cement/Lime/Gypsum Manufacture, Superintendent</summary>
        [XmlEnum("167")]
        OLI_EMPTYPE_CEMENTMFGSUP = 167,

        /// <summary>Cemeteries, All Others</summary>
        [XmlEnum("168")]
        OLI_EMPTYPE_CEMETERYOTH = 168,

        /// <summary>Cemeteries, Superintendent & Clerk, No Manual Labor</summary>
        [XmlEnum("169")]
        OLI_EMPTYPE_CEMETERYSUP = 169,

        /// <summary>Charcoal Manufacture Open Pit Process, Foremen</summary>
        [XmlEnum("170")]
        OLI_EMPTYPE_CHARMFGFOR = 170,

        /// <summary>Charcoal Manufacture Open Pit, Proprietor/Superintendent</summary>
        [XmlEnum("171")]
        OLI_EMPTYPE_CHARMFGSUP = 171,

        /// <summary>Chemical Industry, Chemist(Lab Duty)/Superintendent</summary>
        [XmlEnum("172")]
        OLI_EMPTYPE_CHEMISTSUP = 172,

        /// <summary>Chemical Industry, Chemists (Office Duties Only)</summary>
        [XmlEnum("173")]
        OLI_EMPTYPE_CHEMISTOFFICE = 173,

        /// <summary>Chemical Industry, Foremen/Chemist In Process Work</summary>
        [XmlEnum("174")]
        OLI_EMPTYPE_CHEMICALFOR = 174,

        /// <summary>Chemical Industry, Other Skilled Workers</summary>
        [XmlEnum("175")]
        OLI_EMPTYPE_CHEMOCALOSW = 175,

        /// <summary>Chemist/Assayer/Metallurgist, Engaged In Process Work</summary>
        [XmlEnum("176")]
        OLI_EMPTYPE_CHEMISTASSAYER = 176,

        /// <summary>Chemist/Assayer/Metallurgist--Office Duties Only</summary>
        /// <remarks>May also be classified as --> 44  OLI_EMPTYPE_ASSAYERSMay also be classified as --> 487 OLI_EMPTYPE_METALURGIST</remarks>
        [XmlEnum("177")]
        OLI_EMPTYPE_CHEMISTASSAYEROFF = 177,

        /// <summary>Chemist/Assayer/Metallurgist--Lab Duties</summary>
        /// <remarks>May also be classified as --> 44 OLI_EMPTYPE_ASSAYERS</remarks>
        [XmlEnum("178")]
        OLI_EMPTYPE_CHEMISTASSAYLAB = 178,

        /// <summary>Chimney Cleaners Or Sweeps</summary>
        [XmlEnum("179")]
        OLI_EMPTYPE_CHIMNEYSWEEP = 179,

        /// <summary>Chiropodists</summary>
        [XmlEnum("180")]
        OLI_EMPTYPE_CHIROPODISTS = 180,

        /// <summary>Chiropractors</summary>
        [XmlEnum("181")]
        OLI_EMPTYPE_CHIROPRACTORS = 181,

        /// <summary>City Marshals Process Serving, Armed</summary>
        [XmlEnum("182")]
        OLI_EMPTYPE_MARSHALLARMED = 182,

        /// <summary>City Marshals Process Serving, Unarmed</summary>
        [XmlEnum("183")]
        OLI_EMPTYPE_MARSHALLNOTARMED = 183,

        /// <summary>City Marshals, Office And Court Duties Only</summary>
        [XmlEnum("184")]
        OLI_EMPTYPE_MARSHALLOFFICE = 184,

        /// <summary>Civil Engineer</summary>
        [XmlEnum("185")]
        OLI_EMPTYPE_CIVILENG = 185,

        /// <summary>Claim Adjusters, Insurance, Fire Or Marine</summary>
        [XmlEnum("186")]
        OLI_EMPTYPE_CLAINADJFIREMAR = 186,

        /// <summary>Claim Adjusters, Insurance, Not Fire Or Marine</summary>
        [XmlEnum("187")]
        OLI_EMPTYPE_CLAINADJOTH = 187,

        /// <summary>Clergymen</summary>
        [XmlEnum("188")]
        OLI_EMPTYPE_CLERGY = 188,

        /// <summary>Clock Manufacturing Or Repair, All Others</summary>
        [XmlEnum("189")]
        OLI_EMPTYPE_CLOCKMFGOTH = 189,

        /// <summary>Clock Manufacturing/Repair, Using Hand Tools Only</summary>
        [XmlEnum("190")]
        OLI_EMPTYPE_CLOCKMFGTOOLS = 190,

        /// <summary>Clothing Manufacture (Factory Shop/Store), Custom</summary>
        [XmlEnum("191")]
        OLI_EMPTYPE_CLOTHINGMFGCUSTOM = 191,

        /// <summary>Clothing Manufacture (Factory Shop/Store), Proprietor</summary>
        [XmlEnum("192")]
        OLI_EMPTYPE_CLOTHINGMFGOWNER = 192,

        /// <summary>Clothing Manufacture (Factory/Shop/Store), Other Workers</summary>
        [XmlEnum("193")]
        OLI_EMPTYPE_CLOTHINGMFGOFFICE = 193,

        /// <summary>Coal And Wood Yards, Foremen</summary>
        [XmlEnum("194")]
        OLI_EMPTYPE_COALFOR = 194,

        /// <summary>Coal/Wood Yard, Manager/Proprietor/Superintendent</summary>
        [XmlEnum("195")]
        OLI_EMPTYPE_COALSUP = 195,

        /// <summary>Cobblers</summary>
        [XmlEnum("196")]
        OLI_EMPTYPE_COBBLER = 196,

        /// <summary>Cold Storage, Others</summary>
        [XmlEnum("197")]
        OLI_EMPTYPE_COLDSTOROTH = 197,

        /// <summary>Cold Storage, Proprietors Or Managers</summary>
        [XmlEnum("198")]
        OLI_EMPTYPE_COLDSTODMGR = 198,

        /// <summary>Collectors, Accounts, All Others</summary>
        [XmlEnum("199")]
        OLI_EMPTYPE_COLLECTOROTH = 199,

        /// <summary>Collectors, Accounts, Office Only</summary>
        [XmlEnum("200")]
        OLI_EMPTYPE_COLLECTOROTHCLK = 200,

        /// <summary>Commissary Clerks</summary>
        [XmlEnum("201")]
        OLI_EMPTYPE_COMMISARYCLERK = 201,

        /// <summary>Comptroller</summary>
        [XmlEnum("202")]
        OLI_EMPTYPE_COMPTROLLER = 202,

        /// <summary>Computer Industry--Not At Home, Analyst, Keypunch</summary>
        [XmlEnum("203")]
        OLI_EMPTYPE_COMPINDANALYSTOFF = 203,

        /// <summary>Computer Industry--Not At Home, Deliverymen-Heavy Equipment</summary>
        [XmlEnum("204")]
        OLI_EMPTYPE_COMPINDDELIVERYOFF = 204,

        /// <summary>Computer Industry--Not Working At Home, Deliverymen</summary>
        [XmlEnum("205")]
        OLI_EMPTYPE_COMPINDDELIVERY = 205,

        /// <summary>Computer Industry--Not Working At Home, Salesmen</summary>
        [XmlEnum("206")]
        OLI_EMPTYPE_COMPINDSALES = 206,

        /// <summary>Confectioner (Candy/Cake), Local Delivery</summary>
        [XmlEnum("207")]
        OLI_EMPTYPE_CONFECTIONERDEL = 207,

        /// <summary>Confectioner (Candy/Cake), Packer/Checker/Wrapper</summary>
        [XmlEnum("208")]
        OLI_EMPTYPE_CONFECTIONERPACKER = 208,

        /// <summary>Confectioner (Candy/Cake), Superintendent/Foremen</summary>
        [XmlEnum("209")]
        OLI_EMPTYPE_CONFECTIONERSUP = 209,

        /// <summary>Consultants, Office Duties Only</summary>
        [XmlEnum("210")]
        OLI_EMPTYPE_CONSULTANTOFF = 210,

        /// <summary>Restaurant 1st Class 2nd Liquor, Cook</summary>
        [XmlEnum("211")]
        OLI_EMPTYPE_COOK = 211,

        /// <summary>Copyist (Office Duties Only)</summary>
        [XmlEnum("212")]
        OLI_EMPTYPE_COPYIST = 212,

        /// <summary>Cork Manufacture, Foremen And Inspectors</summary>
        [XmlEnum("213")]
        OLI_EMPTYPE_CORKMFGFOR = 213,

        /// <summary>Cork Manufacture, Others</summary>
        [XmlEnum("214")]
        OLI_EMPTYPE_CORKMFGOTH = 214,

        /// <summary>Cork Manufacture, Skilled Workers</summary>
        [XmlEnum("215")]
        OLI_EMPTYPE_CORKMFGSKILLED = 215,

        /// <summary>Coroners</summary>
        [XmlEnum("216")]
        OLI_EMPTYPE_CORONER = 216,

        /// <summary>Corporate Executive</summary>
        [XmlEnum("217")]
        OLI_EMPTYPE_CORPEXEC = 217,

        /// <summary>Court Reporters</summary>
        [XmlEnum("218")]
        OLI_EMPTYPE_COURTREPORTER = 218,

        /// <summary>Credit Men--(Office Duties)</summary>
        [XmlEnum("219")]
        OLI_EMPTYPE_CERDITMEN = 219,

        /// <summary>Crematories, Attendants</summary>
        [XmlEnum("220")]
        OLI_EMPTYPE_CERMATORYATT = 220,

        /// <summary>Crematories, Proprietors (Management Duties Only)</summary>
        [XmlEnum("221")]
        OLI_EMPTYPE_CERMATORYOTH = 221,

        /// <summary>Critical Care MD'S</summary>
        [XmlEnum("222")]
        OLI_EMPTYPE_CRITCAREMD = 222,

        /// <summary>Curators, Library, Museum Or Art Gallery</summary>
        [XmlEnum("223")]
        OLI_EMPTYPE_CURATOR = 223,

        /// <summary>Custodians</summary>
        [XmlEnum("224")]
        OLI_EMPTYPE_CUSTODIAN = 224,

        /// <summary>Dairy Product Manufacture, Milk Depot/Creamery, Others</summary>
        [XmlEnum("225")]
        OLI_EMPTYPE_DAIRYOTH = 225,

        /// <summary>Dairy Product Manufacture, Milk Depot/Creamery, Skilled Employees</summary>
        [XmlEnum("226")]
        OLI_EMPTYPE_DAIRYSKILLED = 226,

        /// <summary>Dance Teacher (Full Time,Studio Other Than Residence)</summary>
        [XmlEnum("227")]
        OLI_EMPTYPE_DANCEINST = 227,

        /// <summary>Day Care Owner/Employee,Non-Resid Teaching, Licensed</summary>
        [XmlEnum("228")]
        OLI_EMPTYPE_DAYCAREOWNER = 228,

        /// <summary>Decorator/Interior, Other,Including Paper Hanger</summary>
        [XmlEnum("229")]
        OLI_EMPTYPE_DECORATOROTH = 229,

        /// <summary>Decorators, Interior, Consulting Duties Only</summary>
        [XmlEnum("230")]
        OLI_EMPTYPE_DECORATORCON = 230,

        /// <summary>Decorators, Interior, Window And Display</summary>
        [XmlEnum("231")]
        OLI_EMPTYPE_DECORATORINT = 231,

        /// <summary>Dental Hygienist,Office Assist(Not Nurses),Dentistry</summary>
        [XmlEnum("232")]
        OLI_EMPTYPE_DENTALHYGENIST = 232,

        /// <summary>Dental Lab Worker, Technician, Nurse, Dentistry</summary>
        [XmlEnum("233")]
        OLI_EMPTYPE_DENTALLAB = 233,

        /// <summary>Dermatologists</summary>
        [XmlEnum("234")]
        OLI_EMPTYPE_DERMATOLOGIST = 234,

        /// <summary>Designers, Interior</summary>
        [XmlEnum("235")]
        OLI_EMPTYPE_DESIGNER = 235,

        /// <summary>Diamond Cutters, Polishers And Setters</summary>
        [XmlEnum("236")]
        OLI_EMPTYPE_DIAMONDCUTTER = 236,

        /// <summary>Die Makers (No Grinding)</summary>
        [XmlEnum("237")]
        OLI_EMPTYPE_DIEMAKER = 237,

        /// <summary>Dock Worker (Marine), Superintendent/Office Clerks</summary>
        [XmlEnum("238")]
        OLI_EMPTYPE_DOCKWORKER = 238,

        /// <summary>Doctors Of Medicine</summary>
        [XmlEnum("239")]
        OLI_EMPTYPE_MD = 239,

        /// <summary>Dog Catchers</summary>
        [XmlEnum("240")]
        OLI_EMPTYPE_DOGCATCHER = 240,

        /// <summary>Dog Kennels, Groomers (Away From Home)</summary>
        [XmlEnum("241")]
        OLI_EMPTYPE_KENNELGROOMER_RMT = 241,

        /// <summary>Kennels, Proprietors, Breeders, Trainers</summary>
        [XmlEnum("242")]
        OLI_EMPTYPE_KENNELOWNER = 242,

        /// <summary>Doormen</summary>
        [XmlEnum("243")]
        OLI_EMPTYPE_DOORMAN = 243,

        /// <summary>Draftsmen (Office Away From Home Only)</summary>
        [XmlEnum("244")]
        OLI_EMPTYPE_DRAFTSMAN = 244,

        /// <summary>Drawbridge Tenders, In Towers</summary>
        [XmlEnum("245")]
        OLI_EMPTYPE_DRAWBRIDGETENGERTOW = 245,

        /// <summary>Drawbridge Tenders, Others</summary>
        [XmlEnum("246")]
        OLI_EMPTYPE_DRAWBRIDGETENGEROTH = 246,

        /// <summary>Dressmakers, In Shop</summary>
        [XmlEnum("247")]
        OLI_EMPTYPE_DRESSMAKER = 247,

        /// <summary>Drill Press Operators</summary>
        [XmlEnum("248")]
        OLI_EMPTYPE_DRILLPRESSOPER = 248,

        /// <summary>Driver, Taxi,Including Proprietor Of Small Taxi Company</summary>
        /// <remarks>May also be classified as --> 736 OLI_EMPTYPE_TAXICABDRIVER</remarks>
        [XmlEnum("249")]
        OLI_EMPTYPE_DRIVERTAXI = 249,

        /// <summary>Driver, Truck-Non-hazardous:  Light Trucking, Local</summary>
        [XmlEnum("250")]
        OLI_EMPTYPE_DRIVERTRUCKLIGHT = 250,

        /// <summary>Drivers, Ambulances/Ambulance Drivers</summary>
        /// <remarks>Unclassified Ambulance Driver</remarks>
        [XmlEnum("251")]
        OLI_EMPTYPE_DRIVERAMBULANCE = 251,

        /// <summary>Drug And Toilet Preparations Manufacturing, Others</summary>
        [XmlEnum("252")]
        OLI_EMPTYPE_DRUGMFG = 252,

        /// <summary>Drug Store, Clerks</summary>
        [XmlEnum("253")]
        OLI_EMPTYPE_DRUGCLERK = 253,

        /// <summary>Drug/Toilet Preparation Manufacturing, Foremen/Superintendent</summary>
        [XmlEnum("254")]
        OLI_EMPTYPE_DRUGSUP = 254,

        /// <summary>Drug/Toilet Preparation Manufacturing,Skilled Worker</summary>
        [XmlEnum("255")]
        OLI_EMPTYPE_DRUGSKILLED = 255,

        /// <summary>Dry Cleaning And Dyeing, Foremen</summary>
        [XmlEnum("256")]
        OLI_EMPTYPE_DRYCLEANFOR = 256,

        /// <summary>Dry Cleaning And Dyeing, Others</summary>
        [XmlEnum("257")]
        OLI_EMPTYPE_DRYCLEANOTH = 257,

        /// <summary>Dry Cleaning/Dyeing, Clerk(Counter Duty/Manager</summary>
        [XmlEnum("258")]
        OLI_EMPTYPE_DRYCLEANCTR = 258,

        /// <summary>Dye/Dye Intermediate Manufacturing, Superintendent/Chemists</summary>
        [XmlEnum("259")]
        OLI_EMPTYPE_DYEMFGSUP = 259,

        /// <summary>Dye/Dye Intermediate Manufacturing, Chemist Process</summary>
        [XmlEnum("260")]
        OLI_EMPTYPE_DYEMFGCHEMIST = 260,

        /// <summary>Ear Nose And Throat MD'S</summary>
        [XmlEnum("261")]
        OLI_EMPTYPE_ENFMD = 261,

        /// <summary>Economists</summary>
        [XmlEnum("262")]
        OLI_EMPTYPE_ECONOMIST = 262,

        /// <summary>Editors, Magazine And Newspaper, Office Duties Only</summary>
        /// <remarks>May also be classified as --> 513 OLI_EMPTYPE_NEWSOFFICE</remarks>
        [XmlEnum("263")]
        OLI_EMPTYPE_EDITOR = 263,

        /// <summary>Efficiency Expert/Industrial Engineer, Factory/Plant</summary>
        [XmlEnum("264")]
        OLI_EMPTYPE_EFFECEXPPLANT = 264,

        /// <summary>Efficiency Expert/Industrial Engineer, Office Duties</summary>
        [XmlEnum("265")]
        OLI_EMPTYPE_OFFICE = 265,

        /// <summary>Egg Handlers Or Testers</summary>
        [XmlEnum("266")]
        OLI_EMPTYPE_EGGTESTER = 266,

        /// <summary>Electrical Industry-Power House/Sub-Stations, All Other</summary>
        [XmlEnum("267")]
        OLI_EMPTYPE_ELECTRICALPOWOTH = 267,

        /// <summary>Electrical Industry--Apparatus Manufacture, Foremen</summary>
        [XmlEnum("268")]
        OLI_EMPTYPE_ELECTRICALMFGFOR = 268,

        /// <summary>Electrical Industry--Battery Manufacture, All Others</summary>
        [XmlEnum("269")]
        OLI_EMPTYPE_ELECTRICALMFGBATOTH = 269,

        /// <summary>Electrical Industry--Battery Manufacture,Foremen</summary>
        [XmlEnum("270")]
        OLI_EMPTYPE_ELECTRICALMFGBATFOR = 270,

        /// <summary>Electrical Industry--Battery Manufacture/Superintendent</summary>
        [XmlEnum("271")]
        OLI_EMPTYPE_ELECTRICALMFGBATSUP = 271,

        /// <summary>Electrical Industry--Electrical Apparatus Manufacturer</summary>
        [XmlEnum("272")]
        OLI_EMPTYPE_ELECTRICALAPPMFG = 272,

        /// <summary>Electrical Industry--Electrical Apparatus, All Other</summary>
        [XmlEnum("273")]
        OLI_EMPTYPE_ELECTRICALAPPMFGOTH = 273,

        /// <summary>Electrical Industry--General Engineer: Consult/Design</summary>
        [XmlEnum("274")]
        OLI_EMPTYPE_ELECTRICALENGINEERCON = 274,

        /// <summary>Electrical Industry--General, Installer/Repairmen</summary>
        [XmlEnum("275")]
        OLI_EMPTYPE_ELECTRICALINSTALLER = 275,

        /// <summary>Electrical Industry--General, Meter Readers</summary>
        [XmlEnum("276")]
        OLI_EMPTYPE_ELECTRICALMETERREADER = 276,

        /// <summary>Electrical Industry--General,Electrical Contractor</summary>
        [XmlEnum("277")]
        OLI_EMPTYPE_ELECTRICALCONTRACTOR = 277,

        /// <summary>Electrical Industry--General,Electrical Engineers</summary>
        [XmlEnum("278")]
        OLI_EMPTYPE_ELECTRICALENGINEER = 278,

        /// <summary>Electrical Industry--General/Electrical Contractor</summary>
        [XmlEnum("279")]
        OLI_EMPTYPE_ELECTRICALCONTRACTOR2 = 279,

        /// <summary>Electrical Industry--Overhead Line/Tunnel Foremen</summary>
        [XmlEnum("280")]
        OLI_EMPTYPE_ELECTRICALTUNNELFOR = 280,

        /// <summary>Electrical Industry--Overhead/Tunnel Linemen/Splicer</summary>
        [XmlEnum("281")]
        OLI_EMPTYPE_ELECTRICALTUNNELSPLICER = 281,

        /// <summary>Electrical Industry--Overhead/Tunnel Pole Setters</summary>
        [XmlEnum("282")]
        OLI_EMPTYPE_ELECTRICALTUNNELPOLESETTER = 282,

        /// <summary>Electrical Industry--Overhead/Tunnel Tower Erectors</summary>
        [XmlEnum("283")]
        OLI_EMPTYPE_ELECTRICALTOWERERECTOR = 283,

        /// <summary>Electrical Industry--Overhead/Tunnel Transformer</summary>
        [XmlEnum("284")]
        OLI_EMPTYPE_ELECTRICALTUNNELTRANSFORMAR = 284,

        /// <summary>Electrical Industry--Power Houses/Sub-Station Superintendent</summary>
        [XmlEnum("285")]
        OLI_EMPTYPE_ELECTRICALPOWERSUP = 285,

        /// <summary>Electrologists</summary>
        [XmlEnum("286")]
        OLI_EMPTYPE_ELECTROLOGIST = 286,

        /// <summary>Electroplaters</summary>
        [XmlEnum("287")]
        OLI_EMPTYPE_ELECTRPLATER = 287,

        /// <summary>Electrotypers</summary>
        [XmlEnum("288")]
        OLI_EMPTYPE_ELECTRTYPER = 288,

        /// <summary>Elevator Operator, Passenger Operator/Starters</summary>
        [XmlEnum("289")]
        OLI_EMPTYPE_ELEVATOROPER = 289,

        /// <summary>Elevator Operators, Freight Operators</summary>
        [XmlEnum("290")]
        OLI_EMPTYPE_ELEVATORFREIGHT = 290,

        /// <summary>Embalmer/Assistant</summary>
        [XmlEnum("291")]
        OLI_EMPTYPE_EMBALMER = 291,

        /// <summary>Emergency Room Physicians</summary>
        [XmlEnum("292")]
        OLI_EMPTYPE_EMERRMMD = 292,

        /// <summary>Enamel Factory/Tinware/Sanitary Ware, All Others</summary>
        [XmlEnum("293")]
        OLI_EMPTYPE_ENAMELMFGOTH = 293,

        /// <summary>Enamel Factory/Tinware/Sanitary Ware, Foremen</summary>
        [XmlEnum("294")]
        OLI_EMPTYPE_ENAMELMFGFOR = 294,

        /// <summary>Enamel Factory/Tinware/Sanitary Ware, Superintendent</summary>
        [XmlEnum("295")]
        OLI_EMPTYPE_ENAMELMFGSUP = 295,

        /// <summary>Endocrinologist</summary>
        [XmlEnum("296")]
        OLI_EMPTYPE_ENDOCRINOLOGIST = 296,

        /// <summary>Endodontists</summary>
        [XmlEnum("297")]
        OLI_EMPTYPE_ENDODONTIST = 297,

        /// <summary>Engineer (Registered Professional) Non-Hazardous</summary>
        [XmlEnum("298")]
        OLI_EMPTYPE_ENGINEERRPENONHAZ = 298,

        /// <summary>Engineer (Registered Professional) Office/Consultant</summary>
        [XmlEnum("299")]
        OLI_EMPTYPE_ENGINEERRPEOFFICE = 299,

        /// <summary>Engineer, Stationary--Non-Hazardous Industries</summary>
        [XmlEnum("300")]
        OLI_EMPTYPE_ENGINEERSTATNONHAZARD = 300,

        /// <summary>Engineers,Office Duties And Consulting Duties Only</summary>
        [XmlEnum("301")]
        OLI_EMPTYPE_ENGINEEROFFICE = 301,

        /// <summary>Engravers, Celluloid Glass/Metal/Plate Photoengraver</summary>
        [XmlEnum("302")]
        OLI_EMPTYPE_ENGRAVERMISC = 302,

        /// <summary>Engravers, Monument</summary>
        [XmlEnum("303")]
        OLI_EMPTYPE_ENGRAVERMONUMENT = 303,

        /// <summary>Enterologists</summary>
        [XmlEnum("304")]
        OLI_EMPTYPE_ENTEROLOGIST = 304,

        /// <summary>Entomologists, Ethnologists</summary>
        [XmlEnum("305")]
        OLI_EMPTYPE_ENTOMOLOGISTS = 305,

        /// <summary>Epidemiologists</summary>
        [XmlEnum("306")]
        OLI_EMPTYPE_EPIDEMIOLOGIST = 306,

        /// <summary>Executive/Corporate, Office Primarily, 35+ Employee</summary>
        [XmlEnum("307")]
        OLI_EMPTYPE_EXECBIGCO = 307,

        /// <summary>Executive/Corporate, Other Executive, Primarily Office</summary>
        [XmlEnum("308")]
        OLI_EMPTYPE_EXECOTH = 308,

        /// <summary>Expediters, Office And Store Systems Only</summary>
        [XmlEnum("309")]
        OLI_EMPTYPE_EXPEDITERSYS = 309,

        /// <summary>Expediters, Others</summary>
        [XmlEnum("310")]
        OLI_EMPTYPE_EXPEDITEROTH = 310,

        /// <summary>Explosive Manuf, Office Worker Over01/2 Mile From</summary>
        [XmlEnum("311")]
        OLI_EMPTYPE_EXPLOSIVEMFGOFFICE = 311,

        /// <summary>Explosives Manufacture, Superintendent/Chemist</summary>
        [XmlEnum("312")]
        OLI_EMPTYPE_EXPLOSIVEMFGSUP = 312,

        /// <summary>Exterminators</summary>
        [XmlEnum("313")]
        OLI_EMPTYPE_EXTERMINATOR = 313,

        /// <summary>Factory Worker Non-Hazardous Industry, Skilled Worker</summary>
        [XmlEnum("314")]
        OLI_EMPTYPE_FACWKRSKILLERNONHAZ = 314,

        /// <summary>Factory Worker Non-Hazardous, Skilled Worker, Heavy</summary>
        [XmlEnum("315")]
        OLI_EMPTYPE_FACWKRSKILLEDHEAVY = 315,

        /// <summary>Factory Worker Non-Hazardous, Unskilled Worker, Light</summary>
        [XmlEnum("316")]
        OLI_EMPTYPE_FACWKRUNSKILLEDLIGHT = 316,

        /// <summary>Family Practitioners</summary>
        [XmlEnum("317")]
        OLI_EMPTYPE_FAMILYPRACTITIONER = 317,

        /// <summary>Farmer (General Farm/Dairy/Fruit/Nursery/Garden)</summary>
        [XmlEnum("318")]
        OLI_EMPTYPE_FARMERMISC = 318,

        /// <summary>Farmer(General/Dairy/Fruit) Year Round, All Others</summary>
        [XmlEnum("319")]
        OLI_EMPTYPE_FARMEROTH = 319,

        /// <summary>Farmer(General/Dairy/Fruit)Year Round,Proprietor</summary>
        [XmlEnum("320")]
        OLI_EMPTYPE_FARMEROWNER = 320,

        /// <summary>Felt Workers</summary>
        [XmlEnum("321")]
        OLI_EMPTYPE_FELTWORKER = 321,

        /// <summary>Film Manufacture, Foremen(Supervising Duties Only)</summary>
        [XmlEnum("322")]
        OLI_EMPTYPE_FILMMFGSUP = 322,

        /// <summary>Film Manufacture, Skilled Workers</summary>
        [XmlEnum("323")]
        OLI_EMPTYPE_FILMMFGSKILLED = 323,

        /// <summary>Fire Department Chief/Marshal/Superintendent</summary>
        [XmlEnum("324")]
        OLI_EMPTYPE_FIREDEPTSUP = 324,

        /// <summary>Firearm, Inspector/Repairer(Not Testing) Salesmen</summary>
        [XmlEnum("325")]
        OLI_EMPTYPE_FIREARMSALESMAN = 325,

        /// <summary>Fishing Industry Hatcheries, Others</summary>
        [XmlEnum("326")]
        OLI_EMPTYPE_FISHHATCHOTH = 326,

        /// <summary>Fishing Industry Hatcheries, Superintendents</summary>
        [XmlEnum("327")]
        OLI_EMPTYPE_FISHHATCHSUP = 327,

        /// <summary>Floor Finishers And Sanders</summary>
        [XmlEnum("328")]
        OLI_EMPTYPE_FLOORFININSER = 328,

        /// <summary>Floorwalker (In Store)</summary>
        [XmlEnum("329")]
        OLI_EMPTYPE_FLOORWALKER = 329,

        /// <summary>Florists, Artificial Flower Makers</summary>
        [XmlEnum("330")]
        OLI_EMPTYPE_FLORISTARTMFG = 330,

        /// <summary>Florists, Greenhouse And Light Delivery</summary>
        [XmlEnum("331")]
        OLI_EMPTYPE_FLORISTGRNHSE = 331,

        /// <summary>Florists, Store Duties Only</summary>
        [XmlEnum("332")]
        OLI_EMPTYPE_FLORISTSTORE = 332,

        /// <summary>Freight Handler, Foremen/Superintendent (Supervising)</summary>
        [XmlEnum("333")]
        OLI_EMPTYPE_FREIGHTSUP = 333,

        /// <summary>Freight Handlers, All Others</summary>
        [XmlEnum("334")]
        OLI_EMPTYPE_FREIGHTOTH = 334,

        /// <summary>Fumigators</summary>
        [XmlEnum("335")]
        OLI_EMPTYPE_FUMIGATOR = 335,

        /// <summary>Funeral Industry, Director, Proprietor</summary>
        [XmlEnum("336")]
        OLI_EMPTYPE_FUNERALDIRECTOR = 336,

        /// <summary>Funeral Industry, Embalmers</summary>
        [XmlEnum("337")]
        OLI_EMPTYPE_FUNERALEMBALMER = 337,

        /// <summary>Funeral Industry, Others</summary>
        [XmlEnum("338")]
        OLI_EMPTYPE_FUNERALOTH = 338,

        /// <summary>Fur Industry Manufacture Of Fur Goods, Foremen</summary>
        [XmlEnum("339")]
        OLI_EMPTYPE_FURMFGFOR = 339,

        /// <summary>Fur Industry Manufacture Of Fur Goods, Others</summary>
        [XmlEnum("340")]
        OLI_EMPTYPE_FURMFGOTH = 340,

        /// <summary>Fur Industry Manufacture Of Fur Goods, Skilled Worker</summary>
        [XmlEnum("341")]
        OLI_EMPTYPE_FURMFGSKILLED = 341,

        /// <summary>Fur Industry Preparation Of Skins, Foremen</summary>
        [XmlEnum("342")]
        OLI_EMPTYPE_FURPREPFOR = 342,

        /// <summary>Fur Industry Preparation Of Skins, Others</summary>
        [XmlEnum("343")]
        OLI_EMPTYPE_FURPREPOTH = 343,

        /// <summary>Fur Industry Retail/Wholesale Dealer, Store Sales</summary>
        [XmlEnum("344")]
        OLI_EMPTYPE_FURSALESSTORE = 344,

        /// <summary>Fur Industry Retail/Wholesale Dealer/Repairing/Alter</summary>
        [XmlEnum("345")]
        OLI_EMPTYPE_FURSALESREPAIR = 345,

        /// <summary>Fur Industry Retail/Wholesale Dealer/Sales (Travel)</summary>
        [XmlEnum("346")]
        OLI_EMPTYPE_FURSALESTRAVEL = 346,

        /// <summary>Fur Industry, Fur-Bearing Animal Raisers</summary>
        [XmlEnum("347")]
        OLI_EMPTYPE_FURRAISER = 347,

        /// <summary>Furniture Mover (Including Machinery/Safe Movers)</summary>
        [XmlEnum("348")]
        OLI_EMPTYPE_FURNITUREMOVER = 348,

        /// <summary>Furniture/Woodworking Factories, All Others</summary>
        [XmlEnum("349")]
        OLI_EMPTYPE_FURNITUREFACTOTH = 349,

        /// <summary>Furniture/Woodworking Factories, Office Duties Only</summary>
        [XmlEnum("350")]
        OLI_EMPTYPE_FURNITUREFACTOFFICE = 350,

        /// <summary>Furniture/Woodworking Factories, Upholsterers</summary>
        [XmlEnum("351")]
        OLI_EMPTYPE_FURNITUREFACTUPHOL = 351,

        /// <summary>Furniture/Woodworking Factory, Foremen/Superintendent</summary>
        [XmlEnum("352")]
        OLI_EMPTYPE_FURNITUREFOR = 352,

        /// <summary>Galvanizers And Tinners (Not Roofers)</summary>
        [XmlEnum("353")]
        OLI_EMPTYPE_GALVANIZER = 353,

        /// <summary>Gambling Industry (Legal), Card Dealer/Croupier/Dice</summary>
        [XmlEnum("354")]
        OLI_EMPTYPE_GAMBLINGDEALER = 354,

        /// <summary>Gambling Industry (Where Legalized/Operated In Law)</summary>
        [XmlEnum("355")]
        OLI_EMPTYPE_GAMBLING = 355,

        /// <summary>Garbage Disposal Plant/Incinerator, Chemists (Supervision)</summary>
        [XmlEnum("356")]
        OLI_EMPTYPE_GARBAGECHEMIST = 356,

        /// <summary>Garbage Disposal Plant/Incinerator, Skilled Workers</summary>
        [XmlEnum("357")]
        OLI_EMPTYPE_GARBAGESKILLED = 357,

        /// <summary>Garbage/Ash Collection/Scavenging, Foremen (Supervision)</summary>
        [XmlEnum("358")]
        OLI_EMPTYPE_GARBAGESUP = 358,

        /// <summary>Gardener/Landscaper (Year Round,Regularly Employed)</summary>
        [XmlEnum("359")]
        OLI_EMPTYPE_GARDNER = 359,

        /// <summary>Gas Manufacture Acetylene/Coal Foremen (Supervising)</summary>
        [XmlEnum("360")]
        OLI_EMPTYPE_GASMFGFLAMSUP = 360,

        /// <summary>Gas Manufacture Acetylene/Coal, Chemist (No Lab Duties)</summary>
        [XmlEnum("361")]
        OLI_EMPTYPE_GASMFGFLAMCHEMIST = 361,

        /// <summary>Gas Manufacture Coke Oven/Artificial Gas--Chemists</summary>
        [XmlEnum("362")]
        OLI_EMPTYPE_GASMFGCOKECHEMIST = 362,

        /// <summary>Gas Manufacture Coke Oven/Artificials--Burner/Charge</summary>
        [XmlEnum("363")]
        OLI_EMPTYPE_GASMFGCOKENURNER = 363,

        /// <summary>Gas Manufacture Compressed/Liquified, Foremen/Cellme</summary>
        [XmlEnum("364")]
        OLI_EMPTYPE_GASMFGCOMPFOR = 364,

        /// <summary>Gas Manufacture Compressed/Liquified,Chemist(No Lab)</summary>
        [XmlEnum("365")]
        OLI_EMPTYPE_GASMFGCOMPCHEMIST = 365,

        /// <summary>Gas Manufacture Compressed/Liquified--Rackmen/Trucker</summary>
        [XmlEnum("366")]
        OLI_EMPTYPE_GASMFGCOMPTRUCKER = 366,

        /// <summary>Gastroenterologists</summary>
        [XmlEnum("367")]
        OLI_EMPTYPE_GASTROENTEROLOGIST = 367,

        /// <summary>General Dentistry, Dentists</summary>
        [XmlEnum("368")]
        OLI_EMPTYPE_DENTIST = 368,

        /// <summary>General Practitioners</summary>
        [XmlEnum("369")]
        OLI_EMPTYPE_GENPRACT = 369,

        /// <summary>General Surgeons</summary>
        [XmlEnum("370")]
        OLI_EMPTYPE_GENSURGEON = 370,

        /// <summary>Geologist, Working In Us/Canada Only, Field Work</summary>
        [XmlEnum("371")]
        OLI_EMPTYPE_GEOLOGISTFIELD = 371,

        /// <summary>Geologist, Working In Us/Canada Only, Office/Consult</summary>
        [XmlEnum("372")]
        OLI_EMPTYPE_GEOLOGISTFOR = 372,

        /// <summary>Glass Industry, Foremen</summary>
        [XmlEnum("373")]
        OLI_EMPTYPE_GLASSFOR = 373,

        /// <summary>Glass Industry, Other Skilled Workers</summary>
        [XmlEnum("374")]
        OLI_EMPTYPE_GLASSSKILLED = 374,

        /// <summary>Glass Industry, Superintendents (Supervising Only)</summary>
        [XmlEnum("375")]
        OLI_EMPTYPE_GLASSSUP = 375,

        /// <summary>Glaziers</summary>
        [XmlEnum("376")]
        OLI_EMPTYPE_GLAZIER = 376,

        /// <summary>Goldsmiths, Beaters And Refiners</summary>
        [XmlEnum("377")]
        OLI_EMPTYPE_GOLDSMITH = 377,

        /// <summary>Golf (Year Round Industry Only), Proprietor/Managers</summary>
        [XmlEnum("378")]
        OLI_EMPTYPE_GOLFMGR = 378,

        /// <summary>Golf--(Year Round) Instructor/Professional (Resident)</summary>
        [XmlEnum("379")]
        OLI_EMPTYPE_GOLFPRO = 379,

        /// <summary>Golf--(Year Round), Caddie Master/Starter/Caretaker</summary>
        [XmlEnum("380")]
        OLI_EMPTYPE_GOLFCARETAKER = 380,

        /// <summary>Golf--(Year Round), Proprietor/Managers,Driving Range</summary>
        [XmlEnum("381")]
        OLI_EMPTYPE_GOLFRANGE = 381,

        /// <summary>Government Service-State/Municipal</summary>
        [XmlEnum("382")]
        OLI_EMPTYPE_GOVERNMENT = 382,

        /// <summary>Grain Mill/Elevator, Foremen, Skilled Workers</summary>
        [XmlEnum("383")]
        OLI_EMPTYPE_GRAINSKILLED = 383,

        /// <summary>Grain Mill/Grain Elevator, Superintendent/Inspector</summary>
        [XmlEnum("384")]
        OLI_EMPTYPE_GRAINSUP = 384,

        /// <summary>Grain Mills, Grain Elevators, All Other Employees</summary>
        [XmlEnum("385")]
        OLI_EMPTYPE_GRAINOTH = 385,

        /// <summary>Graphic Designers</summary>
        [XmlEnum("386")]
        OLI_EMPTYPE_GRAPHICDESIGN = 386,

        /// <summary>Grave Diggers</summary>
        [XmlEnum("387")]
        OLI_EMPTYPE_GRAVEDIGGER = 387,

        /// <summary>Grinder/Buffer/Polisher Metal, Superintendent/Foremen</summary>
        [XmlEnum("388")]
        OLI_EMPTYPE_METALGRINDERSUP = 388,

        /// <summary>Grinders, Buffers, And Polishers Metal, All Others</summary>
        [XmlEnum("389")]
        OLI_EMPTYPE_GRINDEROTH = 389,

        /// <summary>Guides, Other Sightseeing--Employed All Year</summary>
        [XmlEnum("390")]
        OLI_EMPTYPE_GUIDE = 390,

        /// <summary>Gunsmiths</summary>
        [XmlEnum("391")]
        OLI_EMPTYPE_GUNSMITH = 391,

        /// <summary>Gynecologists</summary>
        [XmlEnum("392")]
        OLI_EMPTYPE_GYNECOLOGIST = 392,

        /// <summary>Hair Good Manufacture, Bleacher/Curler/Dyer/Spinner</summary>
        [XmlEnum("393")]
        OLI_EMPTYPE_HAIRMFGCHEM = 393,

        /// <summary>Hair Goods Manufacture, All Others</summary>
        [XmlEnum("394")]
        OLI_EMPTYPE_HAIRMFGOTH = 394,

        /// <summary>Hair Goods Manufacture, Foremen (Supervising Only)</summary>
        [XmlEnum("395")]
        OLI_EMPTYPE_HAIRMFGSUP = 395,

        /// <summary>Hand Surgeons</summary>
        [XmlEnum("396")]
        OLI_EMPTYPE_HANDSURGEON = 396,

        /// <summary>Harbor Masters</summary>
        [XmlEnum("397")]
        OLI_EMPTYPE_HARBORMASTER = 397,

        /// <summary>Hat Manufacturing, All Others</summary>
        [XmlEnum("398")]
        OLI_EMPTYPE_HATMFGOTH = 398,

        /// <summary>Hat Manufacturing, Millinery Dealers</summary>
        [XmlEnum("399")]
        OLI_EMPTYPE_HATMFRDEALER = 399,

        /// <summary>Hat Manufacturing, Superintending Duties Only</summary>
        [XmlEnum("400")]
        OLI_EMPTYPE_HETMFGSUP = 400,

        /// <summary>Health Officials, Field Duties(No Hazardous Activity</summary>
        [XmlEnum("401")]
        OLI_EMPTYPE_HEALTHOFFHAZ = 401,

        /// <summary>Heating Apparatus (Coal/Oil/Gas/Electric), Dealer</summary>
        [XmlEnum("402")]
        OLI_EMPTYPE_HEATINGDEALER = 402,

        /// <summary>Heating Apparatus (Coal/Oil/Gas/Electric), Installer</summary>
        [XmlEnum("403")]
        OLI_EMPTYPE_HEATINGINSTALLER = 403,

        /// <summary>Hematologists</summary>
        [XmlEnum("404")]
        OLI_EMPTYPE_HEMATOLOGIST = 404,

        /// <summary>Hospital/Asylum/Sanitarium, EMT/Ambulance Driver/Na</summary>
        /// <remarks>One who is employed by Hospital/Asylum/Sanitarium as an EMT/Ambulance Driver</remarks>
        [XmlEnum("405")]
        OLI_EMPTYPE_HOSPITALAMBULANCEDRV = 405,

        /// <summary>Hospital/Asylum/Sanitarium, Manager, Superintendent</summary>
        [XmlEnum("406")]
        OLI_EMPTYPE_HOSPITALSUP = 406,

        /// <summary>Hospital/Asylum/Sanitarium,All Non-Professional/Unskilled</summary>
        [XmlEnum("407")]
        OLI_EMPTYPE_HOSPITALNONPRO = 407,

        /// <summary>Hospitals, Asylums, And Sanitariums, Administrators</summary>
        [XmlEnum("408")]
        OLI_EMPTYPE_HOSPITALADMIN = 408,

        /// <summary>Hotel/Motel/Inn, Proprietor, Manager, Cashier, Clerk</summary>
        [XmlEnum("409")]
        OLI_EMPTYPE_HOTELMGR = 409,

        /// <summary>Hotels, Motels, Inns, All Others</summary>
        [XmlEnum("410")]
        OLI_EMPTYPE_HOTELOTH = 410,

        /// <summary>Household Appliances, Dealers And Salesmen</summary>
        [XmlEnum("411")]
        OLI_EMPTYPE_HOUSEHOLDDEALER = 411,

        /// <summary>Household Appliances, Installers And Repairmen</summary>
        [XmlEnum("412")]
        OLI_EMPTYPE_HOUSEHOLDDREPAIR = 412,

        /// <summary>Humane Society Agents</summary>
        [XmlEnum("413")]
        OLI_EMPTYPE_HUMANESOCIETYAGENT = 413,

        /// <summary>Hydraulic Press Operators</summary>
        [XmlEnum("414")]
        OLI_EMPTYPE_HYDRAULICPRESSOPR = 414,

        /// <summary>Hypnotherapists</summary>
        [XmlEnum("415")]
        OLI_EMPTYPE_HYPNOTHERAPIST = 415,

        /// <summary>Ice Industry (Year-Round), All Other Employees</summary>
        [XmlEnum("416")]
        OLI_EMPTYPE_ICEOTH = 416,

        /// <summary>Ice Industry (Year-Round), Foremen/Stationary Engineer</summary>
        [XmlEnum("417")]
        OLI_EMPTYPE_ICEFOR = 417,

        /// <summary>Ice Industry(Year-Round)Manager/Proprietors/Superintendent</summary>
        [XmlEnum("418")]
        OLI_EMPTYPE_ICEMGR = 418,

        /// <summary>Import/Export</summary>
        [XmlEnum("419")]
        OLI_EMPTYPE_IMPORT = 419,

        /// <summary>Industrial Rehab Executive</summary>
        [XmlEnum("420")]
        OLI_EMPTYPE_INDUSTREHABEXEC = 420,

        /// <summary>Infectious Disease Specialists</summary>
        [XmlEnum("421")]
        OLI_EMPTYPE_INFECTDISEASESPEC = 421,

        /// <summary>Insecticide Manuf(Disinfectant/Fumigants), All Other</summary>
        [XmlEnum("422")]
        OLI_EMPTYPE_INSECTOTH = 422,

        /// <summary>Insecticide Manufacture (Disinfectant/Fumigants)</summary>
        [XmlEnum("423")]
        OLI_EMPTYPE_INSECTMFG = 423,

        /// <summary>Insecticide Mfg (Disinfectant/Fumigants) Lab Chemist</summary>
        [XmlEnum("424")]
        OLI_EMPTYPE_9NSECTCHEMIST = 424,

        /// <summary>Insurance Industry--</summary>
        [XmlEnum("425")]
        OLI_EMPTYPE_INSURANCE = 425,

        /// <summary>Insurance Industry-Adjuster, Agent, Broker, Solicitor</summary>
        [XmlEnum("426")]
        OLI_EMPTYPE_INSURANCEAGENT = 426,

        /// <summary>Internists</summary>
        [XmlEnum("427")]
        OLI_EMPTYPE_INTERNIST = 427,

        /// <summary>Interpreters-Full Time Only</summary>
        [XmlEnum("428")]
        OLI_EMPTYPE_INTREPRETER = 428,

        /// <summary>Investment Banker</summary>
        [XmlEnum("429")]
        OLI_EMPTYPE_INVESTBANKER = 429,

        /// <summary>Irrigation Worker, Superintendent/Water Masters</summary>
        [XmlEnum("430")]
        OLI_EMPTYPE_IMMIGRATION = 430,

        /// <summary>Janitors--Regular/Full Time Janitor/Porters,No Outside</summary>
        [XmlEnum("431")]
        OLI_EMPTYPE_JANITOR = 431,

        /// <summary>Janitors--Regular/Full Time, Building Superintendent</summary>
        [XmlEnum("432")]
        OLI_EMPTYPE_JANITORSUP = 432,

        /// <summary>Jewelry Industry--Not At Residence, Others</summary>
        [XmlEnum("433")]
        OLI_EMPTYPE_JEWELRYOTH = 433,

        /// <summary>Jewelry Industry--Not At Residence, Proprietor, Mgr</summary>
        [XmlEnum("434")]
        OLI_EMPTYPE_JEWELRYMGR = 434,

        /// <summary>Jewelry Industry--Not Residence, Maker/Repairer Hand</summary>
        [XmlEnum("435")]
        OLI_EMPTYPE_JEWELRYMAKER = 435,

        /// <summary>Judge/Courthouse Official, Not In Charge Of Prisoner</summary>
        [XmlEnum("436")]
        OLI_EMPTYPE_JUDGE = 436,

        /// <summary>Junk Dealer, Proprietor/Superintending Duties Only</summary>
        [XmlEnum("437")]
        OLI_EMPTYPE_JUNKDEALER = 437,

        /// <summary>Justices Of The Peace</summary>
        [XmlEnum("438")]
        OLI_EMPTYPE_JUSTICEOFPEACE = 438,

        /// <summary>Kennels, Groomers</summary>
        [XmlEnum("439")]
        OLI_EMPTYPE_KENNELGROOMER = 439,

        /// <summary>Kennels, Managers Or Operators (Supervising Only)</summary>
        [XmlEnum("440")]
        OLI_EMPTYPE_KENNELMGR = 440,

        /// <summary>Kennels, Veterinarians, Household Pets</summary>
        [XmlEnum("441")]
        OLI_EMPTYPE_KENNELVETPET = 441,

        /// <summary>Kennels, Veterinarians, Large Animals</summary>
        [XmlEnum("442")]
        OLI_EMPTYPE_KENNELVETLARGE = 442,

        /// <summary>Keno Writers</summary>
        [XmlEnum("443")]
        OLI_EMPTYPE_KENOWRITER = 443,

        /// <summary>Lab Tech, Other Rn, Hospital, Asylum, & Sanitarium</summary>
        [XmlEnum("444")]
        OLI_EMPTYPE_LABTECHOTH = 444,

        /// <summary>Labor Union, Union Official, Office Duties Only</summary>
        [XmlEnum("445")]
        OLI_EMPTYPE_LABORUNIONOFF = 445,

        /// <summary>Laborers</summary>
        [XmlEnum("446")]
        OLI_EMPTYPE_LABORER = 446,

        /// <summary>Landscape Architects, With Architecture Degree</summary>
        [XmlEnum("447")]
        OLI_EMPTYPE_LANDSCAPEARCHITECT = 447,

        /// <summary>Laundries, Supervisory Duties Only</summary>
        [XmlEnum("448")]
        OLI_EMPTYPE_LAUNDRYSUP = 448,

        /// <summary>Lawyers</summary>
        /// <remarks>One whose profession is to conduct lawsuits for clients or to advise as to legal rights and obligations in other matters (Passed the bar)</remarks>
        [XmlEnum("449")]
        OLI_EMPTYPE_LAWTER = 449,

        /// <summary>Lens Grinders, Polishers, Or Cutters</summary>
        [XmlEnum("450")]
        OLI_EMPTYPE_LENGRINDER = 450,

        /// <summary>Librarian</summary>
        [XmlEnum("451")]
        OLI_EMPTYPE_LIBRARIAN = 451,

        /// <summary>Lighthouse Keepers, Land Duties Only</summary>
        [XmlEnum("452")]
        OLI_EMPTYPE_LIGHTHOUSEKEEPER = 452,

        /// <summary>Linoleum Installers</summary>
        [XmlEnum("453")]
        OLI_EMPTYPE_LINOLEUMINSTALLER = 453,

        /// <summary>Linoleum/Oilcloth Manufacture, Stone Dresser/Laborer</summary>
        [XmlEnum("454")]
        OLI_EMPTYPE_LINOLEUMLABOR = 454,

        /// <summary>Linoleum/Oilcloth Manufacture, Supervisory Only</summary>
        [XmlEnum("455")]
        OLI_EMPTYPE_LINOLEUMSUP = 455,

        /// <summary>Linotypers</summary>
        [XmlEnum("456")]
        OLI_EMPTYPE_LINOTYPER = 456,

        /// <summary>Liquor Industry Brewery/Distillery/Wineries, Supervision</summary>
        [XmlEnum("457")]
        OLI_EMPTYPE_LIQUORMFGSUP = 457,

        /// <summary>Liquor Industry Brewery/Distillery/Winery, All Other</summary>
        [XmlEnum("458")]
        OLI_EMPTYPE_LIQUORMFGOTH = 458,

        /// <summary>Liquor Industry Brewery/Distillery/Winery, Foremen</summary>
        [XmlEnum("459")]
        OLI_EMPTYPE_LIQUORDISTSTORE = 459,

        /// <summary>Liquor Industry Distribution/Sale Warehouse/Store</summary>
        [XmlEnum("460")]
        OLI_EMPTYPE_LIQUORDISTDEL = 460,

        /// <summary>Liquor Industry Distribution/Sales, Others Light Del</summary>
        [XmlEnum("461")]
        OLI_EMPTYPE_LIQUORDISTOTH = 461,

        /// <summary>Liquor Industry Distribution/Sales, Solicitor/Collector</summary>
        [XmlEnum("462")]
        OLI_EMPTYPE_LIQUORSALES = 462,

        /// <summary>Liquor Industry Sales/Package Store, No Liquor Consumed</summary>
        [XmlEnum("463")]
        OLI_EMPTYPE_LIQUORPACKSTORE = 463,

        /// <summary>Literary Agents</summary>
        [XmlEnum("464")]
        OLI_EMPTYPE_LITERARYAGENT = 464,

        /// <summary>Lithographers, All Others</summary>
        [XmlEnum("465")]
        OLI_EMPTYPE_LITHOGRAPHEROTH = 465,

        /// <summary>Lithographers, Office Duties Only And Artists</summary>
        [XmlEnum("466")]
        OLI_EMPTYPE_LITHOGRAPHEROFFICE = 466,

        /// <summary>Lobbyists</summary>
        [XmlEnum("467")]
        OLI_EMPTYPE_LOBBYIST = 467,

        /// <summary>Locksmiths</summary>
        [XmlEnum("468")]
        OLI_EMPTYPE_LOCKSMITH = 468,

        /// <summary>Lumber Industry Logging/Proprietor/Manager/Clerk</summary>
        [XmlEnum("469")]
        OLI_EMPTYPE_LUMBERCLERK = 469,

        /// <summary>Lumber Industry Wood Processing Factories, Foremen</summary>
        [XmlEnum("470")]
        OLI_EMPTYPE_LUMBERFOR = 470,

        /// <summary>Lumber Industry Yard, Foremen/Grader/Inspector/Sales</summary>
        [XmlEnum("471")]
        OLI_EMPTYPE_LUMBERSALES = 471,

        /// <summary>Machine Shop Workers, Millwrights</summary>
        [XmlEnum("472")]
        OLI_EMPTYPE_MACHINESHOP = 472,

        /// <summary>Manicurists (In Shops)</summary>
        [XmlEnum("473")]
        OLI_EMPTYPE_MANICURIST = 473,

        /// <summary>Marine Industry, Harbor Masters</summary>
        [XmlEnum("474")]
        OLI_EMPTYPE_HARBORMAST2 = 474,

        /// <summary>Masons And Bricklayers (No Unusual Hazard)</summary>
        [XmlEnum("475")]
        OLI_EMPTYPE_MASON = 475,

        /// <summary>Match Factories, Foremen</summary>
        [XmlEnum("476")]
        OLI_EMPTYPE_MATCHMFGFOR = 476,

        /// <summary>Match Factories, Supervisory Duties Only</summary>
        [XmlEnum("477")]
        OLI_EMPTYPE_MATCHMFGSUP = 477,

        /// <summary>Mattress And Pillow Factories, All Others</summary>
        [XmlEnum("478")]
        OLI_EMPTYPE_MATTRESSOTH = 478,

        /// <summary>Mattress And Pillow Factories, Foremen</summary>
        [XmlEnum("479")]
        OLI_EMPTYPE_MATTERSSFOR = 479,

        /// <summary>Mattress/Pillow Factories, Supervisory Duties Only</summary>
        [XmlEnum("480")]
        OLI_EMPTYPE_MATRESSSUP = 480,

        /// <summary>Messenger--Armed Or Using Motorcycle</summary>
        [XmlEnum("481")]
        OLI_EMPTYPE_MESSENGER = 481,

        /// <summary>Messengers--Banks, Unarmed</summary>
        [XmlEnum("482")]
        OLI_EMPTYPE_MESSENGERBANK = 482,

        /// <summary>Metal Industry/Trades--Not Otherwise Classified, Skilled</summary>
        [XmlEnum("483")]
        OLI_EMPTYPE_METALTRADEOTH = 483,

        /// <summary>Metal Industry/Trade--Not Other Classified, Foremen</summary>
        [XmlEnum("484")]
        OLI_EMPTYPE_METALTRADEFOR = 484,

        /// <summary>Metal Industry/Trade-Not Otherwise Classified, Office</summary>
        [XmlEnum("485")]
        OLI_EMPTYPE_METALTRADEOFFICE = 485,

        /// <summary>Metal Industry/Trades--Not Otherwise Classified, Engineer</summary>
        [XmlEnum("486")]
        OLI_EMPTYPE_METALTRADEENGR = 486,

        /// <summary>Metallurgists--Office Duties Only</summary>
        [XmlEnum("487")]
        OLI_EMPTYPE_METALURGIST = 487,

        /// <summary>Meteorologists</summary>
        [XmlEnum("488")]
        OLI_EMPTYPE_METEOROLOGIST = 488,

        /// <summary>Meter Readers</summary>
        [XmlEnum("489")]
        OLI_EMPTYPE_METERREADER = 489,

        /// <summary>Mica Mills, Skilled Workers</summary>
        [XmlEnum("490")]
        OLI_EMPTYPE_MICAMILLSKILLED = 490,

        /// <summary>Mica Mills, Supervisory Duties</summary>
        [XmlEnum("491")]
        OLI_EMPTYPE_MICAMILLSUP = 491,

        /// <summary>Midwives--Individ Consideration, Consult Home Office</summary>
        [XmlEnum("492")]
        OLI_EMPTYPE_MIDWIFE = 492,

        /// <summary>Millwrights</summary>
        [XmlEnum("493")]
        OLI_EMPTYPE_MILLWRIGHT = 493,

        /// <summary>Minister</summary>
        [XmlEnum("494")]
        OLI_EMPTYPE_MINISTER = 494,

        /// <summary>Mining/Quarry/Dressing/Concentrating Surface Operator</summary>
        [XmlEnum("495")]
        OLI_EMPTYPE_MININGMISC = 495,

        /// <summary>Mining/Quarrying Surface Operator, Office Duty Only</summary>
        [XmlEnum("496")]
        OLI_EMPTYPE_MININGOFFICE = 496,

        /// <summary>Mining/Quarrying/Ore-Surface Operator, Other Skilled</summary>
        [XmlEnum("497")]
        OLI_EMPTYPE_MININGSUP = 497,

        /// <summary>Mining/Quarrying/Ore/Concentrating Surface Operators</summary>
        [XmlEnum("498")]
        OLI_EMPTYPE_MININGOTH = 498,

        /// <summary>Monument Industry, Carvers, Engravers, Setters</summary>
        [XmlEnum("499")]
        OLI_EMPTYPE_MONUMENTSKILLED = 499,

        /// <summary>Motion Picture/Theater Industry, Director/Producers</summary>
        [XmlEnum("500")]
        OLI_EMPTYPE_MOVIEDIRECTOR = 500,

        /// <summary>Motion Picture/Theater, Management Personnel, Office</summary>
        [XmlEnum("501")]
        OLI_EMPTYPE_MOVIEOFFICE = 501,

        /// <summary>Motion Picture/Theater, Projectionist In Theater,Bo</summary>
        [XmlEnum("502")]
        OLI_EMPTYPE_MOVIETHEATER = 502,

        /// <summary>Motion Picture/Theater, Theater Manager/Proprietors</summary>
        [XmlEnum("503")]
        OLI_EMPTYPE_MOVIEMGR = 503,

        /// <summary>Movers</summary>
        [XmlEnum("504")]
        OLI_EMPTYPE_MOVER = 504,

        /// <summary>Musician (Sole Occupation),Concert/Theater/ Symphony</summary>
        [XmlEnum("505")]
        OLI_EMPTYPE_MUSICIAN = 505,

        /// <summary>Neonatologists</summary>
        [XmlEnum("506")]
        OLI_EMPTYPE_NEONASTOLOGIST = 506,

        /// <summary>Nephrologists</summary>
        [XmlEnum("507")]
        OLI_EMPTYPE_NEPHROLOGIST = 507,

        /// <summary>Neuro Surgeons</summary>
        [XmlEnum("508")]
        OLI_EMPTYPE_NEUROSURGEON = 508,

        /// <summary>Neurologists</summary>
        [XmlEnum("509")]
        OLI_EMPTYPE_NEUROLOGIST = 509,

        /// <summary>News And Magazine Dealers, Light Delivery</summary>
        [XmlEnum("510")]
        OLI_EMPTYPE_NEWSDEALERDEL = 510,

        /// <summary>News/Magazine Dealer, Newsstand Inside Duties</summary>
        [XmlEnum("511")]
        OLI_EMPTYPE_NEWSDEALER = 511,

        /// <summary>Newspapers, Delivery</summary>
        [XmlEnum("512")]
        OLI_EMPTYPE_NEWSDELIVERY = 512,

        /// <summary>Newspapers, Editors, Office Clerks</summary>
        /// <remarks>May also be classified as --> 263 OLI_EMPTYPE_EDITOR</remarks>
        [XmlEnum("513")]
        OLI_EMPTYPE_NEWSOFFICE = 513,

        /// <summary>Newspapers, Helpers</summary>
        [XmlEnum("514")]
        OLI_EMPTYPE_NEWSHELPER = 514,

        /// <summary>Newspapers, Reporters, Photographers (No Flying)</summary>
        /// <remarks>May also be classified as --> 649 OLI_EMPTYPE_REPORTERNEWS</remarks>
        [XmlEnum("515")]
        OLI_EMPTYPE_NEWSREPORTER = 515,

        /// <summary>Nuclear Medicine</summary>
        [XmlEnum("516")]
        OLI_EMPTYPE_NECLESEARMEDICINE = 516,

        /// <summary>Ob-Gyn</summary>
        [XmlEnum("517")]
        OLI_EMPTYPE_OBGYN = 517,

        /// <summary>Obstetricians</summary>
        [XmlEnum("518")]
        OLI_EMPTYPE_OBSTETRICIAN = 518,

        /// <summary>Occupational Therapists</summary>
        [XmlEnum("519")]
        OLI_EMPTYPE_OCCUPATIONALTHERAPIST = 519,

        /// <summary>Office Clerk(Typist,Stenographer,General Office Help</summary>
        [XmlEnum("520")]
        OLI_EMPTYPE_OFFICECLERK = 520,

        /// <summary>Office Machine Operators (Office Duties Only)</summary>
        [XmlEnum("521")]
        OLI_EMPTYPE_OFFICEMACHINEOPERATOR = 521,

        /// <summary>Oil (Vegetable) Mill/Refinery All Processes, Skilled</summary>
        [XmlEnum("522")]
        OLI_EMPTYPE_OILSKILLED = 522,

        /// <summary>Oil (Vegetable) Mill/Refinery Superintendent/Chemist</summary>
        [XmlEnum("523")]
        OLI_EMPTYPE_OILCHEMIST = 523,

        /// <summary>Oil(Vegetable)Mill/Refinery, Unskilled Workers</summary>
        [XmlEnum("524")]
        OLI_EMPTYPE_OILUNSKILLED = 524,

        /// <summary>Oil/Natural Gas Industry Fire Protection Dept/Inspector</summary>
        [XmlEnum("525")]
        OLI_EMPTYPE_OILINSPECTOR = 525,

        /// <summary>Oil/Natural Gas Industry General, Boss/Chemist Process</summary>
        [XmlEnum("526")]
        OLI_EMPTYPE_OILMGR = 526,

        /// <summary>Oil/Natural Gas Industry General, Other Skilled Work</summary>
        [XmlEnum("527")]
        OLI_EMPTYPE_OILOFFICE = 527,

        /// <summary>Oil/Natural Gas Industry General/Chemist In Lab</summary>
        [XmlEnum("528")]
        OLI_EMPTYPE_OILLABTECH = 528,

        /// <summary>Oilers, Non-Hazardous Industries</summary>
        [XmlEnum("529")]
        OLI_EMPTYPE_OILER = 529,

        /// <summary>Oncologists</summary>
        [XmlEnum("530")]
        OLI_EMPTYPE_ONCOLOGIST = 530,

        /// <summary>Ophthalmic Surgeons</summary>
        [XmlEnum("531")]
        OLI_EMPTYPE_OPPTHAALMICSURGEON = 531,

        /// <summary>Ophthalmologists</summary>
        [XmlEnum("532")]
        OLI_EMPTYPE_OPPTHAALMOLOGIST = 532,

        /// <summary>Optician, Oculist, Selling And Fining Duties Only</summary>
        [XmlEnum("533")]
        OLI_EMPTYPE_OPTICIANSALES = 533,

        /// <summary>Opticians, Oculists</summary>
        [XmlEnum("534")]
        OLI_EMPTYPE_OPTICIAN = 534,

        /// <summary>Optometrists (No Selling Duties)</summary>
        [XmlEnum("535")]
        OLI_EMPTYPE_OPTOMETRIST = 535,

        /// <summary>Oral Surgeons</summary>
        [XmlEnum("536")]
        OLI_EMPTYPE_ORALSURGEON = 536,

        /// <summary>Orthodontists</summary>
        [XmlEnum("537")]
        OLI_EMPTYPE_ORTHODONTIST = 537,

        /// <summary>Orthopedic Surgeons</summary>
        [XmlEnum("538")]
        OLI_EMPTYPE_ORTHOPEDICSURGEON = 538,

        /// <summary>Orthopedists</summary>
        [XmlEnum("539")]
        OLI_EMPTYPE_ORTHOPEDIST = 539,

        /// <summary>Orthotists, Prosthetists; Sales, Fitters</summary>
        [XmlEnum("540")]
        OLI_EMPTYPE_ORTHOTIST = 540,

        /// <summary>Osteopaths</summary>
        [XmlEnum("541")]
        OLI_EMPTYPE_OSTEOPATH = 541,

        /// <summary>Otolaryngolic Surgeons</summary>
        [XmlEnum("542")]
        OLI_EMPTYPE_ORTOARYYNGOLIC = 542,

        /// <summary>Otolaryngologists</summary>
        [XmlEnum("543")]
        OLI_EMPTYPE_ORTOARYYNGOLOGIST = 543,

        /// <summary>Paint/Varnish/Lacquer Manufacture, Foremen, Skilled Worker</summary>
        [XmlEnum("544")]
        OLI_EMPTYPE_PAINTSKILLED = 544,

        /// <summary>Paint/Varnish/Lacquer Manufacture, Unskilled Workers</summary>
        [XmlEnum("545")]
        OLI_EMPTYPE_PAINTUNSKILLED = 545,

        /// <summary>Paint/Varnish/Manufacture, Supervisory Duties Only</summary>
        [XmlEnum("546")]
        OLI_EMPTYPE_PAINTSUP = 546,

        /// <summary>Painter/Lacquerer/Varnisher Shop Painter, Manufacturer</summary>
        [XmlEnum("547")]
        OLI_EMPTYPE_PAINTMFG = 547,

        /// <summary>Painter/Lacquerer/Varnisher Sign Painter, Outside</summary>
        [XmlEnum("548")]
        OLI_EMPTYPE_PAINTSIGNOUTSIDE = 548,

        /// <summary>Painter/Lacquerer/Varnisher Sign Painter, Shop Only</summary>
        [XmlEnum("549")]
        OLI_EMPTYPE_PAINTSIGNINSIDE = 549,

        /// <summary>Painter/Lacquerer/Varnisher Sign Painter, Structural</summary>
        [XmlEnum("550")]
        OLI_EMPTYPE_PAINTSIGNSTRUCTURAL = 550,

        /// <summary>Painter/Lacquerer/Varnisher, Bridge & Railroad</summary>
        [XmlEnum("551")]
        OLI_EMPTYPE_PAINTBRIDGE = 551,

        /// <summary>Painter/Lacquerer/Varnisher, Highway-Direct Line/Si</summary>
        [XmlEnum("552")]
        OLI_EMPTYPE_PAINTHWY = 552,

        /// <summary>Painter/Lacquerer/Varnisher, House Painters</summary>
        [XmlEnum("553")]
        OLI_EMPTYPE_PAINTHOUSE = 553,

        /// <summary>Painter/Lacquerer/Varnisher, Ship Painter (Hull/Interest)</summary>
        [XmlEnum("554")]
        OLI_EMPTYPE_PAINTSHIP = 554,

        /// <summary>Paper Hangers</summary>
        [XmlEnum("555")]
        OLI_EMPTYPE_PAPERHANGER = 555,

        /// <summary>Paper/Pulp Industries, Superintendents And Foremen</summary>
        [XmlEnum("556")]
        OLI_EMPTYPE_PAPERPULPSUP = 556,

        /// <summary>Paralegal</summary>
        [XmlEnum("557")]
        OLI_EMPTYPE_PARALEGAL = 557,

        /// <summary>Parks (City/State/National) Administration Employees</summary>
        [XmlEnum("558")]
        OLI_EMPTYPE_PARKADMIN = 558,

        /// <summary>Parks (City/State/National) Maintenance & Operating</summary>
        [XmlEnum("559")]
        OLI_EMPTYPE_PARKMAINT = 559,

        /// <summary>Parks (City/State/National), Superintendent-Supervisor</summary>
        [XmlEnum("560")]
        OLI_EMPTYPE_PARKSUP = 560,

        /// <summary>Pastor</summary>
        [XmlEnum("561")]
        OLI_EMPTYPE_PASTOR = 561,

        /// <summary>Pathologists</summary>
        [XmlEnum("562")]
        OLI_EMPTYPE_PATHOLOGIST = 562,

        /// <summary>Pattern/Model Makers (Metal, Wood, Paper, Wax)</summary>
        [XmlEnum("563")]
        OLI_EMPTYPE_PATTERNMAKER = 563,

        /// <summary>Pawnbrokers</summary>
        [XmlEnum("564")]
        OLI_EMPTYPE_PAWNBROKER = 564,

        /// <summary>Paymasters</summary>
        [XmlEnum("565")]
        OLI_EMPTYPE_PAYMASTER = 565,

        /// <summary>Pediatricians</summary>
        [XmlEnum("566")]
        OLI_EMPTYPE_PEDIATRICIAN = 566,

        /// <summary>Pedodontists</summary>
        [XmlEnum("567")]
        OLI_EMPTYPE_PEDODONTIST = 567,

        /// <summary>Perfusionists</summary>
        [XmlEnum("568")]
        OLI_EMPTYPE_FERFUSIONIST = 568,

        /// <summary>Periodontists</summary>
        [XmlEnum("569")]
        OLI_EMPTYPE_PERIDONTIST = 569,

        /// <summary>Personnel Recruiter</summary>
        [XmlEnum("570")]
        OLI_EMPTYPE_RECRUITER = 570,

        /// <summary>Pharmacist, Registered--Clinical,Hospital,Research</summary>
        [XmlEnum("571")]
        OLI_EMPTYPE_PHARMACISTHOSPITAL = 571,

        /// <summary>Pharmacists, Registered - Drug Store</summary>
        [XmlEnum("572")]
        OLI_EMPTYPE_PHARMACISTDRUGSTORE = 572,

        /// <summary>Photoengravers</summary>
        [XmlEnum("573")]
        OLI_EMPTYPE_PHOTOENGRAVER = 573,

        /// <summary>Photographer/Cameramen, Newspaper/Newsreel/Motion Picture</summary>
        [XmlEnum("574")]
        OLI_EMPTYPE_PHOTOGRAPHER = 574,

        /// <summary>Photographer/Cameramen, X-Ray Technicians</summary>
        [XmlEnum("575")]
        OLI_EMPTYPE_PHOTOGRAPHERXRAY = 575,

        /// <summary>Photographers And Cameramen, Commercial (Studio)</summary>
        [XmlEnum("576")]
        OLI_EMPTYPE_PHOTOGRAPHERSTUDIO = 576,

        /// <summary>Photostat Operators</summary>
        [XmlEnum("577")]
        OLI_EMPTYPE_PHOTOSTAT = 577,

        /// <summary>Physiatrists</summary>
        [XmlEnum("578")]
        OLI_EMPTYPE_PHYSIATRIST = 578,

        /// <summary>Physician - Rehabilitation Medicine</summary>
        [XmlEnum("579")]
        OLI_EMPTYPE_PHYSICIANREHAB = 579,

        /// <summary>Physician's Assistants</summary>
        [XmlEnum("580")]
        OLI_EMPTYPE_PHYSICIANASSIST = 580,

        /// <summary>Physicists</summary>
        [XmlEnum("581")]
        OLI_EMPTYPE_PHYSICIAN = 581,

        /// <summary>Physiotherapists</summary>
        [XmlEnum("582")]
        OLI_EMPTYPE_PHYSIOTHERAPIST = 582,

        /// <summary>Piano Repairers Or Tuners</summary>
        [XmlEnum("583")]
        OLI_EMPTYPE_PIANOTUNER = 583,

        /// <summary>Pile Driver Operators</summary>
        [XmlEnum("584")]
        OLI_EMPTYPE_PIPEDRIVER = 584,

        /// <summary>Pipefitters--Non-Hazardous Industries</summary>
        [XmlEnum("585")]
        OLI_EMPTYPE_PIPEFITTER = 585,

        /// <summary>Plasterers</summary>
        [XmlEnum("586")]
        OLI_EMPTYPE_PLASTERER = 586,

        /// <summary>Plastic Industry Article Manufacture, Skilled Worker</summary>
        [XmlEnum("587")]
        OLI_EMPTYPE_PLASTICSKILLED = 587,

        /// <summary>Plastic Industry Articles Manuf, Unskilled Workers</summary>
        [XmlEnum("588")]
        OLI_EMPTYPE_PLASTICUNSKILLED = 588,

        /// <summary>Plastic Industry Plastic Foremen: Nitrating Dept</summary>
        [XmlEnum("589")]
        OLI_EMPTYPE_PLASTICFOR = 589,

        /// <summary>Plastic Industry Plastic Manufacture Foremen/Supervisory</summary>
        [XmlEnum("590")]
        OLI_EMPTYPE_PLASTICMFGFOR = 590,

        /// <summary>Plastic Industry Plastic Manufacture, Baker/ Coolerm</summary>
        [XmlEnum("591")]
        OLI_EMPTYPE_PLASTICBAKER = 591,

        /// <summary>Plastic Surgeons</summary>
        [XmlEnum("592")]
        OLI_EMPTYPE_PLASTICSURGEON = 592,

        /// <summary>Plastics Industry Articles Manufacture, Foremen</summary>
        [XmlEnum("593")]
        OLI_EMPTYPE_PLASTICMFGFORART = 593,

        /// <summary>Plastics Industry Plastic Manufacture, Others</summary>
        [XmlEnum("594")]
        OLI_EMPTYPE_PLASTICMFGOTH = 594,

        /// <summary>Plater (Electroplater/Galvanizer/Tinners)</summary>
        /// <remarks>May also be classified as --> 287 OLI_EMPTYPE_ELECTRPLATER or 353 OLI_EMPTYPE_GALVANIZER</remarks>
        [XmlEnum("595")]
        OLI_EMPTYPE_PLATER = 595,

        /// <summary>Plumbers</summary>
        [XmlEnum("596")]
        OLI_EMPTYPE_PLUMBER = 596,

        /// <summary>Podiatrists</summary>
        [XmlEnum("597")]
        OLI_EMPTYPE_PODIATRIST = 597,

        /// <summary>Police/Law Enforcement Officer All Other Employees</summary>
        [XmlEnum("598")]
        OLI_EMPTYPE_POLICEOTH = 598,

        /// <summary>Police/Law Enforcement Officer Probation/Truant Officer</summary>
        [XmlEnum("599")]
        OLI_EMPTYPE_POLICETRUANT = 599,

        /// <summary>Police/Law Enforcement Officer, Armed</summary>
        [XmlEnum("600")]
        OLI_EMPTYPE_POLICEARMED = 600,

        /// <summary>Police/Law Enforcement Officer, Unarmed</summary>
        [XmlEnum("601")]
        OLI_EMPTYPE_POLICEUNARMED = 601,

        /// <summary>Police/Law Enforcement Officer, Wardens</summary>
        [XmlEnum("602")]
        OLI_EMPTYPE_POLICEWARDEN = 602,

        /// <summary>Pottery (China/Earthenware/Glazed Brick), All Others</summary>
        [XmlEnum("603")]
        OLI_EMPTYPE_POTTERYOTH = 603,

        /// <summary>Pottery (China/Earthenware/Glazed Brick), Decorating</summary>
        [XmlEnum("604")]
        OLI_EMPTYPE_POTTERYDECORATER = 604,

        /// <summary>Pottery China/Earthenware/Glazed Brick,Foremen</summary>
        [XmlEnum("605")]
        OLI_EMPTYPE_POTTERYFOR = 605,

        /// <summary>Pottery China/Earthenware/Glazed Brick,Inspectors</summary>
        [XmlEnum("606")]
        OLI_EMPTYPE_POTTERYINSPECTOR = 606,

        /// <summary>Poultry--Dealer, Dresser, Raiser Or Breeder</summary>
        [XmlEnum("607")]
        OLI_EMPTYPE_POULTRY = 607,

        /// <summary>Power Shovel Operator/Firemen, Non-Hazardous, Usually</summary>
        [XmlEnum("608")]
        OLI_EMPTYPE_POWERSHOVEL = 608,

        /// <summary>Practical Nurse, Hospitals, Asylums, Nd Sanitariums</summary>
        [XmlEnum("609")]
        OLI_EMPTYPE_PRACTICALNURSE = 609,

        /// <summary>Priest</summary>
        [XmlEnum("610")]
        OLI_EMPTYPE_PRIEST = 610,

        /// <summary>Primary Care MD'S</summary>
        [XmlEnum("611")]
        OLI_EMPTYPE_PRIMARYCAREMD = 611,

        /// <summary>Printing And Publishing, All Others</summary>
        [XmlEnum("612")]
        OLI_EMPTYPE_PRINTOTH = 612,

        /// <summary>Printing And Publishing, Office Duties Only</summary>
        [XmlEnum("613")]
        OLI_EMPTYPE_PRINTOFFICE = 613,

        /// <summary>Proctologists</summary>
        [XmlEnum("614")]
        OLI_EMPTYPE_PROCTOLOGIST = 614,

        /// <summary>Proofreaders</summary>
        [XmlEnum("615")]
        OLI_EMPTYPE_PROOFREADER = 615,

        /// <summary>Prosthodontists</summary>
        [XmlEnum("616")]
        OLI_EMPTYPE_PROSTHODONTIST = 616,

        /// <summary>Psychiatrists</summary>
        [XmlEnum("617")]
        OLI_EMPTYPE_PSYCHIATRIST = 617,

        /// <summary>Psychologists</summary>
        [XmlEnum("618")]
        OLI_EMPTYPE_PSYCHOLOGIST = 618,

        /// <summary>Publicity Agent Or Managers</summary>
        [XmlEnum("619")]
        OLI_EMPTYPE_PUBLICITY = 619,

        /// <summary>Pulmonologists</summary>
        [XmlEnum("620")]
        OLI_EMPTYPE_PULMONOLOGIST = 620,

        /// <summary>Purchasing Agent</summary>
        [XmlEnum("621")]
        OLI_EMPTYPE_PURCHASING = 621,

        /// <summary>Rabbi</summary>
        [XmlEnum("622")]
        OLI_EMPTYPE_RABBI = 622,

        /// <summary>Radio/Television Broadcast Control: Maintenance Engineer</summary>
        [XmlEnum("623")]
        OLI_EMPTYPE_RADIOMAINTENGR = 623,

        /// <summary>Radio/Television Broadcast Transmit: Operator/Engineer</summary>
        [XmlEnum("624")]
        OLI_EMPTYPE_RADIOOPERENGR = 624,

        /// <summary>Radio/Television Broadcasting Control: Chief Engineer</summary>
        [XmlEnum("625")]
        OLI_EMPTYPE_RADIOCHIEFENGR = 625,

        /// <summary>Radio/Television Broadcasting Transmit: Supervisors</summary>
        [XmlEnum("626")]
        OLI_EMPTYPE_RADIOCONTROLSUP = 626,

        /// <summary>Radio/Television Industry Broadcasting Studio: Announcer</summary>
        [XmlEnum("627")]
        OLI_EMPTYPE_RADIOBROADCASTSUP = 627,

        /// <summary>Radio/Television Industry Manufacture, Proprietors</summary>
        [XmlEnum("628")]
        OLI_EMPTYPE_RADIOMFG = 628,

        /// <summary>Radio/Television Industry Sales/Repairing, All Other</summary>
        [XmlEnum("629")]
        OLI_EMPTYPE_RADIOREPAIROTH = 629,

        /// <summary>Radio/Television Industry Sales/Repairing, Clerical</summary>
        [XmlEnum("630")]
        OLI_EMPTYPE_RADIOREPAIROFFICE = 630,

        /// <summary>Radio/Television Manufacturing, All Others</summary>
        [XmlEnum("631")]
        OLI_EMPTYPE_RADIOMFGOTH = 631,

        /// <summary>Radio/Television Manufacturing, Supervisor/Foremen</summary>
        [XmlEnum("632")]
        OLI_EMPTYPE_RADIOMFGSUP = 632,

        /// <summary>Radiologists</summary>
        [XmlEnum("633")]
        OLI_EMPTYPE_RADIOLOGIST = 633,

        /// <summary>Radium Ore Reduction & Refining, Chemist/Lab Workers</summary>
        [XmlEnum("634")]
        OLI_EMPTYPE_RADIUMLAB = 634,

        /// <summary>Radium Ore Reduction & Refining, Watch/Dial Painters</summary>
        [XmlEnum("635")]
        OLI_EMPTYPE_RADIUMPAINTER = 635,

        /// <summary>Railroads, Executives And Office Workers</summary>
        [XmlEnum("636")]
        OLI_EMPTYPE_RAILROADOFFICE = 636,

        /// <summary>Real Estate Developer</summary>
        [XmlEnum("637")]
        OLI_EMPTYPE_REALESTATEDEV = 637,

        /// <summary>Real Estate Salesperson</summary>
        /// <remarks>Unclassified Real Estate sales, may not be licensed</remarks>
        [XmlEnum("638")]
        OLI_EMPTYPE_REALESTATESALES = 638,

        /// <summary>Receiving Or Shipping Clerks, All Others</summary>
        [XmlEnum("639")]
        OLI_EMPTYPE_RECIEVINGOTH = 639,

        /// <summary>Receiving Or Shipping Clerks, Light Goods Only</summary>
        [XmlEnum("640")]
        OLI_EMPTYPE_RECEIVINGLIGHT = 640,

        /// <summary>Refrigerator Manufacture, Charging/Purifying Refrigerants</summary>
        [XmlEnum("641")]
        OLI_EMPTYPE_REFRIGMFG = 641,

        /// <summary>Registered Nurses, Doctor's Office Only</summary>
        [XmlEnum("642")]
        OLI_EMPTYPE_REGISTEREDNURSEOFFICE = 642,

        /// <summary>Registered Nurses, Hospitals, Asylums, & Sanitariums</summary>
        [XmlEnum("643")]
        OLI_EMPTYPE_REGISTEREDNURSEHOSPITAL = 643,

        /// <summary>Registered Nurses, Private Duty</summary>
        [XmlEnum("644")]
        OLI_EMPTYPE_REGISTEREDNURSEPFT = 644,

        /// <summary>Rendering Plant (Animal/Fish)--Chemist/Lab Assistant</summary>
        [XmlEnum("645")]
        OLI_EMPTYPE_RENDERINGCHEMIST = 645,

        /// <summary>Rendering Plant (Animal/Fish)--Not Slaughter/Packing</summary>
        [XmlEnum("646")]
        OLI_EMPTYPE_RENDERINGNOTSLAUGHTER = 646,

        /// <summary>Rendering Plant (Animals/Fish)--All Others</summary>
        [XmlEnum("647")]
        OLI_EMPTYPE_RENDERINGOTH = 647,

        /// <summary>Reporters, Court Reporter</summary>
        [XmlEnum("648")]
        OLI_EMPTYPE_REPORTERCOURT = 648,

        /// <summary>Reporters, Newspaper</summary>
        /// <remarks>May also be classified as --> 515 OLI_EMPTYPE_NEWSREPORTER</remarks>
        [XmlEnum("649")]
        OLI_EMPTYPE_REPORTERNEWS = 649,

        /// <summary>Restaurant Mainly Liquor,Proprietors, Not Bar Tending</summary>
        [XmlEnum("650")]
        OLI_EMPTYPE_RESTAURANTNOBAR = 650,

        /// <summary>Restaurant Mostly Liquor Sales, All Others</summary>
        [XmlEnum("651")]
        OLI_EMPTYPE_RESTAURANTOTH = 651,

        /// <summary>Restaurant 1st Class 2nd Liquor Proprietor/Tend Bar</summary>
        [XmlEnum("652")]
        OLI_EMPTYPE_RESTAURANTBAR = 652,

        /// <summary>Restaurant 1st Class 2nd Liquor Sale Proprietor/Man</summary>
        [XmlEnum("653")]
        OLI_EMPTYPE_RESTAURANTMAN = 653,

        /// <summary>Restaurant 1st Class 2nd Liquor Sale Tending Bar</summary>
        [XmlEnum("654")]
        OLI_EMPTYPE_RESTAURANTBARTEND = 654,

        /// <summary>Restaurant 1st Class 2nd Liquor Sale Waiters/Kitchen</summary>
        [XmlEnum("655")]
        OLI_EMPTYPE_RESTAURANTWAITER = 655,

        /// <summary>Restaurant 1st Class 2nd Liquor Sale, Head Waiter/Matre'd</summary>
        [XmlEnum("656")]
        OLI_EMPTYPE_RESTAURANTHEAD = 656,

        /// <summary>Restaurant 1st Class 2nd Liquor Sale,Prop,Supervising</summary>
        [XmlEnum("657")]
        OLI_EMPTYPE_RESTAURANTSUP = 657,

        /// <summary>Restaurant 1st Class 2nd Liquor,Head Chef, Supervising</summary>
        [XmlEnum("658")]
        OLI_EMPTYPE_RESTAURANTCHEF = 658,

        /// <summary>Retail Outlet--Store Clerks, Usually</summary>
        [XmlEnum("659")]
        OLI_EMPTYPE_RETAIL = 659,

        /// <summary>Retinal Surgeons</summary>
        [XmlEnum("660")]
        OLI_EMPTYPE_RETINALSURGEON = 660,

        /// <summary>Rheumatologist</summary>
        [XmlEnum("661")]
        OLI_EMPTYPE_RHEUMATOLOGIST = 661,

        /// <summary>Riggers, All Others</summary>
        [XmlEnum("662")]
        OLI_EMPTYPE_RIGGEROTH = 662,

        /// <summary>Riggers, Motion Picture Studios, Sign Erectors</summary>
        [XmlEnum("663")]
        OLI_EMPTYPE_RIGGERMOVIE = 663,

        /// <summary>Rock Wool, All Others</summary>
        [XmlEnum("664")]
        OLI_EMPTYPE_ROCKWOOLOTH = 664,

        /// <summary>Rock Wool,Insulating Building, Manufacturing-Foremen</summary>
        [XmlEnum("665")]
        OLI_EMPTYPE_ROCKWOOLFOR = 665,

        /// <summary>Roofing Material Manufacture Asphalt/Asbestos, Foremen</summary>
        [XmlEnum("666")]
        OLI_EMPTYPE_ROOFINGFOR = 666,

        /// <summary>Roofing Material Manufacture Asphalt/Asbestos, Other</summary>
        [XmlEnum("667")]
        OLI_EMPTYPE_ROOFINGOTH = 667,

        /// <summary>Rubber Products Manufacture, Superintendent/Chemist</summary>
        [XmlEnum("668")]
        OLI_EMPTYPE_RUBBERSUP = 668,

        /// <summary>Rubber/Rubber Product Manufacture, All Others</summary>
        [XmlEnum("669")]
        OLI_EMPTYPE_RUBBERMFGOTH = 669,

        /// <summary>Rubber/Rubber Product Manufacture, Foremen</summary>
        [XmlEnum("670")]
        OLI_EMPTYPE_RUBBERMFGSUP = 670,

        /// <summary>Safe And Machinery Movers</summary>
        [XmlEnum("671")]
        OLI_EMPTYPE_SAFEMOVER = 671,

        /// <summary>Safety Engineers-Non-Hazardous Industries</summary>
        [XmlEnum("672")]
        OLI_EMPTYPE_SAFTYENGR = 672,

        /// <summary>Salesmen, Office & Outside Soliciting, No Delivering</summary>
        [XmlEnum("673")]
        OLI_EMPTYPE_SALESNODEL = 673,

        /// <summary>Salesmen--Full Time--Delivering By Light Truck/Van</summary>
        [XmlEnum("674")]
        OLI_EMPTYPE_SALESDEL = 674,

        /// <summary>Salesmen--Full Time--Installing/Repairing/Servicing</summary>
        [XmlEnum("675")]
        OLI_EMPTYPE_SALESSERVICE = 675,

        /// <summary>Salesmen--Full Time-Soliciting/Delivery By Auto Only</summary>
        [XmlEnum("676")]
        OLI_EMPTYPE_SALESDELAUTO = 676,

        /// <summary>Sandblaster, Building Cleaner/Glass/Pottery/Stone</summary>
        [XmlEnum("677")]
        OLI_EMPTYPE_SANDBLASTER = 677,

        /// <summary>School, Principal/Superintendents/Administrative Office</summary>
        [XmlEnum("678")]
        OLI_EMPTYPE_SCHOOL = 678,

        /// <summary>Seamstresses And Dressmakers, In Shop</summary>
        [XmlEnum("679")]
        OLI_EMPTYPE_SEAMSTRESS = 679,

        /// <summary>Sewer/Sewage Disposal/Cesspool Worker Inspector, Forman</summary>
        [XmlEnum("680")]
        OLI_EMPTYPE_SEWERINSP = 680,

        /// <summary>Sewer/Sewage Disposal/Cesspool Workers, Others</summary>
        [XmlEnum("681")]
        OLI_EMPTYPE_SEWEROTH = 681,

        /// <summary>Sewing Machine Operators And Repairmen</summary>
        [XmlEnum("682")]
        OLI_EMPTYPE_SEWING = 682,

        /// <summary>Sextons</summary>
        [XmlEnum("683")]
        OLI_EMPTYPE_SECTON = 683,

        /// <summary>Sheet Metal Workers, Tinsmiths, Others</summary>
        [XmlEnum("684")]
        OLI_EMPTYPE_SHEETMETALOTH = 684,

        /// <summary>Sheet Metal Workers, Tinsmiths, Shop Work Only</summary>
        [XmlEnum("685")]
        OLI_EMPTYPE_SHEETMETALSHOP = 685,

        /// <summary>Shoe Manufacture/Repair Factory Worker, All Skilled</summary>
        [XmlEnum("686")]
        OLI_EMPTYPE_SHOEMFGSKILLED = 686,

        /// <summary>Shoe Manufacture/Repair Factory, Unskilled Employees</summary>
        [XmlEnum("687")]
        OLI_EMPTYPE_SHOEMFGUNSKILLED = 687,

        /// <summary>Shoe Manufacture/Repair Non-Factory, Shoemaker/Repair</summary>
        [XmlEnum("688")]
        OLI_EMPTYPE_SHOEMFGREPAIR = 688,

        /// <summary>Shovel Operator (Power)/Firemen, Non-Hazardous</summary>
        [XmlEnum("689")]
        OLI_EMPTYPE_SHOVELOPRFOR = 689,

        /// <summary>Sign/Billboard Erector/Builder, Bench Work Only</summary>
        [XmlEnum("690")]
        OLI_EMPTYPE_SIGNBENCH = 690,

        /// <summary>Sign/Billboard Erectors Or Builders, All Others</summary>
        [XmlEnum("691")]
        OLI_EMPTYPE_SIGNERECTOR = 691,

        /// <summary>Silver Polishers</summary>
        [XmlEnum("692")]
        OLI_EMPTYPE_SILVERPOLISHER = 692,

        /// <summary>Silversmiths</summary>
        [XmlEnum("693")]
        OLI_EMPTYPE_SILVERSMITH = 693,

        /// <summary>Slot Machine (Legal), Collector/Distributor/Repairer</summary>
        [XmlEnum("694")]
        OLI_EMPTYPE_SLOTMACHREPAIR = 694,

        /// <summary>Soap And Detergent Manufacture, All Others</summary>
        [XmlEnum("695")]
        OLI_EMPTYPE_SOAPMFGOTH = 695,

        /// <summary>Soap/Detergent Manufacture, Workmen,Abrasive Grinding</summary>
        [XmlEnum("696")]
        OLI_EMPTYPE_SOAPMFGWORKMAN = 696,

        /// <summary>Social Workers, All Others</summary>
        [XmlEnum("697")]
        OLI_EMPTYPE_SOCIALWORKEROTH = 697,

        /// <summary>Social Workers, Office Duties Only</summary>
        [XmlEnum("698")]
        OLI_EMPTYPE_SOCIALWORKEROFFICE = 698,

        /// <summary>Solder Makers</summary>
        [XmlEnum("699")]
        OLI_EMPTYPE_SOLDERMAKER = 699,

        /// <summary>Solderers, Non-Hazardous Industries, Usually</summary>
        [XmlEnum("700")]
        OLI_EMPTYPE_SOLDERER = 700,

        /// <summary>Speech Therapists</summary>
        [XmlEnum("701")]
        OLI_EMPTYPE_SPEECHTHERAPIST = 701,

        /// <summary>Spice Grinders And Packers</summary>
        [XmlEnum("702")]
        OLI_EMPTYPE_SPICEGRINDER = 702,

        /// <summary>Sports (Pro)Owner/Manager/Coach/Scout (Non-Part)</summary>
        [XmlEnum("703")]
        OLI_EMPTYPE_SPORTSOWNER = 703,

        /// <summary>Sports Athletic Instructor/Director, School/College</summary>
        [XmlEnum("704")]
        OLI_EMPTYPE_SPORTSATHDIR = 704,

        /// <summary>Sports Beach/Pool/Billiard/Bowling Alley, Attendants</summary>
        [XmlEnum("705")]
        OLI_EMPTYPE_SPORTSATTNEDANT = 705,

        /// <summary>Sports Beach/Pool/Billiard/Bowling Proprietor/Manager</summary>
        [XmlEnum("706")]
        OLI_EMPTYPE_SPORTSMANAGER = 706,

        /// <summary>Sports Dance Hall/Skating, Proprietor/Manager, Fulltime</summary>
        [XmlEnum("707")]
        OLI_EMPTYPE_SPORTSSKATING = 707,

        /// <summary>Sports Racing Automobile:  Mechanics, No Driving</summary>
        [XmlEnum("708")]
        OLI_EMPTYPE_SPORTSAUTONODRIVE = 708,

        /// <summary>Sports Racing Horse And Dog:  Parimutuel Clerks</summary>
        [XmlEnum("709")]
        OLI_EMPTYPE_SPORTSCLERK = 709,

        /// <summary>Sports Racing Horse/Dog: Starter/Judge/Steward/Office</summary>
        [XmlEnum("710")]
        OLI_EMPTYPE_SPORTSSTARTER = 710,

        /// <summary>Sports Riding School, Proprietor/Manager (Supervision)</summary>
        [XmlEnum("711")]
        OLI_EMPTYPE_SPORTSRIDINGMGR = 711,

        /// <summary>Sports Riding Schools, Instructors</summary>
        [XmlEnum("712")]
        OLI_EMPTYPE_SPORTSRIDINGINST = 712,

        /// <summary>Starters, Taxicab, Elevator</summary>
        [XmlEnum("713")]
        OLI_EMPTYPE_STARTER = 713,

        /// <summary>Stationary Engineer/Firemen, Non-Hazardous Industry</summary>
        [XmlEnum("714")]
        OLI_EMPTYPE_STATIONARYENGR = 714,

        /// <summary>Statistician</summary>
        [XmlEnum("715")]
        OLI_EMPTYPE_STATISTICIAN = 715,

        /// <summary>Steamfitter--Non-hazardous Industries, Usually</summary>
        [XmlEnum("716")]
        OLI_EMPTYPE_STEAMFITTER = 716,

        /// <summary>Stenographers</summary>
        [XmlEnum("717")]
        OLI_EMPTYPE_STENOGRAPHER = 717,

        /// <summary>Stock And Bond Brokers Or Salespeople</summary>
        [XmlEnum("718")]
        OLI_EMPTYPE_STOCKSALES = 718,

        /// <summary>Stock Clerk/Keeper/Chaser, Light Goods Only</summary>
        [XmlEnum("719")]
        OLI_EMPTYPE_STOCKCLERK = 719,

        /// <summary>Stock Clerks, Keepers Or Chasers, All Others</summary>
        [XmlEnum("720")]
        OLI_EMPTYPE_STOCKCLERKOTH = 720,

        /// <summary>Stockyard/Slaughter/Packing House Superintendent</summary>
        [XmlEnum("721")]
        OLI_EMPTYPE_STOCKYARDSUP = 721,

        /// <summary>Stockyard/Slaughter/Packing House, Commission Men</summary>
        [XmlEnum("722")]
        OLI_EMPTYPE_STOCKYARDCOMMISSIONMAN = 722,

        /// <summary>Stone Industry Other Stone, All Others</summary>
        [XmlEnum("723")]
        OLI_EMPTYPE_STONEOTH = 723,

        /// <summary>Stone Industry Other Stone, Foremen</summary>
        [XmlEnum("724")]
        OLI_EMPTYPE_STONEFOR = 724,

        /// <summary>Street Cleaning, All Others Including Drivers</summary>
        [XmlEnum("725")]
        OLI_EMPTYPE_STREETCLEANER = 725,

        /// <summary>Street Cleaning, Foremen (Inspectors)</summary>
        [XmlEnum("726")]
        OLI_EMPTYPE_STREETCLEANFOR = 726,

        /// <summary>Sugar Refinery (Starch And Corn Products), Foremen</summary>
        [XmlEnum("727")]
        OLI_EMPTYPE_SUGARFOR = 727,

        /// <summary>Sugar Refinery (Starch/Corn Product), Superintendent</summary>
        [XmlEnum("728")]
        OLI_EMPTYPE_SUGARSUP = 728,

        /// <summary>Sugar Refinery (Starch/Corn Products), All Others</summary>
        [XmlEnum("729")]
        OLI_EMPTYPE_SUGAROTH = 729,

        /// <summary>Sugar Refinery (Starch/Corn), Kiln Cleaner/ Unskilled</summary>
        [XmlEnum("730")]
        OLI_EMPTYPE_SUGARUNSKILLED = 730,

        /// <summary>Surveyors, Non-hazardous Industries, Usually</summary>
        [XmlEnum("731")]
        OLI_EMPTYPE_SURVEYOR = 731,

        /// <summary>Tailor (Working Away From Home), Not Pressing/Cleaning</summary>
        [XmlEnum("732")]
        OLI_EMPTYPE_TAILOR = 732,

        /// <summary>Tailors (Working Away From Home), General Duties</summary>
        [XmlEnum("733")]
        OLI_EMPTYPE_TAILORGEN = 733,

        /// <summary>Talc Industry Mills, All Other Workers</summary>
        [XmlEnum("734")]
        OLI_EMPTYPE_TALCOTH = 734,

        /// <summary>Talc Industry Mills, Foremen, Skilled Workers</summary>
        [XmlEnum("735")]
        OLI_EMPTYPE_TALCSKILLED = 735,

        /// <summary>Taxicab Drivers</summary>
        /// <remarks>May also be classified as --> 249 OLI_EMPTYPE_DRIVERTAXI</remarks>
        [XmlEnum("736")]
        OLI_EMPTYPE_TAXICABDRIVER = 736,

        /// <summary>Taxidermists</summary>
        [XmlEnum("737")]
        OLI_EMPTYPE_TAXIDERMIST = 737,

        /// <summary>Teacher, School/College (Fulltime Employment)</summary>
        [XmlEnum("738")]
        OLI_EMPTYPE_TEACHER = 738,

        /// <summary>Teacher, School/College (Part-time Employment)</summary>
        [XmlEnum("739")]
        OLI_EMPTYPE_TEACHERPARTTIMER = 739,

        /// <summary>Teacher,School/College (F/T)-Agri/Animal Husbandry</summary>
        [XmlEnum("740")]
        OLI_EMPTYPE_TEACHERANIMAL = 740,

        /// <summary>Telegraph And Telephone Inside Workers, All Others</summary>
        [XmlEnum("741")]
        OLI_EMPTYPE_TELEPHONEOTH = 741,

        /// <summary>Telegraph/Telephone Inside Worker/Inspector/Installer</summary>
        [XmlEnum("742")]
        OLI_EMPTYPE_TELEPHONEINSTALLER = 742,

        /// <summary>Telegraph/Telephone Inside Worker/Operator/Exchange</summary>
        [XmlEnum("743")]
        OLI_EMPTYPE_TELEPHONEOPERATOR = 743,

        /// <summary>Telegraph/Telephone Inside Worker/Repairmen</summary>
        [XmlEnum("744")]
        OLI_EMPTYPE_TELEPHONEREPAIRMAN = 744,

        /// <summary>Telegraph/Telephone Outside Line Construct/Maintenance</summary>
        [XmlEnum("745")]
        OLI_EMPTYPE_TELEPHONEMAINT = 745,

        /// <summary>Telegraph/Telephone Outside Lines Constr, Maintenance</summary>
        [XmlEnum("746")]
        OLI_EMPTYPE_TELEPHONEMAINT2 = 746,

        /// <summary>Tent Makers</summary>
        [XmlEnum("747")]
        OLI_EMPTYPE_TENTMAKER = 747,

        /// <summary>Textile Industry, Inspectors, Graders, Sorters</summary>
        [XmlEnum("748")]
        OLI_EMPTYPE_TEXTILESKILLED = 748,

        /// <summary>Textile Industry, Other Skilled Workers</summary>
        [XmlEnum("749")]
        OLI_EMPTYPE_TEXTILEOTH = 749,

        /// <summary>Textile Industry, Superintendents And Foreman</summary>
        [XmlEnum("750")]
        OLI_EMPTYPE_TEXTILESUP = 750,

        /// <summary>Therapists--Occupational</summary>
        [XmlEnum("751")]
        OLI_EMPTYPE_THERAPISTOCCUP = 751,

        /// <summary>Thoracic Surgeons</summary>
        [XmlEnum("752")]
        OLI_EMPTYPE_THORASICSURGEON = 752,

        /// <summary>Ticket Agents (Office Duties Only)</summary>
        [XmlEnum("753")]
        OLI_EMPTYPE_TICKETAGENT = 753,

        /// <summary>Tile Layers/Setters, Pipers Or Drains Or Roofers</summary>
        [XmlEnum("754")]
        OLI_EMPTYPE_TILELAYER = 754,

        /// <summary>Timekeepers</summary>
        [XmlEnum("755")]
        OLI_EMPTYPE_TIMEKEEPER = 755,

        /// <summary>Tinners And Galvanizers (Not Roofers)</summary>
        [XmlEnum("756")]
        OLI_EMPTYPE_TINNER = 756,

        /// <summary>Tinsmiths, Others</summary>
        [XmlEnum("757")]
        OLI_EMPTYPE_TINSMITHOTH = 757,

        /// <summary>Tinsmiths, Shop Work Only</summary>
        [XmlEnum("758")]
        OLI_EMPTYPE_TINSMITHSHOP = 758,

        /// <summary>Tobacco Manufacture, Auctioneer/Buyer/Inspectors</summary>
        [XmlEnum("759")]
        OLI_EMPTYPE_TOBACCOBUYER = 759,

        /// <summary>Tobacco Manufacture, Other Skilled Workers</summary>
        [XmlEnum("760")]
        OLI_EMPTYPE_TOBACCOOTH = 760,

        /// <summary>Toll Collectors</summary>
        [XmlEnum("761")]
        OLI_EMPTYPE_TOLLCOLLECTOR = 761,

        /// <summary>Topographers</summary>
        [XmlEnum("762")]
        OLI_EMPTYPE_TOPOGRAPHER = 762,

        /// <summary>Tour Directors Or Conductors</summary>
        [XmlEnum("763")]
        OLI_EMPTYPE_TOURDIRECTOR = 763,

        /// <summary>Traffic Managers (Office Duties Only)</summary>
        [XmlEnum("764")]
        OLI_EMPTYPE_TRAFFICMGR = 764,

        /// <summary>Travel Agency, Agents</summary>
        [XmlEnum("765")]
        OLI_EMPTYPE_TRAVELAGENT = 765,

        /// <summary>Travel Agency, Proprietors</summary>
        [XmlEnum("766")]
        OLI_EMPTYPE_TRAVELAGENTOWNER = 766,

        /// <summary>Tree Workers, Fumigators And Sprayers</summary>
        [XmlEnum("767")]
        OLI_EMPTYPE_TREEWORKERSPRAY = 767,

        /// <summary>Tree Workers, Surgeons And Trimmers</summary>
        [XmlEnum("768")]
        OLI_EMPTYPE_TREEWORKER = 768,

        /// <summary>Turpentine Industry, All Others</summary>
        [XmlEnum("769")]
        OLI_EMPTYPE_TURPENTINEOTH = 769,

        /// <summary>Turpentine Industry, Superintendents</summary>
        [XmlEnum("770")]
        OLI_EMPTYPE_TURPENTINESUP = 770,

        /// <summary>Typists</summary>
        [XmlEnum("771")]
        OLI_EMPTYPE_TYPIST = 771,

        /// <summary>Umbrella Makers Or Repairers</summary>
        [XmlEnum("772")]
        OLI_EMPTYPE_UMBRELLAMFG = 772,

        /// <summary>Funeral Industry, Undertakers, Assistants And Embalmers</summary>
        [XmlEnum("773")]
        OLI_EMPTYPE_UNDERTAKERASSIST = 773,

        /// <summary>Undertakers, Others</summary>
        [XmlEnum("774")]
        OLI_EMPTYPE_UNDERTAKEROTH = 774,

        /// <summary>Undertakers, Proprietors (Not Embalming)</summary>
        [XmlEnum("775")]
        OLI_EMPTYPE_UNDERTAKEROWNER = 775,

        /// <summary>Unemployed, Retired</summary>
        [XmlEnum("776")]
        OLI_EMPTYPE_RETIRED = 776,

        /// <summary>Upholsterers</summary>
        [XmlEnum("777")]
        OLI_EMPTYPE_UPHOLSTERER = 777,

        /// <summary>Urological Surgeons</summary>
        [XmlEnum("778")]
        OLI_EMPTYPE_UROLOGISTSURGEON = 778,

        /// <summary>Urologists</summary>
        [XmlEnum("779")]
        OLI_EMPTYPE_UROLOGIST = 779,

        /// <summary>Vacuum Cleaner Dealer/Salesmen, No Repairing, Delivery</summary>
        [XmlEnum("780")]
        OLI_EMPTYPE_VACUUMSALES = 780,

        /// <summary>Vacuum Cleaner Dealers And Salesmen, Repairing</summary>
        [XmlEnum("781")]
        OLI_EMPTYPE_VACUUMREPAIR = 781,

        /// <summary>Vascular Surgeons</summary>
        [XmlEnum("782")]
        OLI_EMPTYPE_VASCULARSURGEON = 782,

        /// <summary>Vending Machine (Legal) Collector/Filler/ Installers</summary>
        [XmlEnum("783")]
        OLI_EMPTYPE_VENDINGMACHINE = 783,

        /// <summary>Venetian Blinds--Installer</summary>
        [XmlEnum("784")]
        OLI_EMPTYPE_VENETIANBLINDINSTALLER = 784,

        /// <summary>Venetian Blinds--Makers Or Repairers</summary>
        [XmlEnum("785")]
        OLI_EMPTYPE_VENETIANBLINDNFG = 785,

        /// <summary>Veterinarian (DVM)--Large Animals</summary>
        /// <remarks>May also be classified as --> 441 OLI_EMPTYPE_KENNELVETLARGE</remarks>
        [XmlEnum("786")]
        OLI_EMPTYPE_VETERINANRIANLARGE = 786,

        /// <summary>Veterinarians (DVM)--Small Animals</summary>
        /// <remarks>May also be classified as --> 442 OLI_EMPTYPE_KENNELVETPET</remarks>
        [XmlEnum("787")]
        OLI_EMPTYPE_VETERINANRIANSMALL = 787,

        /// <summary>Vinegar Makers</summary>
        [XmlEnum("788")]
        OLI_EMPTYPE_VINEGARMFG = 788,

        /// <summary>Violin Makers Or Repairers</summary>
        [XmlEnum("789")]
        OLI_EMPTYPE_VIOLINMFG = 789,

        /// <summary>Wall Paper, Designers</summary>
        [XmlEnum("790")]
        OLI_EMPTYPE_WALLPAPERDESIGNER = 790,

        /// <summary>Wall Paper, Hangers Or Printers</summary>
        [XmlEnum("791")]
        OLI_EMPTYPE_WALLPAPERHANGER = 791,

        /// <summary>Wall Paper, Makers</summary>
        [XmlEnum("792")]
        OLI_EMPTYPE_WALLPAPERMAKER = 792,

        /// <summary>Warehousemen, All Other Warehouse Employees</summary>
        [XmlEnum("793")]
        OLI_EMPTYPE_WAREHOUSEMANOTH = 793,

        /// <summary>Warehousemen, Checker/Crater/Foremen Or Packers</summary>
        [XmlEnum("794")]
        OLI_EMPTYPE_WAREHOUSEMANFOR = 794,

        /// <summary>Warehousemen, Checkers, Not Handling Goods</summary>
        [XmlEnum("795")]
        OLI_EMPTYPE_WAREHOUSEMANCHECKER = 795,

        /// <summary>Washing Machine, Dealer/Salesmen, Not Delivery/Repair</summary>
        [XmlEnum("796")]
        OLI_EMPTYPE_WASHINGMACHINESALES = 796,

        /// <summary>Washing Machine, Delivering Or Repairing</summary>
        [XmlEnum("797")]
        OLI_EMPTYPE_WASHINGTMACHINEREPAIR = 797,

        /// <summary>Watch/Watch Cases, Maker/Repairer, Hand Tools Only</summary>
        [XmlEnum("798")]
        OLI_EMPTYPE_WATCHREPAIR = 798,

        /// <summary>Watches Or Watch Cases, Testers, In Factory</summary>
        [XmlEnum("799")]
        OLI_EMPTYPE_WATCHTESTER = 799,

        /// <summary>Watches/Watch Case, Maker/Repairer, Using Other Tool</summary>
        [XmlEnum("800")]
        OLI_EMPTYPE_WATCHCASEREPAIR = 800,

        /// <summary>Watchmen</summary>
        [XmlEnum("801")]
        OLI_EMPTYPE_WATCHMAN = 801,

        /// <summary>Water Meters, Installers, Repairers, Or Testers</summary>
        [XmlEnum("802")]
        OLI_EMPTYPE_WATERMETERINSTALLER = 802,

        /// <summary>Water Meters, Readers Or Inspectors</summary>
        [XmlEnum("803")]
        OLI_EMPTYPE_WATERMETERREADER = 803,

        /// <summary>Water Works, All Others Employees</summary>
        [XmlEnum("804")]
        OLI_EMPTYPE_WATERWORKSOTH = 804,

        /// <summary>Water Works, Filtermen Or Pumpmen</summary>
        [XmlEnum("805")]
        OLI_EMPTYPE_WATERWORKSFOR = 805,

        /// <summary>Water Works, Superintendent (Superintending Only)</summary>
        [XmlEnum("806")]
        OLI_EMPTYPE_WATERWORKSSUP = 806,

        /// <summary>Weather Observers</summary>
        [XmlEnum("807")]
        OLI_EMPTYPE_WEATHEROBSERVER = 807,

        /// <summary>Weighers, Not Otherwise Classified</summary>
        [XmlEnum("808")]
        OLI_EMPTYPE_WEIGHERUNCLASSIFIED = 808,

        /// <summary>Weighers, Office Duties Only</summary>
        [XmlEnum("809")]
        OLI_EMPTYPE_WEIGHEROFFICE = 809,

        /// <summary>Welders And Cutters (No Unusual Hazard)</summary>
        [XmlEnum("810")]
        OLI_EMPTYPE_WELDER = 810,

        /// <summary>Welfare Workers, All Others</summary>
        [XmlEnum("811")]
        OLI_EMPTYPE_WELFAREWORKEROTH = 811,

        /// <summary>Welfare Workers, Office Duties Only</summary>
        [XmlEnum("812")]
        OLI_EMPTYPE_WELFAREWORKEROFFICE = 812,

        /// <summary>Well (Not Gas/Oil/Salt), Borer/Diggers, No Explosive</summary>
        [XmlEnum("813")]
        OLI_EMPTYPE_WELLDIGGER = 813,

        /// <summary>Wheelwrights, Not Using Machinery</summary>
        [XmlEnum("814")]
        OLI_EMPTYPE_WHEELWRIGHTNOMACHINE = 814,

        /// <summary>Wheelwrights, Using Machinery</summary>
        [XmlEnum("815")]
        OLI_EMPTYPE_WHEELWRIGHTMACHINE = 815,

        /// <summary>White Lead Manufacture, All Others</summary>
        [XmlEnum("816")]
        OLI_EMPTYPE_WHITELEADMFGOTH = 816,

        /// <summary>White Lead Manufacture, Foremen</summary>
        [XmlEnum("817")]
        OLI_EMPTYPE_WHITELEADMFGFOR = 817,

        /// <summary>White Lead Manufacture, Superintendent/Chemist</summary>
        [XmlEnum("818")]
        OLI_EMPTYPE_WHITELEADMFGSUP = 818,

        /// <summary>Wig Makers</summary>
        [XmlEnum("819")]
        OLI_EMPTYPE_WIGMAKER = 819,

        /// <summary>Window Industry, Cleaner Inside/Ground Floor Only</summary>
        [XmlEnum("820")]
        OLI_EMPTYPE_WINDOWCLEANER = 820,

        /// <summary>Window Industry, Dresser/Trimmer, Shade Maker/Hanger</summary>
        [XmlEnum("821")]
        OLI_EMPTYPE_WINDOWDRESSER = 821,

        /// <summary>Window Industry, Screen Makers Or Installers</summary>
        [XmlEnum("822")]
        OLI_EMPTYPE_WINDOWINSTALLER = 822,

        /// <summary>Wire Fence Erectors</summary>
        [XmlEnum("823")]
        OLI_EMPTYPE_WIREFENCEERECTOR = 823,

        /// <summary>Wire Mill Worker, Annealer/Drawer/Oiler/Laborers</summary>
        [XmlEnum("824")]
        OLI_EMPTYPE_WIREWORKER = 824,

        /// <summary>Wire Mill Workers, All Other Mill Employees</summary>
        [XmlEnum("825")]
        OLI_EMPTYPE_WIREWORKEROTH = 825,

        /// <summary>Wireless And Radio Operators, Shore Stations</summary>
        [XmlEnum("826")]
        OLI_EMPTYPE_WIRELESSOPERATOR = 826,

        /// <summary>Wireless/Radio Operator, Lighthouse--Mainland Only</summary>
        [XmlEnum("827")]
        OLI_EMPTYPE_WIRELESSLIGHTHOUSE = 827,

        /// <summary>X-Ray, Operators, Salesmen, Technicians</summary>
        [XmlEnum("828")]
        OLI_EMPTYPE_XRAYOPERATOR = 828,

        /// <summary>X-Ray, Repairmen, Servicemen, Testers</summary>
        [XmlEnum("829")]
        OLI_EMPTYPE_XRAYREPAIR = 829,

        /// <summary>Yarn Makers</summary>
        [XmlEnum("830")]
        OLI_EMPTYPE_YARNMAKER = 830,

        /// <summary>Yeast Maker, Superintendent/Foremen (Supervising Only)</summary>
        [XmlEnum("831")]
        OLI_EMPTYPE_YEASTMAKERSUP = 831,

        /// <summary>Yeast Makers, Process Workers</summary>
        [XmlEnum("832")]
        OLI_EMPTYPE_YEASTMAKERWRK = 832,

        /// <summary>Yeast Makers, Unskilled Workers</summary>
        [XmlEnum("833")]
        OLI_EMPTYPE_YEASTMAKERUNSKILLED = 833,

        /// <summary>YMCA/Similar Organizations, Officers, Directors</summary>
        [XmlEnum("834")]
        OLI_EMPTYPE_YMCEMGT = 834,

        /// <summary>YMCA/Similar Organizations, Physical Directors</summary>
        [XmlEnum("835")]
        OLI_EMPTYPE_YMCADIRECTOR = 835,

        /// <summary>Zoos, Zoo Director (No Contact With Animals)</summary>
        [XmlEnum("836")]
        OLI_EMPTYPE_ZOODIRECTOR = 836,

        /// <summary>Zoos, Zoo Keeper</summary>
        [XmlEnum("837")]
        OLI_EMPTYPE_ZOOKEEPER = 837,

        /// <summary>Fireman</summary>
        /// <remarks>A person whose work is to extinguish fires.  A member of a Fire Department.</remarks>
        [XmlEnum("838")]
        OLI_EMPTYPE_FIREMAN = 838,

        /// <summary>Astronaut</summary>
        /// <remarks>A person who is trained to make rocket flights into outer space.</remarks>
        [XmlEnum("839")]
        OLI_EMPTYPE_ASTRONAUT = 839,

        /// <summary>Pilot</summary>
        /// <remarks>A person who is trained to fly airplanes, airships, or hot air balloons.</remarks>
        [XmlEnum("840")]
        OLI_EMPTYPE_PILOT = 840,

        /// <summary>Pyrotechnist</summary>
        /// <remarks>A person who is skilled in the art of creating and using fireworks</remarks>
        [XmlEnum("841")]
        OLI_EMPTYPE_PYROTECHNIST = 841,

        /// <summary>Detective</summary>
        /// <remarks>A person whose work involves investigating and trying to solve crimes, including participation on stake outs for suspected persons.</remarks>
        [XmlEnum("842")]
        OLI_EMPTYPE_DETECTIVE = 842,

        /// <summary>Animal Trainer</summary>
        /// <remarks>A person who trains or exhibits animals.  Includes Horse Trainer, Dog Trainer, or Tamer.</remarks>
        [XmlEnum("843")]
        OLI_EMPTYPE_ANIMALTRAINER = 843,

        /// <summary>Coal Miner</summary>
        /// <remarks>A person who works in a coal mine.  Also commonly known as a collier, or pitman.</remarks>
        [XmlEnum("844")]
        OLI_EMPTYPE_COALMINER = 844,

        /// <summary>Abrasives Manufacture</summary>
        /// <remarks>A person working in the manufacture of silica abrasives.</remarks>
        [XmlEnum("845")]
        OLI_EMPTYPE_ABRWORKER = 845,

        /// <summary>Acid Manufacture</summary>
        /// <remarks>A person working in the manufacture of hydrochloric, hydrocyanic, hydrofluoric, nitric, picric, sulphurous or sulphuric acids.</remarks>
        [XmlEnum("846")]
        OLI_EMPTYPE_ACIDWORKER = 846,

        /// <summary>Aquanics</summary>
        /// <remarks>Divers involved in deep-water diving for construction, salvage, search and rescue, military or scientific or exploration.</remarks>
        [XmlEnum("847")]
        OLI_EMPTYPE_AQUANICS = 847,

        /// <summary>Aviation (Military)</summary>
        /// <remarks>Risk depends on age and type of aircraft flown.</remarks>
        [XmlEnum("848")]
        OLI_EMPTYPE_AVIATIONMIL = 848,

        /// <summary>Building Demolition</summary>
        /// <remarks>Involves demolition of buildings and other structures with exposure to the same hazards found in the erection of buildings plus the added danger of unsound structures which may collapse.</remarks>
        [XmlEnum("849")]
        OLI_EMPTYPE_DEMOLITION = 849,

        /// <summary>Carnival, circus and fair worker</summary>
        /// <remarks>May include daredevil, trapeze or equestrian acts.  Also includes general laborers or roustabouts.</remarks>
        [XmlEnum("850")]
        OLI_EMPTYPE_CARNIVAL = 850,

        /// <summary>Weaponry, Chemical and biological</summary>
        /// <remarks>Engaged in research, development, testing, storage, disposal or transportation of various toxic agents.</remarks>
        [XmlEnum("851")]
        OLI_EMPTYPE_WEAPONS = 851,

        /// <summary>Stunt men</summary>
        /// <remarks>Acting performers who may be involved in high-speed driving, leaps and dives and fire/explosive exposure.</remarks>
        [XmlEnum("852")]
        OLI_EMPTYPE_STUNTMAN = 852,

        /// <summary>Explosives and Munitions</summary>
        /// <remarks>Manufacture, assembling, loading, testing and delivering of explosives and other elements for the preparation of ammunition for firing.</remarks>
        [XmlEnum("853")]
        OLI_EMPTYPE_EXPLOSIVES = 853,

        /// <summary>Fireman, Smoke Jumper</summary>
        /// <remarks>A fireman specializing in extinguishing forest fires.</remarks>
        [XmlEnum("854")]
        OLI_EMPTYPE_SMOKEJUMPER = 854,

        /// <summary>Fireman, Off-shore Oil or Gas wells</summary>
        /// <remarks>A fireman specializing in extinguishing fires on off-shore wells.</remarks>
        [XmlEnum("855")]
        OLI_EMPTYPE_FIREMANOFFSHORE = 855,

        /// <summary>Commercial fisherman</summary>
        /// <remarks>Commercial fisherman</remarks>
        [XmlEnum("856")]
        OLI_EMPTYPE_COMMFISHERMAN = 856,

        /// <summary>Foreign Correspondents or Journalists</summary>
        /// <remarks>Journalist, news crew member or photographer whose assignments include foreign travel.</remarks>
        [XmlEnum("857")]
        OLI_EMPTYPE_FOREIGNJOURNALIST = 857,

        /// <summary>Metal Industry</summary>
        /// <remarks>Workers in heavy (iron and steel) and light (magnesium and aluminum) metal industries.</remarks>
        [XmlEnum("858")]
        OLI_EMPTYPE_METALS = 858,

        /// <summary>Military</summary>
        /// <remarks>Those individuals on active duty in the military</remarks>
        [XmlEnum("859")]
        OLI_EMPTYPE_MILITARY = 859,

        /// <summary>Nuclear energy industry</summary>
        /// <remarks>Workers in nuclear reactors, power generating plants, isotope production, research and testing facilities and waste conversion.</remarks>
        [XmlEnum("860")]
        OLI_EMPTYPE_NUCLEAR = 860,

        /// <summary>Oil and natural gas industry</summary>
        /// <remarks>Workers involved in the exploration, drilling and production of oil and natural gas, at both on and off-shore locations.</remarks>
        [XmlEnum("861")]
        OLI_EMPTYPE_OILGAS = 861,

        /// <summary>Political appointments</summary>
        /// <remarks>Embassy personnel, foreign diplomats and governmental officials.</remarks>
        [XmlEnum("862")]
        OLI_EMPTYPE_POLITICAL = 862,

        /// <summary>Professional athletes</summary>
        /// <remarks>Those whose primary avocation is that of a paid athlete.</remarks>
        [XmlEnum("863")]
        OLI_EMPTYPE_PROATHLETES = 863,

        /// <summary>Lumberman</summary>
        /// <remarks>Boom men, high climbers, raftsmen, riggers, rivermen, topmen</remarks>
        [XmlEnum("864")]
        OLI_EMPTYPE_LUMBERMAN = 864,

        /// <summary>Student</summary>
        /// <remarks>One who is enrolled or attends classes at a school, college, or university on a full time basis</remarks>
        [XmlEnum("865")]
        OLI_EMPTYPE_STUDENT = 865,

        /// <summary>Homemaker</summary>
        /// <remarks>One who manages a household, as one's main daily activity</remarks>
        [XmlEnum("866")]
        OLI_EMPTYPE_HOMEMAKER = 866,

        /// <summary>Actor/Actress</summary>
        [XmlEnum("867")]
        OLI_EMPTYPE_ACTOR = 867,

        /// <summary>Automobile Racer</summary>
        [XmlEnum("868")]
        OLI_EMPTYPE_AUTORACER = 868,

        /// <summary>Bookmaker</summary>
        /// <remarks>Gambler - taker of wagers</remarks>
        [XmlEnum("869")]
        OLI_EMPTYPE_BOOKMAKER = 869,

        /// <summary>Bridge Worker</summary>
        [XmlEnum("870")]
        OLI_EMPTYPE_BRIDGEWKR = 870,

        /// <summary>Caisson Worker</summary>
        [XmlEnum("871")]
        OLI_EMPTYPE_CAISSON = 871,

        /// <summary>Dancer</summary>
        [XmlEnum("872")]
        OLI_EMPTYPE_DANCER = 872,

        /// <summary>Disc Jockey</summary>
        [XmlEnum("873")]
        OLI_EMPTYPE_DJ = 873,

        /// <summary>Entertainer</summary>
        [XmlEnum("874")]
        OLI_EMPTYPE_ENTERTAINER = 874,

        /// <summary>Exerciser</summary>
        [XmlEnum("875")]
        OLI_EMPTYPE_EXERCISER = 875,

        /// <summary>Iron Worker</summary>
        [XmlEnum("876")]
        OLI_EMPTYPE_IRONWKR = 876,

        /// <summary>Jockey</summary>
        [XmlEnum("877")]
        OLI_EMPTYPE_JOCKEY = 877,

        /// <summary>Lineman</summary>
        [XmlEnum("878")]
        OLI_EMPTYPE_LINEMAN = 878,

        /// <summary>Missile Worker</summary>
        [XmlEnum("879")]
        OLI_EMPTYPE_MISSILEWKR = 879,

        /// <summary>Model</summary>
        [XmlEnum("880")]
        OLI_EMPTYPE_MODEL = 880,

        /// <summary>Motorcycle Racer</summary>
        [XmlEnum("881")]
        OLI_EMPTYPE_MOTORACER = 881,

        /// <summary>Professional Racer</summary>
        [XmlEnum("882")]
        OLI_EMPTYPE_PRORACER = 882,

        /// <summary>Rodeo Performer</summary>
        [XmlEnum("883")]
        OLI_EMPTYPE_RODEO = 883,

        /// <summary>Ship Hull Worker</summary>
        [XmlEnum("884")]
        OLI_EMPTYPE_SHIPHULLWKR = 884,

        /// <summary>Stable Hand</summary>
        [XmlEnum("885")]
        OLI_EMPTYPE_STABLEHAND = 885,

        /// <summary>Steeplejack</summary>
        /// <remarks>One whose work is building smokestacks, towers, or steeples or climbing up the outside of such structures to paint and make repairs.</remarks>
        [XmlEnum("886")]
        OLI_EMPTYPE_STEEPLEJACK = 886,

        /// <summary>Subway Worker</summary>
        [XmlEnum("887")]
        OLI_EMPTYPE_SUBWAYWKR = 887,

        /// <summary>Tower Erector</summary>
        [XmlEnum("888")]
        OLI_EMPTYPE_TOWERERECTOR = 888,

        /// <summary>Trotting Horse Driver</summary>
        [XmlEnum("889")]
        OLI_EMPTYPE_TROTTINGDRV = 889,

        /// <summary>Tunnel Worker</summary>
        [XmlEnum("890")]
        OLI_EMPTYPE_TUNNELWKR = 890,

        /// <summary>Other</summary>
        [XmlEnum("2147483647")]
        OLI_OTHER = 2147483647,
    }
}
