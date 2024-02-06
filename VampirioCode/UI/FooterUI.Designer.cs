namespace VampirioCode.UI
{
    partial class FooterUI
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
            lineLabel = new Label();
            charLabel = new Label();
            infoLabel = new Label();
            languageLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lineLabel
            // 
            lineLabel.ForeColor = Color.Silver;
            lineLabel.Location = new Point(7, 4);
            lineLabel.Name = "lineLabel";
            lineLabel.Size = new Size(75, 19);
            lineLabel.TabIndex = 0;
            lineLabel.Text = "Line 0";
            // 
            // charLabel
            // 
            charLabel.ForeColor = Color.Silver;
            charLabel.Location = new Point(88, 4);
            charLabel.Name = "charLabel";
            charLabel.Size = new Size(75, 19);
            charLabel.TabIndex = 1;
            charLabel.Text = "Char 0";
            // 
            // infoLabel
            // 
            infoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            infoLabel.ForeColor = SystemColors.WindowFrame;
            infoLabel.Location = new Point(219, 4);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(251, 19);
            infoLabel.TabIndex = 2;
            infoLabel.Text = "...";
            // 
            // languageLabel
            // 
            languageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            languageLabel.ForeColor = Color.Silver;
            languageLabel.Location = new Point(476, 4);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(83, 19);
            languageLabel.TabIndex = 3;
            languageLabel.Text = "C#";
            languageLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(179, 4);
            label1.Name = "label1";
            label1.Size = new Size(41, 19);
            label1.TabIndex = 4;
            label1.Text = "Info:";
            // 
            // FooterUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            Controls.Add(label1);
            Controls.Add(languageLabel);
            Controls.Add(infoLabel);
            Controls.Add(charLabel);
            Controls.Add(lineLabel);
            Name = "FooterUI";
            Size = new Size(562, 30);
            ResumeLayout(false);
        }

        #endregion

        private Label lineLabel;
        private Label charLabel;
        private Label infoLabel;
        private Label languageLabel;
        private Label label1;
    }
}
