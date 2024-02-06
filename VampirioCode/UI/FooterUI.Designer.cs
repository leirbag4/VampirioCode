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
            columnLabel = new Label();
            infoLabel = new Label();
            languageLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lineLabel
            // 
            lineLabel.ForeColor = Color.Silver;
            lineLabel.Location = new Point(40, 4);
            lineLabel.Name = "lineLabel";
            lineLabel.Size = new Size(42, 19);
            lineLabel.TabIndex = 0;
            lineLabel.Text = "1";
            // 
            // columnLabel
            // 
            columnLabel.ForeColor = Color.Silver;
            columnLabel.Location = new Point(131, 4);
            columnLabel.Name = "columnLabel";
            columnLabel.Size = new Size(42, 19);
            columnLabel.TabIndex = 1;
            columnLabel.Text = "1";
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
            // label2
            // 
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(38, 19);
            label2.TabIndex = 5;
            label2.Text = "Line";
            // 
            // label3
            // 
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(88, 4);
            label3.Name = "label3";
            label3.Size = new Size(43, 19);
            label3.TabIndex = 6;
            label3.Text = "Char";
            // 
            // FooterUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(languageLabel);
            Controls.Add(infoLabel);
            Controls.Add(columnLabel);
            Controls.Add(lineLabel);
            Name = "FooterUI";
            Size = new Size(562, 30);
            ResumeLayout(false);
        }

        #endregion

        private Label lineLabel;
        private Label columnLabel;
        private Label infoLabel;
        private Label languageLabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
