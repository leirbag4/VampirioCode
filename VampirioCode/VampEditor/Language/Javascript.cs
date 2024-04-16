using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace VampEditor.Language
{
    public class Javascript : LanguageBase
    {
        private const String JS_VALUE_PROPERTIES =              "Infinity NaN undefined null ";
        private const String JS_FUNCTION_PROPERTIES =           "btoa atob eval uneval isFinite isNaN parseFloat parseInt decodeURI decodeURIComponent encodeURI encodeURIComponent ";
        private const String JS_FUNDAMENTAL_OBJECTS =           "Object Function Boolean Symbol EvalError InternalError ReferenceError SyntaxError TypeError URIError ";
        private const String JS_NUMBER_AND_DATES =              "Number Math Date ";
        private const String JS_COMMON_TEXT_PROCESSING =        "String RegExp ";
        private const String JS_INDEXED_COLLECTIONS =           "Array Int8Array Uint8Array Uint8ClampedArray Int16Array Uint16Array Int32Array Uint32Array Float32Array Float64Array ";
        private const String JS_KEYED_COLLECTIONS =             "Map Set WeakMap WearkSet ";
        private const String JS_STRUCTURED_DATA =               "ArrayBuffer DataView JSON ";
        private const String JS_CONTROL_ABSTRACTION_OBJECTS =   "Promise Generator GeneratorFunction ";
        private const String JS_REFLECTION =                    "Reflect Proxy ";
        private const String JS_INTERNATIONALIZATION =          "Intl Intl.Collator Intl.DateTimeFormat Intl.NumberFormat ";
        private const String JS_OTHERS =                        "console arguments alert";
        private static String JS_COMMON_CLASSES =               JS_VALUE_PROPERTIES + JS_FUNCTION_PROPERTIES + JS_FUNDAMENTAL_OBJECTS + JS_NUMBER_AND_DATES + JS_COMMON_TEXT_PROCESSING + JS_INDEXED_COLLECTIONS + JS_KEYED_COLLECTIONS + JS_STRUCTURED_DATA + JS_CONTROL_ABSTRACTION_OBJECTS + JS_REFLECTION + JS_INTERNATIONALIZATION + JS_OTHERS;
        private static String JS_LANG_KEYWORDS =                "async do if in for let new try var case else enum eval null this true void with await break catch class const false super throw while yield delete export import public return static switch typeof default extends finally package private continue debugger function arguments interface protected implements instanceof";
        
        private static List<String> JS_EXTRA_CLASSES = new List<String>();



        protected override void OnActivate(StyleMode style)
        {

            if (style == StyleMode.Lite)
            {



            }
            else if (style == StyleMode.Dark)
            {

                editor.LexerName = "cpp";

                //
                // This Should be before 'StyleClearAll' to work!!!
                //
                SetFontSyle();
                Styles[Style.Default].BackColor = CColor(39, 40, 34);

                // clear command
                editor.StyleClearAll();


                // Custom Style
                Styles[Style.Cpp.Identifier].ForeColor =        CColor(215, 215, 215); // any other text
                                                                                //Styles[Style.Cpp.Default].ForeColor =           Color.Red; //DO NOTHING??? BUG???
                Styles[Style.Cpp.Comment].ForeColor =           CColor(128, 233, 88); // Green
                Styles[Style.Cpp.CommentLine].ForeColor =       CColor(128, 233, 88);//CColor(87, 166, 74);  // Green
                Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128); // Gray
                Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                Styles[Style.Cpp.Word].ForeColor =              CColor(255, 60, 85); //CColor(31, 144, 255);// CColor(57, 135, 214);
                Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 176);
                Styles[Style.Cpp.String].ForeColor =            CColor(86, 226, 145);
                Styles[Style.Cpp.StringEol].ForeColor =         CColor(214, 175, 90);   // string with no closed quotation marks -> ["start string]
                Styles[Style.Cpp.Character].ForeColor =         CColor(109, 205, 172);
                Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);//CColor(163, 21, 21); // Red
                Styles[Style.Cpp.Operator].ForeColor =          CColor(195, 171, 243);
                Styles[Style.Cpp.Preprocessor].ForeColor =      Color.Maroon;
                



                //IndentationGuides = IndentView.LookBoth;

                //editor.Line = Color.Red;

                editor.SetKeywords(0, JS_LANG_KEYWORDS);

                string classes = "";

                for (int a = 0; a < JS_EXTRA_CLASSES.Count; a++)
                    classes += JS_EXTRA_CLASSES[a] + " ";

                editor.SetKeywords(1, classes + JS_COMMON_CLASSES);
                //editor.SetKeywordsSafe(1, classes + CSHARP_COMMON_CLASSES);


                SetFoldMarginStyle();
                EnableCodeFolding();
                SetSelctionStyle();
                SetLinesNumber(true, 40);
            }

        }


    }
}
