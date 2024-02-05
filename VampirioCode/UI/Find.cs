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

    public partial class Find : UserControl
    {
        enum Mode
        {
            Find,
            FindAndReplace
        }

        public delegate void CloseEvent();
        public event CloseEvent Close;

        private string FindText { get { return findInput.Text; } set { findInput.Text = value; } }
        private string ReplaceText { get { return replaceInput.Text; } set { replaceInput.Text = value; } }

        private VampirioEditor editor;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(139, 70, 166);
        private Mode mode = Mode.Find;

        public Find(VampirioEditor editor, bool replace = false) : base()
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

            FindNow(FindText);
        }

        public void FindNow(String str)
        {
            int pos = FindNext(str);

            if (pos == -1)
            {
                editor.GotoPosition(0);
                pos = FindNext(str);

                if (pos == -1)
                    MessageBox.Show("No more occurrences.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            FindNext(FindText);
        }

        private void OnReplaceEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            XConsole.Println("replace");
        }

        private int FindNext(string text)
        {
            editor.StartHighlight(FindText);
            editor.SetSelectionStyle();

            editor.SearchFlags =    GetFlags();
            editor.TargetStart =    Math.Max(editor.CurrentPosition, editor.AnchorPosition);
            editor.TargetEnd =      editor.TextLength;

            var pos = editor.SearchInTarget(text);
            if (pos >= 0)
                editor.SetSel(editor.TargetStart, editor.TargetEnd);

            return pos;
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
            editor.ResetSelectionStyle();
            editor.SearchFlags = SearchFlags.None;

            if (Close != null)
                Close();
        }

    }
}
