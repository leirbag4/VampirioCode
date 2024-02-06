using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampEditor;
using VampirioCode.UI.Controls;

namespace VampirioCode.UI
{

    public partial class FindUI : UserControl
    {
        enum Mode
        {
            Find,
            FindAndReplace
        }

        public delegate void CloseEvent();
        public event CloseEvent Close;

        private static List<String> lastSearchList = new List<string>();
        private static List<String> lastReplaceList = new List<string>();

        private string FindText { get { return findInput.Text; } set { findInput.Text = value; } }
        private string ReplaceText { get { return replaceInput.Text; } set { replaceInput.Text = value; } }
        private ComboBoxAdv lastFocusedInput = null;

        public bool OptionsVisible
        {
            get { return optionsGBox.Visible; }
            set
            {
                optionsGBox.Visible = value;

                if (optionsGBox.Visible)
                {
                    if (mode == Mode.Find)
                    {
                        this.Height = SizeFindOptions;
                        this.optionsGBox.Top = OptionsYFind;
                    }
                    else if (mode == Mode.FindAndReplace)
                    {
                        this.Height = SizeFindAndReplaceOptions;
                        this.optionsGBox.Top = OptionsYFindAndReplace;
                    }
                }
                else
                {
                    if (mode == Mode.Find)
                        this.Height = SizeFind;
                    else if (mode == Mode.FindAndReplace)
                        this.Height = SizeFindAndReplace;
                }

                this.Invalidate();
            }
        }

        private VampirioEditor editor;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(139, 70, 166);
        private Mode mode = Mode.Find;

        private const int SizeFind = 42;
        private const int SizeFindAndReplace = 78;
        private const int SizeFindOptions = 120;
        private const int SizeFindAndReplaceOptions = 156;
        private const int OptionsYFind = 40;
        private const int OptionsYFindAndReplace = 76;

        public FindUI(VampirioEditor editor, bool replace = false) : base()
        {
            InitializeComponent();

            mode = replace ? Mode.FindAndReplace : Mode.Find;

            this.editor = editor;
            this.editor.KeyDown -=          OnKeyDown;
            this.findInput.KeyDown -=       OnKeyDown;
            this.replaceInput.KeyDown -=    OnKeyDown;

            this.editor.KeyDown +=          OnKeyDown;
            this.findInput.KeyDown +=       OnKeyDown;
            this.replaceInput.KeyDown +=    OnKeyDown;

            this.findInput.GotFocus +=      OnInputsGotFocus;
            this.replaceInput.GotFocus +=   OnInputsGotFocus;

            this.matchCaseCKBox.CheckedChanged +=       OnOptionCheckedChanged;
            this.matchWholeWordCKBox.CheckedChanged +=  OnOptionCheckedChanged;
            this.useRegexCKBox.CheckedChanged +=        OnOptionCheckedChanged;

            if (mode == Mode.Find)
            {
                this.replaceInput.Visible = false;
                this.Height = 42;
                mode = Mode.Find;
            }

            OptionsVisible = false;

            FindText = editor.SelectedText;
        }

        private void OnOptionCheckedChanged(object sender, EventArgs e)
        {
            RestoreFocusToInput();
        }

        private void OnInputsGotFocus(object sender, EventArgs e)
        {
            lastFocusedInput = sender as ComboBoxAdv;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (mode == Mode.Find)
            {
                findInput.Focus();
            }
            else if (mode == Mode.FindAndReplace)
            {
                replaceInput.Focus();
            }

            ResetPointer();
            Find();
        }

        public void Find()
        {
            ProcessLastList(FindText.Trim(), lastSearchList);
            ProcessLastList(ReplaceText.Trim(), lastReplaceList);

            int pos = FindNext(FindText);

            if (pos == -1)
            {
                editor.GotoPosition(0);
                pos = FindNext(FindText);

                if (pos == -1)
                    MsgBox.Show("Find", "No more occurrences.", DialogButtons.OK, DialogIcon.Info);
            }
        }

        private int FindNext(string text)
        {
            editor.StartHighlight(FindText);
            //editor.SetSelectionStyle();

            editor.SearchFlags =    GetFlags();
            editor.TargetStart =    Math.Max(editor.CurrentPosition, editor.AnchorPosition);
            editor.TargetEnd =      editor.TextLength;

            var pos = editor.SearchInTarget(text);
            if (pos >= 0)
                editor.SetSel(editor.TargetStart, editor.TargetEnd);

            return pos;
        }

        private void Replace()
        {
            if (FindText == "")
                return;

            ProcessLastList(FindText.Trim(), lastSearchList);
            ProcessLastList(ReplaceText.Trim(), lastReplaceList);

            ResetPointer();

            int pos = ReplaceNext(FindText, ReplaceText);

            if (pos == -1)
                MsgBox.Show("Find", "No more occurrences.", DialogButtons.OK, DialogIcon.Info);
            else
                Find();

        }

        private int ReplaceNext(string findText, string replaceText)
        {
            // Find the text and, if found, replace the selection
            var pos = FindNext(findText);
            if (pos >= 0)
                editor.ReplaceSelection(replaceText);
            return pos;
        }

        private void ResetPointer()
        {
            if (editor.SelectionStart < editor.SelectionEnd)
                editor.SelectionEnd = editor.SelectionStart;
            else
                editor.SelectionStart = editor.SelectionEnd;
        }

        private SearchFlags GetFlags()
        {
            SearchFlags flags = SearchFlags.None;

            if (matchCaseCKBox.Checked)         flags |= SearchFlags.MatchCase;
            if (matchWholeWordCKBox.Checked)    flags |= SearchFlags.WholeWord;
            if (useRegexCKBox.Checked)          flags |= SearchFlags.Regex;

            return flags;
        }

        private String ProcessLastList(String inText, List<String> list)
        {
            String str = inText;
            String toFind = "";

            if (str != "")
            {
                toFind = str;

                for (int a = 0; a < list.Count; a++)
                {
                    if (list[a] == toFind)
                    {
                        list.RemoveAt(a);
                        break;
                    }
                }

                list.Insert(0, toFind);
            }
            else
            {
                if (list.Count > 0)
                    toFind = list[0];
            }

            if (list.Count > 12)
                list.RemoveAt(list.Count - 1);

            if (list == lastSearchList)
            {
                findInput.Items.Clear();
                findInput.Items.AddRange(list.ToArray());
            }
            else if (list == lastReplaceList)
            {
                replaceInput.Items.Clear();
                replaceInput.Items.AddRange(list.ToArray());
            }

            return toFind;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Exit();
            }
        }

        private void OnCloseButtonPressed(object sender, EventArgs e)
        {
            Exit();
        }

        private void OnFindEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            Find();
        }

        private void OnReplaceEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            Replace();
        }

        private void OnReplaceAllPressed(object sender, EventArgs e)
        {
            int pos = 0;
            int currentPos =            editor.CurrentPosition;
            int currentAnchorPos =      editor.AnchorPosition;
            int count = 0;

            if (FindText == "")
                return;

            // Start search at the beginning of the control text
            editor.CurrentPosition =    0;
            editor.AnchorPosition =     0;
            
            // Call Replace All
            while (pos >= 0)
            {
                pos = ReplaceNext(FindText, ReplaceText);
                count++;
            }

            XConsole.FooterInfo("replaced " + count + " searches");

            // Restore the position and anchor
            editor.CurrentPosition =    currentPos;
            editor.AnchorPosition =     currentAnchorPos;

            // Restore last input focus
            RestoreFocusToInput();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_borderSize > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(_borderColor), ClientRectangle);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
            }

            base.OnPaint(e);
        }

        // Return focus to inputs. Otherwise, Escape key won't be detected
        private void RestoreFocusToInput()
        {
                 if (lastFocusedInput == findInput)     findInput.Focus();
            else if (lastFocusedInput == replaceInput)  replaceInput.Focus();
        }

        private void Exit()
        {
            editor.StopHighlight();
            editor.SearchFlags = SearchFlags.None;

            this.editor.KeyDown -=          OnKeyDown;
            this.findInput.KeyDown -=       OnKeyDown;
            this.replaceInput.KeyDown -=    OnKeyDown;

            if (Close != null)
                Close();
        }

        private void OnOptionsPressed(object sender, EventArgs e)
        {
            OptionsVisible = !OptionsVisible;
            RestoreFocusToInput();
        }

    }
}
