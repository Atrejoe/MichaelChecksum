﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MichaelChecksum.Console {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MichaelChecksum.Console.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Calculating hash for: {0}.
        /// </summary>
        internal static string Calculating_Hash {
            get {
                return ResourceManager.GetString("Calculating_Hash", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Visit https://michaelchecksum.com for online checksum calculation..
        /// </summary>
        internal static string CallToAction_Visit_Website {
            get {
                return ResourceManager.GetString("CallToAction_Visit_Website", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to read file : {0}.
        /// </summary>
        internal static string FailedToReadFile {
            get {
                return ResourceManager.GetString("FailedToReadFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SHA1Mone!:{0}.
        /// </summary>
        internal static string Hash_Result_SHA1Mone {
            get {
                return ResourceManager.GetString("Hash_Result_SHA1Mone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File &apos;{0}&apos; does not exist.
        /// </summary>
        internal static string Input_Validation_File_does_not_exists {
            get {
                return ResourceManager.GetString("Input_Validation_File_does_not_exists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please specify a file to check, this can be a local file, UNC path or Url..
        /// </summary>
        internal static string Input_Validation_Missing_File_name {
            get {
                return ResourceManager.GetString("Input_Validation_Missing_File_name", resourceCulture);
            }
        }
    }
}
