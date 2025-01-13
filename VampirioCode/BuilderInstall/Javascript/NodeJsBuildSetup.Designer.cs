namespace VampirioCode.BuilderInstall.Javascript
{
    partial class NodeJsBuildSetup
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
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            nodejs_exe_input = new UI.FileInput();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            labelAdv1 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv3 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = SystemColors.WindowFrame;
            labelAdv2.Location = new Point(213, 28);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(249, 13);
            labelAdv2.TabIndex = 36;
            labelAdv2.Text = "C:\\programs_dev\\node-v20.11.0-win-x64\\nodejs.exe";
            // 
            // nodejs_exe_input
            // 
            nodejs_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            nodejs_exe_input.FilePath = "";
            nodejs_exe_input.Location = new Point(22, 43);
            nodejs_exe_input.Margin = new Padding(3, 2, 3, 2);
            nodejs_exe_input.Name = "nodejs_exe_input";
            nodejs_exe_input.Size = new Size(450, 30);
            nodejs_exe_input.TabIndex = 35;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(22, 26);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(160, 15);
            labelAdv3.TabIndex = 34;
            labelAdv3.Text = "'node.exe' interpreter path";
            // 
            // buttonAdv2
            // 
            buttonAdv2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            buttonAdv2.Location = new Point(487, 17);
            buttonAdv2.Margin = new Padding(3, 2, 3, 2);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(107, 56);
            buttonAdv2.TabIndex = 37;
            buttonAdv2.Text = "Use reference hardcoded paths";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnUseHardcodedPaths;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(labelAdv1);
            groupBoxAdv1.Controls.Add(buttonAdv1);
            groupBoxAdv1.Controls.Add(pictureBoxAdv1);
            groupBoxAdv1.Controls.Add(buttonAdv3);
            groupBoxAdv1.Controls.Add(labelAdv8);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(34, 106);
            groupBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Padding = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Size = new Size(550, 196);
            groupBoxAdv1.TabIndex = 40;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // labelAdv1
            // 
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv1.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv1.Location = new Point(23, 47);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(477, 49);
            labelAdv1.TabIndex = 34;
            labelAdv1.Text = "A portable version can be download here. Just extract it and point 'node.exe' input to to the file 'node.exe' inside that folder.";
            // 
            // buttonAdv1
            // 
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
            buttonAdv1.Location = new Point(186, 112);
            buttonAdv1.Margin = new Padding(3, 2, 3, 2);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(107, 25);
            buttonAdv1.TabIndex = 33;
            buttonAdv1.Text = "Download";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnDownloadPressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.nodejs_med_logo;
            pictureBoxAdv1.Location = new Point(23, 98);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(125, 55);
            pictureBoxAdv1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAdv1.TabIndex = 32;
            pictureBoxAdv1.TabStop = false;
            // 
            // buttonAdv3
            // 
            buttonAdv3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            buttonAdv3.Location = new Point(48, 378);
            buttonAdv3.Margin = new Padding(3, 2, 3, 2);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(107, 25);
            buttonAdv3.TabIndex = 31;
            buttonAdv3.Text = "Download";
            buttonAdv3.UseVisualStyleBackColor = false;
            // 
            // labelAdv8
            // 
            labelAdv8.BorderColor = Color.DarkGray;
            labelAdv8.BorderSize = 1;
            labelAdv8.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv8.ForeColor = Color.Silver;
            labelAdv8.Location = new Point(5, 8);
            labelAdv8.ModifyClampMax = 0F;
            labelAdv8.ModifyClampMin = 0F;
            labelAdv8.ModifyControlName = "";
            labelAdv8.ModifyScale = 1F;
            labelAdv8.Name = "labelAdv8";
            labelAdv8.Size = new Size(509, 43);
            labelAdv8.TabIndex = 30;
            labelAdv8.Text = "A download of 'nodejs' must be done in orther to work.";
            // 
            // NodeJsBuildSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(groupBoxAdv1);
            Controls.Add(buttonAdv2);
            Controls.Add(labelAdv2);
            Controls.Add(nodejs_exe_input);
            Controls.Add(labelAdv3);
            Name = "NodeJsBuildSetup";
            Size = new Size(618, 408);
            groupBoxAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private UI.FileInput nodejs_exe_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
    }
}
