using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TEditableTextBox : TextBoxAdv
    {
        //public string Text { get; set; } = "";

        public TEditableTextBox()
        { 
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = Color.Silver;
            this.BackColor = Color.FromArgb(50, 50, 50);
        }
    }
}
