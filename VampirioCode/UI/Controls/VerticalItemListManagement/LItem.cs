using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class LItem : Control
    {

        protected enum LItemState
        {
            UP,
            OVER,
            DOWN
        }

        public enum BMode
        {
            ONLY_ON_SELECTION,
            ALWAYS
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Up Color")]
        [Browsable(true)]
        public Color UpColor
        {
            get { return _upColor; }
            set { _upColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Over Color")]
        [Browsable(true)]
        public Color OverColor
        {
            get { return _overColor; }
            set { _overColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Down Color")]
        [Browsable(true)]
        public Color DownColor
        {
            get { return _downColor; }
            set { _downColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Selected Color")]
        [Browsable(true)]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Selected Border Color")]
        [Browsable(true)]
        public Color SelectedBorderColor
        {
            get { return _selectedBorderColor; }
            set { _selectedBorderColor = value; Invalidate(); }
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
        [Description("Border Mode")]
        [Browsable(true)]
        public BMode BorderMode
        {
            get { return _borderMode; }
            set { _borderMode = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; /*Invalidate();*/ }
        }

        



        protected LItemState state =                LItemState.UP;
        protected Color _selectedBorderColor =      Color.FromArgb(65, 105, 225);
        protected int _borderSize =                 1;
        protected Color _borderColor =              Color.FromArgb(20, 20, 20);
        protected Color _upColor =                  Color.FromArgb(64, 64, 64);
        protected Color _overColor =                Color.FromArgb(60, 60, 60);
        protected Color _downColor =                Color.FromArgb(55, 56, 63);
        protected Color _selectedColor =            Color.FromArgb(57, 58, 70);
        protected bool _selected =                  false;
        protected BMode _borderMode =               BMode.ONLY_ON_SELECTION;

        public LItem()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true); // Allow Double Click event
        }


        protected override void OnMouseHover(EventArgs e)
        {
            state = LItemState.OVER;
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            state = LItemState.DOWN;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            state = LItemState.UP;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = LItemState.UP;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            state = LItemState.OVER;
            Invalidate();
            base.OnMouseMove(mevent);
        }

        protected void PaintCheckBox(Graphics g, SItemCheckBox checkBox, bool expand)
        {
            PaintImage(g, checkBox, expand);
            //Image img = checkBox.Image;
            //g.DrawImage(img, new Rectangle(_x + image.Offsets.X, _y + image.Offsets.Y, _w, _h), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
        }

        protected void PaintImage(Graphics g, SItemImage image, bool expand, float red = 1f, float green = 1f, float blue = 1f)
        {
            float col = 0;
            int _x, _y, _w, _h;
            float R, G, B;

            Image img = image.Image;

            //if (image.Image == null)
            //    return;

            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                  new float[] {1 * red, 0, 0, 0, 0},
                  new float[] {0, 1 * green, 0, 0, 0},
                  new float[] {0, 0, 1 * blue, 0, 0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0.3f, 0.3f, 0.3f, 0, 1}
                });

            if (state == LItemState.UP)
                col = 0;
            else if (state == LItemState.OVER)
                col = 0.1f;
            else if (state == LItemState.DOWN)
                col = 0.15f;

            if (!Enabled)
            {
                cm = new ColorMatrix(new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            }
            else
            {
                /*if (Selected && PaintImageOnSelected)
                {
                    R = (((float)SelectedColor.R) / 0xFF);
                    G = (((float)SelectedColor.G) / 0xFF);
                    B = (((float)SelectedColor.B) / 0xFF);

                    cm = new ColorMatrix(new float[][]
                    {
                      new float[] {R, 0, 0, 0, 0},
                      new float[] {0, G, 0, 0, 0},
                      new float[] {0, 0, B, 0, 0},
                      new float[] {0, 0, 0, 0.7f, 0},
                      new float[] {0.2f, 0.2f, 0.2f, 0, 1}
                    });
                }
                else
                {
                    cm.Matrix40 = col;
                    cm.Matrix41 = col;
                    cm.Matrix42 = col;
                }*/
                cm.Matrix40 = col;
                cm.Matrix41 = col;
                cm.Matrix42 = col;
            }

            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            if (expand)
            {
                g.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                g.DrawImage(img, new Rectangle(0, 0, Width, Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            }
            else
            {
                _w = img.Width;
                _h = img.Height;
                _x = 0;
                _y = 0;

                //ImageAlign == ContentAlignment.MiddleCenter

                Int32 lNum = (Int32)Math.Log((Double)image.ImageAlign, 2);
                float yAlign = (lNum / 4);
                float xAlign = (lNum % 4);
                xAlign--; yAlign--;
                //FROM -1 to 1


                if (xAlign == -1)
                    _x = 0 + Margin.Left;
                else if (xAlign == 0)
                    _x = (Width >> 1) - (img.Width >> 1);
                else //if(xAlign == 1)
                    _x = Width - img.Width - Margin.Right;

                if (yAlign == -1)
                    _y = 0 + Margin.Top;
                else if (yAlign == 0)
                    _y = (Height >> 1) - (img.Height >> 1);
                else //if(yAlign == 1)
                    _y = Height - img.Height - Margin.Right;

                g.DrawImage(img, new Rectangle(_x + image.Offsets.X, _y + image.Offsets.Y, _w, _h), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            SolidBrush itemBrush = null;
            SolidBrush borderBrush = null;
            
            if (_selected)
            {
                itemBrush =     new SolidBrush(_selectedColor);
                borderBrush =   new SolidBrush(_selectedBorderColor);
            }
            else
            {
                if (state == LItemState.UP)
                {
                    itemBrush = new SolidBrush(_upColor);
                }
                else if (state == LItemState.OVER)
                {
                    itemBrush = new SolidBrush(_overColor);
                }
                else if (state == LItemState.DOWN)
                {
                    itemBrush = new SolidBrush(_downColor);
                }

                borderBrush = new SolidBrush(_borderColor);
            }

            if (_borderMode == BMode.ONLY_ON_SELECTION)
            {
                if (_selected)
                {
                    e.Graphics.FillRectangle(borderBrush, ClientRectangle);
                    e.Graphics.FillRectangle(itemBrush, new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
                }
                else
                    e.Graphics.FillRectangle(itemBrush, ClientRectangle);

            }
            else if(_borderMode == BMode.ALWAYS)
            {
                e.Graphics.FillRectangle(borderBrush, ClientRectangle);
                e.Graphics.FillRectangle(itemBrush, new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
            }

        }

    }
}
