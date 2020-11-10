using MelonLoader;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(DirectionalVoice.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct(DirectionalVoice.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DirectionalVoice.BuildInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("28893deb-734b-4161-926e-5cc6c28ce143")]

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
[assembly: AssemblyVersion(DirectionalVoice.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DirectionalVoice.BuildInfo.Version)]

[assembly: MelonInfo(typeof(DirectionalVoice.DirectionalVoiceMod), DirectionalVoice.BuildInfo.Name, DirectionalVoice.BuildInfo.Version, DirectionalVoice.BuildInfo.Author, DirectionalVoice.BuildInfo.DownloadLink)]
[assembly: MelonGame("VRChat", "VRChat")]