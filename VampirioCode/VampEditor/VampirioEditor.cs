using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ClearCmdKey(Keys.Control | Keys.Shift | Keys.Z);

            //MarkerEnableHighlight(true);
            
        }

        public void SetLanguage(DocumentType docType, StyleMode styleMode = StyleMode.Dark)
        {
            StyleMode = styleMode;

                 if (docType == DocumentType.CSHARP)    Language = new CSharp();
            else if (docType == DocumentType.CPP)       Language = new CPP();
            else if (docType == DocumentType.JS)        Language = new Javascript();
            else if (docType == DocumentType.PHP)       Language = new PHP();
            else                                        Language = new CSharp();

            Language.Config(this);
            Language.Activate(StyleMode);

        }

        // Use this method to set the 'Text' instead of editr.Text property because this
        // is the only way to reset the undo to beging just after the input document
        public void SetText(string text)
        {
            this.Text = text;
            EmptyUndoBuffer();
        }

        protected override void OnUpdateUI(UpdateUIEventArgs e)
        {
            HighlightBraces();

            base.OnUpdateUI(e);
        }

        private bool HighlightBraces()
        { 
            int prevPos = CurrentPosition - 1;
            int currPos = CurrentPosition;

            char prevChar = prevPos >= 0            ? (char)GetCharAt(prevPos) : '\0';
            char currChar = currPos < TextLength    ? (char)GetCharAt(currPos) : '\0';
            int matchPos = -1;


            if (currChar != '\0' && IsBrace(currChar))
            {
                matchPos =          BraceMatch(currPos);
                if (matchPos != -1) BraceHighlight(currPos, matchPos);
                else                BraceBadLight(currPos);
                return true;
            }
            else if (prevChar != '\0' && IsBrace(prevChar))
            {
                matchPos =          BraceMatch(prevPos);
                if (matchPos != -1) BraceHighlight(prevPos, matchPos);
                else                BraceBadLight(prevPos);
                return true;
            }
            else
                BraceHighlight(-1, -1);

            return false;
        }

        private bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }

        protected override void OnInsertCheck(InsertCheckEventArgs e)
        {
            //#################################################################
            //#############          SMART C# INDENT            ###############
            //#################################################################
            //if ((currentLanguage == Language.CSHARP) || (currentLanguage == Language.JS) || (currentLanguage == Language.CPP))
            {
                if (e.Text.EndsWith("\n"))
                {
                    var curLine = LineFromPosition(e.Position);
                    var curLineText = Lines[curLine].Text;

                    var indent = Regex.Match(curLineText, @"^[ \t]*");
                    e.Text += indent.Value; // Add indent following "\r\n"

                    // Current line end with bracket?
                    if (Regex.IsMatch(curLineText, @"{\s*$"))
                        e.Text += '\t'; // Add tab
                }
            }
            //#################################################################

            base.OnInsertCheck(e);
        }


    }
}
