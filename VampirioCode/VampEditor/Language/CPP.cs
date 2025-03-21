﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace VampEditor.Language
{
    public class CPP : LanguageBase
    {
        private const String CPP_STD_COMMON_CLASSES_STRUCTS = "string_view string vector fstream ifstream ofstream rotl rotr pair tuple map set list array deque queue stack priority_queue forward_list unordered_map unordered_set unordered_multimap unordered_multiset multimap multiset iterator function unique_ptr shared_ptr weak_ptr atomic mutex condition_variable";


        private const String CPP_CONTROL_STATEMENTS =   "if else goto case break continue for do while return switch default ";
        private const String CPP_COMMONS =              "malloc free cout endl cin nullptr null";
        
        private const String CPP_TYPES =                "bool int double float short signed long void char wchar_t ";
        private const String CPP_TYPES_2 =              "uint8_t int8_t uint16_t int16_t uint32_t int32_t uint64_t int64_t size_t ";
        private const String CPP_STRUCT_AND_ARR =       "this class delete new using struct enum namespace ";
        private const String CPP_QUALIFIERS =           "public private protected static virtual override ";
        private const String CPP_OTHERS_1 =             "false true try catch inline throw ";
        private const String CPP_OTHERS_2 =             "unsigned const ";
        private const String CPP_OTHERS_3 =             "decltype constexpr volatile asm friend operator template mutable explicit static_cast const_cast dynamic_cast typeid typename auto register sizeof typedef union extern reinterpret_cast";
        private static String CPP_LANG_KEYWORDS =       CPP_TYPES + CPP_TYPES_2 + CPP_STRUCT_AND_ARR + CPP_QUALIFIERS + CPP_OTHERS_1 + CPP_OTHERS_2 + CPP_OTHERS_3;

        private static List<String> CPP_EXTRA_CLASSES = new List<String>();
        
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
                Styles[Style.Cpp.Comment].ForeColor =           CColor(0, 178, 45);                 
                Styles[Style.Cpp.CommentLine].ForeColor =       CColor(0, 178, 45);                 
                Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128);              
                Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                Styles[Style.Cpp.Word].ForeColor =              CColor(170, 60, 85);    // void public static             //CColor(31, 144, 255);// CColor(57, 135, 214);
                Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 176);   // string vector fstream
                Styles[Style.Cpp.String].ForeColor =            CColor(214, 157, 65);
                Styles[Style.Cpp.StringEol].ForeColor =         CColor(214, 175, 90);   // string with no closed quotation marks -> ["start string]
                Styles[Style.Cpp.Character].ForeColor =         CColor(163, 21, 21);
                Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);               
                Styles[Style.Cpp.Operator].ForeColor =          CColor(170, 170, 200);  // - + = ( )
                Styles[Style.Cpp.Preprocessor].ForeColor =      CColor(110, 88, 205);//CColor(110, 62, 253); // CColor(155, 0, 0);                  //Color.Maroon;// CColor(105, 0, 140);    // #define <iostream>
                

                Styles[19].ForeColor =                          CColor(179, 153, 255);   // if else do while for

                SetInactivePreprocessor(CColor(100, 100, 100));

                //IndentationGuides = IndentView.LookBoth;

                editor.SetKeywords(0, CPP_LANG_KEYWORDS);
                editor.SetKeywords(3, CPP_CONTROL_STATEMENTS + CPP_COMMONS);

                string classes = "";

                for (int a = 0; a < CPP_EXTRA_CLASSES.Count; a++)
                    classes += CPP_EXTRA_CLASSES[a] + " ";

                editor.SetKeywords(1, classes + CPP_STD_COMMON_CLASSES_STRUCTS);
                //editor.SetKeywordsSafe(1, classes + CSHARP_COMMON_CLASSES);


                SetFoldMarginStyle();
                EnableCodeFolding();
                SetSelctionStyle();
                SetLinesNumber(true, 40);
            }

        }

        private void SetInactivePreprocessor(Color color)
        {
            int[] styleArr = new int[] {    Style.Cpp.Identifier, Style.Cpp.Comment, Style.Cpp.CommentLine, Style.Cpp.CommentLineDoc, Style.Cpp.Number, Style.Cpp.Word, 
                                            Style.Cpp.Word2, Style.Cpp.String, Style.Cpp.Character, Style.Cpp.Verbatim, Style.Cpp.StringEol, Style.Cpp.Operator, Style.Cpp.Preprocessor, 19 };

            foreach (int style in styleArr)
                PreprocessStyle(style).ForeColor = color;
        }
    }
}
