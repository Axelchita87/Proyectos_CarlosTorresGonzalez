﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCTS.DataAccess.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class GetCountryResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GetCountryResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyCTS.DataAccess.Resources.GetCountryResources", typeof(GetCountryResources).Assembly);
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
        ///   Looks up a localized string similar to CatCitCouId.
        /// </summary>
        internal static string PARAM_CATCITCOUID {
            get {
                return ResourceManager.GetString("PARAM_CATCITCOUID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CatCouName.
        /// </summary>
        internal static string PARAM_CATCOUNAME {
            get {
                return ResourceManager.GetString("PARAM_CATCOUNAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @city.
        /// </summary>
        internal static string PARAM_CITY {
            get {
                return ResourceManager.GetString("PARAM_CITY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Country.
        /// </summary>
        internal static string PARAM_COUNTRY {
            get {
                return ResourceManager.GetString("PARAM_COUNTRY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetCountry.
        /// </summary>
        internal static string SP_GET_COUNTRY {
            get {
                return ResourceManager.GetString("SP_GET_COUNTRY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetCountryByCity.
        /// </summary>
        internal static string SP_GetCountryByCity {
            get {
                return ResourceManager.GetString("SP_GetCountryByCity", resourceCulture);
            }
        }
    }
}
