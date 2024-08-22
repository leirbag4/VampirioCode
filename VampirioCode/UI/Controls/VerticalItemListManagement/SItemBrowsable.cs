using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public enum BrowseMode
    {
        File,
        Directory
    }

    public class BrowseInfo
    {
        public string Title { get; set; } = "";
        public BrowseMode Mode { get { return _mode; } }

        protected BrowseMode _mode = BrowseMode.Directory;
    }

    public class DirBrowseInfo : BrowseInfo
    {
        public DirBrowseInfo()
        {
            _mode = BrowseMode.Directory;
        }
    }

    public class FileBrowseInfo : BrowseInfo
    {
        public string Filter { get; set; } = "";
        public bool FullPath { get; set; } = false;
        public FileBrowseInfo(string title, bool fullPath, string filter)
        {
            _mode =     BrowseMode.File;
            FullPath =  fullPath;
            Filter =    filter;
        }
    }

    public class SItemBrowsable : SItem
    {
        public BrowseInfo BrowseInfo { get; set; } = null;

        private TextBox editableTxtBox;
        private BrowseButton browseButton;

        public SItemBrowsable() : base()
        {
            type = SItemType.Browsable;

            editableTxtBox = new TextBox();
            editableTxtBox.BorderStyle = BorderStyle.None;
            editableTxtBox.ForeColor =   Color.Silver;

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

            //
            // Browseable Button
            //
            
            browseButton =          new BrowseButton();
            browseButton.Text =     ". . .";
            browseButton.Size =     new Size(30, this.Height - _borderSize - _borderSize);
            browseButton.Top =      _borderSize;
            browseButton.Left =     this.Width - browseButton.Width - BorderSize;
            browseButton.OffsetY = -4;
            browseButton.Click +=   OnBrowsePressed;
            this.Controls.Add(browseButton);
            this.Controls.Add(editableTxtBox);


            editableTxtBox.Width -= browseButton.Width * 2;
            editableTxtBox.Left = _borderSize + browseButton.Width;

        }

        private void OnBrowsePressed(object? sender, EventArgs e)
        {
            if (BrowseInfo != null)
            {
                if (BrowseInfo.Mode == BrowseMode.Directory)
                {
                    DirBrowseInfo browseInfo = (DirBrowseInfo)BrowseInfo;

                    using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                    {
                        //folderBrowserDialog.ShowNewFolderButton = true; // Optional: Allows the user to create new folders

                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                        {
                            this.Text = dialog.SelectedPath;
                        }
                    }
                }
                else if (BrowseInfo.Mode == BrowseMode.File)
                {
                    FileBrowseInfo browseInfo = (FileBrowseInfo)BrowseInfo;

                    using (OpenFileDialog dialog = new OpenFileDialog())
                    {
                        dialog.Title =  browseInfo.Title;
                        dialog.Filter = browseInfo.Filter;
                        dialog.Multiselect = false; // Ensure only one file can be selected

                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                        {
                            if (browseInfo.FullPath)
                                Text = dialog.FileName;
                            else
                                Text = Path.GetFileName(dialog.FileName);
                        }
                    }
                }
            }

            EndEdition();
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


            browseButton.Click -= OnBrowsePressed;
            this.Controls.Remove(browseButton);

            base.Invalidate();
        }

    }


    public class BrowseButton : Control
    {
        protected enum State { Up, Over, Down }

        public Color UpColor { get; set; } = Color.FromArgb(220, 220, 220);
        public Color OverColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color DownColor { get; set; } = Color.FromArgb(190, 190, 190);
        public Color BkgUpColor { get; set; } = Color.FromArgb(63, 64, 76);
        public Color BkgOverColor { get; set; } = Color.FromArgb(65, 63, 76);
        public Color BkgDownColor { get; set; } = Color.FromArgb(69, 63, 76);

        public int OffsetX = 0;
        public int OffsetY = 0;

        private StringFormat stringFormat;
        private State currState = State.Up;


        public BrowseButton()
        {
            DoubleBuffered = true;
            stringFormat =                  new StringFormat(StringFormatFlags.NoWrap);
            stringFormat.Alignment =        StringAlignment.Center;
            stringFormat.LineAlignment =    StringAlignment.Center;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            currState = State.Up;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (currState != State.Down)
            {
                currState = State.Over;
                Invalidate();
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            currState = State.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            currState = State.Up;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = Color.Transparent;
            Color bkgColor =  Color.Transparent;

                 if (currState == State.Up)     bkgColor = BkgUpColor;
            else if(currState == State.Over)    bkgColor = BkgOverColor;
            else if(currState == State.Down)    bkgColor = BkgDownColor;

                 if (currState == State.Up)     foreColor = UpColor;
            else if(currState == State.Over)    foreColor = OverColor;
            else if(currState == State.Down)    foreColor = DownColor;

            e.Graphics.FillRectangle(new SolidBrush(bkgColor), this.ClientRectangle);
            e.Graphics.DrawString(Text, Font, new SolidBrush(foreColor), new RectangleF(OffsetX, OffsetY, this.Width, this.Height), stringFormat);
        }
    }

}
