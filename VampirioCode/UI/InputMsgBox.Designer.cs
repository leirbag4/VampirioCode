namespace VampirioCode.UI
{
    partial class InputMsgBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            okButton = new Controls.ButtonAdv();
            cancelButton = new Controls.ButtonAdv();
            groupBoxAdv1 = new Controls.GroupBoxAdv();
            descLabel = new Controls.LabelAdv();
            groupBoxAdv2 = new Controls.GroupBoxAdv();
            inputLabel = new Controls.LabelAdv();
            input = new Controls.TextBoxAdv();
            groupBoxAdv1.SuspendLayout();
            groupBoxAdv2.SuspendLayout();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.BackColor = Color.FromArgb(30, 30, 30);
            okButton.BorderColor = Color.FromArgb(25, 25, 25);
            okButton.BorderSize = 2;
            okButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            okButton.expandImage = false;
            okButton.extraText = "";
            okButton.extraTextAlign = ContentAlignment.MiddleCenter;
            okButton.extraTextColor = Color.Black;
            okButton.extraTextFont = null;
            okButton.extraTextOffset = new Point(0, 0);
            okButton.FocusColor = Color.FromArgb(24, 81, 115);
            okButton.FocusEnabled = true;
            okButton.ForeColor = Color.FromArgb(224, 224, 224);
            okButton.Location = new Point(316, 202);
            okButton.Margin = new Padding(4, 5, 4, 5);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(108, 32);
            okButton.TabIndex = 9;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OnOkPressed;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(30, 30, 30);
            cancelButton.BorderColor = Color.FromArgb(25, 25, 25);
            cancelButton.BorderSize = 2;
            cancelButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            cancelButton.expandImage = false;
            cancelButton.extraText = "";
            cancelButton.extraTextAlign = ContentAlignment.MiddleCenter;
            cancelButton.extraTextColor = Color.Black;
            cancelButton.extraTextFont = null;
            cancelButton.extraTextOffset = new Point(0, 0);
            cancelButton.FocusColor = Color.FromArgb(24, 81, 115);
            cancelButton.FocusEnabled = true;
            cancelButton.ForeColor = Color.FromArgb(224, 224, 224);
            cancelButton.Location = new Point(432, 202);
            cancelButton.Margin = new Padding(4, 5, 4, 5);
            cancelButton.Name = "cancelButton";
            cancelButton.PaintImageOnSelected = true;
            cancelButton.processEnterKey = true;
            cancelButton.resizeImage = new Point(0, 0);
            cancelButton.Selected = false;
            cancelButton.SelectedColor = Color.FromArgb(0, 122, 204);
            cancelButton.Size = new Size(108, 32);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += OnCancelPressed;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAdv1.BackColor = Color.FromArgb(52, 52, 52);
            groupBoxAdv1.BorderColor = Color.FromArgb(64, 64, 64);
            groupBoxAdv1.BorderSize = 2;
            groupBoxAdv1.Controls.Add(descLabel);
            groupBoxAdv1.CStyle = UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(11, 11);
            groupBoxAdv1.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Padding = new Padding(4, 5, 4, 5);
            groupBoxAdv1.Size = new Size(528, 129);
            groupBoxAdv1.TabIndex = 10;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // descLabel
            // 
            descLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            descLabel.BorderColor = Color.DarkGray;
            descLabel.BorderSize = 1;
            descLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            descLabel.ForeColor = Color.Silver;
            descLabel.Location = new Point(8, 9);
            descLabel.Margin = new Padding(4, 0, 4, 0);
            descLabel.ModifyClampMax = 0F;
            descLabel.ModifyClampMin = 0F;
            descLabel.ModifyControlName = "";
            descLabel.ModifyScale = 1F;
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(509, 111);
            descLabel.TabIndex = 3;
            descLabel.Text = "Test Message\r\nLine 1\r\nLine 2\r\n";
            // 
            // groupBoxAdv2
            // 
            groupBoxAdv2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAdv2.BackColor = Color.FromArgb(52, 52, 52);
            groupBoxAdv2.BorderColor = Color.FromArgb(64, 64, 64);
            groupBoxAdv2.BorderSize = 2;
            groupBoxAdv2.Controls.Add(inputLabel);
            groupBoxAdv2.Controls.Add(input);
            groupBoxAdv2.CStyle = UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv2.Location = new Point(11, 145);
            groupBoxAdv2.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdv2.Name = "groupBoxAdv2";
            groupBoxAdv2.Padding = new Padding(4, 5, 4, 5);
            groupBoxAdv2.Size = new Size(528, 49);
            groupBoxAdv2.TabIndex = 11;
            groupBoxAdv2.TabStop = false;
            groupBoxAdv2.Text = "groupBoxAdv2";
            // 
            // inputLabel
            // 
            inputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            inputLabel.BorderColor = Color.DarkGray;
            inputLabel.BorderSize = 1;
            inputLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            inputLabel.ForeColor = Color.Silver;
            inputLabel.Location = new Point(19, 14);
            inputLabel.ModifyClampMax = 0F;
            inputLabel.ModifyClampMin = 0F;
            inputLabel.ModifyControlName = "";
            inputLabel.ModifyScale = 1F;
            inputLabel.Name = "inputLabel";
            inputLabel.RightToLeft = RightToLeft.Yes;
            inputLabel.Size = new Size(100, 25);
            inputLabel.TabIndex = 1;
            inputLabel.Text = "input";
            // 
            // input
            // 
            input.AllowBackspace = true;
            input.AllowTextEdition = true;
            input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input.AutoEdition = false;
            input.AutoSelect = false;
            input.BackColor = Color.FromArgb(80, 80, 80);
            input.BorderStyle = BorderStyle.FixedSingle;
            input.ExcludeCharacters = null;
            input.ForeColor = SystemColors.ScrollBar;
            input.IncludeOnlyCharacters = null;
            input.LeftLeadingCharacter = '\0';
            input.Location = new Point(140, 11);
            input.Name = "input";
            input.Size = new Size(241, 27);
            input.TabIndex = 0;
            input.EnterPressed += OnEnterPressed;
            // 
            // InputMsgBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(550, 241);
            Controls.Add(groupBoxAdv2);
            Controls.Add(groupBoxAdv1);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Name = "InputMsgBox";
            Text = "InputMsgBox";
            groupBoxAdv1.ResumeLayout(false);
            groupBoxAdv2.ResumeLayout(false);
            groupBoxAdv2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Controls.ButtonAdv okButton;
        private Controls.ButtonAdv cancelButton;
        private Controls.GroupBoxAdv groupBoxAdv1;
        private Controls.LabelAdv descLabel;
        private Controls.GroupBoxAdv groupBoxAdv2;
        private Controls.TextBoxAdv input;
        private Controls.LabelAdv inputLabel;
    }
}