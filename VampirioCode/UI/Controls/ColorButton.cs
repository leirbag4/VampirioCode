using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.UI.Controls
{
    public class ColorButton : ButtonAdv
    {

        public delegate void ColorChangedEvent(Object sender, Color color);

        [Category("Extra Events")]
        [Description("Event on color changed")]
        [Browsable(true)]
        public event ColorChangedEvent ColorChanged;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Color")]
        [Browsable(true)]
        public Color SelectedColor
        {
            set { _selectedColor = value; Invalidate(); }
            get { return _selectedColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor
        {
            set { _borderColor = value; }
            get { return _borderColor; }
        }

        public String HtmlColor
        {
            set { SelectedColor = System.Drawing.ColorTranslator.FromHtml(value); }
            //get { return System.Drawing.ColorTranslator.ToHtml(selectedColor); }
            get { return System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(SelectedColor.ToArgb())); } // avoid the KnownColor trick ;)
        }

        private Color _selectedColor =  Color.White;
        private Color _borderColor =    Color.Gray;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SelectedColor = colorDialog.Color;
                
                if (ColorChanged != null)
                    ColorChanged(this, SelectedColor);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush brush = new SolidBrush(SelectedColor);
            Pen pen = new Pen(BorderColor);
            e.Graphics.FillRectangle(brush, 3, 3, Width - 6, Height - 6);
            e.Graphics.DrawRectangle(pen, 3, 3, Width - 7, Height - 7);
        }

    }
}
