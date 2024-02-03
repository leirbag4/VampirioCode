using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace VampEditor.Language
{
    public class CSharp : LanguageBase
    {
        private static String CSHARP_LANG_KEYWORDS_CONTROL_FLOW =   "if else do while for foreach switch case break continue return goto try";

        private static String CSHARP_COMMON_CLASSES =               "Dictionary List String Object Boolean Decimal Double Char Int16 Int32 Int64 UInt16 UInt32 UInt64";
        private static String CSHARP_COMMON_CLASSES_2 =             "Console File Math DateTime Exception IO Thread";
        private static String CSHARP_LANG_KEYWORDS =                "where var get set value bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void abstract as base checked default delegate event explicit extern false finally fixed implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref sealed sizeof stackalloc this throw true typeof unchecked unsafe using virtual";
        private static List<String> CSHARP_EXTRA_CLASSES =          new List<String>();

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
                Styles[Style.Cpp.Comment].ForeColor =           CColor(0, 178, 45); // Green
                Styles[Style.Cpp.CommentLine].ForeColor =       CColor(0, 178, 45);//CColor(87, 166, 74);  // Green
                Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128); // Gray
                Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                Styles[Style.Cpp.Word].ForeColor =              CColor(140, 100, 235);  // void public static        //CColor(170, 60, 85); //CColor(31, 144, 255);// CColor(57, 135, 214);
                Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 176);
                Styles[Style.Cpp.String].ForeColor =            CColor(214, 157, 65);
                Styles[Style.Cpp.Character].ForeColor =         CColor(163, 21, 21);
                Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);//CColor(163, 21, 21); // Red
                Styles[Style.Cpp.StringEol].BackColor =         Color.Pink;
                Styles[Style.Cpp.Operator].ForeColor =          CColor(170, 170, 200);  // - + = ( )
                Styles[Style.Cpp.Preprocessor].ForeColor =      Color.Maroon;

                Styles[19].ForeColor =                          CColor(200, 153, 255);   // if else do while for

                //IndentationGuides = IndentView.LookBoth;

                editor.SetKeywords(0, CSHARP_LANG_KEYWORDS);
                editor.SetKeywords(3, CSHARP_LANG_KEYWORDS_CONTROL_FLOW);

                string classes = "";

                for (int a = 0; a < CSHARP_EXTRA_CLASSES.Count; a++)
                    classes += CSHARP_EXTRA_CLASSES[a] + " ";

                
                editor.SetKeywords(1, classes + CSHARP_COMMON_CLASSES + " " + CSHARP_COMMON_CLASSES_2);
                //editor.SetKeywordsSafe(1, classes + CSHARP_COMMON_CLASSES);


                SetFoldMarginStyle();
                EnableCodeFolding();
                SetSelctionStyle();
                SetLinesNumber(true, 40);
            }

        }

        

        

    }
}
