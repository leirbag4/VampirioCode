using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class JsonTreeNode : TreeNode
    {
        public JsonTreeNode(string text = "") :base(text) { }

        public override void OnTextPaint(Graphics g, Font font, TRect rect, string text)
        {
            string []arr = text.Split(':');
            string prop;
            string val;
            TRect currRect;
            Color color;
            Color normalColor = Color.FromArgb(191, 191, 255);

            if (arr.Length == 2)
            {
                //VampirioGraphics.DrawString(g, font, text, Color.Red, rect.X, rect.Y);

                //VampirioGraphics.DrawString(g, font, arr[0], Color.Red, rect.X, rect.Y);
                //VampirioGraphics.DrawString(g, font, arr[1], Color.Blue, rect.X, rect.Y);
                
                prop =  arr[0];
                val =   arr[1].Trim();

                if (val.ToLower() == "null")
                {
                    color = Color.FromArgb(79, 140, 191); // It's a null
                }
                else if (int.TryParse(val, out int ival))
                {
                    color = Color.FromArgb(181, 206, 168); // It's an int
                }
                else if (double.TryParse(val, out double dval))
                {
                    color = Color.FromArgb(181, 206, 168); // It's a decimal
                }
                else if (bool.TryParse(val, out bool bval))
                {
                    color = Color.FromArgb(114, 184, 255); // It's a boolean
                }
                else if ((val.Length > 0) && (val[0] == '"') && (val[val.Length - 1] == '"'))
                {
                    color = Color.FromArgb(206, 145, 120); // It's a string
                }
                else
                {
                    color = Color.Red; // Unknown value
                }


                TStringBuilder stringBuilder = new TStringBuilder(rect);
                int space = (int)stringBuilder.GetSpaceSize(font).Width;

                currRect = stringBuilder.Add(font, prop);
                VampirioGraphics.DrawString(g, font, prop, normalColor, currRect.X, currRect.Y);

                currRect = stringBuilder.Add(font, ":");
                VampirioGraphics.DrawString(g, font, ":", normalColor, currRect.X, currRect.Y);

                currRect = stringBuilder.Add(font, val);
                VampirioGraphics.DrawString(g, font, val, color, currRect.X - space, currRect.Y);

            }
            else
                VampirioGraphics.DrawString(g, font, Text, normalColor, rect.X, rect.Y);
        }

    }
}
