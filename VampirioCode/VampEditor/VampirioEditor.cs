using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using VampEditor.Language;

namespace VampEditor
{
    public class VampirioEditor : Scintilla
    {
        public LanguageBase Language { get; private set; }
        public StyleMode StyleMode { get; private set; }

        public void SetLanguage(LangId lang, StyleMode styleMode = StyleMode.Dark)
        {
            StyleMode = styleMode;

            if (lang == LangId.CSharp)
                Language = new CSharp();


            Language.Config(this);
            Language.Activate(StyleMode);
        }

        private int dbgCount = 0;

        public void DebugTest()
        {

            Styles[dbgCount].BackColor = Color.Red;
            MessageBox.Show("dbgCount: " + dbgCount);

            dbgCount++;
            if (dbgCount > Styles.Count)
                dbgCount = 0;
        }


    }
}
