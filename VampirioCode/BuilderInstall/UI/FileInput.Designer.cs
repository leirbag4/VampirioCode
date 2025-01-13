namespace VampirioCode.BuilderInstall.UI
{
    partial class FileInput
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
            input = new VampirioCode.UI.Controls.TextBoxAdv();
            browseButton = new VampirioCode.UI.Controls.ButtonAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
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
            input.Location = new Point(21, 4);
            input.Margin = new Padding(3, 2, 3, 2);
            input.Name = "input";
            input.Size = new Size(268, 23);
            input.TabIndex = 0;
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
            browseButton.Location = new Point(294, 4);
            browseButton.Margin = new Padding(3, 2, 3, 2);
            browseButton.Name = "browseButton";
            browseButton.PaintImageOnSelected = true;
            browseButton.processEnterKey = true;
            browseButton.resizeImage = new Point(0, 0);
            browseButton.Selected = false;
            browseButton.SelectedColor = Color.FromArgb(0, 122, 204);
            browseButton.Size = new Size(93, 22);
            browseButton.TabIndex = 26;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = false;
            browseButton.Click += OnBrowsePressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.file_icon_generic;
            pictureBoxAdv1.Location = new Point(2, 7);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(14, 16);
            pictureBoxAdv1.TabIndex = 27;
            pictureBoxAdv1.TabStop = false;
            // 
            // FileInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(pictureBoxAdv1);
            Controls.Add(browseButton);
            Controls.Add(input);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FileInput";
            Size = new Size(396, 29);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.TextBoxAdv input;
        private VampirioCode.UI.Controls.ButtonAdv browseButton;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
    }
}
