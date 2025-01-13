namespace VampirioCode.BuilderSetting.UI
{
    partial class ItemListPackages
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            downButton = new VampirioCode.UI.Controls.ButtonAdv();
            upButton = new VampirioCode.UI.Controls.ButtonAdv();
            addButton = new VampirioCode.UI.Controls.ButtonAdv();
            removeButton = new VampirioCode.UI.Controls.ButtonAdv();
            iconImg = new VampirioCode.UI.Controls.PictureBoxAdv();
            titleLabel = new VampirioCode.UI.Controls.LabelAdv();
            list = new VampirioCode.UI.Controls.VerticalItemListAdv();
            ((System.ComponentModel.ISupportInitialize)iconImg).BeginInit();
            SuspendLayout();
            // 
            // downButton
            // 
            downButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            downButton.BackColor = Color.FromArgb(30, 30, 30);
            downButton.BorderColor = Color.FromArgb(10, 10, 10);
            downButton.BorderSize = 1;
            downButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            downButton.expandImage = false;
            downButton.extraText = "";
            downButton.extraTextAlign = ContentAlignment.MiddleCenter;
            downButton.extraTextColor = Color.Black;
            downButton.extraTextFont = null;
            downButton.extraTextOffset = new Point(0, 0);
            downButton.FocusColor = Color.FromArgb(24, 81, 115);
            downButton.FocusEnabled = false;
            downButton.ForeColor = Color.FromArgb(120, 120, 120);
            downButton.Image = Properties.Resources.mini_arrow_down_style_b;
            downButton.Location = new Point(112, 142);
            downButton.Margin = new Padding(3, 2, 3, 2);
            downButton.Name = "downButton";
            downButton.PaintImageOnSelected = true;
            downButton.processEnterKey = true;
            downButton.resizeImage = new Point(0, 0);
            downButton.Selected = false;
            downButton.SelectedColor = Color.FromArgb(0, 122, 204);
            downButton.Size = new Size(36, 12);
            downButton.TabIndex = 38;
            downButton.UseVisualStyleBackColor = false;
            downButton.Click += OnDownPressed;
            // 
            // upButton
            // 
            upButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            upButton.BackColor = Color.FromArgb(30, 30, 30);
            upButton.BorderColor = Color.FromArgb(10, 10, 10);
            upButton.BorderSize = 1;
            upButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            upButton.expandImage = false;
            upButton.extraText = "";
            upButton.extraTextAlign = ContentAlignment.MiddleCenter;
            upButton.extraTextColor = Color.Black;
            upButton.extraTextFont = null;
            upButton.extraTextOffset = new Point(0, 0);
            upButton.FocusColor = Color.FromArgb(24, 81, 115);
            upButton.FocusEnabled = false;
            upButton.ForeColor = Color.FromArgb(120, 120, 120);
            upButton.Image = Properties.Resources.mini_arrow_up_style_b;
            upButton.Location = new Point(112, 128);
            upButton.Margin = new Padding(3, 2, 3, 2);
            upButton.Name = "upButton";
            upButton.PaintImageOnSelected = true;
            upButton.processEnterKey = true;
            upButton.resizeImage = new Point(0, 0);
            upButton.Selected = false;
            upButton.SelectedColor = Color.FromArgb(0, 122, 204);
            upButton.Size = new Size(36, 12);
            upButton.TabIndex = 37;
            upButton.UseVisualStyleBackColor = false;
            upButton.Click += OnUpPressed;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addButton.BackColor = Color.FromArgb(30, 30, 30);
            addButton.BorderColor = Color.FromArgb(10, 10, 10);
            addButton.BorderSize = 1;
            addButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            addButton.expandImage = false;
            addButton.extraText = "";
            addButton.extraTextAlign = ContentAlignment.MiddleCenter;
            addButton.extraTextColor = Color.Black;
            addButton.extraTextFont = null;
            addButton.extraTextOffset = new Point(0, 0);
            addButton.FocusColor = Color.FromArgb(24, 81, 115);
            addButton.FocusEnabled = false;
            addButton.ForeColor = Color.FromArgb(120, 120, 120);
            addButton.Image = Properties.Resources.mmenu_mini_find;
            addButton.Location = new Point(0, 128);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.PaintImageOnSelected = true;
            addButton.processEnterKey = true;
            addButton.resizeImage = new Point(0, 0);
            addButton.Selected = false;
            addButton.SelectedColor = Color.FromArgb(0, 122, 204);
            addButton.Size = new Size(51, 26);
            addButton.TabIndex = 36;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += OnFindPackagePressed;
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            removeButton.BackColor = Color.FromArgb(30, 30, 30);
            removeButton.BorderColor = Color.FromArgb(10, 10, 10);
            removeButton.BorderSize = 1;
            removeButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            removeButton.expandImage = false;
            removeButton.extraText = "";
            removeButton.extraTextAlign = ContentAlignment.MiddleCenter;
            removeButton.extraTextColor = Color.Black;
            removeButton.extraTextFont = null;
            removeButton.extraTextOffset = new Point(0, 0);
            removeButton.FocusColor = Color.FromArgb(24, 81, 115);
            removeButton.FocusEnabled = false;
            removeButton.ForeColor = Color.FromArgb(120, 120, 120);
            removeButton.Image = Properties.Resources.mmenu_mini_remove;
            removeButton.Location = new Point(56, 128);
            removeButton.Margin = new Padding(3, 2, 3, 2);
            removeButton.Name = "removeButton";
            removeButton.PaintImageOnSelected = true;
            removeButton.processEnterKey = true;
            removeButton.resizeImage = new Point(0, 0);
            removeButton.Selected = false;
            removeButton.SelectedColor = Color.FromArgb(0, 122, 204);
            removeButton.Size = new Size(51, 26);
            removeButton.TabIndex = 35;
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Click += OnRemovePressed;
            // 
            // iconImg
            // 
            iconImg.Image = Properties.Resources.package_icon;
            iconImg.Location = new Point(0, 1);
            iconImg.Margin = new Padding(3, 2, 3, 2);
            iconImg.Name = "iconImg";
            iconImg.Size = new Size(24, 18);
            iconImg.SizeMode = PictureBoxSizeMode.CenterImage;
            iconImg.TabIndex = 34;
            iconImg.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BorderColor = Color.DarkGray;
            titleLabel.BorderSize = 1;
            titleLabel.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(130, 130, 130);
            titleLabel.Location = new Point(26, 2);
            titleLabel.ModifyClampMax = 0F;
            titleLabel.ModifyClampMin = 0F;
            titleLabel.ModifyControlName = "";
            titleLabel.ModifyScale = 1F;
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(94, 15);
            titleLabel.TabIndex = 33;
            titleLabel.Text = "Install Packages";
            // 
            // list
            // 
            list.AllowPressedEvents = true;
            list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            list.BackColor = Color.FromArgb(54, 54, 54);
            list.ItemHeight = 35;
            list.ItemHeightType = VampirioCode.UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            list.Location = new Point(0, 24);
            list.Margin = new Padding(3, 2, 3, 2);
            list.Name = "list";
            list.SelectedIndex = -1;
            list.SelectionEnable = true;
            list.Size = new Size(148, 100);
            list.TabIndex = 32;
            // 
            // ItemListPackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(iconImg);
            Controls.Add(titleLabel);
            Controls.Add(list);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ItemListPackages";
            Size = new Size(148, 154);
            ((System.ComponentModel.ISupportInitialize)iconImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.ButtonAdv downButton;
        private VampirioCode.UI.Controls.ButtonAdv upButton;
        private VampirioCode.UI.Controls.ButtonAdv addButton;
        private VampirioCode.UI.Controls.ButtonAdv removeButton;
        private VampirioCode.UI.Controls.PictureBoxAdv iconImg;
        private VampirioCode.UI.Controls.LabelAdv titleLabel;
        private VampirioCode.UI.Controls.VerticalItemListAdv list;
    }
}
