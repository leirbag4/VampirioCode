using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using VampirioCode.UI;

namespace VampEditor.Language
{
    public class HTML : LanguageBase
    {


        private const String JS_VALUE_PROPERTIES = "Infinity NaN undefined null ";
        private const String JS_FUNCTION_PROPERTIES = "btoa atob eval uneval isFinite isNaN parseFloat parseInt decodeURI decodeURIComponent encodeURI encodeURIComponent ";
        private const String JS_FUNDAMENTAL_OBJECTS = "Object Function Boolean Symbol EvalError InternalError ReferenceError SyntaxError TypeError URIError ";
        private const String JS_NUMBER_AND_DATES = "Number Math Date ";
        private const String JS_COMMON_TEXT_PROCESSING = "String RegExp ";
        private const String JS_INDEXED_COLLECTIONS = "Array Int8Array Uint8Array Uint8ClampedArray Int16Array Uint16Array Int32Array Uint32Array Float32Array Float64Array ";
        private const String JS_KEYED_COLLECTIONS = "Map Set WeakMap WearkSet ";
        private const String JS_STRUCTURED_DATA = "ArrayBuffer DataView JSON ";
        private const String JS_CONTROL_ABSTRACTION_OBJECTS = "Promise Generator GeneratorFunction ";
        private const String JS_REFLECTION = "Reflect Proxy ";
        private const String JS_INTERNATIONALIZATION = "Intl Intl.Collator Intl.DateTimeFormat Intl.NumberFormat ";
        private const String JS_OTHERS = "console arguments alert";
        private static String JS_COMMON_CLASSES = JS_VALUE_PROPERTIES + JS_FUNCTION_PROPERTIES + JS_FUNDAMENTAL_OBJECTS + JS_NUMBER_AND_DATES + JS_COMMON_TEXT_PROCESSING + JS_INDEXED_COLLECTIONS + JS_KEYED_COLLECTIONS + JS_STRUCTURED_DATA + JS_CONTROL_ABSTRACTION_OBJECTS + JS_REFLECTION + JS_INTERNATIONALIZATION + JS_OTHERS;
        private static String JS_LANG_KEYWORDS = "get set constructor of async do if in for let new try var case else enum eval null this true void with await break catch class const false super throw while yield delete export import public return static switch typeof default extends finally package private continue debugger function arguments interface protected implements instanceof";


        protected override void OnActivate(StyleMode style)
        {

            if (style == StyleMode.Lite)
            {

                

            }
            else if (style == StyleMode.Dark)
            {

                editor.Lexer = Lexer.Html;
                editor.LexerName = "xml";

                //
                // This Should be before 'StyleClearAll' to work!!!
                //
                SetFontSyle();
                Styles[Style.Default].BackColor = CColor(39, 40, 34);

                // clear command
                editor.StyleClearAll();

                //
                // HTML Style
                //
                Styles[Style.Html.Default].ForeColor = CColor(255, 255, 255); // Styles[Style.Html.Default].ForeColor = CColor(0, 255, 219); //Styles[Style.Html.Default].ForeColor = CColor(203, 255, 0);
                Styles[Style.Html.Tag].ForeColor = CColor(205, 131, 255);
                Styles[Style.Html.TagUnknown].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Attribute].ForeColor = CColor(162, 255, 91);
                Styles[Style.Html.AttributeUnknown].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Number].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.DoubleString].ForeColor = CColor(0, 255, 172);
                Styles[Style.Html.SingleString].ForeColor = CColor(0, 255, 172);
                Styles[Style.Html.Other].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Comment].ForeColor = CColor(121, 119, 131);
                Styles[Style.Html.Entity].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.TagEnd].ForeColor = CColor(205, 131, 255);
                Styles[Style.Html.XmlStart].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.XmlEnd].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Script].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Asp].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.AspAt].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.CData].ForeColor = CColor(255, 167, 165);
                Styles[Style.Html.Question].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.Value].ForeColor = CColor(255, 255, 255);
                Styles[Style.Html.XcComment].ForeColor = CColor(255, 255, 255);



                //
                // JAVASCRIPT
                //
                Styles[Style.JavaScript.Start].ForeColor = Color.Red;
                Styles[Style.JavaScript.Default].ForeColor = Color.Green;
                Styles[Style.JavaScript.Comment].ForeColor = CColor(128, 233, 88);
                Styles[Style.JavaScript.CommentLine].ForeColor = CColor(128, 233, 88);
                Styles[Style.JavaScript.CommentDoc].ForeColor = Color.Yellow;
                Styles[Style.JavaScript.Number].ForeColor = CColor(166, 226, 46);
                Styles[Style.JavaScript.Word].ForeColor = CColor(224, 226, 255);
                Styles[Style.JavaScript.Keyword].ForeColor = CColor(255, 60, 85);
                Styles[Style.JavaScript.DoubleString].ForeColor = CColor(86, 226, 145);
                Styles[Style.JavaScript.SingleString].ForeColor = CColor(86, 226, 145);
                Styles[Style.JavaScript.Symbols].ForeColor = CColor(215, 215, 215);
                Styles[Style.JavaScript.StringEol].ForeColor = Color.LightCoral;
                Styles[Style.JavaScript.Regex].ForeColor = Color.LightPink;


                Styles[21].BackColor = Color.LightGray;


                //
                // CSS
                //
                /*Styles[Style.Css.Default].ForeColor =   Color.Red;
                Styles[Style.Css.Tag].ForeColor =   Color.Red;
                Styles[Style.Css.Class].ForeColor =     Color.Red;
                Styles[Style.Css.PseudoClass].ForeColor =   Color.Red;
                Styles[Style.Css.UnknownPseudoClass].ForeColor =    Color.Red;
                Styles[Style.Css.Operator].ForeColor =  Color.Red;
                Styles[Style.Css.Identifier].ForeColor =    Color.Red;
                Styles[Style.Css.UnknownIdentifier].ForeColor =     Color.Red;
                Styles[Style.Css.Value].ForeColor =     Color.Red;
                Styles[Style.Css.Comment].ForeColor =   Color.Red;
                Styles[Style.Css.Id].ForeColor =    Color.Red;
                Styles[Style.Css.Important].ForeColor =     Color.Red;
                Styles[Style.Css.Directive].ForeColor =     Color.Red;
                Styles[Style.Css.DoubleString].ForeColor =  Color.Red;
                Styles[Style.Css.SingleString].ForeColor =  Color.Red;
                Styles[Style.Css.Identifier2].ForeColor =   Color.Red;
                Styles[Style.Css.Attribute].ForeColor =     Color.Red;
                Styles[Style.Css.Identifier3].ForeColor =   Color.Red;
                Styles[Style.Css.PseudoElement].ForeColor =     Color.Red;
                Styles[Style.Css.ExtendedIdentifier].ForeColor =    Color.Red;
                Styles[Style.Css.ExtendedPseudoClass].ForeColor =   Color.Red;
                Styles[Style.Css.ExtendedPseudoElement].ForeColor =     Color.Red;
                Styles[Style.Css.Media].ForeColor =     Color.Red;
                Styles[Style.Css.Variable].ForeColor =  Color.Red;*/


                //Styles[Style.Cpp.Word].ForeColor = Color.Blue;
                //Styles[Style.Cpp.Word2].ForeColor = Color.Purple;
                //editor.SetKeywords(0, "Array Int8Array Uint8Array Uint8ClampedArray Int16Array");
                
                editor.SetKeywords(1, JS_LANG_KEYWORDS);

                //Styles[HIGHLIGHT_TAG].BackColor = Color.Red;

                //for(int n = 53; n < 350; n++)
                //    Styles[n].ForeColor = Color.Yellow;

                SetFoldMarginStyle();
                EnableCodeFolding();
                SetSelctionStyle();
                SetLinesNumber(true, 40);

                //editor.Lexer = Lexer.Html;

                /*SetProperty("lexer.html.script", "1");
                SetProperty("lexer.html.asp.script", "1");

                //https://github.com/jacobslusser/ScintillaNET/issues/442

                editor.StyleNeeded += (sender, eventArgs) =>
                {
                    XConsole.Alert("yes");
                };*/

                // Config lexer for <script> tags
                //SetProperty("lexer.html.script", "1");
                //SetProperty("asp.default.language", "javascript");

                editor.StyleNeeded += (sender, eventArgs) =>
                {
                    XConsole.Alert("yes");
                };


                // Highlight Configuration for TAGs matching
                editor.Indicators[8].Style = IndicatorStyle.CompositionThick; // IndicatorStyle.CompositionThin; // IndicatorStyle.Plain; // IndicatorStyle.RoundBox;
                editor.Indicators[8].Under = true;
                editor.Indicators[8].ForeColor = Color.FromArgb(38, 147, 255);
                editor.Indicators[8].OutlineAlpha = 90; // 70
                editor.Indicators[8].Alpha = 40;


                // Cursor Events
                editor.UpdateUI += (sender, e) => HighlightTags(editor);
                //editor.DwellStart += (sender, e) => HighlightTags(editor);
                //editor.DwellEnd += (sender, e) => ClearHighlight(editor);

            }

        }

        private void HighlightTags(Scintilla scintilla)
        {
            ClearHighlight(scintilla);

            int currentPos = scintilla.CurrentPosition;
            int currentStyle = scintilla.GetStyleAt(currentPos);

            if (currentStyle == Style.Html.Tag || currentStyle == Style.Html.TagUnknown)
            {
                HighlightMatchingTag(scintilla, currentPos);
            }
        }

        private void ClearHighlight(Scintilla scintilla)
        {
            scintilla.IndicatorCurrent = 8;
            scintilla.IndicatorClearRange(0, scintilla.TextLength);
        }

        private void HighlightMatchingTag(Scintilla scintilla, int currentPos)
        {
            string text = scintilla.Text;

            // Find the start of the current tag
            int tagStart = text.LastIndexOf('<', currentPos);
            if (tagStart == -1) return;

            // Find the end of the current tag
            int tagEnd = text.IndexOf('>', tagStart);
            if (tagEnd == -1) return;

            // Extract the complete tag
            string tag = text.Substring(tagStart, tagEnd - tagStart + 1);

            // Determine if it is a closing tag
            bool isClosingTag = tag.StartsWith("</");

            if (isClosingTag)
            {
                // Closing tag, find the corresponding opening tag
                string openingTag = tag.Replace("</", "<").TrimEnd('>');
                int openTagPos = text.LastIndexOf(openingTag, tagStart - 1);
                if (openTagPos != -1)
                {
                    XConsole.Println("openingTag: " + openingTag);
                    XConsole.Println("tag: " + tag);

                    string newOpen = text.Substring(openTagPos, openingTag.Length + 1);

                    // There's a space or argument ->   <script src='img.png'  on the openingTag
                    if (newOpen.IndexOf(' ') != -1)
                        HighlightTextRange(scintilla, openTagPos, openingTag.Length);
                    // The openingTag is like this <script> with '<' and '>' and no arguments or spaces
                    else
                        HighlightTextRange(scintilla, openTagPos, openingTag.Length + 1);


                    HighlightTextRange(scintilla, tagStart, tagEnd - tagStart + 1);
                }
            }
            else
            {
                // Opening tag, find the corresponding closing tag
                int spaceIndex = tag.IndexOf(' ');
                if (spaceIndex != -1)
                {
                    // There is a space after the tag name, take only the tag name
                    string tagName = tag.Substring(1, spaceIndex - 1); // tagName is the tag name without '<' and ' '
                    string closingTag = $"</{tagName}>";

                    int closeTagPos = text.IndexOf(closingTag, tagEnd);
                    if (closeTagPos != -1)
                    {
                        HighlightTextRange(scintilla, tagStart, tagName.Length + 1);
                        HighlightTextRange(scintilla, closeTagPos, closingTag.Length);
                    }
                }
                else
                {
                    // No space after the tag name, use the whole tag
                    string closingTag = tag.Insert(1, "/");
                    int closeTagPos = text.IndexOf(closingTag, tagEnd);
                    if (closeTagPos != -1)
                    {
                        HighlightTextRange(scintilla, tagStart, tagEnd - tagStart + 1);
                        HighlightTextRange(scintilla, closeTagPos, closingTag.Length);
                    }
                }
            }
        }


        private void HighlightTextRange(Scintilla scintilla, int start, int length)
        {
            scintilla.IndicatorCurrent = 8;
            scintilla.IndicatorFillRange(start, length);
        }


        /*private void SetInactivePreprocessor(Color color)
        {
            int[] styleArr = new int[] {    Style.Cpp.Identifier, Style.Cpp.Comment, Style.Cpp.CommentLine, Style.Cpp.CommentLineDoc, Style.Cpp.Number, Style.Cpp.Word,
                                            Style.Cpp.Word2, Style.Cpp.String, Style.Cpp.Character, Style.Cpp.Verbatim, Style.Cpp.StringEol, Style.Cpp.Operator, Style.Cpp.Preprocessor, 19 };

            foreach (int style in styleArr)
                PreprocessStyle(style).ForeColor = color;
        }*/



    }
}
