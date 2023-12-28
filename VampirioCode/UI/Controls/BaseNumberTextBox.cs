using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls
{
    public class BaseNumberTextBox : TextBox
    {
        protected const String _includeOnlyCharacters = "0123456789";
        protected char DECIMAL_SEPARATOR;
        protected int ROUND_DIGITS;
        public bool enableEvents = true;

        protected override void OnTextChanged(EventArgs e)
        {
            if (enableEvents)
                base.OnTextChanged(e);
        }

        protected bool reachDecimalLength()
        {
            int decimalStartAt;
            char[] chars = this.Text.ToCharArray();
            int decimalCount = 0;

            decimalStartAt = this.Text.IndexOf(DECIMAL_SEPARATOR.ToString());

            if (decimalStartAt == -1)
                return false;
            else if (SelectionStart <= decimalStartAt)
            {
                return false;
            }
            else
            {

                for (int a = decimalStartAt; a < chars.Length; a++)
                {
                    if (char.IsNumber(chars[a]))
                        decimalCount++;
                }

                if (decimalCount < ROUND_DIGITS)
                    return false;
                else
                    return true;
            }

        }

        protected bool isAnyNumberToTheLeft()
        {
            bool leftNumb = false;
            char[] chars = this.Text.ToCharArray();

            for (int a = 0; a < SelectionStart; a++)
            {
                if (char.IsNumber(chars[a]))
                {
                    leftNumb = true;
                    break;
                }
            }

            return leftNumb;
        }

        protected bool isIncluded(char c)
        {

            char[] chars = _includeOnlyCharacters.ToCharArray();

            for (int a = 0; a < chars.Length; a++)
            {
                if (chars[a] == c)
                    return true;
            }

            return false;
        }

    }
}
