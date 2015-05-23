﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Plainion.WhiteRabbit.Presentation.Reports
{
    using Plainion.WhiteRabbit;
    using Plainion.WhiteRabbit.Model;
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class WeekReport : WeekReportBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n\r\n<html>\r\n<head>\r\n    <title>WhiteRabbit</title>\r\n</head>\r\n<body>\r\n    <center>" +
                    "\r\n        <h2>\r\n            WhiteRabbit</h2>\r\n    </center>\r\n    <center>\r\n     " +
                    "   <h4>\r\n            ");
            
            #line 19 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Begin.Date.ToShortDateString()));
            
            #line default
            #line hidden
            this.Write(" - ");
            
            #line 19 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(End.Date.ToShortDateString()));
            
            #line default
            #line hidden
            this.Write("\r\n        </h4>\r\n    </center>\r\n    <table border=\"0\" cellpadding=\"4\" cellspacing" +
                    "=\"0\">\r\n        <tr>\r\n            <th>\r\n                Category\r\n            </t" +
                    "h>\r\n            <th>\r\n                Time\r\n            </th>\r\n        </tr>\r\n  " +
                    "      ");
            
            #line 31 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 
TimeSpan sum = new TimeSpan();
foreach ( string cat in Overview.Keys )
{
    if ( cat == "unknown" )
    {
        continue;
    }
        
            
            #line default
            #line hidden
            this.Write("        <tr>\r\n            <td>\r\n                ");
            
            #line 42 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cat));
            
            #line default
            #line hidden
            this.Write("\r\n            </td>\r\n            <td>\r\n                ");
            
            #line 45 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Overview[cat].ToReportString()));
            
            #line default
            #line hidden
            this.Write("\r\n            </td>\r\n        </tr>\r\n        ");
            
            #line 48 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 
        sum += Overview[cat];
        }
        
            
            #line default
            #line hidden
            this.Write("        \r\n        ");
            
            #line 53 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 if ( Overview["unknown"] != TimeSpan.Zero ) 
        {
        
            
            #line default
            #line hidden
            this.Write("        <tr>\r\n            <td>\r\n                <b>Unassigned</b>\r\n            </" +
                    "td>\r\n            <td>\r\n                ");
            
            #line 61 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Overview["unknown"].ToReportString()));
            
            #line default
            #line hidden
            this.Write("\r\n            </td>\r\n        </tr>\r\n        ");
            
            #line 64 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 }
            
            #line default
            #line hidden
            this.Write("        <tr>\r\n            <td style=\"border-top:solid 2px #060\">\r\n               " +
                    " <b>Sum</b>\r\n            </td>\r\n            <td style=\"border-top:solid 2px #060" +
                    "\">\r\n                ");
            
            #line 70 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sum.ToReportString()));
            
            #line default
            #line hidden
            this.Write("\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    \r\n    <br />\r\n    \r\n    <ta" +
                    "ble cellpadding=\"4\" cellspacing=\"0\">\r\n        <tr>\r\n            <th>Category</th" +
                    ">\r\n            ");
            
            #line 80 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"

            var sums = new Dictionary<DateTime, TimeSpan>();
            for ( var date = Begin; date <= End; date = date.AddDays( 1 ) )
            {
                sums[ date ] = TimeSpan.Zero;
            
            
            #line default
            #line hidden
            this.Write("            <th>");
            
            #line 86 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(date.Day));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 86 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(date.Month));
            
            #line default
            #line hidden
            this.Write(".</th>\r\n            ");
            
            #line 87 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 }
            
            #line default
            #line hidden
            this.Write("        </tr>\r\n        ");
            
            #line 89 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 
        foreach ( var cat in Overview.Keys ) 
        { 
        
            
            #line default
            #line hidden
            this.Write("            <tr>\r\n                <td>");
            
            #line 94 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cat));
            
            #line default
            #line hidden
            this.Write("</td>\r\n        ");
            
            #line 95 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 for ( var date = Begin; date <= End; date = date.AddDays( 1 ) ) 
           { 
               if ( Details[ date ].ContainsKey( cat ) )
               {
                    sums[ date ] += Details[ date ][ cat ];
        
            
            #line default
            #line hidden
            this.Write("                <td align=\"center\">");
            
            #line 101 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Details[ date ][ cat ].ToReportString()));
            
            #line default
            #line hidden
            this.Write("</td>\r\n        ");
            
            #line 102 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"

               }
               else
               {
        
            
            #line default
            #line hidden
            this.Write("               <td align=\"center\">-</td>\r\n        ");
            
            #line 108 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"

               }
        
            
            #line default
            #line hidden
            this.Write("                    \r\n        ");
            
            #line 112 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            </tr>\r\n        ");
            
            #line 114 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        \r\n        <tr>\r\n            <td style=\"border-top:solid 2px #060\">\r\n     " +
                    "           <b>Sum</b>\r\n            </td>\r\n        ");
            
            #line 120 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 for ( var date = Begin; date <= End; date = date.AddDays( 1 ) ) { 
            
            #line default
            #line hidden
            this.Write("            <td align=\"center\" style=\"border-top:solid 2px #060\">\r\n              " +
                    "  ");
            
            #line 122 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sums[ date ].ToReportString()));
            
            #line default
            #line hidden
            this.Write("\r\n            </td>\r\n        ");
            
            #line 124 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
} 
            
            #line default
            #line hidden
            this.Write("        </tr>\r\n    </table>\r\n    \r\n    <br />\r\n    \r\n    ");
            
            #line 130 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 if ( !IsComplete ) 
{
    
            
            #line default
            #line hidden
            this.Write("    <font color=\"red\">The report is not complete because the data of the day is n" +
                    "ot complete.</font>\r\n    ");
            
            #line 134 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 }
            
            #line default
            #line hidden
            this.Write("</body>\r\n</html>\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 138 "D:\seb\workspace\Plainion\Plainion.Bees\src\Plainion.WhiteRabbit\Presentation\Reports\WeekReport.tt"
 
public DateTime Begin { get; set; }
public DateTime End { get; set; }
public Dictionary<string, TimeSpan> Overview { get; set; }
public Dictionary<DateTime, Dictionary<string, TimeSpan>> Details { get; set; }
public bool IsComplete { get; set; }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class WeekReportBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
