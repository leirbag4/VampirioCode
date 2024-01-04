using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.UI
{
    public partial class ToolBar : UserControl
    {

        public delegate void StartPressedEvent();
        public delegate void ReloadPressedEvent();

        public event StartPressedEvent StartPressed;
        public event ReloadPressedEvent ReloadPressed;

        public ToolBar()
        {
            InitializeComponent();
        }

        private void OnStartPressed(object sender, EventArgs e)
        {
            if (StartPressed != null)
                StartPressed();
        }

        private void OnReloadPressed(object sender, EventArgs e)
        {
            if (ReloadPressed != null)
                ReloadPressed();
        }
    }
}
