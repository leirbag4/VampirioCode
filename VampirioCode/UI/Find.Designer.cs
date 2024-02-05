namespace VampirioCode.UI
{
    partial class Find
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
            findInput = new Controls.ComboBoxAdv();
            closeButton = new Controls.ButtonAdv();
            pictureBoxAdv1 = new Controls.PictureBoxAdv();
            replaceInput = new Controls.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // findInput
            // 
            findInput.BackColor = Color.FromArgb(52, 52, 52);
            findInput.BorderColor = Color.FromArgb(100, 100, 100);
            findInput.BorderSize = 2;
            findInput.ButtonColor = SystemColors.Control;
            findInput.ForeColor = Color.Silver;
            findInput.FormattingEnabled = true;
            findInput.Location = new Point(35, 7);
            findInput.Name = "findInput";
            findInput.Size = new Size(151, 28);
            findInput.TabIndex = 0;
            findInput.EnterPressed += OnFindEnterPressed;
            // 
            // closeButton
            // 
            closeButton.BorderColor = Color.DarkGray;
            closeButton.BorderSize = 1;
            closeButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
            closeButton.expandImage = false;
            closeButton.extraText = "";
            closeButton.extraTextAlign = ContentAlignment.MiddleCenter;
            closeButton.extraTextColor = Color.Black;
            closeButton.extraTextFont = null;
            closeButton.extraTextOffset = new Point(0, 0);
            closeButton.FocusColor = Color.FromArgb(24, 81, 115);
            closeButton.FocusEnabled = false;
            closeButton.Image = Properties.Resources.mmenu_mini_remove;
            closeButton.Location = new Point(192, 6);
            closeButton.Name = "closeButton";
            closeButton.PaintImageOnSelected = true;
            closeButton.processEnterKey = true;
            closeButton.resizeImage = new Point(0, 0);
            closeButton.Selected = false;
            closeButton.SelectedColor = Color.FromArgb(0, 122, 204);
            closeButton.Size = new Size(30, 30);
            closeButton.TabIndex = 1;
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += OnCloseButtonPressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.mmenu_mini_find;
            pictureBoxAdv1.Location = new Point(8, 12);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(16, 16);
            pictureBoxAdv1.TabIndex = 3;
            pictureBoxAdv1.TabStop = false;
            // 
            // replaceInput
            // 
            replaceInput.BackColor = Color.FromArgb(52, 52, 52);
            replaceInput.BorderColor = Color.FromArgb(100, 100, 100);
            replaceInput.BorderSize = 2;
            replaceInput.ButtonColor = SystemColors.Control;
            replaceInput.ForeColor = Color.Silver;
            replaceInput.FormattingEnabled = true;
            replaceInput.Location = new Point(35, 43);
            replaceInput.Name = "replaceInput";
            replaceInput.Size = new Size(151, 28);
            replaceInput.TabIndex = 1;
            replaceInput.EnterPressed += OnReplaceEnterPressed;
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            Controls.Add(replaceInput);
            Controls.Add(pictureBoxAdv1);
            Controls.Add(closeButton);
            Controls.Add(findInput);
            Name = "Find";
            Size = new Size(229, 78);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Controls.ComboBoxAdv findInput;
        private Controls.ButtonAdv closeButton;
        private Controls.PictureBoxAdv pictureBoxAdv1;
        private Controls.ComboBoxAdv replaceInput;
    }
}
