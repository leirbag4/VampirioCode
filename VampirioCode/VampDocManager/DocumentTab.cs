using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampEditor;

namespace VampDocManager
{
    public class DocumentTab : TabPage
    {
        public string Text { get { return _editor.Text; } set { _editor.Text = value; } }
        public string Title { get { return base.Text; } set { base.Text = value; } }

        public Document Document { get; private set; }
        public VampirioEditor Editor { get { return _editor; } }

        private VampirioEditor _editor;



        public DocumentTab() 
        {
            _editor =               new VampirioEditor();
            _editor.Dock =          DockStyle.Fill;
            _editor.BorderStyle =   ScintillaNET.BorderStyle.None;
            _editor.SetLanguage(VampEditor.LangId.CSharp, VampEditor.StyleMode.Dark);
            this.BackColor =        Color.FromArgb(30, 30, 30);
            this.BorderStyle =      BorderStyle.None;
            this.Controls.Add(_editor);
        }

        private void Init(Document doc)
        { 
            this.Document = doc;
            this.Title =    doc.FileName;
            this.Text =     doc.Text;
        }

        public static DocumentTab Create(Document doc)
        { 
            DocumentTab docTab = new DocumentTab();
            docTab.Init(doc);
            return docTab;
        }

    }
}
