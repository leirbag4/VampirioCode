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
        //public string Text { get { return _editor.Text; } set { _editor.Text = value; } }
        public string Text { get { return ""; } set { } } // remove title behaviour
        public string Title { get { return base.Text; } }

        public Document Document { get; private set; }
        public VampirioEditor Editor { get { return editor; } }

        private VampirioEditor editor;

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
            Editor.TextChanged +=   OnEditorTextChanged;
            Document.OnSaved +=     OnSaved;
            Document.OnModified +=  OnModified;

            return this;
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
    }
}
