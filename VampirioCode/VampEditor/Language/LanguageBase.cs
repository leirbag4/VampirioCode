using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.IO;

namespace VampEditor.Language
{
    public class LanguageBase
    {
        protected VampirioEditor editor;
        protected StyleCollection Styles { get; private set; }
        protected MarkerCollection Markers { get; private set; }
        protected MarginCollection Margins { get; private set; }
        protected Lexer Lexer { get; private set; }

        protected bool _lineNumbVisibile = false;
        private int _maxLineNumberCharLength;
        private int _minLineMarginWidth = 0;

        public void Config(VampirioEditor editor)
        {
            this.editor =   editor;
            this.Styles =   editor.Styles;
            this.Markers =  editor.Markers;
            this.Margins =  editor.Margins;
            this.Lexer =    editor.Lexer;

            editor.TextChanged += OnTextChanged;

            //string str = string.Join(',', Lexilla.GetLexerNames());
            //MessageBox.Show(str);
        }

        private void OnTextChanged(object? sender, EventArgs e)
        {
            if (_lineNumbVisibile)
                ResizeLineNumbMargins();
        }

        public void Activate(StyleMode style)
        {
            OnActivate(style);
        }

        protected void SetFontSyle()
        {
            int fontSize = 10;

            Display.Initialize();
            if (Display.Scale < 125)
                fontSize = 11;

            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = fontSize;
            //Styles[Style.Default].Bold = true;
        }

        protected void SetProperty(string name, string value)
        {
            editor.SetProperty(name, value);
        }

        protected void SetKeywords(int set, string keywords)
        {
            editor.SetKeywords(set, keywords);
        }

        protected void SetSelctionStyle()
        { 
            // selected text ->     if(░░░░░░code)
            editor.SetSelectionBackColor(true, CColor(53, 46, 66));

            // Full row color ->    |▓▓▓▓▓▓if(code)▓▓▓▓▓▓▓▓▓▓▓▓|
            editor.CaretLineBackColor =     CColor(34, 33, 30);// CColor(30, 31, 25); // CColor(34, 33, 33); // CColor(42, 40, 45); // CColor(45, 46, 40); //CColor(34, 35, 29);

            // Caret '|' color and width
            editor.CaretForeColor =         CColor(102, 51, 153);
            editor.CaretWidth =             2;

            //                                      data.|   data.ToStr|
            // Allows multiple carets writing ->    data.|   data.ToStr|
            //                                      data.|   data.ToStr|
            editor.AdditionalSelectionTyping = true;

            //                                      data.|  <-- CaretForeColor
            // Additional carets color ->           data.|  <-- AdditionalCaretForeColor
            //                                      data.|  <-- AdditionalCaretForeColor
            editor.AdditionalCaretForeColor =       CColor(81, 69, 93); //CColor(127, 127, 127);

            // Selected Brace using 'BraceHighlight' and 'BraceBadLight' (){}<>[] colors
            Styles[Style.BraceLight].BackColor =    CColor(71, 46, 94);
            Styles[Style.BraceLight].ForeColor =    CColor(170, 170, 170);
            Styles[Style.BraceBad].BackColor =      CColor(80, 78, 76); // CColor(79, 44, 39);
            Styles[Style.BraceBad].ForeColor =      CColor(170, 170, 170);
        }

        protected virtual void OnActivate(StyleMode style)
        { }

        private void ResizeLineNumbMargins()
        {
            // from: https://github.com/jacobslusser/ScintillaNET/wiki/Displaying-Line-Numbers

            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = editor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this._maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            int newMarginWidth = editor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            
            if (newMarginWidth > _minLineMarginWidth)
                editor.Margins[0].Width = newMarginWidth;
            else
                editor.Margins[0].Width = _minLineMarginWidth;

            this._maxLineNumberCharLength = maxLineNumberCharLength;
        }

        protected void SetFoldMarginStyle()
        {
            /*
            Styles[Style.LineNumber].BackColor = Color.FromArgb(35, 35, 35);
            Styles[Style.LineNumber].ForeColor = Color.FromArgb(144, 144, 144);
            Color col = Color.FromArgb(35, 35, 35);
            */
            Styles[Style.LineNumber].BackColor = CColor(28, 32, 37);
            Styles[Style.LineNumber].ForeColor = CColor(70, 60, 50);//Styles[Style.LineNumber].ForeColor = Color.FromArgb(92, 51, 82);
            Color col = CColor(36, 37, 34);
            editor.SetFoldMarginColor(true, col);          // use both! they work like a trama
            editor.SetFoldMarginHighlightColor(true, col); // use both! they work like a trama

            //Styles[Style.LineNumber].Font = "Sanserif";

        }

        protected void EnableCodeFolding()
        {
            Color col0, col1;
            // Instruct the lexer to calculate folding
            editor.SetProperty("fold", "1");
            editor.SetProperty("fold.compact", "1");


            // Configure a margin to display folding symbols
            Margins[2].Type = MarginType.Symbol;
            Margins[2].Mask = Marker.MaskFolders;
            Margins[2].Sensitive = true;
            Margins[2].Width = 16;

            // Set colors for all folding markers
            col0 = Color.FromArgb(70, 70, 70);
            col1 = Color.FromArgb(28, 32, 37);
            for (int i = 25; i <= 31; i++)
            {
                Markers[i].SetForeColor(col0);
                Markers[i].SetBackColor(col1);
            }

            // Configure folding markers with respective symbols
            /*Markers[Marker.Folder].Symbol =         MarkerSymbol.BoxPlus;
            Markers[Marker.FolderOpen].Symbol =     MarkerSymbol.BoxMinus;
            Markers[Marker.FolderEnd].Symbol =      MarkerSymbol.BoxPlusConnected;
            Markers[Marker.FolderMidTail].Symbol =  MarkerSymbol.TCorner;
            Markers[Marker.FolderOpenMid].Symbol =  MarkerSymbol.BoxMinusConnected;
            Markers[Marker.FolderSub].Symbol =      MarkerSymbol.VLine;
            Markers[Marker.FolderTail].Symbol =     MarkerSymbol.LCorner;*/
            Markers[Marker.FolderEnd].Symbol =      MarkerSymbol.Minus;
            Markers[Marker.FolderOpenMid].Symbol =  MarkerSymbol.Plus;
            Markers[Marker.FolderMidTail].Symbol =  MarkerSymbol.TCorner;
            Markers[Marker.FolderTail].Symbol =     MarkerSymbol.LCorner;
            Markers[Marker.FolderSub].Symbol =      MarkerSymbol.VLine;
            Markers[Marker.Folder].Symbol =         MarkerSymbol.BoxPlus;
            Markers[Marker.FolderOpen].Symbol =     MarkerSymbol.BoxMinus;

            // SET CUSTOM IMAGE
            // Markers[Marker.FolderOpen].DefineRgbaImage(VampirioCode.Properties.Resources.play_icon);

            // Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            //editor.SetFoldFlags(FoldFlags.LineAfterContracted);

        }

        protected void SetLinesNumber(bool visible, int width)
        {
            /*
                From user's internet post:

                'By default, margins 0-2 are given the following width and display attributes. A margin
                'with zero width is not displayed.
                '    margin      display      width
                '      0        line numbers    0  (not visible)
                '      1        symbols         16 (visible)
                '      2        symbols         0  (not visible)

                From Scintilla github:

                In Scintilla there can be up to five margins (0 through 4) on the left edge of the control, of which, line numbers 
                is just one of those. By convention Scintilla sets the Margin.Type property of margin 0 to MarginType.Number, making 
                it the de facto line number margin. Any margin can display line numbers though if its Type property is set to 
                MarginType.Number. Scintilla also hides line numbers by default by setting the Width of margin 0 to zero. To display the
                default line number margin, increase its width:
                
                scintilla.Margins[0].Width = 16;
            */

            _lineNumbVisibile =     visible;
            _minLineMarginWidth =    width;

            if (!_lineNumbVisibile)
                _minLineMarginWidth = 0;
            else
                _minLineMarginWidth = width;

            Margins[0].Width = _minLineMarginWidth;
        }

        protected Style PreprocessStyle(int index)
        {
            return Styles[64 + index];
        }

        protected Style PreprocessStyle(int startIndex, int index)
        {
            return Styles[startIndex + index];
        }

        protected Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }


    }
}
