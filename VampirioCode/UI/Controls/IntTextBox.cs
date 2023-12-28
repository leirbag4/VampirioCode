using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.Events;

namespace VampirioCode.UI.Controls
{
    public class IntTextBox : BaseNumberTextBox, ICustomInput
    {
        public delegate void KeyPressedEventHandler(Object sender, KeyPressedEventArgs e);

        //private const String _includeOnlyCharacters = "0123456789";
        private bool _allowEmptyInput = false;
        private String _numberMask = "";

        //public bool enableEvents = true;

        [Category("Extra Events")]
        [Description("Event on ENTER key pressed")]
        [Browsable(true)]
        public event KeyPressedEventHandler EnterPressed;

        public IntTextBox()
        {
            value = 0;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int value
        {
            get { return NORMALIZED_VALUE(); }
            set
            {
                base.Text = value.ToString();
                NORMALIZE_AND_CHANGE_NUMBER();
            }
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

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Number Mask")]
        [Browsable(true)]
        public String NumberMask
        {
            get { return _numberMask; }
            set { _numberMask = value; }
        }

        public String getValue()
        {
            NORMALIZE_AND_CHANGE_NUMBER();
            return Text;
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
            String prevTxt;

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
            else if (!isIncluded(e.KeyChar))
            {
                e.Handled = true;
            }



            base.OnKeyPress(e);
        }

        private void NORMALIZE_AND_CHANGE_NUMBER()
        {
            int value;

            if (!int.TryParse(Text, out value))
                value = 0;

            if (_allowEmptyInput && (base.Text.Trim() == ""))
            {
                base.Text = "";
                return;
            }

            if (_numberMask != "")
                base.Text = value.ToString(_numberMask);
            else
                base.Text = value.ToString();

        }

        private int NORMALIZED_VALUE()
        {
            int value;

            if (!int.TryParse(base.Text, out value))
                value = 0;

            return value;
        }

        /*private bool isIncluded(char c)
        {
            char[] chars = _includeOnlyCharacters.ToCharArray();

            for (int a = 0; a < chars.Length; a++)
            {
                if (chars[a] == c)
                    return true;
            }

            return false;
        }*/


    }
}
