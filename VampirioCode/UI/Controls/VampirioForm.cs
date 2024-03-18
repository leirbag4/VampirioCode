using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Style;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls
{
    public class VampirioForm : Form
    {

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor { get; set; } = Color.FromArgb(20, 20, 20);

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Size")]
        [Browsable(true)]
        public int BorderSize { get; set; } = 0;

        public VampirioForm()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public void ShowMe(ContainerControl parent)
        {
            if (parent != null) SimpleOverlay.ShowFX(parent);
            this.ShowDialog(parent);
            if (parent != null) SimpleOverlay.HideFX();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            VampirioGraphics.FillRect(e.Graphics, BackColor, BorderColor, BorderSize, ClientRectangle);

            base.OnPaint(e);
        }
    }
}
