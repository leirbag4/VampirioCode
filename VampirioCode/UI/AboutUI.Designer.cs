namespace VampirioCode.UI
{
    partial class AboutUI
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
            labelAdv1 = new Controls.LabelAdv();
            githubLinkLabel = new LinkLabel();
            pictureBoxAdv1 = new Controls.PictureBoxAdv();
            labelAdv2 = new Controls.LabelAdv();
            labelAdv3 = new Controls.LabelAdv();
            versionLabel = new Controls.LabelAdv();
            closeButton = new Controls.ButtonAdv();
            labelAdv4 = new Controls.LabelAdv();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(34, 57);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(87, 15);
            labelAdv1.TabIndex = 0;
            labelAdv1.Text = "Vampirio Code";
            // 
            // githubLinkLabel
            // 
            githubLinkLabel.ActiveLinkColor = Color.MediumOrchid;
            githubLinkLabel.AutoSize = true;
            githubLinkLabel.LinkColor = Color.BlueViolet;
            githubLinkLabel.Location = new Point(108, 106);
            githubLinkLabel.Name = "githubLinkLabel";
            githubLinkLabel.Size = new Size(236, 15);
            githubLinkLabel.TabIndex = 1;
            githubLinkLabel.TabStop = true;
            githubLinkLabel.Text = "https://github.com/leirbag4/VampirioCode";
            githubLinkLabel.LinkClicked += OnGithubLinkPressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.logo_mini;
            pictureBoxAdv1.Location = new Point(33, 18);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(78, 27);
            pictureBoxAdv1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAdv1.TabIndex = 2;
            pictureBoxAdv1.TabStop = false;
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.ForeColor = Color.FromArgb(150, 150, 150);
            labelAdv2.Location = new Point(207, 28);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(63, 15);
            labelAdv2.TabIndex = 3;
            labelAdv2.Text = "Copyright:";
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAdv3.ForeColor = Color.FromArgb(130, 130, 130);
            labelAdv3.Location = new Point(363, 18);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(56, 15);
            labelAdv3.TabIndex = 4;
            labelAdv3.Text = "Vampirio";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.BorderColor = Color.DarkGray;
            versionLabel.BorderSize = 1;
            versionLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            versionLabel.ForeColor = Color.FromArgb(130, 130, 130);
            versionLabel.Location = new Point(361, 38);
            versionLabel.ModifyClampMax = 0F;
            versionLabel.ModifyClampMin = 0F;
            versionLabel.ModifyControlName = "";
            versionLabel.ModifyScale = 1F;
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(59, 15);
            versionLabel.TabIndex = 5;
            versionLabel.Text = "version: -";
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(30, 30, 30);
            closeButton.BorderColor = Color.FromArgb(10, 10, 10);
            closeButton.BorderSize = 1;
            closeButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            closeButton.expandImage = false;
            closeButton.extraText = "";
            closeButton.extraTextAlign = ContentAlignment.MiddleCenter;
            closeButton.extraTextColor = Color.Black;
            closeButton.extraTextFont = null;
            closeButton.extraTextOffset = new Point(0, 0);
            closeButton.FocusColor = Color.FromArgb(24, 81, 115);
            closeButton.FocusEnabled = false;
            closeButton.ForeColor = Color.FromArgb(120, 120, 120);
            closeButton.Location = new Point(200, 134);
            closeButton.Margin = new Padding(3, 2, 3, 2);
            closeButton.Name = "closeButton";
            closeButton.PaintImageOnSelected = true;
            closeButton.processEnterKey = true;
            closeButton.resizeImage = new Point(0, 0);
            closeButton.Selected = false;
            closeButton.SelectedColor = Color.FromArgb(0, 122, 204);
            closeButton.Size = new Size(82, 22);
            closeButton.TabIndex = 6;
            closeButton.Text = "close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += OnClosePressed;
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.ForeColor = Color.FromArgb(150, 150, 150);
            labelAdv4.Location = new Point(157, 57);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(155, 30);
            labelAdv4.TabIndex = 7;
            labelAdv4.Text = "Developed by Gabriel Frasca\r\nalso known as Leirbag4";
            labelAdv4.TextAlign = ContentAlignment.TopCenter;
            // 
            // AboutUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderColor = Color.FromArgb(50, 50, 50);
            BorderSize = 2;
            ClientSize = new Size(470, 166);
            Controls.Add(labelAdv4);
            Controls.Add(closeButton);
            Controls.Add(versionLabel);
            Controls.Add(labelAdv3);
            Controls.Add(labelAdv2);
            Controls.Add(pictureBoxAdv1);
            Controls.Add(githubLinkLabel);
            Controls.Add(labelAdv1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AboutUI";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.LabelAdv labelAdv1;
        private LinkLabel githubLinkLabel;
        private Controls.PictureBoxAdv pictureBoxAdv1;
        private Controls.LabelAdv labelAdv2;
        private Controls.LabelAdv labelAdv3;
        private Controls.LabelAdv versionLabel;
        private Controls.ButtonAdv closeButton;
        private Controls.LabelAdv labelAdv4;
    }
}