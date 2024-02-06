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

        private static List<String> lastSearchList =    new List<string>();
        private static List<String> lastReplaceList =   new List<string>();

        private string FindText { get { return findInput.Text; } set { findInput.Text = value; } }
        private string ReplaceText { get { return replaceInput.Text; } set { replaceInput.Text = value; } }

        private VampirioEditor editor;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(139, 70, 166);
        private Mode mode = Mode.Find;

        public FindUI(VampirioEditor editor, bool replace = false) : base()
        {
            InitializeComponent();

            mode = replace ? Mode.FindAndReplace : Mode.Find;

            this.editor = editor;
            this.findInput.KeyDown +=       OnKeyDown;
            this.replaceInput.KeyDown +=    OnKeyDown;

            if(mode == Mode.Find)
            {
                this.replaceInput.Visible = false;
                this.Height = 42;
                mode = Mode.Find;
            }

            FindText = editor.SelectedText;
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
            ProcessLastList(FindText.Trim(),    lastSearchList);
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

            ProcessLastList(FindText.Trim(),    lastSearchList);
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
            if(editor.SelectionStart < editor.SelectionEnd)
                editor.SelectionEnd = editor.SelectionStart;
            else
                editor.SelectionStart = editor.SelectionEnd;
        }

        private SearchFlags GetFlags()
        {
            SearchFlags flags;

            /*flags = ScintillaNET.SearchFlags.None;
            if (matchCaseCKBox.Checked)
                flags |= ScintillaNET.SearchFlags.MatchCase;
            if (matchWholeWordCKBox.Checked)
                flags |= ScintillaNET.SearchFlags.WholeWord;
            if (useRegularExpCKBox.Checked)
                flags |= ScintillaNET.SearchFlags.Regex;*/

            flags = SearchFlags.None;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_borderSize > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(_borderColor), ClientRectangle);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
            }

            base.OnPaint(e);
        }

        private void Exit()
        {
            editor.StopHighlight();
            //editor.ResetSelectionStyle();
            editor.SearchFlags = SearchFlags.None;

            if (Close != null)
                Close();
        }

    }
}
