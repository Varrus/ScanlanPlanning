﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScanlanPlanning.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ScanlanPlanning.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to SELECT c.WO, c.StartQty, c.Assembly, c.ceaQty, (c.ceaQty/(c.startQty*c.BOX)) AS ceaPercentage, c.boxQty, (c.boxQty/c.startQty) AS boxPercentage
        ///FROM
        ///(SELECT  dbo.WO.WO, 
        ///		WO.WorkOrderNumber, 
        ///		WO.StartQty, 
        ///		WO.Assembly,  
        ///		Standards.BOX,
        ///		(SELECT SUM(ScanData.Quantity) 
        ///			
        ///			FROM
        ///				ScanData
        ///			WHERE
        ///				(ScanData.Task = &apos;CEA&apos; AND (WO.WorkOrderNumber = ScanData.WorkOrderNumber))
        ///		) AS ceaQty,
        ///		(SELECT SUM(ScanData.Quantity)
        ///			FROM
        ///				ScanData	
        ///			WHERE
        ///				(ScanData.Task = &apos;Bo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string bardQuery {
            get {
                return ResourceManager.GetString("bardQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT c.WO, c.StartQty, c.Assembly, c.[Mfg Family], c.ceaQty, (c.ceaQty/(c.startQty*c.BOX)) AS ceaPercentage, c.boxQty, (c.boxQty/c.startQty) AS boxPercentage
        ///FROM
        ///(SELECT  dbo.WO.WO, 
        ///		WO.WorkOrderNumber, 
        ///		WO.StartQty, 
        ///		WO.Assembly, 
        ///		Standards.[Mfg Family], 
        ///		Standards.BOX,
        ///		(SELECT SUM(ScanData.Quantity) 
        ///			
        ///			FROM
        ///				ScanData
        ///			WHERE
        ///				(ScanData.Task = &apos;CEA&apos; AND (WO.WorkOrderNumber = ScanData.WorkOrderNumber))
        ///		) AS ceaQty,
        ///		(SELECT SUM(ScanData.Quantity)
        ///			FROM
        ///				Sc [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string sqlQuery {
            get {
                return ResourceManager.GetString("sqlQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT c.WO, c.StartQty, c.Assembly, c.ceaQty, (c.ceaQty/(c.startQty*c.BOX)) AS ceaPercentage, c.boxQty, (c.boxQty/c.startQty) AS boxPercentage
        ///FROM
        ///(SELECT  dbo.WO.WO, 
        ///		WO.WorkOrderNumber, 
        ///		WO.StartQty, 
        ///		WO.Assembly,  
        ///		Standards.BOX,
        ///		(SELECT SUM(ScanData.Quantity) 
        ///			
        ///			FROM
        ///				ScanData
        ///			WHERE
        ///				(ScanData.Task = &apos;CEA&apos; AND (WO.WorkOrderNumber = ScanData.WorkOrderNumber))
        ///		) AS ceaQty,
        ///		(SELECT SUM(ScanData.Quantity)
        ///			FROM
        ///				ScanData	
        ///			WHERE
        ///				(ScanData.Task = &apos;Bo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string vencloseQuery {
            get {
                return ResourceManager.GetString("vencloseQuery", resourceCulture);
            }
        }
    }
}