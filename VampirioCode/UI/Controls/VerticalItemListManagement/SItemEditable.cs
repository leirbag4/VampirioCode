using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItemEditable : SItem
    {
        private TextBox editableTxtBox;

        public SItemEditable() 
        {
            type = SItemType.Editable;

            editableTxtBox = new TextBox();
            editableTxtBox.BorderStyle = BorderStyle.None;
            editableTxtBox.ForeColor = Color.Silver;

            this.Text0.Truncated = true;
        }

        protected static HorizontalAlignment ContentAlignToHorizontal(ContentAlignment align)
        {
            int numb = (int)align;
        
                if((numb & 0x111) != 0) return HorizontalAlignment.Left;
           else if((numb & 0x222) != 0) return HorizontalAlignment.Center;
           else if((numb & 0x444) != 0) return HorizontalAlignment.Right;

            return HorizontalAlignment.Center;// never reach here
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            BeginEdit();

            base.OnDoubleClick(e);
        }

        protected void BeginEdit()
        {
            //
            // Original Text control
            //
            this.Text0.Visible = false;

            //
            // Editable Text Box
            //
            editableTxtBox.Left =       _borderSize;
            editableTxtBox.Width =      this.Width - _borderSize - _borderSize;
            editableTxtBox.Height =     this.Height - _borderSize - _borderSize;
            editableTxtBox.Top =        (this.Height >> 1) - (editableTxtBox.Height >> 1);
            editableTxtBox.BackColor =  GetCurrBackColor();
            editableTxtBox.Text =       this.Text;
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


        }

        private void OnParentIndexChanged(object sender)
        {
            EndEdition();
        }

        private void OnEditableTxtBoxTextChanged(object? sender, EventArgs e)
        {
            this.Text = editableTxtBox.Text;
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
            this.Text0.Visible = true;


            if (this.Parent != null)
                ((VerticalItemListAdv)this.Parent).SelectedItemChanged -= OnParentIndexChanged;
            this.Controls.Remove(editableTxtBox);


            base.Invalidate();
        }
    }
}
