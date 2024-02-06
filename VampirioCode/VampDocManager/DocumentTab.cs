using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampEditor;
using VampirioCode.UI;

namespace VampDocManager
{
    public class DocumentTab : TabPage
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

        private DocumentTab Init(Document doc)
        {
            // editor style
            editor = new VampirioEditor();
            editor.Dock = DockStyle.Fill;
            editor.BorderStyle = ScintillaNET.BorderStyle.None;
            editor.SetLanguage(doc.DocType, VampEditor.StyleMode.Dark);

            // tab style
            BackColor = Color.FromArgb(30, 30, 30);
            BorderStyle = BorderStyle.None;
            Controls.Add(editor);

            // set data
            Document =      doc;
            Editor.SetText(doc.Text);
            SetTitle(Document.FileName);

            // events
            Editor.TextChanged +=           OnEditorTextChanged;
            Editor.ContextItemPressed +=    OnContextItemPressed;
            Document.OnSaved +=             OnSaved;
            Document.OnModified +=          OnModified;

            return this;
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
                if(Document.IsTemporary)
                    base.Text = title + " ~";
                else
                    base.Text = title;
            }
        }

        private void OnEditorTextChanged(object? sender, EventArgs e)
        {
            Document.Modified = true;
            Document.Text =     Editor.Text;
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

            if (Editor.IsVerticalScrollVisible) x = this.Width - find.Width - SystemInformation.VerticalScrollBarWidth;
            else                                x = this.Width - find.Width;

            find.Location = new Point(x, y);
            find.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            find.Close += OnFindClose;

            this.Controls.Add(find);
            find.BringToFront();

            IsFindActive = true;
        }

        private void OnFindClose()
        {
            if (IsFindActive)
            {
                this.Controls.Remove(find);
                IsFindActive = false;
                Editor.Focus();
            }
        }
    }
}
