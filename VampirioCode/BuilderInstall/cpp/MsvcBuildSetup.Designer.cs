namespace VampirioCode.BuilderInstall.cpp
{
    partial class MsvcBuildSetup
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
            cl_exe_input = new UI.FileInput();
            lib_exe_input = new UI.FileInput();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            okButton = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            labelAdv9 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv7 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv6 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            lib_ucrt_input = new UI.DirectoryInput();
            lib_um_input = new UI.DirectoryInput();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            lib_input = new UI.DirectoryInput();
            include_ucrt_input = new UI.DirectoryInput();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            include_input = new UI.DirectoryInput();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv1.SuspendLayout();
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
            labelAdv1.Location = new Point(28, 12);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(156, 20);
            labelAdv1.TabIndex = 0;
            labelAdv1.Text = "'cl.exe' compiler path";
            // 
            // cl_exe_input
            // 
            cl_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            cl_exe_input.FilePath = "";
            cl_exe_input.Location = new Point(28, 35);
            cl_exe_input.Name = "cl_exe_input";
            cl_exe_input.Size = new Size(514, 40);
            cl_exe_input.TabIndex = 1;
            // 
            // lib_exe_input
            // 
            lib_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            lib_exe_input.FilePath = "";
            lib_exe_input.Location = new Point(28, 99);
            lib_exe_input.Name = "lib_exe_input";
            lib_exe_input.Size = new Size(514, 40);
            lib_exe_input.TabIndex = 3;
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(28, 76);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(162, 20);
            labelAdv2.TabIndex = 2;
            labelAdv2.Text = "'lib.exe' compiler path";
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.BackColor = Color.FromArgb(30, 30, 30);
            okButton.BorderColor = Color.FromArgb(10, 10, 10);
            okButton.BorderSize = 1;
            okButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            okButton.expandImage = false;
            okButton.extraText = "";
            okButton.extraTextAlign = ContentAlignment.MiddleCenter;
            okButton.extraTextColor = Color.Black;
            okButton.extraTextFont = null;
            okButton.extraTextOffset = new Point(0, 0);
            okButton.FocusColor = Color.FromArgb(24, 81, 115);
            okButton.FocusEnabled = false;
            okButton.ForeColor = Color.Silver;
            okButton.Location = new Point(14, 475);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(213, 30);
            okButton.TabIndex = 26;
            okButton.Text = "1. Auto Check installation";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OnAutoCheckInstallation;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(65, 65, 65);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(labelAdv9);
            groupBoxAdv1.Controls.Add(labelAdv8);
            groupBoxAdv1.Controls.Add(labelAdv7);
            groupBoxAdv1.Controls.Add(labelAdv6);
            groupBoxAdv1.Controls.Add(labelAdv5);
            groupBoxAdv1.Controls.Add(lib_ucrt_input);
            groupBoxAdv1.Controls.Add(lib_um_input);
            groupBoxAdv1.Controls.Add(labelAdv4);
            groupBoxAdv1.Controls.Add(lib_input);
            groupBoxAdv1.Controls.Add(include_ucrt_input);
            groupBoxAdv1.Controls.Add(labelAdv3);
            groupBoxAdv1.Controls.Add(include_input);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(14, 145);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Size = new Size(622, 312);
            groupBoxAdv1.TabIndex = 27;
            groupBoxAdv1.TabStop = false;
            // 
            // labelAdv9
            // 
            labelAdv9.AutoSize = true;
            labelAdv9.BorderColor = Color.DarkGray;
            labelAdv9.BorderSize = 1;
            labelAdv9.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv9.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv9.ForeColor = SystemColors.WindowFrame;
            labelAdv9.Location = new Point(81, 254);
            labelAdv9.ModifyClampMax = 0F;
            labelAdv9.ModifyClampMin = 0F;
            labelAdv9.ModifyControlName = "";
            labelAdv9.ModifyScale = 1F;
            labelAdv9.Name = "labelAdv9";
            labelAdv9.Size = new Size(389, 17);
            labelAdv9.TabIndex = 13;
            labelAdv9.Text = "C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\XX.X.XXXXX.X\\ucrt\\x64";
            // 
            // labelAdv8
            // 
            labelAdv8.AutoSize = true;
            labelAdv8.BorderColor = Color.DarkGray;
            labelAdv8.BorderSize = 1;
            labelAdv8.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv8.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv8.ForeColor = SystemColors.WindowFrame;
            labelAdv8.Location = new Point(81, 201);
            labelAdv8.ModifyClampMax = 0F;
            labelAdv8.ModifyClampMin = 0F;
            labelAdv8.ModifyControlName = "";
            labelAdv8.ModifyScale = 1F;
            labelAdv8.Name = "labelAdv8";
            labelAdv8.Size = new Size(385, 17);
            labelAdv8.TabIndex = 12;
            labelAdv8.Text = "C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\XX.X.XXXXX.X\\um\\x64";
            // 
            // labelAdv7
            // 
            labelAdv7.AutoSize = true;
            labelAdv7.BorderColor = Color.DarkGray;
            labelAdv7.BorderSize = 1;
            labelAdv7.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv7.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv7.ForeColor = SystemColors.WindowFrame;
            labelAdv7.Location = new Point(81, 148);
            labelAdv7.ModifyClampMax = 0F;
            labelAdv7.ModifyClampMin = 0F;
            labelAdv7.ModifyControlName = "";
            labelAdv7.ModifyScale = 1F;
            labelAdv7.Name = "labelAdv7";
            labelAdv7.Size = new Size(305, 17);
            labelAdv7.TabIndex = 11;
            labelAdv7.Text = "...\\Community\\VC\\Tools\\MSVC\\XX.XX.XXXXX\\lib\\x64";
            // 
            // labelAdv6
            // 
            labelAdv6.AutoSize = true;
            labelAdv6.BorderColor = Color.DarkGray;
            labelAdv6.BorderSize = 1;
            labelAdv6.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv6.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv6.ForeColor = SystemColors.WindowFrame;
            labelAdv6.Location = new Point(81, 71);
            labelAdv6.ModifyClampMax = 0F;
            labelAdv6.ModifyClampMin = 0F;
            labelAdv6.ModifyControlName = "";
            labelAdv6.ModifyScale = 1F;
            labelAdv6.Name = "labelAdv6";
            labelAdv6.Size = new Size(387, 17);
            labelAdv6.TabIndex = 10;
            labelAdv6.Text = "C:\\Program Files (x86)\\Windows Kits\\10\\Include\\XX.X.XXXXX.X\\ucrt";
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv5.ForeColor = SystemColors.WindowFrame;
            labelAdv5.Location = new Point(81, 18);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(306, 17);
            labelAdv5.TabIndex = 9;
            labelAdv5.Text = "...\\Community\\VC\\Tools\\MSVC\\XX.XX.XXXXX\\include";
            // 
            // lib_ucrt_input
            // 
            lib_ucrt_input.BackColor = Color.FromArgb(35, 35, 35);
            lib_ucrt_input.DirPath = "";
            lib_ucrt_input.ForeColor = Color.FromArgb(120, 120, 120);
            lib_ucrt_input.Location = new Point(61, 269);
            lib_ucrt_input.Name = "lib_ucrt_input";
            lib_ucrt_input.Size = new Size(514, 36);
            lib_ucrt_input.TabIndex = 8;
            // 
            // lib_um_input
            // 
            lib_um_input.BackColor = Color.FromArgb(35, 35, 35);
            lib_um_input.DirPath = "";
            lib_um_input.ForeColor = Color.FromArgb(120, 120, 120);
            lib_um_input.Location = new Point(61, 215);
            lib_um_input.Name = "lib_um_input";
            lib_um_input.Size = new Size(514, 36);
            lib_um_input.TabIndex = 7;
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv4.ForeColor = Color.Silver;
            labelAdv4.Location = new Point(14, 125);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(139, 20);
            labelAdv4.TabIndex = 6;
            labelAdv4.Text = "Library Directories";
            // 
            // lib_input
            // 
            lib_input.BackColor = Color.FromArgb(35, 35, 35);
            lib_input.DirPath = "";
            lib_input.ForeColor = Color.FromArgb(120, 120, 120);
            lib_input.Location = new Point(61, 165);
            lib_input.Name = "lib_input";
            lib_input.Size = new Size(514, 36);
            lib_input.TabIndex = 5;
            // 
            // include_ucrt_input
            // 
            include_ucrt_input.BackColor = Color.FromArgb(35, 35, 35);
            include_ucrt_input.DirPath = "";
            include_ucrt_input.ForeColor = Color.FromArgb(120, 120, 120);
            include_ucrt_input.Location = new Point(61, 86);
            include_ucrt_input.Name = "include_ucrt_input";
            include_ucrt_input.Size = new Size(514, 36);
            include_ucrt_input.TabIndex = 4;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(14, 6);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(67, 20);
            labelAdv3.TabIndex = 3;
            labelAdv3.Text = "Includes";
            // 
            // include_input
            // 
            include_input.BackColor = Color.FromArgb(35, 35, 35);
            include_input.DirPath = "";
            include_input.ForeColor = Color.FromArgb(120, 120, 120);
            include_input.Location = new Point(61, 35);
            include_input.Name = "include_input";
            include_input.Size = new Size(514, 36);
            include_input.TabIndex = 0;
            // 
            // buttonAdv1
            // 
            buttonAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            buttonAdv1.Location = new Point(242, 475);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(250, 30);
            buttonAdv1.TabIndex = 28;
            buttonAdv1.Text = "2. Auto Fill Includes and Libraries";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnAutoFillIncludesAndLibraries;
            // 
            // MsvcBuildSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonAdv1);
            Controls.Add(groupBoxAdv1);
            Controls.Add(okButton);
            Controls.Add(lib_exe_input);
            Controls.Add(labelAdv2);
            Controls.Add(cl_exe_input);
            Controls.Add(labelAdv1);
            Name = "MsvcBuildSetup";
            Size = new Size(650, 536);
            groupBoxAdv1.ResumeLayout(false);
            groupBoxAdv1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private UI.FileInput cl_exe_input;
        private UI.FileInput lib_exe_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.ButtonAdv okButton;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private UI.DirectoryInput include_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private UI.DirectoryInput lib_um_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private UI.DirectoryInput lib_input;
        private UI.DirectoryInput include_ucrt_input;
        private UI.DirectoryInput lib_ucrt_input;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private VampirioCode.UI.Controls.LabelAdv labelAdv6;
        private VampirioCode.UI.Controls.LabelAdv labelAdv9;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.LabelAdv labelAdv7;
    }
}
