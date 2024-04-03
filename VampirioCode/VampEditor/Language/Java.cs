using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace VampEditor.Language
{
    public class Java : LanguageBase
    {
        private static String JAVA_LANG_KEYWORDS_CONTROL_FLOW =     "if else do while for continue return goto try catch finally switch case break default";

        private static String JAVA_COMMON_CLASSES =                 "String Integer Double Float Boolean Character Object Thread ArrayList HashMap Exception HashSet StringBuilder Arrays Collections LocalDate LocalDateTime Files File Scanner System Iterator Runnable Class IOException LinkedList Executors Optional Stream Vector List";
        private static String JAVA_COMMON_CLASSES_2 =               "Math Date Calendar Random FileReader FileWriter BufferedReader BufferedWriter InputStreamReader OutputStreamWriter StringBuffer Pattern Matcher TimeZone BigDecimal BigInteger Stack Queue PriorityQueue BitSet Hashtable Properties UUID Process Runtime ProcessBuilder InetAddress URL HttpURLConnection URLConnection Socket ServerSocket DatagramSocket URI Charset CharsetEncoder CharsetDecoder Base64 Comparator Enumeration ListIterator Comparable Cloneable Serializable ObjectInputStream ObjectOutputStream InputStream OutputStream FileInputStream FileOutputStream ByteArrayInputStream ByteArrayOutputStream DataInputStream DataOutputStream ObjectInput ObjectOutput ByteArrayOutputStream ByteArrayInputStream ZipFile ZipEntry JarFile JarEntry SimpleDateFormat DateFormat DecimalFormat MessageFormat NumberFormat Locale ResourceBundle Timer";
        private static String JAVA_LANG_KEYWORDS =                  "int float boolean byte char short double long var void new const class private protected public static abstract final enum throw throws this assert exports extends implements import instanceof interface module native package requires strictfp super synchronized transient volatile true false null permits provides record sealed to transitive uses when with yield";
        private static List<String> JAVA_EXTRA_CLASSES =            new List<String>();

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
                Styles[Style.Cpp.Comment].ForeColor =           CColor(140, 198, 45); // Green
                Styles[Style.Cpp.CommentLine].ForeColor =       CColor(140, 198, 45);//CColor(87, 166, 74);  // Green
                Styles[Style.Cpp.CommentLineDoc].ForeColor =    CColor(128, 128, 128); // Gray
                Styles[Style.Cpp.Number].ForeColor =            CColor(166, 226, 46);
                Styles[Style.Cpp.Word].ForeColor =              CColor(70, 70, 235);   // void public static        //CColor(170, 60, 85); //CColor(31, 144, 255);// CColor(57, 135, 214);
                Styles[Style.Cpp.Word2].ForeColor =             CColor(61, 201, 106);     // System
                Styles[Style.Cpp.String].ForeColor =            CColor(50, 178, 145);
                Styles[Style.Cpp.StringEol].ForeColor =         CColor(60, 178, 135);   // string with no closed quotation marks -> ["start string]
                Styles[Style.Cpp.Character].ForeColor =         CColor(60, 198, 135);
                Styles[Style.Cpp.Verbatim].ForeColor =          CColor(214, 157, 65);//CColor(163, 21, 21); // Red
                Styles[Style.Cpp.Operator].ForeColor =          CColor(170, 170, 200);  // - + = ( )
                Styles[Style.Cpp.Preprocessor].ForeColor =      Color.Maroon;

                Styles[19].ForeColor =                          CColor(170, 130, 200);   // if else do while for

                SetInactivePreprocessor(CColor(100, 100, 100));

                //IndentationGuides = IndentView.LookBoth;

                editor.SetKeywords(0, JAVA_LANG_KEYWORDS);
                editor.SetKeywords(3, JAVA_LANG_KEYWORDS_CONTROL_FLOW);

                string classes = "";

                for (int a = 0; a < JAVA_EXTRA_CLASSES.Count; a++)
                    classes += JAVA_EXTRA_CLASSES[a] + " ";

                
                editor.SetKeywords(1, classes + JAVA_COMMON_CLASSES + " " + JAVA_COMMON_CLASSES_2);
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
