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
    public partial class DocumentTab : TabItem
    {

        public delegate void ContextItemPressedEvent(EditorEventType eventType, Document document);
        public delegate void TextChangedEvent(Document document);
        public delegate void ModifiedChangedEvent(Document document);

        public event ContextItemPressedEvent ContextItemPressed;
        public event TextChangedEvent TextChanged;
        public event ModifiedChangedEvent ModifiedChanged;

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

            // add editor
            Content.Controls.Add(editor);

            // create scrollbars
            CreateCustomScrollBars();

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

            if (TextChanged != null)
                TextChanged(Document);
        }

        private void OnModified()
        {
            SetTitle(Document.FileName);

            if (ModifiedChanged != null)
                ModifiedChanged(Document);
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
