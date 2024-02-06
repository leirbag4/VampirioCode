namespace VampirioCode.UI
{
    partial class FindUI
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
            replaceInput = new Controls.ComboBoxAdv();
            optionsGBox = new Controls.GroupBoxAdv();
            useRegexCKBox = new CheckBox();
            matchWholeWordCKBox = new CheckBox();
            matchCaseCKBox = new CheckBox();
            optionsButton = new Controls.ButtonAdv();
            replaceAllButton = new Controls.ButtonAdv();
            optionsGBox.SuspendLayout();
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
            closeButton.FocusColor = Color.FromArgb(0, 122, 204);
            closeButton.FocusEnabled = true;
            closeButton.Image = Properties.Resources.mmenu_mini_remove;
            closeButton.Location = new Point(192, 6);
            closeButton.Name = "closeButton";
            closeButton.PaintImageOnSelected = true;
            closeButton.processEnterKey = true;
            closeButton.resizeImage = new Point(0, 0);
            closeButton.Selected = false;
            closeButton.SelectedColor = Color.FromArgb(0, 122, 204);
            closeButton.Size = new Size(30, 30);
            closeButton.TabIndex = 3;
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += OnCloseButtonPressed;
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
            // optionsGBox
            // 
            optionsGBox.BorderColor = Color.DarkGray;
            optionsGBox.BorderSize = 1;
            optionsGBox.Controls.Add(useRegexCKBox);
            optionsGBox.Controls.Add(matchWholeWordCKBox);
            optionsGBox.Controls.Add(matchCaseCKBox);
            optionsGBox.CStyle = UI.Controls.GroupBoxAdv.CustomStyle.SOLID_NO_BORDERS;
            optionsGBox.Location = new Point(30, 56);
            optionsGBox.Name = "optionsGBox";
            optionsGBox.Size = new Size(188, 75);
            optionsGBox.TabIndex = 5;
            optionsGBox.TabStop = false;
            // 
            // useRegexCKBox
            // 
            useRegexCKBox.AutoSize = true;
            useRegexCKBox.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            useRegexCKBox.ForeColor = Color.FromArgb(224, 224, 224);
            useRegexCKBox.Location = new Point(5, 51);
            useRegexCKBox.Name = "useRegexCKBox";
            useRegexCKBox.Size = new Size(171, 21);
            useRegexCKBox.TabIndex = 7;
            useRegexCKBox.Text = "Use regular expressions";
            useRegexCKBox.UseVisualStyleBackColor = true;
            // 
            // matchWholeWordCKBox
            // 
            matchWholeWordCKBox.AutoSize = true;
            matchWholeWordCKBox.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matchWholeWordCKBox.ForeColor = Color.FromArgb(224, 224, 224);
            matchWholeWordCKBox.Location = new Point(6, 26);
            matchWholeWordCKBox.Name = "matchWholeWordCKBox";
            matchWholeWordCKBox.Size = new Size(138, 21);
            matchWholeWordCKBox.TabIndex = 6;
            matchWholeWordCKBox.Text = "Match whole word";
            matchWholeWordCKBox.UseVisualStyleBackColor = true;
            // 
            // matchCaseCKBox
            // 
            matchCaseCKBox.AutoSize = true;
            matchCaseCKBox.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            matchCaseCKBox.ForeColor = Color.FromArgb(224, 224, 224);
            matchCaseCKBox.Location = new Point(6, 3);
            matchCaseCKBox.Name = "matchCaseCKBox";
            matchCaseCKBox.Size = new Size(96, 21);
            matchCaseCKBox.TabIndex = 5;
            matchCaseCKBox.Text = "Match case";
            matchCaseCKBox.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            optionsButton.BorderColor = Color.DarkGray;
            optionsButton.BorderSize = 1;
            optionsButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
            optionsButton.expandImage = false;
            optionsButton.extraText = "";
            optionsButton.extraTextAlign = ContentAlignment.MiddleCenter;
            optionsButton.extraTextColor = Color.Black;
            optionsButton.extraTextFont = null;
            optionsButton.extraTextOffset = new Point(0, 0);
            optionsButton.FocusColor = Color.FromArgb(24, 81, 115);
            optionsButton.FocusEnabled = false;
            optionsButton.Image = Properties.Resources.mmenu_mini_find;
            optionsButton.Location = new Point(6, 8);
            optionsButton.Name = "optionsButton";
            optionsButton.PaintImageOnSelected = true;
            optionsButton.processEnterKey = true;
            optionsButton.resizeImage = new Point(0, 0);
            optionsButton.Selected = false;
            optionsButton.SelectedColor = Color.FromArgb(0, 122, 204);
            optionsButton.Size = new Size(26, 26);
            optionsButton.TabIndex = 6;
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += OnOptionsPressed;
            // 
            // replaceAllButton
            // 
            replaceAllButton.BackColor = Color.FromArgb(34, 34, 34);
            replaceAllButton.BorderColor = Color.FromArgb(57, 57, 57);
            replaceAllButton.BorderSize = 2;
            replaceAllButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            replaceAllButton.expandImage = false;
            replaceAllButton.extraText = "all";
            replaceAllButton.extraTextAlign = ContentAlignment.MiddleCenter;
            replaceAllButton.extraTextColor = Color.FromArgb(130, 130, 130);
            replaceAllButton.extraTextFont = new Font("Segoe UI", 7F);
            replaceAllButton.extraTextOffset = new Point(0, 0);
            replaceAllButton.FocusColor = Color.FromArgb(0, 122, 204);
            replaceAllButton.FocusEnabled = true;
            replaceAllButton.ForeColor = SystemColors.ControlText;
            replaceAllButton.Location = new Point(194, 43);
            replaceAllButton.Name = "replaceAllButton";
            replaceAllButton.PaintImageOnSelected = true;
            replaceAllButton.processEnterKey = true;
            replaceAllButton.resizeImage = new Point(0, 0);
            replaceAllButton.Selected = false;
            replaceAllButton.SelectedColor = Color.FromArgb(0, 122, 204);
            replaceAllButton.Size = new Size(28, 28);
            replaceAllButton.TabIndex = 2;
            replaceAllButton.UseVisualStyleBackColor = false;
            replaceAllButton.Click += OnReplaceAllPressed;
            // 
            // FindUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            Controls.Add(replaceAllButton);
            Controls.Add(optionsButton);
            Controls.Add(optionsGBox);
            Controls.Add(replaceInput);
            Controls.Add(closeButton);
            Controls.Add(findInput);
            Name = "FindUI";
            Size = new Size(229, 78);
            optionsGBox.ResumeLayout(false);
            optionsGBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.ComboBoxAdv findInput;
        private Controls.ButtonAdv closeButton;
        private Controls.ComboBoxAdv replaceInput;
        private Controls.GroupBoxAdv optionsGBox;
        private CheckBox matchWholeWordCKBox;
        private CheckBox matchCaseCKBox;
        private CheckBox useRegexCKBox;
        private Controls.ButtonAdv optionsButton;
        private Controls.ButtonAdv replaceAllButton;
    }
}
