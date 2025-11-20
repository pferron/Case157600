using log4net.Config;
using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("IllustrationValuesModelTester")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Woodmen of the World")]
[assembly: AssemblyProduct("IllustrationValuesModelTester")]
[assembly: AssemblyCopyright("Copyright © Woodmen of the World 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("cd653826-896e-46a3-8fd3-1f6feb4cdc03")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.*")]
[assembly: AssemblyFileVersion("1.0.0")]
[assembly: NeutralResourcesLanguageAttribute("en-US")]
[assembly: CLSCompliant(true)]
[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
