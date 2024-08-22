using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItem : LItem
    {
        public override String Text
        {
            set { Text0.Text = value; }
            get { return Text0.Text; }
        }

        public Image Image
        {
            set { Image0.Image = value; }
            get { return Image0.Image; }
        }

        public /*override */ContentAlignment TextAlign
        {
            set { Texts[0].TextAlign = value; }
            get { return Texts[0].TextAlign; }
        }

        public SItemType type = SItemType.SItem;

        public SItemText Text0 { set { if (Texts.Count < 1) Texts.Add(new SItemText()); Texts[0] = value; } get { if (Texts.Count < 1) Texts.Add(new SItemText()); return Texts[0]; } }
        public SItemText Text1 { set { if (Texts.Count < 2) Texts.Add(new SItemText()); Texts[1] = value; } get { if (Texts.Count < 2) Texts.Add(new SItemText()); return Texts[1]; } }
        public SItemText Text2 { set { if (Texts.Count < 3) Texts.Add(new SItemText()); Texts[2] = value; } get { if (Texts.Count < 3) Texts.Add(new SItemText()); return Texts[2]; } }
        public SItemText Text3 { set { if (Texts.Count < 4) Texts.Add(new SItemText()); Texts[3] = value; } get { if (Texts.Count < 4) Texts.Add(new SItemText()); return Texts[3]; } }

        public SItemImage Image0 { set { if (Images.Count < 1) Images.Add(new SItemImage()); Images[0] = value; } get { if (Images.Count < 1) Images.Add(new SItemImage()); return Images[0]; } }
        public SItemImage Image1 { set { if (Images.Count < 2) Images.Add(new SItemImage()); Images[1] = value; } get { if (Images.Count < 2) Images.Add(new SItemImage()); return Images[1]; } }
        public SItemImage Image2 { set { if (Images.Count < 3) Images.Add(new SItemImage()); Images[2] = value; } get { if (Images.Count < 3) Images.Add(new SItemImage()); return Images[2]; } }
        public SItemImage Image3 { set { if (Images.Count < 4) Images.Add(new SItemImage()); Images[3] = value; } get { if (Images.Count < 4) Images.Add(new SItemImage()); return Images[3]; } }


        public List<SItemText> Texts =      new List<SItemText>();
        public List<SItemImage> Images =    new List<SItemImage>();

        private int mouseX = -1;
        private int mouseY = -1;
        private bool doubleClick = false;

        public SItem()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }

        private bool IsInside(int mouseX, int mouseY, RectangleF rect)
        {
            return IsInside(mouseX, mouseY, (int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Bottom);
        }

        private bool IsInside(int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return ((mouseX >= x) && (mouseX <= (x + width)) && (mouseY >= y) && (mouseY <= (y + height)));
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            doubleClick = true;
            base.OnDoubleClick(e);
        }

        protected override void OnUpdate(int mouseX, int mouseY, MouseState mouseState, MouseButtons buttons)
        {
            this.mouseX =       mouseX;
            this.mouseY =       mouseY;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            SItemText itext;
            SItemImage iimage;
            Brush textColor = Brushes.Black;
            Brush backColor = Brushes.Transparent;
            
            base.OnPaint(e);

            for (int a = 0; a < Images.Count; a++)
            {
                iimage = Images[a];
                if (iimage.Visible)
                    PaintImage(e.Graphics, Images[a], false);
            }

            for (int a = 0; a < Texts.Count; a++)
            {
                itext = Texts[a];

                if (itext.Visible)
                {
                         if (state == LItemState.UP)    { textColor = new SolidBrush(itext.UpColor);    backColor = new SolidBrush(itext.BackUpColor);   }
                    else if (state == LItemState.OVER)  { textColor = new SolidBrush(itext.OverColor);  backColor = new SolidBrush(itext.BackOverColor); }
                    else if (state == LItemState.DOWN)  { textColor = new SolidBrush(itext.DownColor);  backColor = new SolidBrush(itext.BackDownColor); }

                    string text = itext.Text;

                    if (itext.PercentMode)
                    {

                        itext.CalcPercents(this.Width, this.Height);

                        if (itext.Truncated)
                            text = itext.Truncate(e.Graphics, itext.rect.Width);

                        RectangleF rect = itext.rect;
                        

                        if (itext.StateMode == SItemTextStateMode.OwnBehaviour)
                        {
                            if (IsInside(mouseX, mouseY, rect))
                            {
         
                                if (state == LItemState.DOWN)
                                {
                                    itext.dragging = true;

                                    textColor = new SolidBrush(itext.DownColor);
                                    backColor = new SolidBrush(itext.BackDownColor);
                                }
                                else if (state == LItemState.OVER)
                                {
                                    if (itext.dragging)
                                    {
                                        textColor = new SolidBrush(itext.DownColor);
                                        backColor = new SolidBrush(itext.BackDownColor);
                                    }
                                    else
                                    {
                                        textColor = new SolidBrush(itext.OverColor);
                                        backColor = new SolidBrush(itext.BackOverColor);
                                    }
                                }
                                else if (state == LItemState.UP)
                                {
                                    textColor = new SolidBrush(itext.UpColor);
                                    backColor = new SolidBrush(itext.BackUpColor);
                                    itext.dragging = false;
                                }

                                // trigger double click event
                                if (doubleClick)
                                {
                                    itext.TriggerDoubleClick();
                                    doubleClick = false;
                                }
                            }
                            else 
                            {
                                if(state == LItemState.UP)
                                    itext.dragging = false;

                                if (itext.dragging)
                                {
                                    textColor = new SolidBrush(itext.DownColor);
                                    backColor = new SolidBrush(itext.BackDownColor);
                                }
                                else
                                {
                                    textColor = new SolidBrush(itext.UpColor); 
                                    backColor = new SolidBrush(itext.BackUpColor);
                                }
                            }

                            if (itext.UseBackColor)
                                e.Graphics.FillRectangle(backColor, rect);

                            e.Graphics.DrawString(text, itext.Font, textColor, rect, itext.StringFormat);

                        }
                        else if (itext.StateMode == SItemTextStateMode.InheritFromParent)
                        {
                            if (itext.UseBackColor)
                                e.Graphics.FillRectangle(backColor, rect);

                            e.Graphics.DrawString(text, itext.Font, textColor, rect, itext.StringFormat);
                        }
                    }
                    else
                    {
                        if (itext.Truncated)
                            text = itext.Truncate(e.Graphics, this.Width);

                        RectangleF rect = new RectangleF(itext.Offsets.X, itext.Offsets.Y, this.Width + itext.Offsets.X, this.Height + itext.Offsets.Y);

                        if (itext.UseBackColor)
                            e.Graphics.FillRectangle(backColor, rect);

                        e.Graphics.DrawString(text, itext.Font, textColor, rect, itext.StringFormat);
                    }

                }
            }

        }

    }
}
