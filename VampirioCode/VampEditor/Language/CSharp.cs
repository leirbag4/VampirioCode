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

        private static String CSHARP_COMMON_CLASSES =       "Dictionary List String Object Boolean Decimal Double Char Int16 Int32 Int64 UInt16 UInt32 UInt64";
        private static String CSHARP_COMMON_CLASSES_2 =     "Console Math DateTime Exception IO Threading";
        private static String CSHARP_LANG_KEYWORDS =        "where var get set value bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while";
        private static List<String> CSHARP_EXTRA_CLASSES =  new List<String>();

        protected override void OnActivate(StyleMode style)
        {

            if (style == StyleMode.Lite)
            {



            }
            else if (style == StyleMode.Dark)
            {


                //           Styles[Style.Default].BackColor = CColor(39, 40, 34);
                /*StyleClearAll();

                SetSelectionBackColor(true, CColor(73, 72, 62));
                CaretLineBackColorAlpha = 256;

                CaretForeColor = Color.White;
                CaretLineBackColor = CColor(15, 15, 15);*/

                /*            Styles[Style.Cpp.Identifier].ForeColor =        CColor(235, 235, 235);
                            Styles[Style.Cpp.Default].ForeColor =           Color.Red; //DO NOTHING??? BUG???
                            Styles[Style.Cpp.Comment].ForeColor =           CColor(0, 178, 45); // Green
                            Styles[Style.Cpp.CommentLine].ForeColor =       CColor(0, 178, 45);//CColor(87, 166, 74);  // Green
                            Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128); // Gray
                            Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                            Styles[Style.Cpp.Word].ForeColor =              CColor(31, 144, 255);// CColor(57, 135, 214);
                            Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 176);
                            Styles[Style.Cpp.String].ForeColor =            CColor(214, 157, 65);
                            Styles[Style.Cpp.Character].ForeColor =         CColor(163, 21, 21);
                            Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);//CColor(163, 21, 21); // Red
                            Styles[Style.Cpp.StringEol].BackColor =         Color.Pink;
                            Styles[Style.Cpp.Operator].ForeColor =          Color.White;
                            Styles[Style.Cpp.Preprocessor].ForeColor =      Color.Maroon;

                            //IndentationGuides = IndentView.LookBoth;
                            Styles[Style.BraceLight].BackColor =            CColor(50, 84, 180);
                            Styles[Style.BraceLight].ForeColor =            CColor(130, 130, 130);
                            Styles[Style.BraceBad].BackColor =              CColor(50, 84, 180);
                            Styles[Style.BraceBad].ForeColor =              CColor(170, 170, 170);*/

                /*String font = "Sanserif";
                Styles[Style.Cpp.Identifier].Font =    font;
                Styles[Style.Cpp.Default].Font =       font;
                Styles[Style.Cpp.Comment].Font =       font;
                Styles[Style.Cpp.CommentLine].Font =   font;
                Styles[Style.Cpp.CommentLineDoc].Font =font;
                Styles[Style.Cpp.Number].Font =        font;
                Styles[Style.Cpp.Word].Font =          font;
                Styles[Style.Cpp.Word2].Font =         font;
                Styles[Style.Cpp.String].Font =        font;
                Styles[Style.Cpp.Character].Font =     font;
                Styles[Style.Cpp.Verbatim].Font =      font;
                Styles[Style.Cpp.StringEol].Font =     font;
                Styles[Style.Cpp.Operator].Font =      font;
                Styles[Style.Cpp.Preprocessor].Font =  font;*/

                /*// Margin and Folding Style
                SET_MARGIN_AND_FOLDING_STYLE_DARK();

                ENABLE_CODE_FOLDING();
                // Set the keywords
                //mat2 mat3 mat4 vec2 vec3 vec4
                //GL 
                SetKeywords(0, CSHARP_LANG_KEYWORDS);
                refreshKeywordClasses();*/





               /* editor.StyleResetDefault();
                Styles[Style.Default].Font = "Consolas";
                Styles[Style.Default].Size = 8;
                editor.StyleClearAll();

                Styles[ScintillaNET.Style.Default].BackColor = Color.FromArgb(39, 40, 34);
                Styles[ScintillaNET.Style.Default].ForeColor = Color.FromArgb(39, 40, 34);

                editor.SetSelectionBackColor(true, CColor(73, 72, 62));
                editor.CaretLineBackColorAlpha = 256;

                editor.CaretForeColor = Color.White;
                editor.CaretLineBackColor = CColor(15, 15, 15);

                Styles[Style.Cpp.Default].ForeColor = CColor(235, 0, 0);
                Styles[Style.Cpp.Default].BackColor = CColor(235, 0, 0);
                //Styles[Style.Cpp.Identifier].ForeColor = CColor(235, 235, 235);

                Styles[Style.Cpp.String].BackColor = CColor(0, 255, 0);*/



                editor.LexerName = "cpp";

                //Styles[ScintillaNET.Style.Default].BackColor = Color.FromArgb(39, 40, 34);
                //Styles[ScintillaNET.Style.Default].ForeColor = Color.FromArgb(39, 40, 34);

                Styles[Style.Default].Font = "Consolas";
                Styles[Style.Default].Size = 10;

                //
                // This Should be before 'StyleClearAll' to work!!!
                //
                Styles[Style.Default].BackColor = CColor(39, 40, 34);
                


                editor.StyleClearAll();
                //editor.StyleResetDefault();
                
                //editor.Styles[ScintillaNET.Style.Default].BackColor = Color.Red;

                editor.SetSelectionBackColor(true, CColor(73, 72, 62));
                
                editor.CaretLineBackColorAlpha = 256;
                editor.CaretForeColor = Color.White;
                editor.CaretLineBackColor = CColor(15, 15, 15);


                //SetForcedBackColor(CColor(39, 40, 34));
                Styles[Style.Default].BackColor = CColor(39, 40, 34);
                


                Styles[Style.Cpp.Identifier].ForeColor =        CColor(215, 215, 215); // any other text
                            //Styles[Style.Cpp.Default].ForeColor =           Color.Red; //DO NOTHING??? BUG???
                            Styles[Style.Cpp.Comment].ForeColor =           CColor(0, 178, 45); // Green
                            Styles[Style.Cpp.CommentLine].ForeColor =       CColor(0, 178, 45);//CColor(87, 166, 74);  // Green
                            Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128); // Gray
                            Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                            Styles[Style.Cpp.Word].ForeColor =              CColor(170, 60, 85); //CColor(31, 144, 255);// CColor(57, 135, 214);
                            Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 176);
                            Styles[Style.Cpp.String].ForeColor =            CColor(214, 157, 65);
                            Styles[Style.Cpp.Character].ForeColor =         CColor(163, 21, 21);
                            Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);//CColor(163, 21, 21); // Red
                            Styles[Style.Cpp.StringEol].BackColor =         Color.Pink;
                            Styles[Style.Cpp.Operator].ForeColor =          Color.White;
                            Styles[Style.Cpp.Preprocessor].ForeColor =      Color.Maroon;

                

                            //IndentationGuides = IndentView.LookBoth;
                            Styles[Style.BraceLight].BackColor =            CColor(50, 84, 180);
                            Styles[Style.BraceLight].ForeColor =            CColor(130, 130, 130);
                            Styles[Style.BraceBad].BackColor =              CColor(50, 84, 180);
                            Styles[Style.BraceBad].ForeColor =              CColor(170, 170, 170);

                //editor.Line = Color.Red;

                editor.SetKeywords(0, CSHARP_LANG_KEYWORDS);

                string classes = "";

                for (int a = 0; a < CSHARP_EXTRA_CLASSES.Count; a++)
                    classes += CSHARP_EXTRA_CLASSES[a] + " ";

                editor.SetKeywords(1, classes + CSHARP_COMMON_CLASSES + " " + CSHARP_COMMON_CLASSES_2);
                //editor.SetKeywordsSafe(1, classes + CSHARP_COMMON_CLASSES);


                SetFoldMarginStyle();
                EnableCodeFolding();

                SetLinesNumber(true, 40);
            }

        }

        

        

    }
}
