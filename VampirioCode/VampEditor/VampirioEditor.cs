using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
    public enum ItemType
    {
        Cut,
        Copy,
        Paste,
        Delete,
        SelectAll,
        OpenBinDirLocation,
        OpenFileLocation
    }

    public enum EditorEventType
    { 
        OpenFileLocation,
        OpenOutputFilename
    }

    public class VampirioEditor : Scintilla
    {
        public delegate void ContextItemPressedEvent(EditorEventType eventType);
        public delegate void PositionChangedEvent(VampirioEditor editor, int lineNumber, int columnNumber, int position);
        public event ContextItemPressedEvent ContextItemPressed;
        public event PositionChangedEvent PositionChanged;

        public int CurrentColumn { get { return GetColumn(CurrentPosition); } }
        public bool IsVerticalScrollVisible { get { return (Lines.Count > LinesOnScreen); } }
        public LanguageBase Language { get; private set; }
        public StyleMode StyleMode { get; private set; }

        private ContextMenu<ItemType> menu;
        private bool _highlighted = false;

        public VampirioEditor()
        {
            /*AssignCmdKey(Keys.Control | Keys.F, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.S, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.G, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.P, ScintillaNET.Command.Null);
            AssignCmdKey(Keys.Control | Keys.D, ScintillaNET.Command.Null);*/

            ClearCmdKey(Keys.Control | Keys.X); // cut
            ClearCmdKey(Keys.Control | Keys.C); // copy
            ClearCmdKey(Keys.Control | Keys.V); // paste
            ClearCmdKey(Keys.Control | Keys.N); // new
            ClearCmdKey(Keys.Control | Keys.O); // open
            ClearCmdKey(Keys.Control | Keys.W); // close
            ClearCmdKey(Keys.Control | Keys.F); // find
            ClearCmdKey(Keys.Control | Keys.H); // find and replace
            ClearCmdKey(Keys.Control | Keys.S); // save
            ClearCmdKey(Keys.Control | Keys.G); // goto
            ClearCmdKey(Keys.Control | Keys.D); // duplicate
            ClearCmdKey(Keys.Control | Keys.P);
            ClearCmdKey(Keys.Control | Keys.Z);
            ClearCmdKey(Keys.Control | Keys.Shift | Keys.Z);

            //MarkerEnableHighlight(true);

            menu = new ContextMenu<ItemType>();
            menu.AddItem(ItemType.Cut,                  "Cut",                      VampirioCode.Properties.Resources.omenu_mini_cut);
            menu.AddItem(ItemType.Copy,                 "Copy",                     VampirioCode.Properties.Resources.mmenu_mini_copy_path);
            menu.AddItem(ItemType.Paste,                "Paste",                    VampirioCode.Properties.Resources.omenu_mini_paste);
            menu.AddSeparator();
            menu.AddItem(ItemType.Delete,               "Delete",                   VampirioCode.Properties.Resources.omenu_mini_delete);
            menu.AddItem(ItemType.SelectAll,            "Select all",               VampirioCode.Properties.Resources.omenu_mini_select_all);
            menu.AddSeparator();
            menu.AddItem(ItemType.OpenBinDirLocation,   "Open output file",         VampirioCode.Properties.Resources.mmenu_mini_folder_b);
            menu.AddItem(ItemType.OpenFileLocation,     "Open file location",       VampirioCode.Properties.Resources.mmenu_mini_folder);
            menu.OnItemPressed += OnContextItemPressed;
            menu.OnOpening +=     OnContextOpening;
            this.ContextMenuStrip = menu.Context;

        }

        private void OnContextOpening(System.ComponentModel.CancelEventArgs e)
        {
            bool anyTextSelected = this.SelectedText.Length > 0;
            menu.SetEnable(ItemType.Cut,        anyTextSelected);
            menu.SetEnable(ItemType.Copy,       anyTextSelected);
            menu.SetEnable(ItemType.Delete,     anyTextSelected);
            menu.SetEnable(ItemType.SelectAll,  (this.TextLength > 0) && (this.TextLength != this.SelectedText.Length));
        }

        private void OnContextItemPressed(ItemType selection)
        {
                 if(selection == ItemType.Cut)                  { this.Cut(); }
            else if(selection == ItemType.Copy)                 { this.Copy(); }
            else if(selection == ItemType.Paste)                { this.Paste(); }
            else if(selection == ItemType.Delete)               { this.DeleteRange(this.SelectionStart, this.SelectedText.Length); }
            else if(selection == ItemType.SelectAll)            { this.SelectAll(); }
            else if(selection == ItemType.OpenFileLocation)     { if (ContextItemPressed != null) ContextItemPressed(EditorEventType.OpenFileLocation); }
            else if(selection == ItemType.OpenBinDirLocation)   { if (ContextItemPressed != null) ContextItemPressed(EditorEventType.OpenOutputFilename); }
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //
            // Cut
            //
            if (e.Control && (e.KeyCode == Keys.X))
            {
                // if no text is selected, then cut the entire line
                if (SelectedText == "")
                {
                    // Clipboard.SetText() doesn't allow an empty string
                    // so we have to insert at least a new line
                    string str = Lines[CurrentLine].Text.Trim();
                    if (str == "")
                        str = "\n";
                    
                    Clipboard.SetText(str);

                    int pos =       CurrentPosition;
                    int start =     Lines[CurrentLine].Position;
                    int length =    Lines[CurrentLine].Length;
                    //int end =     Lines[CurrentLine].EndPosition;
                    DeleteRange(start, length);
                    //GotoPosition(pos);
                }
                else
                    this.Cut();
            }
            //
            // Copy
            //
            else if (e.Control && (e.KeyCode == Keys.C))
            {
                // if no text is selected, then copy the entire line
                if (SelectedText == "")
                {
                    // Clipboard.SetText() doesn't allow an empty string
                    // so we have to insert at least a new line
                    string str = Lines[CurrentLine].Text.Trim();
                    if (str == "")
                        str = "\n";
                    
                    Clipboard.SetText(str);
                    //this.CopyAllowLine(); // also works but different
                }
                else
                    this.Copy();
            }
            //
            // Paste
            //
            else if (e.Control && (e.KeyCode == Keys.V))
            {
                this.Paste();
                
            }

            base.OnKeyDown(e);
        }

        protected override void OnUpdateUI(UpdateUIEventArgs e)
        {
            RaiseEvents();
            HighlightBraces();

            base.OnUpdateUI(e);
        }

        private void RaiseEvents()
        {
            if (PositionChanged != null)
                PositionChanged(this, CurrentLine, CurrentColumn, CurrentPosition);
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

        public void StartHighlight(String str, SearchFlags searchFlags = SearchFlags.None)
        {
            if (str == "")
                return;

            //---------- highlight ------------
            IndicatorCurrent = 8;
            Indicators[8].Style = ScintillaNET.IndicatorStyle.RoundBox;
            Indicators[8].Under = false;
            Indicators[8].ForeColor = Color.FromArgb(38, 147, 255);
            Indicators[8].OutlineAlpha = 70;
            Indicators[8].Alpha = 40;
            //----------------------------------

            IndicatorClearRange(0, TextLength);

            // Search the document
            TargetStart = 0;
            TargetEnd = TextLength;
            SearchFlags = searchFlags;

            while (SearchInTarget(str) != -1)
            {
                // Mark the search results with the current indicator
                IndicatorFillRange(TargetStart, TargetEnd - TargetStart);

                // Search the remainder of the document
                TargetStart = TargetEnd;
                TargetEnd = TextLength;
            }

            _highlighted = true;
        }

        public void StopHighlight()
        {
            if (_highlighted)
            {
                IndicatorCurrent = 8;
                IndicatorClearRange(0, TextLength);

                _highlighted = false;
            }
        }

    }
}
