using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using VampDocManager;
using VampEditor.Language;
using VampirioCode.UI;

namespace VampEditor
{
    public class VampirioEditor : Scintilla
    {
        public LanguageBase Language { get; private set; }
        public StyleMode StyleMode { get; private set; }

        public VampirioEditor() 
        {
            /*AssignCmdKey(Keys.Control | Keys.F, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.S, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.G, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.P, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.D, ScintillaNET.Command.Null);*/


            ClearCmdKey(Keys.Control | Keys.N); // new
            ClearCmdKey(Keys.Control | Keys.O); // open
            ClearCmdKey(Keys.Control | Keys.W); // close
            ClearCmdKey(Keys.Control | Keys.F); // find
            ClearCmdKey(Keys.Control | Keys.H); // find and replace
            ClearCmdKey(Keys.Control | Keys.S); // save
            ClearCmdKey(Keys.Control | Keys.G); // goto
            ClearCmdKey(Keys.Control | Keys.D); // duplicate
            ClearCmdKey(Keys.Control | Keys.P);


        }

        public void SetLanguage(DocumentType docType, StyleMode styleMode = StyleMode.Dark)
        {
            StyleMode = styleMode;

                 if (docType == DocumentType.CSHARP)    Language = new CSharp();
            else if (docType == DocumentType.CPP)       Language = new CPP();
            else if (docType == DocumentType.JS)        Language = new Javascript();
            else                                        Language = new CSharp();

            Language.Config(this);
            Language.Activate(StyleMode);
        }




    }
}
