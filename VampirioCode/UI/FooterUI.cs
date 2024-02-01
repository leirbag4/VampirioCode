using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampDocManager;

namespace VampirioCode.UI
{
    public partial class FooterUI : UserControl
    {
        private int _line = 0;
        private int _char = 0;

        public int Line { get { return _line; } set { _line = value; this.lineLabel.Text = "Line " + _line; } }
        public int Character { get { return _char; } set { _char = value; this.charLabel.Text = "Char " + _char; } }

        public DocumentType DocType 
        {
            set 
            { 
                     if (value == DocumentType.OTHER)   languageLabel.Text = "...";
                else if (value == DocumentType.CSHARP)  languageLabel.Text = "C#";
                else if (value == DocumentType.CPP)     languageLabel.Text = "C++";
                else if (value == DocumentType.JS)      languageLabel.Text = "JS";
                else if (value == DocumentType.PHP)     languageLabel.Text = "PHP";
            } 
        }

        public FooterUI()
        {
            InitializeComponent();
        }

        public void SetLineChar(int line, int character)
        { 
            Line =      line;
            Character = character;
        }
    }
}
