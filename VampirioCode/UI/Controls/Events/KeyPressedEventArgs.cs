using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.Events
{
    public class KeyPressedEventArgs : EventArgs
    {

        public bool valueChanged;
        public bool highlighted;

        public KeyPressedEventArgs(bool valueChanged, bool highlighted)
        {
            this.valueChanged = valueChanged;
            this.highlighted = highlighted;
        }

    }
}
