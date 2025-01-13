namespace VampirioCode.BuilderInstall.cpp
{
    partial class EmscriptenBuildSetup
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
            emsdk_bat_input = new UI.FileInput();
            labelAdv1 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            nodejs_exe_input = new UI.FileInput();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv2 = new VampirioCode.UI.Controls.GroupBoxAdv();
            buttonAdv4 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            pictureBoxAdv2 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv7 = new VampirioCode.UI.Controls.LabelAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv3 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            SuspendLayout();
            // 
            // emsdk_bat_input
            // 
            emsdk_bat_input.BackColor = Color.FromArgb(35, 35, 35);
            emsdk_bat_input.FilePath = "";
            emsdk_bat_input.Location = new Point(18, 33);
            emsdk_bat_input.Margin = new Padding(3, 2, 3, 2);
            emsdk_bat_input.Name = "emsdk_bat_input";
            emsdk_bat_input.Size = new Size(450, 30);
            emsdk_bat_input.TabIndex = 3;
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(18, 16);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(153, 15);
            labelAdv1.TabIndex = 2;
            labelAdv1.Text = "'emsdk.bat' compiler path";
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv5.ForeColor = SystemColors.WindowFrame;
            labelAdv5.Location = new Point(256, 18);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(170, 13);
            labelAdv5.TabIndex = 10;
            labelAdv5.Text = "C:\\programs_dev\\emsdk\\emsdk.bat";
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
            buttonAdv2.Location = new Point(480, 16);
            buttonAdv2.Margin = new Padding(3, 2, 3, 2);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(107, 56);
            buttonAdv2.TabIndex = 30;
            buttonAdv2.Text = "Use reference hardcoded paths";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnUseHardcodedPaths;
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = SystemColors.WindowFrame;
            labelAdv2.Location = new Point(256, 75);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(249, 13);
            labelAdv2.TabIndex = 33;
            labelAdv2.Text = "C:\\programs_dev\\node-v20.11.0-win-x64\\nodejs.exe";
            // 
            // nodejs_exe_input
            // 
            nodejs_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            nodejs_exe_input.FilePath = "";
            nodejs_exe_input.Location = new Point(18, 90);
            nodejs_exe_input.Margin = new Padding(3, 2, 3, 2);
            nodejs_exe_input.Name = "nodejs_exe_input";
            nodejs_exe_input.Size = new Size(450, 30);
            nodejs_exe_input.TabIndex = 32;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(18, 73);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(160, 15);
            labelAdv3.TabIndex = 31;
            labelAdv3.Text = "'node.exe' interpreter path";
            // 
            // groupBoxAdv2
            // 
            groupBoxAdv2.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv2.BorderSize = 1;
            groupBoxAdv2.Controls.Add(buttonAdv4);
            groupBoxAdv2.Controls.Add(labelAdv4);
            groupBoxAdv2.Controls.Add(pictureBoxAdv2);
            groupBoxAdv2.Controls.Add(buttonAdv1);
            groupBoxAdv2.Controls.Add(labelAdv7);
            groupBoxAdv2.Controls.Add(pictureBoxAdv1);
            groupBoxAdv2.Controls.Add(buttonAdv3);
            groupBoxAdv2.Controls.Add(labelAdv8);
            groupBoxAdv2.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv2.Location = new Point(23, 134);
            groupBoxAdv2.Margin = new Padding(3, 2, 3, 2);
            groupBoxAdv2.Name = "groupBoxAdv2";
            groupBoxAdv2.Padding = new Padding(3, 2, 3, 2);
            groupBoxAdv2.Size = new Size(572, 214);
            groupBoxAdv2.TabIndex = 42;
            groupBoxAdv2.TabStop = false;
            groupBoxAdv2.Text = "groupBoxAdv2";
            // 
            // buttonAdv4
            // 
            buttonAdv4.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv4.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv4.BorderSize = 1;
            buttonAdv4.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv4.expandImage = false;
            buttonAdv4.extraText = "";
            buttonAdv4.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv4.extraTextColor = Color.Black;
            buttonAdv4.extraTextFont = null;
            buttonAdv4.extraTextOffset = new Point(0, 0);
            buttonAdv4.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv4.FocusEnabled = false;
            buttonAdv4.ForeColor = Color.Silver;
            buttonAdv4.Location = new Point(408, 170);
            buttonAdv4.Margin = new Padding(3, 2, 3, 2);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(107, 25);
            buttonAdv4.TabIndex = 36;
            buttonAdv4.Text = "Download";
            buttonAdv4.UseVisualStyleBackColor = false;
            buttonAdv4.Click += OnNodeJsDownloadPressed;
            // 
            // labelAdv4
            // 
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv4.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv4.Location = new Point(265, 130);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(258, 38);
            labelAdv4.TabIndex = 37;
            labelAdv4.Text = "A portable version of 'nodejs' can be downloaded here";
            // 
            // pictureBoxAdv2
            // 
            pictureBoxAdv2.Image = Properties.Resources.nodejs_med_logo;
            pictureBoxAdv2.Location = new Point(13, 130);
            pictureBoxAdv2.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv2.Name = "pictureBoxAdv2";
            pictureBoxAdv2.Size = new Size(130, 55);
            pictureBoxAdv2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAdv2.TabIndex = 35;
            pictureBoxAdv2.TabStop = false;
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
            buttonAdv1.Location = new Point(408, 101);
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
            buttonAdv1.Click += OnEmscriptenDownloadPressed;
            // 
            // labelAdv7
            // 
            labelAdv7.BorderColor = Color.DarkGray;
            labelAdv7.BorderSize = 1;
            labelAdv7.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv7.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv7.Location = new Point(265, 61);
            labelAdv7.ModifyClampMax = 0F;
            labelAdv7.ModifyClampMin = 0F;
            labelAdv7.ModifyControlName = "";
            labelAdv7.ModifyScale = 1F;
            labelAdv7.Name = "labelAdv7";
            labelAdv7.Size = new Size(258, 38);
            labelAdv7.TabIndex = 34;
            labelAdv7.Text = "A portable version of emscripten 'emsdk' can be downloaded here";
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.emscripten_med_logo;
            pictureBoxAdv1.Location = new Point(13, 63);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(190, 48);
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
            buttonAdv3.Location = new Point(48, 584);
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
            labelAdv8.Size = new Size(509, 53);
            labelAdv8.TabIndex = 30;
            labelAdv8.Text = "Emscripten and also nodejs are needed. Emscripten 'emsdk' is needed for the compilation process and 'nodejs' for the execution.";
            // 
            // EmscriptenBuildSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(groupBoxAdv2);
            Controls.Add(labelAdv2);
            Controls.Add(nodejs_exe_input);
            Controls.Add(labelAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(labelAdv5);
            Controls.Add(emsdk_bat_input);
            Controls.Add(labelAdv1);
            Name = "EmscriptenBuildSetup";
            Size = new Size(618, 408);
            groupBoxAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.FileInput emsdk_bat_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private UI.FileInput nodejs_exe_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv2;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv7;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv4;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv2;
    }
}
