using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls
{
    public class LabelAdv : Label
    {

        private CustomStyle _customStyle = CustomStyle.NORMAL;

        public enum CustomStyle
        {
            NORMAL,
            LITE_RECT_LEFT,
            LITE_DASHED_RECT_LEFT,
            LITE_RECT_RIGHT,
            LITE_DASHED_RECT_RIGHT,
            SOLID
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Custom Visual Style")]
        [Browsable(true)]
        public CustomStyle CStyle
        {
            get { return _customStyle; }
            set { _customStyle = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Size")]
        [Browsable(true)]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Modify Control Name")]
        [Browsable(true)]
        public String ModifyControlName
        {
            get { return _modifyControlName; }
            set { _modifyControlName = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Modify Scale")]
        [Browsable(true)]
        public float ModifyScale
        {
            get { return _modifyScale; }
            set { _modifyScale = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Modify Clamp Min")]
        [Browsable(true)]
        public float ModifyClampMin
        {
            get { return _modifyClampMin; }
            set { _modifyClampMin = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Modify Clamp Max")]
        [Browsable(true)]
        public float ModifyClampMax
        {
            get { return _modifyClampMax; }
            set { _modifyClampMax = value; }
        }

        private Color _borderColor = Color.DarkGray;
        private int _borderSize = 1;
        private String _modifyControlName = "";

        private IntTextBox MOD_intTextBox = null;
        private DecimalTextBox MOD_decimalTextBox = null;
        private float _modifyScale = 1.0f;
        private float _modifyClampMin = 0.0f;
        private float _modifyClampMax = 0.0f;

        private int lastMouseX = 0;

        /*protected override void OnMouseHover(EventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
            base.OnMouseHover(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
            base.OnMouseEnter(e);
        }*/

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int diff;
            decimal decimalVal;
            int intVal;

            setupModifyControl();
            if (hasModifyControl())
            {
                Cursor.Current = Cursors.SizeWE;
                diff = Cursor.Position.X - lastMouseX;
                lastMouseX = Cursor.Position.X;

                if (e.Button == MouseButtons.Left)
                {
                    if (MOD_decimalTextBox != null)
                    {
                        decimalVal = MOD_decimalTextBox.value + (decimal)(diff * _modifyScale);
                        if (_modifyClampMin != _modifyClampMax)
                        {
                            if (decimalVal < (decimal)_modifyClampMin) decimalVal = (decimal)_modifyClampMin;
                            if (decimalVal > (decimal)_modifyClampMax) decimalVal = (decimal)_modifyClampMax;
                        }
                        MOD_decimalTextBox.value = decimalVal;
                    }
                    else if (MOD_intTextBox != null)
                    {
                        intVal = MOD_intTextBox.value + (int)(diff * _modifyScale);
                        if (_modifyClampMin != _modifyClampMax)
                        {
                            if (intVal < (int)_modifyClampMin) intVal = (int)_modifyClampMin;
                            if (intVal > (int)_modifyClampMax) intVal = (int)_modifyClampMax;
                        }
                        MOD_intTextBox.value = intVal;
                    }


                    Screen myScreen = Screen.FromControl(this);
                    Rectangle area = myScreen.WorkingArea;

                    if (Cursor.Position.X > (area.X + area.Width - 5))
                    {
                        Cursor.Position = new Point(area.X + 1, Cursor.Position.Y);
                        lastMouseX = Cursor.Position.X;
                    }
                    else if (Cursor.Position.X < (area.X + 1))
                    {
                        Cursor.Position = new Point(area.X + area.Width - 10, Cursor.Position.Y);
                        lastMouseX = Cursor.Position.X;
                    }
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            setupModifyControl();
            if (hasModifyControl())
            {
                Cursor.Current = Cursors.SizeWE;
                lastMouseX = Cursor.Position.X;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            setupModifyControl();
            if (hasModifyControl())
            {

            }

            base.OnMouseUp(e);
        }

        protected bool hasModifyControl()
        {
            return ((MOD_intTextBox != null) || (MOD_decimalTextBox != null));
        }

        protected void setupModifyControl()
        {
            Control con;
            if ((MOD_intTextBox == null) && (MOD_decimalTextBox == null) && (_modifyControlName != ""))
            {
                Control[] controls = this.Parent.Controls.Find(_modifyControlName, true);
                if (controls.Length > 0)
                {
                    con = controls[0];

                    MOD_intTextBox = con as IntTextBox;
                    MOD_decimalTextBox = con as DecimalTextBox;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen;
            Brush brush;

            if ((CStyle == CustomStyle.LITE_RECT_LEFT) || (CStyle == CustomStyle.LITE_DASHED_RECT_LEFT))
            {
                pen = new Pen(Color.FromArgb(217, 217, 217), 1);
                if (CStyle == CustomStyle.LITE_DASHED_RECT_LEFT)
                    pen.DashPattern = new float[] { 6.0f, 3.0f };
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                brush = new SolidBrush(Color.FromArgb(217, 217, 217));
                e.Graphics.FillRectangle(brush, 0, 0, 4, this.Height);
            }
            else if ((CStyle == CustomStyle.LITE_RECT_RIGHT) || (CStyle == CustomStyle.LITE_DASHED_RECT_RIGHT))
            {
                pen = new Pen(Color.FromArgb(217, 217, 217), 1);
                if (CStyle == CustomStyle.LITE_DASHED_RECT_RIGHT)
                    pen.DashPattern = new float[] { 6.0f, 3.0f };
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                brush = new SolidBrush(Color.FromArgb(217, 217, 217));
                e.Graphics.FillRectangle(brush, this.Width - 4, 0, 4, this.Height);
            }
            else if (CStyle == CustomStyle.SOLID)
            {
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), ClientRectangle);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
            }

            base.OnPaint(e);
        }


    }
}
