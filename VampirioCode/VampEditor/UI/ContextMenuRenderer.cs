using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode
{
    public class ContextMenuRenderer : ToolStripProfessionalRenderer
    {

        public Color BackColor;
        public Color SelectedBackColor;
        public Color BorderColor;
        public Color FontColor;
        public Color SeparatorLineColor;
        public Color SeparatorLine2Color;
        public int BorderSize;

        public ContextMenuRenderer()
        {
            SetDefaultStyle2();
        }

        public void SetDefaultStyle()
        {
            BackColor =             CColor(30, 30, 30);
            SelectedBackColor =     CColor(40, 40, 40);
            BorderColor =           CColor(63, 52, 83); //CColor(0, 122, 240);
            FontColor =             CColor(160, 160, 160);
            SeparatorLineColor =    CColor(63, 52, 83);
            SeparatorLine2Color =   CColor(40, 30, 50);
            BorderSize =            1;
        }

        public void SetDefaultStyle2()
        {
            BackColor =             CColor(45, 45, 45);
            SelectedBackColor =     CColor(40, 40, 40);
            BorderColor =           CColor(139, 70, 166);//CColor(63, 52, 83); //CColor(0, 122, 240);
            FontColor =             CColor(180, 180, 180);
            SeparatorLineColor =    CColor(139, 70, 166);
            SeparatorLine2Color =   CColor(80, 65, 90);
            BorderSize =            1;
        }

        private Color CColor(int red, int green, int blue)
        { 
            return Color.FromArgb(red, green, blue);
        }

        public void SetItem(ToolStripMenuItem item)
        { 
            item.ForeColor = FontColor;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

            Color color;
            if (e.Item.Selected)
                color = SelectedBackColor;
            else
                color = BackColor;

            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, rc);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {

            if (e.Item as ToolStripSeparator == null)
                base.OnRenderSeparator(e);
            else
            {

                SolidBrush backBrush =  new SolidBrush(BackColor);              //new SolidBrush(Color.FromArgb(60, 60, 60));
                SolidBrush lineBrush =  new SolidBrush(SeparatorLineColor);     //new SolidBrush(Color.FromArgb(71, 71, 71));
                SolidBrush lineBrush2 = new SolidBrush(SeparatorLine2Color);    //new SolidBrush(Color.FromArgb(66, 66, 66));

                e.Graphics.FillRectangle(backBrush, 0, 0, e.Item.Width, e.Item.Height);
                e.Graphics.FillRectangle(lineBrush, 4, (e.Item.Height >> 1) - 1, e.Item.Width - 8, 1);
                e.Graphics.FillRectangle(lineBrush2, 4, e.Item.Height >> 1, e.Item.Width - 8, 1);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            //IF TOP bar menu, return
            if (e.ToolStrip as MenuStrip != null)
                return;

            SolidBrush br =     new SolidBrush(BackColor);  //new SolidBrush(Color.FromArgb(200, 40, 40));
            SolidBrush br2 =    new SolidBrush(BorderColor);//new SolidBrush(Color.FromArgb(0, 122, 240));
            Pen pen = new Pen(br);
            Pen pen2 = new Pen(br2);


            if (BorderSize == 1)
            {
                e.Graphics.DrawRectangle(pen, 1, 1, e.AffectedBounds.Width - 3, e.AffectedBounds.Height - 3);
                e.Graphics.DrawRectangle(pen2, 0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
            }
            else if (BorderSize == 2)
            {
                e.Graphics.DrawRectangle(pen2, 1, 1, e.AffectedBounds.Width - 3, e.AffectedBounds.Height - 3);
                e.Graphics.DrawRectangle(pen2, 0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
            }
        }
    }
}
