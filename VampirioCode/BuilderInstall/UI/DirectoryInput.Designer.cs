namespace VampirioCode.BuilderInstall.UI
{
    partial class DirectoryInput
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
            browseButton = new VampirioCode.UI.Controls.ButtonAdv();
            input = new VampirioCode.UI.Controls.TextBoxAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.BackColor = Color.FromArgb(30, 30, 30);
            browseButton.BorderColor = Color.FromArgb(10, 10, 10);
            browseButton.BorderSize = 1;
            browseButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            browseButton.expandImage = false;
            browseButton.extraText = "";
            browseButton.extraTextAlign = ContentAlignment.MiddleCenter;
            browseButton.extraTextColor = Color.Black;
            browseButton.extraTextFont = null;
            browseButton.extraTextOffset = new Point(0, 0);
            browseButton.FocusColor = Color.FromArgb(24, 81, 115);
            browseButton.FocusEnabled = false;
            browseButton.ForeColor = Color.Silver;
            browseButton.Location = new Point(338, 5);
            browseButton.Name = "browseButton";
            browseButton.PaintImageOnSelected = true;
            browseButton.processEnterKey = true;
            browseButton.resizeImage = new Point(0, 0);
            browseButton.Selected = false;
            browseButton.SelectedColor = Color.FromArgb(0, 122, 204);
            browseButton.Size = new Size(106, 29);
            browseButton.TabIndex = 28;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = false;
            browseButton.Click += OnBrowsePressed;
            // 
            // input
            // 
            input.AllowBackspace = true;
            input.AllowTextEdition = true;
            input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input.AutoEdition = false;
            input.AutoSelect = false;
            input.BackColor = Color.FromArgb(30, 30, 30);
            input.BorderStyle = BorderStyle.FixedSingle;
            input.ExcludeCharacters = null;
            input.ForeColor = Color.Silver;
            input.IncludeOnlyCharacters = null;
            input.LeftLeadingCharacter = '\0';
            input.Location = new Point(24, 6);
            input.Name = "input";
            input.Size = new Size(308, 27);
            input.TabIndex = 27;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.file_icon_folder;
            pictureBoxAdv1.Location = new Point(2, 10);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(16, 16);
            pictureBoxAdv1.TabIndex = 29;
            pictureBoxAdv1.TabStop = false;
            // 
            // DirectoryInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(pictureBoxAdv1);
            Controls.Add(browseButton);
            Controls.Add(input);
            Name = "DirectoryInput";
            Size = new Size(455, 39);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.ButtonAdv browseButton;
        private VampirioCode.UI.Controls.TextBoxAdv input;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
    }
}
