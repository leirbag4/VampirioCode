﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabStyle
    {
        public Color BackColor;
        public Color TextColor;
        public Color BorderColor;

        public TabStyle(Color backColor,  Color textColor, Color borderColor)
        { 
            this.BackColor =    backColor;
            this.TextColor =    textColor;
            this.BorderColor =  borderColor;
        }
    }
}
