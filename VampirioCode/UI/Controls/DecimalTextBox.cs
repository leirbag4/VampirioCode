using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.Events;

namespace VampirioCode.UI.Controls
{
    public class DecimalTextBox : BaseNumberTextBox, ICustomInput
    {
        private bool _useNegativeValues = false;
        private bool _allowEmptyInput = false;

        public delegate void KeyPressedEventHandler(Object sender, KeyPressedEventArgs e);

        [Category("Extra Events")]
        [Description("Event on ENTER key pressed")]
        [Browsable(true)]
        public event KeyPressedEventHandler EnterPressed;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Use Negative Values")]
        [Browsable(true)]
        public bool UseNegativeValues
        {
            get { return _useNegativeValues; }
            set { _useNegativeValues = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Max Decimal Places")]
        [Browsable(true)]
        public int MaxDecimalPlaces
        {
            get { return ROUND_DIGITS; }
            set { ROUND_DIGITS = value; NORMALIZE_AND_CHANGE_NUMBER(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Allow Empty Input")]
        [Browsable(true)]
        public bool AllowEmptyInput
        {
            get { return _allowEmptyInput; }
            set { _allowEmptyInput = value; }
        }

        public DecimalTextBox()
        {
            DECIMAL_SEPARATOR = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            ROUND_DIGITS = 2;
            value = 0;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal value
        {
            get { return NORMALIZED_VALUE(); }
            set
            {
                //base.Text = decimal.Round(value, ROUND_DIGITS).ToString("F" + ROUND_DIGITS); 
                base.Text = value.ToString();
                NORMALIZE_AND_CHANGE_NUMBER();
            }
        }

        public String getValue()
        {
            NORMALIZE_AND_CHANGE_NUMBER();
            return base.Text;
        }

        protected override void OnLeave(EventArgs e)
        {
            NORMALIZE_AND_CHANGE_NUMBER();
            base.OnLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            // Kick off SelectAll asyncronously so that it occurs after Click
            BeginInvoke((Action)delegate
            {
                SelectAll();
            });

            base.OnMouseUp(mevent);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //Console.WriteLine("e.KeyChar: " + e.KeyChar);
            String prevTxt;

            if (e.KeyChar == '.')
                e.KeyChar = DECIMAL_SEPARATOR;

            if (e.KeyChar == (char)Keys.Back)//backspace
            {

            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                prevTxt = Text;
                NORMALIZE_AND_CHANGE_NUMBER();
                BeginInvoke((Action)delegate
                {
                    SelectAll();
                });
                e.Handled = false;


                //EVENT
                if (EnterPressed != null)
                    EnterPressed(this, new KeyPressedEventArgs(prevTxt != Text, SelectionLength != 0));
            }
            else if (e.KeyChar == DECIMAL_SEPARATOR)
            {
                //if all text is selected (highlighted), then any key will delete text
                //so accept another DECIMAL_SEPARATOR
                if (SelectionLength == base.Text.Length)
                    e.Handled = false;
                else if (base.Text.Contains(DECIMAL_SEPARATOR))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else if (UseNegativeValues && e.KeyChar == '-')
            {
                if (SelectionLength == base.Text.Length)
                    e.Handled = false;
                else if (base.Text.Contains("-"))
                    e.Handled = true;
                else if (isAnyNumberToTheLeft())
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else if (!isIncluded(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (reachDecimalLength() && (ROUND_DIGITS != -1))
            {
                e.Handled = true;
            }



            base.OnKeyPress(e);
        }

        private decimal ROUND(decimal val)
        {
            if (ROUND_DIGITS == -1)
                return val;
            else
                return decimal.Round(val, ROUND_DIGITS);
        }

        private void NORMALIZE_AND_CHANGE_NUMBER()
        {
            Decimal value;

            if (!Decimal.TryParse(base.Text, out value))
                value = 0;

            if (_allowEmptyInput && (base.Text.Trim() == ""))
            {
                base.Text = "";
                return;
            }

            value = ROUND(value);

            if (ROUND_DIGITS == -1)
                base.Text = value.ToString();
            else
                base.Text = value.ToString("F" + ROUND_DIGITS);
        }

        private decimal NORMALIZED_VALUE()
        {
            Decimal value;

            if (!Decimal.TryParse(base.Text, out value))
                value = 0;

            return ROUND(value);
        }

    }
}
