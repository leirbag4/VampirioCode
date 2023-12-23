using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampEditor.Language
{
    public class LanguageBase
    {
        protected VampirioEditor editor;
        protected StyleCollection Styles { get; private set; }
        protected MarkerCollection Markers { get; private set; }
        protected MarginCollection Margins { get; private set; }
        protected Lexer Lexer { get; private set; }

        public void Config(VampirioEditor editor)
        {
            this.editor =   editor;
            this.Styles =   editor.Styles;
            this.Markers =  editor.Markers;
            this.Margins =  editor.Margins;
            this.Lexer =    editor.Lexer;

            //string str = string.Join(',', Lexilla.GetLexerNames());
            //MessageBox.Show(str);
        }

        public void Activate(StyleMode style)
        {
            OnActivate(style);
        }

        protected virtual void OnActivate(StyleMode style)
        { }

        protected void SetForcedBackColor(Color color)
        {
            for (int a = 0; a < Styles.Count; a++)
                Styles[a].BackColor = Color.FromArgb(39, 40, 34);
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
            Margins[2].Width = 20;

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

            // Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            //editor.SetFoldFlags(FoldFlags.LineAfterContracted);

        }

        protected Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }


    }
}
