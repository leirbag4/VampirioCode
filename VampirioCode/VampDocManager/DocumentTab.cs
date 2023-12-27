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
        public Document Document { get; set; }
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


    }
}
