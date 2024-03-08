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

        public DocumentType DocType 
        {
            set 
            { 
                     if (value == DocumentType.OTHER)   languageLabel.Text = "...";
                else if (value == DocumentType.CSHARP)  languageLabel.Text = "C#";
                else if (value == DocumentType.CPP)     languageLabel.Text = "C++";
                else if (value == DocumentType.JS)      languageLabel.Text = "JS";
                else if (value == DocumentType.PHP)     languageLabel.Text = "PHP";
                else if (value == DocumentType.TXT)     languageLabel.Text = "TXT";
            } 
        }

        private int _line =     1;
        private int _column =   1;

        public FooterUI()
        {
            InitializeComponent();
        }

        public void SetLineColumn(int line, int column)
        {
            line +=     1;
            column +=   1;

            // update only if value has changed
            if (_line != line)
            {
                if (lineLabel.InvokeRequired)
                {
                    lineLabel.Invoke(new MethodInvoker(delegate { lineLabel.Text = line.ToString(); }));
                }
                else
                    lineLabel.Text = line.ToString();
                
                _line = line;
            }

            // update only if value has changed
            if (_column != column)
            {
                if (columnLabel.InvokeRequired)
                {
                    columnLabel.Invoke(new MethodInvoker(delegate { columnLabel.Text = column.ToString(); }));
                }
                else
                    columnLabel.Text = column.ToString();

                _column = column;
            }
        }

        public void SetInfo(string str)
        {
            if (infoLabel.InvokeRequired)
            {
                infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text = str; }));
            }
            else
                infoLabel.Text = str;
        }
    }
}
