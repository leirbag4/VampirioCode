using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Style;

namespace VampirioCode.UI.Controls
{
    public class VampirioForm : Form
    {

        public VampirioForm()
        {
            this.BackColor = Color.FromArgb(45, 45, 45);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public void ShowMe(ContainerControl parent)
        {
            if (parent != null) SimpleOverlay.showFX(parent);
            this.ShowDialog(parent);
            if (parent != null) SimpleOverlay.hideFX();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
