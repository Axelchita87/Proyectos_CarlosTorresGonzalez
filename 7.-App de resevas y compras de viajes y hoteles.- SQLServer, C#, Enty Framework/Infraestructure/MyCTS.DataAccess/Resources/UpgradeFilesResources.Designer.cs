﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.4963
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCTS.DataAccess.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso con establecimiento inflexible de tipos, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o vuelva a generar su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UpgradeFilesResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UpgradeFilesResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyCTS.DataAccess.Resources.UpgradeFilesResources", typeof(UpgradeFilesResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso con establecimiento inflexible de tipos.
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
        ///   Busca una cadena traducida similar a Extension.
        /// </summary>
        internal static string PARAM_EXTENSION {
            get {
                return ResourceManager.GetString("PARAM_EXTENSION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a NombreDoc.
        /// </summary>
        internal static string PARAM_NOMBREDOC {
            get {
                return ResourceManager.GetString("PARAM_NOMBREDOC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a UserId.
        /// </summary>
        internal static string PARAM_USERID {
            get {
                return ResourceManager.GetString("PARAM_USERID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a spGetFilesUpgrade.
        /// </summary>
        internal static string SP_GETFILESUPGRADE {
            get {
                return ResourceManager.GetString("SP_GETFILESUPGRADE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a spUpdateCompleteStatusUpgrade.
        /// </summary>
        internal static string SP_UPDATECOMPLETESTATUSUPGRADE {
            get {
                return ResourceManager.GetString("SP_UPDATECOMPLETESTATUSUPGRADE", resourceCulture);
            }
        }
    }
}
