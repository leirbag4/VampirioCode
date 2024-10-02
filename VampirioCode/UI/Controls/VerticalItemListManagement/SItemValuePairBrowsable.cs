using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItemValuePairBrowsable : SItem
    {
        // Events
        public event ValueChangedEvent LeftValueChanged;
        public event ValueChangedEvent RightValueChanged;

        public string LeftValue { get { return Text0.Text; } set { Text0.Text = value; if (LeftValueChanged != null) LeftValueChanged(Text0, Text0.Text); } }
        public string RightValue { get { return Text1.Text; } set { Text1.Text = value; if (RightValueChanged != null) RightValueChanged(Text1, Text1.Text); } }

        public bool LeftBrowsable { get; set; } = true;
        public bool RightBrowsable { get; set; } = true;

        public bool LeftEditable { get; set; } = true;
        public bool RightEditable { get; set; } = true;

        public BrowseInfo BrowseInfo { get; set; } = null;
        public BrowseInfo LeftBrowseInfo { get; set; } = null;
        public BrowseInfo RightBrowseInfo { get; set; } = null;

        private BrowseButton browseButton;
        protected TextBox editableTxtBox;
        protected SItemText currSitem;
        protected bool _editing = false;

        private const int BrowseButtonWidth = 30;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Division")]
        [Browsable(true)]
        public float Division { get { return _division; } set { SetDivision(value); } }

        private float _division = 0.5f;


        public SItemValuePairBrowsable() : base()
        {
            type = SItemType.ValuePairBrowsable;

            Text0.TextAlign = ContentAlignment.MiddleLeft;
            Text0.SetPercents(0.02f, 0.51f, 0.10f, 0.10f);
            Text0.SetBackColors(Color.FromArgb(58, 64, 72), Color.FromArgb(54, 62, 73), Color.FromArgb(60, 65, 71));
            Text0.Truncated = true;
            Text0.StateMode = SItemTextStateMode.OwnBehaviour;

            Text1.TextAlign = ContentAlignment.MiddleLeft;
            Text1.SetPercents(0.51f, 0.02f, 0.10f, 0.10f);
            Text1.SetBackColors(Color.FromArgb(72, 74, 88), Color.FromArgb(73, 76, 94), Color.FromArgb(71, 73, 84));
            Text1.Truncated = true;
            Text1.StateMode = SItemTextStateMode.OwnBehaviour;

            Text0.DoubleClick += OnLeftDoubleClick;
            Text1.DoubleClick += OnRightDoubleClick;

            editableTxtBox = new TextBox();
            editableTxtBox.BorderStyle = BorderStyle.None;
            editableTxtBox.ForeColor = Color.Silver;

            SetDivision(0.5f);
        }

        private void SetDivision(float division)
        {
            _division = division;

            Text0.RightPercent = 1.0f - _division + 0.01f;
            Text1.LeftPercent = _division + 0.01f;

            Invalidate();
        }

        private void OnLeftDoubleClick(SItemText sender)
        {
            if (LeftEditable)
                BeginEdit(sender);
        }

        private void OnRightDoubleClick(SItemText sender)
        {
            if (RightEditable)
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

        protected bool IsLeft(SItemText itext)
        {
            return (itext == Text0);
        }

        protected bool IsRight(SItemText itext)
        {
            return (itext == Text1);
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
            Text0.Visible = false;
            Text1.Visible = false;

            //
            // Editable Text Box
            //
            //editableTxtBox.Left =       _borderSize;
            /*editableTxtBox.Left =       (int)currSitem.rect.Left;

            editableTxtBox.Width =      (int)currSitem.rect.Width;//this.Width - _borderSize - _borderSize;
            editableTxtBox.Height =     this.Height - _borderSize - _borderSize;
            editableTxtBox.Top =        (this.Height >> 1) - (editableTxtBox.Height >> 1);
            editableTxtBox.BackColor =  GetCurrBackColor();
            editableTxtBox.Text =       currSitem.Text;
            editableTxtBox.TextAlign =  ContentAlignToHorizontal(TextAlign);

            this.Controls.Add(editableTxtBox);*/






            //
            // Editable Text Box
            //
            editableTxtBox.Left =       _borderSize;
            editableTxtBox.Width =      this.Width - _borderSize - _borderSize;
            editableTxtBox.Height =     this.Height - _borderSize - _borderSize;
            editableTxtBox.Top =        (this.Height >> 1) - (editableTxtBox.Height >> 1);
            editableTxtBox.BackColor =  GetCurrBackColor();
            editableTxtBox.Text =       currSitem.Text;//this.Text;
            editableTxtBox.TextAlign =  HorizontalAlignment.Center; //ContentAlignToHorizontal(TextAlign);

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


            //
            // Browseable Button
            //
            
            browseButton =          new BrowseButton();
            browseButton.Text =     ". . .";
            browseButton.Size =     new Size(BrowseButtonWidth, this.Height - _borderSize - _borderSize);
            browseButton.Top =      _borderSize;
            browseButton.Left =     this.Width - browseButton.Width - BorderSize;
            browseButton.OffsetY = -4;
            browseButton.Click +=   OnBrowsePressed;
            this.Controls.Add(browseButton);
            this.Controls.Add(editableTxtBox);


            editableTxtBox.Width -= browseButton.Width * 2;
            editableTxtBox.Left = _borderSize + browseButton.Width;


            

            _editing = true;
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

        private void OnEditableTxtBoxTextChanged(object? sender, EventArgs e)
        {
            currSitem.Text = editableTxtBox.Text;
        }

        private void OnEditableTxtBoxLeave(object? sender, EventArgs e)
        {
            EndEdition();
        }

        private void OnBrowsePressed(object? sender, EventArgs e)
        {
            if (IsLeft(currSitem))
            {
                if (LeftBrowseInfo != null)
                    OpenDirOrFile(LeftBrowseInfo);
                else
                    OpenDirOrFile(BrowseInfo);
            }
            else if (IsRight(currSitem))
            {
                if (RightBrowseInfo != null)
                    OpenDirOrFile(RightBrowseInfo);
                else
                    OpenDirOrFile(BrowseInfo);
            }

            EndEdition();
        }

        private void OpenDirOrFile(BrowseInfo browseInfo)
        {
            if (browseInfo.Mode == BrowseMode.Directory)
            {
                DirBrowseInfo binfo = (DirBrowseInfo)browseInfo;

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    //folderBrowserDialog.ShowNewFolderButton = true; // Optional: Allows the user to create new folders

                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    {
                        currSitem.Text = dialog.SelectedPath;
                    }
                }
            }
            else if (browseInfo.Mode == BrowseMode.File)
            {
                FileBrowseInfo binfo = (FileBrowseInfo)browseInfo;

                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Title = binfo.Title;
                    dialog.Filter = binfo.Filter;
                    dialog.Multiselect = false; // Ensure only one file can be selected

                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                    {
                        if (binfo.FullPath)
                            currSitem.Text = dialog.FileName;
                        else
                            currSitem.Text = Path.GetFileName(dialog.FileName);
                    }
                }
            }
        }

        private void OnParentIndexChanged(object sender)
        {
            EndEdition();
        }

        private void EndEdition()
        {
            // Original Text control
            //currSitem.Visible = true;
            Text0.Visible = true;
            Text1.Visible = true;


            if (this.Parent != null)
                ((VerticalItemListAdv)this.Parent).SelectedItemChanged -= OnParentIndexChanged;
            this.Controls.Remove(editableTxtBox);

            browseButton.Click -= OnBrowsePressed;
            this.Controls.Remove(browseButton);

            _editing = false;

            if ((LeftValueChanged != null) && (currSitem == Text0))
                LeftValueChanged(Text0, Text0.Text);

            if ((RightValueChanged != null) && (currSitem == Text1))
                RightValueChanged(Text1, Text1.Text);

            base.Invalidate();
        }
    }
}
