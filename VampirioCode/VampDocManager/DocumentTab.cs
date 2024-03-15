using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampEditor;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TabManagement;
using static VampEditor.VampirioEditor;

namespace VampDocManager
{
    public class DocumentTab : TabItem
    {

        public delegate void ContextItemPressedEvent(EditorEventType eventType, Document document);

        public event ContextItemPressedEvent ContextItemPressed;

        //public string Text { get { return _editor.Text; } set { _editor.Text = value; } }
        public string Text { get { return ""; } set { } } // remove title behaviour
        public string Title { get { return base.Text; } }

        public Document Document { get; private set; }
        public VampirioEditor Editor { get { return editor; } }
        public bool IsFindActive { get; set; } = false;

        private VampirioEditor editor;
        private FindUI find;

        public static DocumentTab Create(Document doc)
        {
            return new DocumentTab().Init(doc);
        }


        private ScrollBarAdv vertScrollBar;

        private DocumentTab Init(Document doc)
        {
            // editor style
            editor = new VampirioEditor();
            editor.Dock = DockStyle.Fill;
            editor.BorderStyle = ScintillaNET.BorderStyle.None;
            editor.SetLanguage(doc.DocType, VampEditor.StyleMode.Dark);

            // tab style
            //BackColor = Color.FromArgb(30, 30, 30);
            //BorderStyle = BorderStyle.None;
            //Controls.Add(editor);
            Content.Controls.Add(editor);

            vertScrollBar = new ScrollBarAdv();
            vertScrollBar.Height = Content.Height;
            vertScrollBar.Location = new Point(Content.Width - vertScrollBar.Width - 30, 0);
            vertScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vertScrollBar.Scroll += OnVertScroll;

            Content.Controls.Add(vertScrollBar);
            vertScrollBar.BringToFront();



            // set data
            Document = doc;
            Editor.SetText(doc.Text);
            SetTitle(Document.FileName);

            // events
            Editor.TextChanged += OnEditorTextChanged;
            Editor.ContextItemPressed += OnContextItemPressed;
            Editor.SizeChanged += OnEditorSizeChanged;
            Document.OnSaved += OnSaved;
            Document.OnModified += OnModified;

            return this;
        }

        private void OnEditorSizeChanged(object sender, EventArgs e)
        {
            RefreshScrollBars();
        }

        private void RefreshScrollBars()
        {
            /*if (Editor.IsVerticalScrollVisible)
                x = this.Content.Width - find.Width - SystemInformation.VerticalScrollBarWidth;
            else
                x = this.Content.Width - find.Width;*/

            ScrollInfo scrollInfo = Editor.GetVScrollInfo();

            vertScrollBar.Minimum = scrollInfo.min;
            vertScrollBar.Maximum = scrollInfo.max;
            vertScrollBar.LargeChange = scrollInfo.nPage;
        }

        private void OnVertScroll(object? sender, ScrollEventArgs e)
        {
            
            var scrollInfo = Editor.GetVScrollInfo();

            int limit = scrollInfo.max - (scrollInfo.nPage - 1);
            int newVal = vertScrollBar.Value - (scrollInfo.nPage - 1);
            int newVal2 = (int)(Math.Round(vertScrollBar.NormalizedValue * limit));
            int newVal3 = (int)(Math.Round(vertScrollBar.NormalizedValue * (scrollInfo.max - (scrollInfo.nPage - 1))));

            //vertScrollBar.LargeChange = 8;

            XConsole.Println("VAL: " + vertScrollBar.Value + " [ "+newVal+" ] limit: " + limit + " ( min: " + vertScrollBar.Minimum + "  max: " + vertScrollBar.Maximum + "  large: " + vertScrollBar.LargeChange + " )");
            XConsole.Println("NVal: " + vertScrollBar.NormalizedValue.ToString("0.00") + "  newVal3: " + newVal3);

            XConsole.Println("min: " + scrollInfo.min + " max: " + scrollInfo.max + " nPos: " + scrollInfo.nPos +
                            " nPage: " + scrollInfo.nPage + " cbSize: " + scrollInfo.cbSize + 
                            " nTrackPos: " + scrollInfo.nTrackPos);


            //vertScrollBar.Minimum = scrollInfo.min;
            //vertScrollBar.Maximum = scrollInfo.max;
            //vertScrollBar.SmallChange = 1;
            //vertScrollBar.LargeChange = 1;

            //vertScrollBar.LargeChange;

            //Editor.VScrollBar = false;
            //Editor.LineScroll(val, 0);
        }

        private void OnContextItemPressed(EditorEventType eventType)
        {
            if (ContextItemPressed != null)
                ContextItemPressed(eventType, Document);
        }

        private void SetTitle(string title)
        {
            if (Document.Modified)
                base.Text = title + " *";
            else
            {
                if (Document.IsTemporary)
                    base.Text = title + " ~";
                else
                    base.Text = title;
            }
        }

        private void OnEditorTextChanged(object? sender, EventArgs e)
        {
            Document.Modified = true;
            Document.Text = Editor.Text;
        }

        private void OnModified()
        {
            SetTitle(Document.FileName);
        }

        private void OnSaved()
        {
            //Document.Modified = false;
        }

        public void ShowFind(bool replace = false)
        {
            if (IsFindActive)
                return;

            int x, y = -2;

            find = new FindUI(Editor, replace);

            if (Editor.IsVerticalScrollVisible) 
                x = this.Content.Width - find.Width - SystemInformation.VerticalScrollBarWidth;
            else 
                x = this.Content.Width - find.Width;

            find.Location = new Point(x, y);
            find.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            find.Close += OnFindClose;

            this.Content.Controls.Add(find);
            find.BringToFront();

            IsFindActive = true;
        }

        private void OnFindClose()
        {
            if (IsFindActive)
            {
                this.Content.Controls.Remove(find);
                IsFindActive = false;
                Editor.Focus();
            }
        }


    }
}
