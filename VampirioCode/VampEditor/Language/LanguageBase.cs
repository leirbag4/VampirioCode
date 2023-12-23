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
        protected Lexer Lexer { get; private set; }

        public void Config(VampirioEditor editor)
        {
            this.editor =   editor;
            this.Styles =   editor.Styles;
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

        protected Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }


    }
}
