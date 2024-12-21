using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.Events;

namespace VampirioCode.UI.Controls
{
    public class TextBoxAdv : TextBox, ICustomInput
    {
        private String _excludeCharacters;
        private String _includeOnlyCharacters;
        private bool _allowBackspace = true;
        private bool _autoEdition = false;
        private bool _allowTextEdition = true;
        private char _leftLeadingChar = '\0';
        private bool _autoSelect = false;

        public bool enableEvents = true;

        public delegate void KeyPressedEventHandler(Object sender, KeyPressedEventArgs e);

        [Category("Extra Events")]
        [Description("Event on ENTER key pressed")]
        [Browsable(true)]
        public event KeyPressedEventHandler EnterPressed;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Exclude these characters")]
        [Browsable(true)]
        public String ExcludeCharacters
        {
            get { return _excludeCharacters; }
            set { _excludeCharacters = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Only these characters will be accepted. If filled, then ExcludeCharacters is not relevant.")]
        [Browsable(true)]
        public String IncludeOnlyCharacters
        {
            get { return _includeOnlyCharacters; }
            set { _includeOnlyCharacters = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Allow Backspace so user can delete innerText")]
        [Browsable(true)]
        public bool AllowBackspace
        {
            get { return _allowBackspace; }
            set { _allowBackspace = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Allow Text Edition")]
        [Browsable(true)]
        public bool AllowTextEdition
        {
            get { return _allowTextEdition; }
            set { _allowTextEdition = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Input will stay as Read Only on Focus Out.")]
        [Browsable(true)]
        public bool AutoEdition
        {
            get { return _autoEdition; }
            set
            {
                _autoEdition = value;

                if (_autoEdition)
                {
                    ReadOnly = true;

                }
                else
                {
                    ReadOnly = false;
                }

            }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Left leading character. E.g with zeros: 0001")]
        [Browsable(true)]
        public char LeftLeadingCharacter
        {
            get { return _leftLeadingChar; }
            set { _leftLeadingChar = value; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Auto Select")]
        [Browsable(true)]
        public bool AutoSelect
        {
            get { return _autoSelect; }
            set { _autoSelect = value; }
        }

        public String TextOrInt
        {
            get
            {
                int numb;

                if (int.TryParse(Text, out numb))
                    return numb.ToString();
                else
                    return Text;
            }
        }

        public String getValue()
        {
            return Text;
        }

        public bool isIntNumber()
        {
            int n;
            return int.TryParse(Text, out n);
        }

        /*public void parseToInt()
        { 
            Text = int.Parse(Text).ToString();
        }*/

        public int intValue()
        {
            return int.Parse(Text);
        }



        protected override void OnClick(EventArgs e)
        {
            if (_autoEdition && Focused)
            {
                ReadOnly = false;
            }

            base.OnClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (_autoEdition)
            {
                ReadOnly = false;
            }

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (_autoEdition)
            {
                ReadOnly = true;
            }

            if ((_leftLeadingChar != '\0') && (MaxLength < 100))
            {
                Text = Text.PadLeft(MaxLength, _leftLeadingChar);
                Console.WriteLine("MaxLength: " + MaxLength + " _leftLeadingChar:" + _leftLeadingChar);
            }

            base.OnLostFocus(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (_autoSelect)
            {
                // Kick off SelectAll asyncronously so that it occurs after Click
                BeginInvoke((Action)delegate
                {
                    SelectAll();
                });
            }

            base.OnMouseUp(mevent);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            String prevTxt;

            if (_autoEdition && Focused)
                ReadOnly = false;

            if (!_allowTextEdition)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == (char)Keys.Back) && _allowBackspace)//backspace
            {

            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                prevTxt = Text;

                if (_autoEdition)
                {
                    ReadOnly = true;
                }

                if (_autoSelect)
                {
                    // Kick off SelectAll asyncronously so that it occurs after Click
                    BeginInvoke((Action)delegate
                    {
                        SelectAll();
                    });
                }

                //EVENT
                if (EnterPressed != null)
                    EnterPressed(this, new KeyPressedEventArgs(prevTxt != Text, SelectionLength != 0));
            }
            else
            {
                if ((IncludeOnlyCharacters != null) && (IncludeOnlyCharacters != ""))
                {
                    if (!isIncluded(e.KeyChar))
                        e.Handled = true;
                }
                else
                {
                    if (isExcluded(e.KeyChar))
                        e.Handled = true;
                }
            }

            base.OnKeyPress(e);
        }

        private bool isExcluded(char c)
        {
            if (_excludeCharacters == null)
                return false;

            char[] chars = _excludeCharacters.ToCharArray();

            for (int a = 0; a < chars.Length; a++)
            {
                if (chars[a] == c)
                    return true;
            }

            return false;
        }

        private bool isIncluded(char c)
        {
            if (_includeOnlyCharacters == null)
                return false;

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
