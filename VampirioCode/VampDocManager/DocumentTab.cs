//#define DEBUG_SCROLLBARS

using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private ScrollBarAdv horScrollBar;
        private Control scrollBarCorner;

#if DEBUG_SCROLLBARS
        private const int scrollBarOffset = 30;
#else
        private const int scrollBarOffset = 0;
#endif

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


            vertScrollBar =             new ScrollBarAdv();
            vertScrollBar.ButtonSize =  SystemInformation.VerticalScrollBarWidth;
            vertScrollBar.Width =       SystemInformation.VerticalScrollBarWidth;
            vertScrollBar.Height =      Content.Height;
            vertScrollBar.Location =    new Point(Content.Width - vertScrollBar.Width - scrollBarOffset, 0);
            vertScrollBar.Anchor =      AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vertScrollBar.Scroll +=     OnVertScroll;


            horScrollBar =              new ScrollBarAdv();
            horScrollBar.Orientation = VampirioCode.UI.Controls.ScrollBarAdvance.ScrollBarOrientation.Horizontal;
            horScrollBar.AllowMouseScrolling = false;
            horScrollBar.ButtonSize =   SystemInformation.HorizontalScrollBarHeight;
            horScrollBar.Height =       SystemInformation.HorizontalScrollBarHeight;
            horScrollBar.Width =        Content.Width;
            horScrollBar.Location =     new Point(0, Content.Height - horScrollBar.Height - scrollBarOffset);
            horScrollBar.Anchor =       AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            horScrollBar.Scroll +=      OnHorScroll;

            scrollBarCorner = new Control();

            Content.Controls.Add(vertScrollBar);
            Content.Controls.Add(horScrollBar);
            vertScrollBar.BringToFront();
            horScrollBar.BringToFront();

            RefreshScrollBarsVisibility();

            // set data
            Document = doc;
            Editor.SetText(doc.Text);
            SetTitle(Document.FileName);

            // events
            Editor.TextChanged +=               OnEditorTextChanged;
            Editor.ContextItemPressed +=        OnContextItemPressed;
            Editor.VerticalScrollChanged +=     OnVerticalScrollChanged;
            Editor.HorizontalScrollChanged +=   OnHorizontalScrollChanged;
            Editor.SizeChanged +=               OnEditorSizeChanged;
            Document.OnSaved +=                 OnSaved;
            Document.OnModified +=              OnModified;

            return this;
        }


        private void OnEditorSizeChanged(object sender, EventArgs e)
        {
            VerticalScrollChanged(Editor.GetVScrollInfo(), Editor.FirstVisibleLine);
            HorizontalScrollChanged(Editor.GetHScrollInfo(), Editor.XOffset);
            RefreshScrollBarsVisibility();
        }


        private string DebugScrollInfo(ScrollInfo scroll)
        {
            return $"cbSize: {scroll.cbSize} fMask: {scroll.fMask} min: {scroll.min} max: {scroll.max} nPage: {scroll.nPage} nPos: {scroll.nPos} nTrackPos: {scroll.nTrackPos}";
        }

        private void RefreshScrollBarsVisibility()
        {
            bool vscrollVisible = Editor.IsVerticalScrollVisible;
            bool hscrollVisible = horScrollBar.Maximum >= horScrollBar.LargeChange;

            
            if(hscrollVisible)
                vertScrollBar.Height =  Content.Height - horScrollBar.Height;
            else
                vertScrollBar.Height =  Content.Height;
            
            if (vscrollVisible)
                horScrollBar.Width =    Content.Width - vertScrollBar.Width;
            else
                horScrollBar.Width =    Content.Width;


            vertScrollBar.Location = new Point(Content.Width - vertScrollBar.Width - scrollBarOffset, 0);
            horScrollBar.Location =  new Point(0, Content.Height - horScrollBar.Height - scrollBarOffset);


            vertScrollBar.Visible = vscrollVisible;
            horScrollBar.Visible =  hscrollVisible;

        }


        private void OnVertScroll(int newValue, int oldValue)
        {
            Editor.FirstVisibleLine = vertScrollBar.Value;
        }

        private void OnHorScroll(int newValue, int oldValue)
        {
            Editor.XOffset = horScrollBar.Value;
        }

        private void VerticalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            OnVerticalScrollChanged(scrollInfo, position);
        }

        private void HorizontalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            OnHorizontalScrollChanged(scrollInfo, position);
        }

        private void OnVerticalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            ScrollBarAdv scroll =    vertScrollBar;

            if(scroll.Minimum !=     scrollInfo.min)        scroll.Minimum =     scrollInfo.min;
            if(scroll.Maximum !=     scrollInfo.max)        scroll.Maximum =     scrollInfo.max;
            if(scroll.LargeChange != scrollInfo.nPage)      scroll.LargeChange = scrollInfo.nPage;
            if(scroll.Value !=       position)              scroll.Value =       position;
            // scroll.nTrackPos is not used here because not always has new values

            RefreshScrollBarsVisibility();
        }

        private void OnHorizontalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            ScrollBarAdv scroll =    horScrollBar;

            if(scroll.Minimum !=     scrollInfo.min)        scroll.Minimum =     scrollInfo.min;
            if(scroll.Maximum !=     scrollInfo.max)        scroll.Maximum =     scrollInfo.max;
            if(scroll.LargeChange != scrollInfo.nPage)      scroll.LargeChange = scrollInfo.nPage;
            if(scroll.Value !=       position)              scroll.Value =       position;
            // scroll.nTrackPos is not used here because not always has new values

            RefreshScrollBarsVisibility();
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
