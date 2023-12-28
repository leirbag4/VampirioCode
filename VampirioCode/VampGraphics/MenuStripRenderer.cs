using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.VampGraphics
{
    public class MenuStripRenderer : ToolStripProfessionalRenderer
    {


        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

            Color color;
            if (e.Item.Selected)
                color = Color.FromArgb(40, 40, 40);
            else
                color = Color.FromArgb(30, 30, 30);

            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, rc);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {

            if ((e.Item as ToolStripSeparator) == null)
                base.OnRenderSeparator(e);
            else
            {

                SolidBrush backBrush = new SolidBrush(Color.FromArgb(60, 60, 60));
                SolidBrush lineBrush = new SolidBrush(Color.FromArgb(71, 71, 71));
                SolidBrush lineBrush2 = new SolidBrush(Color.FromArgb(66, 66, 66));

                e.Graphics.FillRectangle(backBrush, 0, 0, e.Item.Width, e.Item.Height);
                e.Graphics.FillRectangle(lineBrush, 4, (e.Item.Height >> 1) - 1, e.Item.Width - 8, 1);
                e.Graphics.FillRectangle(lineBrush2, 4, (e.Item.Height >> 1), e.Item.Width - 8, 1);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            //IF TOP bar menu, return
            if ((e.ToolStrip as MenuStrip) != null)
                return;

            SolidBrush br = new SolidBrush(Color.FromArgb(40, 40, 40));
            SolidBrush br2 = new SolidBrush(Color.FromArgb(0, 122, 240));
            Pen pen = new Pen(br);
            Pen pen2 = new Pen(br2);

            e.Graphics.DrawRectangle(pen, 1, 1, e.AffectedBounds.Width - 3, e.AffectedBounds.Height - 3);
            e.Graphics.DrawRectangle(pen2, 0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
        }
    }
}
