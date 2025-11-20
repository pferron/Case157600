using System.Resources;
using Microsoft.Owin;
using System.Reflection;
using System.Runtime.InteropServices;
using WOW.WoodmenIntegrationService;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Woodmen Integration Service")]
[assembly: AssemblyDescription("Self-hosted WebAPI service for product illustrations, e-App intergration & mobility")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("WoodmenLife")]
[assembly: AssemblyProduct("Woodmen Integration Service")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5042bf6a-6c3b-4340-b6ac-d3f7db7deb40")]

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
[assembly: AssemblyVersion("1.0.30.*")]
[assembly: AssemblyFileVersion("1.0.30")]

[assembly: OwinStartup(typeof(IntegrationServiceStartup))]
[assembly: NeutralResourcesLanguage("en-US")]

