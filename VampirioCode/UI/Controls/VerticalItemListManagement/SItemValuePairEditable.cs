using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItemValuePairEditable : SItemValuePair
    {
        // Events
        public event ValueChangedEvent LeftValueChanged;
        public event ValueChangedEvent RightValueChanged;

        public string LeftValue { get { return Text0.Text; } set { Text0.Text = value; if (LeftValueChanged != null) LeftValueChanged(Text0, Text0.Text); } }
        public string RightValue { get { return Text1.Text; } set { Text1.Text = value; if (RightValueChanged != null) RightValueChanged(Text1, Text1.Text); } }

        public bool LeftEditable { get; set; } = true;
        public bool RightEditable { get; set; } = true;

        //public string LeftText { get { return Text0.Text; } set { Text0.Text = value; if (LeftTextChanged != null) LeftTextChanged(Text0, Text0.Text); } }
        //public string RightText { get { return Text1.Text; } set { Text1.Text = value; if (RightTextChanged != null) RightTextChanged(Text1, Text1.Text); } }

        protected TextBox editableTxtBox;
        protected SItemText currSitem;
        protected bool _editing = false;

        public SItemValuePairEditable() :base() 
        {
            type = SItemType.ValuePairEditable;

            Text0.DoubleClick += OnLeftDoubleClick;
            Text1.DoubleClick += OnRightDoubleClick;

            editableTxtBox =                new TextBox();
            editableTxtBox.BorderStyle =    BorderStyle.None;
            editableTxtBox.ForeColor =      Color.Silver;
        }

        private void OnLeftDoubleClick(SItemText sender)
        {
            if(LeftEditable)
                BeginEdit(sender);
        }

        private void OnRightDoubleClick(SItemText sender)
        {
            if(RightEditable)
                BeginEdit(sender);
        }

        protected static HorizontalAlignment ContentAlignToHorizontal(ContentAlignment align)
        {
            int numb = (int)align;
        
                if((numb & 0x111) != 0) return HorizontalAlignment.Left;
           else if((numb & 0x222) != 0) return HorizontalAlignment.Center;
           else if((numb & 0x444) != 0) return HorizontalAlignment.Right;

            return HorizontalAlignment.Center;// never reach here
        }

        protected void BeginEdit(SItemText itext)
        {
            if (_editing)
            {
                if (itext != currSitem)
                    EndEdition();
            }

            currSitem = itext;

            //
            // Original Text control
            //
            currSitem.Visible = false;

            //
            // Editable Text Box
            //
            //editableTxtBox.Left =       _borderSize;
            editableTxtBox.Left =       (int)currSitem.rect.Left;

            editableTxtBox.Width =      (int)currSitem.rect.Width;//this.Width - _borderSize - _borderSize;
            editableTxtBox.Height =     this.Height - _borderSize - _borderSize;
            editableTxtBox.Top =        (this.Height >> 1) - (editableTxtBox.Height >> 1);
            editableTxtBox.BackColor =  GetCurrBackColor();
            editableTxtBox.Text =       currSitem.Text;
            editableTxtBox.TextAlign =  ContentAlignToHorizontal(TextAlign);

            this.Controls.Add(editableTxtBox);

            editableTxtBox.Focus();
            editableTxtBox.TextChanged -=   OnEditableTxtBoxTextChanged;
            editableTxtBox.TextChanged +=   OnEditableTxtBoxTextChanged;
            editableTxtBox.Leave -=         OnEditableTxtBoxLeave;
            editableTxtBox.Leave +=         OnEditableTxtBoxLeave;
            editableTxtBox.KeyDown -=       OnEditableTxtBoxKeyPressed;
            editableTxtBox.KeyDown +=       OnEditableTxtBoxKeyPressed;

            ((VerticalItemListAdv)this.Parent).SelectedItemChanged -= OnParentIndexChanged;
            ((VerticalItemListAdv)this.Parent).SelectedItemChanged += OnParentIndexChanged;

            _editing = true;
        }

        private void OnParentIndexChanged(object sender)
        {
            EndEdition();
        }

        private void OnEditableTxtBoxTextChanged(object? sender, EventArgs e)
        {
            currSitem.Text = editableTxtBox.Text;
        }

        private void OnEditableTxtBoxKeyPressed(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EndEdition();
                e.Handled = true;
                e.SuppressKeyPress = true; // Supress the ding doing sound
            }
        }

        private void OnEditableTxtBoxLeave(object? sender, EventArgs e)
        {
            EndEdition();
        }

        private void EndEdition()
        {
            // Original Text control
            currSitem.Visible = true;


            if (this.Parent != null)
                ((VerticalItemListAdv)this.Parent).SelectedItemChanged -= OnParentIndexChanged;
            this.Controls.Remove(editableTxtBox);

            _editing = false;

            if ((LeftValueChanged != null) && (currSitem == Text0))
                LeftValueChanged(Text0, Text0.Text);

            if ((RightValueChanged != null) && (currSitem == Text1))
                RightValueChanged(Text1, Text1.Text);

            base.Invalidate();
        }
    }
}
