using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls
{
    public class ButtonAdv : Button
    {
        private enum ImageState
        {
            UP,
            OVER,
            DOWN
        }

        protected String _extraText = "";
        protected ContentAlignment _extraTextAlign = ContentAlignment.MiddleCenter;
        protected Point _extraTextOffset;//0, 0 by default
        protected Font _extraTextFont;
        protected Color _extraTextColor = Color.Black;
        protected Point _resizeImage;
        protected bool _expandImage = false;

        protected StringFormat strFormat;
        private ImageState state = ImageState.UP;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Process Enter Key")]
        [Browsable(true)]
        public bool processEnterKey
        {
            set { _processEnterKey= value; }
            get { return _processEnterKey; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Extra Text")]
        [Browsable(true)]
        public String extraText
        {
            set { _extraText = value; }
            get { return _extraText; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Extra Text Align")]
        [Browsable(true)]
        public ContentAlignment extraTextAlign
        {
            set
            {
                _extraTextAlign = value;
                strFormat = new StringFormat();

                Int32 lNum = (Int32)Math.Log((Double)_extraTextAlign, 2);
                strFormat.LineAlignment = (StringAlignment)(lNum / 4);
                strFormat.Alignment = (StringAlignment)(lNum % 4);
            }
            get { return _extraTextAlign; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Extra Text Offset")]
        [Browsable(true)]
        public Point extraTextOffset
        {
            set { _extraTextOffset = value; }
            get { return _extraTextOffset; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Extra Text Font")]
        [Browsable(true)]
        public Font extraTextFont
        {
            set { _extraTextFont = value; }
            get { return _extraTextFont; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Extra Text Color")]
        [Browsable(true)]
        public Color extraTextColor
        {
            set { _extraTextColor = value; }
            get { return _extraTextColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Expand Image")]
        [Browsable(true)]
        public bool expandImage
        {
            set { _expandImage = value; }
            get { return _expandImage; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Resize Image")]
        [Browsable(true)]
        public Point resizeImage
        {
            set
            {
                if (Image != null)
                {
                    _resizeImage = value;

                    if ((_resizeImage.X > 0) && (_resizeImage.Y > 0))
                        Image = VampirioGraphics.ResizeBitmap((Bitmap)Image, _resizeImage.X, _resizeImage.Y, true);
                }
            }
            get { return _resizeImage; }

        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Custom Visual Style")]
        [Browsable(true)]
        public CustomStyle CStyle
        {
            get { return _customStyle; }
            set { _customStyle = value; Invalidate(); }
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
        [Description("Border Size")]
        [Browsable(true)]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
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
        [Description("Selected")]
        [Browsable(true)]
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Focus Color")]
        [Browsable(true)]
        public Color FocusColor
        {
            get { return _focusColor; }
            set { _focusColor= value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Focus Color")]
        [Browsable(true)]
        public bool FocusEnabled
        {
            get { return _focusEnabled; }
            set { _focusEnabled = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Paint Image On Selected")]
        [Browsable(true)]
        public bool PaintImageOnSelected
        {
            get { return _paintImageOnSelected; }
            set { _paintImageOnSelected = value; Invalidate(); }
        }

        public enum CustomStyle
        {
            NORMAL,
            SOLID,
            ROUND_SOLID,
            SOLID_NO_BORDERS,
            SOLID_RIGHT_ARROW
        }

        protected bool _processEnterKey = true;
        protected CustomStyle _customStyle = CustomStyle.NORMAL;
        protected Color _borderColor = Color.DarkGray;
        protected int _borderSize = 1;
        protected Color _selectedColor = Color.FromArgb(0, 122, 204);
        protected bool _selected = false;
        protected Color _focusColor = Color.FromArgb(0x18, 0x51, 0x73);
        protected bool _focusEnabled = false;
        protected bool _paintImageOnSelected = true;

        protected void paintXImage(Graphics g, bool expand)
        {
            float col = 0;
            int _x, _y, _w, _h;
            float R, G, B;

            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                  new float[] {1, 0, 0, 0, 0},
                  new float[] {0, 1, 0, 0, 0},
                  new float[] {0, 0, 1, 0, 0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {0.3f, 0.3f, 0.3f, 0, 1}
                });

            if (state == ImageState.UP)
                col = 0;
            else if (state == ImageState.OVER)
                col = 0.1f;
            else if (state == ImageState.DOWN)
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
                if (Selected && PaintImageOnSelected)
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
                }
            }

            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            if (expand)
            {
                g.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                g.DrawImage(Image, new Rectangle(0, 0, Width, Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ia);
            }
            else
            {
                _w = Image.Width;
                _h = Image.Height;
                _x = 0;
                _y = 0;

                //ImageAlign == ContentAlignment.MiddleCenter

                Int32 lNum = (Int32)Math.Log((Double)this.ImageAlign, 2);
                float yAlign = (lNum / 4);
                float xAlign = (lNum % 4);
                xAlign--; yAlign--;
                //FROM -1 to 1

                
                if (xAlign == -1)
                    _x = 0 + Margin.Left;
                else if (xAlign == 0)
                    _x = (Width >> 1) - (Image.Width >> 1);
                else //if(xAlign == 1)
                    _x = Width - Image.Width - Margin.Right;

                if (yAlign == -1)
                    _y = 0 + Margin.Top;
                else if (yAlign == 0)
                    _y = (Height >> 1) - (Image.Height >> 1);
                else //if(yAlign == 1)
                    _y = Height - Image.Height - Margin.Right;

                g.DrawImage(Image, new Rectangle(_x, _y, _w, _h), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ia);
            }
        }


        protected override void OnMouseHover(EventArgs e)
        {
            //if (expandImage)
            //{
            state = ImageState.OVER;
            Invalidate();
            //}
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            //if (expandImage)
            //{
            state = ImageState.DOWN;
            //    Invalidate();
            //}
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            //if (expandImage)
            //{
            state = ImageState.UP;
            Invalidate();
            //}
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //if (expandImage)
            //{
            state = ImageState.UP;
            Invalidate();
            //}
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            //if (expandImage)
            //{
            state = ImageState.OVER;
            Invalidate();
            //}
            base.OnMouseMove(mevent);
        }

        protected StringFormat getFormat()
        {
            StringFormat cFormat = new StringFormat();
            Int32 lNum = (Int32)Math.Log((Double)this.TextAlign, 2);
            cFormat.LineAlignment = (StringAlignment)(lNum / 4);
            cFormat.Alignment = (StringAlignment)(lNum % 4);
            return cFormat;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Disable ENTER Key
            if (_processEnterKey == false)
            {
                if (keyData == Keys.Return)
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color borColor = BorderColor;
            Color bkgColor = BackColor;
            Rectangle rect;


            if (state == ImageState.OVER)
            {
                borColor = ImageFX.Tint(BorderColor, Color.White, 0.025f);
                bkgColor = ImageFX.Tint(BackColor, Color.White, 0.025f);
            }

            if (Selected)
            {
                borColor = ImageFX.Tint(BorderColor, SelectedColor, 0.55f);
                bkgColor = ImageFX.Tint(BackColor, SelectedColor, 0.55f);
            }

            if (!Enabled)
            {
                borColor = ImageFX.Tint(BorderColor, Color.Black, 0.15f);
                bkgColor = ImageFX.Tint(BackColor, Color.Black, 0.15f);
            }

            if (expandImage && (Image != null))
            {
                paintXImage(e.Graphics, true);
            }
            else
            {
                if (_customStyle == CustomStyle.NORMAL)
                {
                    base.OnPaint(e);
                }
                else if (_customStyle == CustomStyle.SOLID)
                {
                    rect = new Rectangle(ClientRectangle.X + Margin.Left, ClientRectangle.Y + Margin.Top, ClientRectangle.Width - Margin.Right, ClientRectangle.Height - Margin.Bottom);
                    e.Graphics.FillRectangle(new SolidBrush(borColor), ClientRectangle);
                    e.Graphics.FillRectangle(new SolidBrush(bkgColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, getFormat());

                    if (Image != null)
                        paintXImage(e.Graphics, false);
                }
                else if (_customStyle == CustomStyle.ROUND_SOLID)
                {
                    rect = new Rectangle(ClientRectangle.X + Margin.Left, ClientRectangle.Y + Margin.Top, ClientRectangle.Width - Margin.Right, ClientRectangle.Height - Margin.Bottom);
                    e.Graphics.Clear(Parent.BackColor);
                    VampirioGraphics.FillRoundRect(e.Graphics, bkgColor, borColor, _borderSize, ClientRectangle);
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, getFormat());

                    if (Image != null)
                        paintXImage(e.Graphics, false);
                }
                else if (_customStyle == CustomStyle.SOLID_NO_BORDERS)
                {
                    rect = new Rectangle(ClientRectangle.X + Margin.Left, ClientRectangle.Y + Margin.Top, ClientRectangle.Width - Margin.Right, ClientRectangle.Height - Margin.Bottom);
                    e.Graphics.FillRectangle(new SolidBrush(bkgColor), ClientRectangle);
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, getFormat());

                    if (Image != null)
                        paintXImage(e.Graphics, false);
                }
                else if (_customStyle == CustomStyle.SOLID_RIGHT_ARROW)
                {
                    int arrow_width = 14;
                    Point[] points;
                    rect = new Rectangle(ClientRectangle.X + Margin.Left, ClientRectangle.Y + Margin.Top, ClientRectangle.Width - Margin.Right, ClientRectangle.Height - Margin.Bottom);

                    e.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
                    e.Graphics.FillRectangle(new SolidBrush(borColor), 0, 0, Width - arrow_width - BorderSize, Height);
                    e.Graphics.FillRectangle(new SolidBrush(bkgColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2) - arrow_width, Height - (_borderSize * 2)));

                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    int boff = BorderSize >> 1;
                    if (boff <= 0)
                        boff = 1;

                    //------------------------------------------------------------
                    points = new Point[] { new Point(Width - arrow_width - BorderSize - boff, 0),
                                       new Point(Width - boff - boff, Height >> 1),
                                       new Point(Width - arrow_width - BorderSize - boff, Height - boff)};

                    e.Graphics.FillPolygon(new SolidBrush(bkgColor), points);
                    e.Graphics.DrawLines(new Pen(borColor, BorderSize), points);
                    //------------------------------------------------------------

                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, getFormat());

                    if (Image != null)
                        paintXImage(e.Graphics, false);
                }
                
            }

            if ((_extraText != "") && (_extraTextFont != null))
            {
                e.Graphics.DrawString(_extraText, _extraTextFont, new SolidBrush(extraTextColor), new RectangleF(_extraTextOffset.X, _extraTextOffset.Y, this.Width + _extraTextOffset.X, this.Height + _extraTextOffset.Y), strFormat);
            }

            if(Focused && _focusEnabled)
                e.Graphics.DrawRectangle(new Pen(_focusColor, 1), 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }

    }
}
