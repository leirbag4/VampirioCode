namespace VampirioCode.BuilderInstall.csharp
{
    partial class DotnetBuildSetup
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
            labelAdv1 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv3 = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(35, 23);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(167, 20);
            labelAdv1.TabIndex = 2;
            labelAdv1.Text = "Download 'dotnet sdk'";
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(labelAdv2);
            groupBoxAdv1.Controls.Add(buttonAdv2);
            groupBoxAdv1.Controls.Add(pictureBoxAdv1);
            groupBoxAdv1.Controls.Add(buttonAdv1);
            groupBoxAdv1.Controls.Add(labelAdv8);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(35, 79);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Size = new Size(628, 261);
            groupBoxAdv1.TabIndex = 39;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // labelAdv2
            // 
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv2.Location = new Point(26, 90);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(545, 38);
            labelAdv2.TabIndex = 34;
            labelAdv2.Text = "A know working version is the 8.0";
            // 
            // buttonAdv2
            // 
            buttonAdv2.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv2.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv2.BorderSize = 1;
            buttonAdv2.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv2.expandImage = false;
            buttonAdv2.extraText = "";
            buttonAdv2.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv2.extraTextColor = Color.Black;
            buttonAdv2.extraTextFont = null;
            buttonAdv2.extraTextOffset = new Point(0, 0);
            buttonAdv2.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv2.FocusEnabled = false;
            buttonAdv2.ForeColor = Color.Silver;
            buttonAdv2.Location = new Point(181, 151);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(122, 33);
            buttonAdv2.TabIndex = 33;
            buttonAdv2.Text = "Download";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnDownloadPressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.dotnet_med_icon;
            pictureBoxAdv1.Location = new Point(26, 131);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(130, 73);
            pictureBoxAdv1.TabIndex = 32;
            pictureBoxAdv1.TabStop = false;
            // 
            // buttonAdv1
            // 
            buttonAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv1.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv1.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv1.BorderSize = 1;
            buttonAdv1.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv1.expandImage = false;
            buttonAdv1.extraText = "";
            buttonAdv1.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv1.extraTextColor = Color.Black;
            buttonAdv1.extraTextFont = null;
            buttonAdv1.extraTextOffset = new Point(0, 0);
            buttonAdv1.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv1.FocusEnabled = false;
            buttonAdv1.ForeColor = Color.Silver;
            buttonAdv1.Location = new Point(55, 343);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(122, 33);
            buttonAdv1.TabIndex = 31;
            buttonAdv1.Text = "Download";
            buttonAdv1.UseVisualStyleBackColor = false;
            // 
            // labelAdv8
            // 
            labelAdv8.BorderColor = Color.DarkGray;
            labelAdv8.BorderSize = 1;
            labelAdv8.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv8.ForeColor = Color.Silver;
            labelAdv8.Location = new Point(6, 10);
            labelAdv8.ModifyClampMax = 0F;
            labelAdv8.ModifyClampMin = 0F;
            labelAdv8.ModifyControlName = "";
            labelAdv8.ModifyScale = 1F;
            labelAdv8.Name = "labelAdv8";
            labelAdv8.Size = new Size(582, 57);
            labelAdv8.TabIndex = 30;
            labelAdv8.Text = "The compiler needs 'dotnet sdk' installed on your computer in order to work. Download it and follow the instructions.";
            // 
            // buttonAdv3
            // 
            buttonAdv3.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv3.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv3.BorderSize = 1;
            buttonAdv3.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv3.expandImage = false;
            buttonAdv3.extraText = "";
            buttonAdv3.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv3.extraTextColor = Color.Black;
            buttonAdv3.extraTextFont = null;
            buttonAdv3.extraTextOffset = new Point(0, 0);
            buttonAdv3.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv3.FocusEnabled = false;
            buttonAdv3.ForeColor = Color.Silver;
            buttonAdv3.Location = new Point(50, 370);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(162, 33);
            buttonAdv3.TabIndex = 35;
            buttonAdv3.Text = "Test Installation";
            buttonAdv3.UseVisualStyleBackColor = false;
            buttonAdv3.Click += OnTestInstallationPressed;
            // 
            // DotnetBuildSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(buttonAdv3);
            Controls.Add(groupBoxAdv1);
            Controls.Add(labelAdv1);
            Name = "DotnetBuildSetup";
            Size = new Size(706, 539);
            groupBoxAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
    }
}
