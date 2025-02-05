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
            lib_exe_input = new UI.FileInput();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            okButton = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            buttonAdv7 = new VampirioCode.UI.Controls.ButtonAdv();
            buttonAdv6 = new VampirioCode.UI.Controls.ButtonAdv();
            stl_include_input = new UI.DirectoryInput();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv14 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv13 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv12 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv11 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv10 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv9 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv7 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv6 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            ucrt_lib_input = new UI.DirectoryInput();
            um_kernel32_lib_input = new UI.DirectoryInput();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            stl_lib_dir_input = new UI.DirectoryInput();
            ucrt_include_input = new UI.DirectoryInput();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            panelContainer = new Panel();
            buttonAdv4 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv15 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv3 = new VampirioCode.UI.Controls.ButtonAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            cl_exe_input = new UI.FileInput();
            buttonAdv5 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv16 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv17 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv1.SuspendLayout();
            panelContainer.SuspendLayout();
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
            labelAdv1.Location = new Point(24, 69);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(127, 15);
            labelAdv1.TabIndex = 0;
            labelAdv1.Text = "'cl.exe' compiler path";
            // 
            // lib_exe_input
            // 
            lib_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            lib_exe_input.FilePath = "";
            lib_exe_input.Location = new Point(24, 129);
            lib_exe_input.Margin = new Padding(3, 2, 3, 2);
            lib_exe_input.Name = "lib_exe_input";
            lib_exe_input.Size = new Size(388, 30);
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
            labelAdv2.Location = new Point(24, 116);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(131, 15);
            labelAdv2.TabIndex = 2;
            labelAdv2.Text = "'lib.exe' compiler path";
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            okButton.BackColor = Color.FromArgb(30, 30, 40);
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
            okButton.Location = new Point(8, 245);
            okButton.Margin = new Padding(3, 2, 3, 2);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(233, 25);
            okButton.TabIndex = 26;
            okButton.Text = "1. Auto Check installation";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OnAutoCheckInstallation;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(65, 65, 65);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(buttonAdv7);
            groupBoxAdv1.Controls.Add(buttonAdv6);
            groupBoxAdv1.Controls.Add(stl_include_input);
            groupBoxAdv1.Controls.Add(buttonAdv1);
            groupBoxAdv1.Controls.Add(okButton);
            groupBoxAdv1.Controls.Add(labelAdv14);
            groupBoxAdv1.Controls.Add(labelAdv13);
            groupBoxAdv1.Controls.Add(labelAdv12);
            groupBoxAdv1.Controls.Add(labelAdv11);
            groupBoxAdv1.Controls.Add(labelAdv10);
            groupBoxAdv1.Controls.Add(labelAdv9);
            groupBoxAdv1.Controls.Add(labelAdv8);
            groupBoxAdv1.Controls.Add(labelAdv7);
            groupBoxAdv1.Controls.Add(labelAdv6);
            groupBoxAdv1.Controls.Add(labelAdv5);
            groupBoxAdv1.Controls.Add(ucrt_lib_input);
            groupBoxAdv1.Controls.Add(um_kernel32_lib_input);
            groupBoxAdv1.Controls.Add(labelAdv4);
            groupBoxAdv1.Controls.Add(stl_lib_dir_input);
            groupBoxAdv1.Controls.Add(ucrt_include_input);
            groupBoxAdv1.Controls.Add(labelAdv3);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(14, 5);
            groupBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Padding = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Size = new Size(574, 303);
            groupBoxAdv1.TabIndex = 27;
            groupBoxAdv1.TabStop = false;
            // 
            // buttonAdv7
            // 
            buttonAdv7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv7.BackColor = Color.FromArgb(30, 30, 40);
            buttonAdv7.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv7.BorderSize = 1;
            buttonAdv7.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv7.expandImage = false;
            buttonAdv7.extraText = "";
            buttonAdv7.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv7.extraTextColor = Color.Black;
            buttonAdv7.extraTextFont = null;
            buttonAdv7.extraTextOffset = new Point(0, 0);
            buttonAdv7.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv7.FocusEnabled = false;
            buttonAdv7.ForeColor = Color.Silver;
            buttonAdv7.Location = new Point(8, 274);
            buttonAdv7.Margin = new Padding(3, 2, 3, 2);
            buttonAdv7.Name = "buttonAdv7";
            buttonAdv7.PaintImageOnSelected = true;
            buttonAdv7.processEnterKey = true;
            buttonAdv7.resizeImage = new Point(0, 0);
            buttonAdv7.Selected = false;
            buttonAdv7.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv7.Size = new Size(461, 25);
            buttonAdv7.TabIndex = 35;
            buttonAdv7.Text = "Use Visual Studio 2022 hardcoded paths";
            buttonAdv7.UseVisualStyleBackColor = false;
            buttonAdv7.Click += OnUseVisualStudioCommonHardcodedPaths;
            // 
            // buttonAdv6
            // 
            buttonAdv6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv6.BackColor = Color.FromArgb(30, 30, 40);
            buttonAdv6.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv6.BorderSize = 1;
            buttonAdv6.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv6.expandImage = false;
            buttonAdv6.extraText = "";
            buttonAdv6.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv6.extraTextColor = Color.Black;
            buttonAdv6.extraTextFont = null;
            buttonAdv6.extraTextOffset = new Point(0, 0);
            buttonAdv6.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv6.FocusEnabled = false;
            buttonAdv6.ForeColor = Color.Silver;
            buttonAdv6.Location = new Point(477, 245);
            buttonAdv6.Margin = new Padding(3, 2, 3, 2);
            buttonAdv6.Name = "buttonAdv6";
            buttonAdv6.PaintImageOnSelected = true;
            buttonAdv6.processEnterKey = true;
            buttonAdv6.resizeImage = new Point(0, 0);
            buttonAdv6.Selected = false;
            buttonAdv6.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv6.Size = new Size(89, 25);
            buttonAdv6.TabIndex = 34;
            buttonAdv6.Text = "clear";
            buttonAdv6.UseVisualStyleBackColor = false;
            buttonAdv6.Click += OnClearPressed;
            // 
            // stl_include_input
            // 
            stl_include_input.BackColor = Color.FromArgb(35, 35, 35);
            stl_include_input.DirPath = "";
            stl_include_input.ForeColor = Color.FromArgb(120, 120, 120);
            stl_include_input.Location = new Point(53, 31);
            stl_include_input.Margin = new Padding(3, 2, 3, 2);
            stl_include_input.Name = "stl_include_input";
            stl_include_input.Size = new Size(450, 27);
            stl_include_input.TabIndex = 0;
            // 
            // buttonAdv1
            // 
            buttonAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv1.BackColor = Color.FromArgb(30, 30, 40);
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
            buttonAdv1.Location = new Point(250, 245);
            buttonAdv1.Margin = new Padding(3, 2, 3, 2);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(219, 25);
            buttonAdv1.TabIndex = 28;
            buttonAdv1.Text = "2. Auto Fill Includes and Libraries";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnAutoFillIncludesAndLibraries;
            // 
            // labelAdv14
            // 
            labelAdv14.AutoSize = true;
            labelAdv14.BorderColor = Color.DarkGray;
            labelAdv14.BorderSize = 1;
            labelAdv14.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv14.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv14.ForeColor = Color.Silver;
            labelAdv14.Location = new Point(53, 200);
            labelAdv14.ModifyClampMax = 0F;
            labelAdv14.ModifyClampMin = 0F;
            labelAdv14.ModifyControlName = "";
            labelAdv14.ModifyScale = 1F;
            labelAdv14.Name = "labelAdv14";
            labelAdv14.Size = new Size(158, 13);
            labelAdv14.TabIndex = 33;
            labelAdv14.Text = "Universal C Runtime - libucrt.lib";
            // 
            // labelAdv13
            // 
            labelAdv13.AutoSize = true;
            labelAdv13.BorderColor = Color.DarkGray;
            labelAdv13.BorderSize = 1;
            labelAdv13.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv13.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv13.ForeColor = Color.Silver;
            labelAdv13.Location = new Point(53, 160);
            labelAdv13.ModifyClampMax = 0F;
            labelAdv13.ModifyClampMin = 0F;
            labelAdv13.ModifyControlName = "";
            labelAdv13.ModifyScale = 1F;
            labelAdv13.Name = "labelAdv13";
            labelAdv13.Size = new Size(131, 13);
            labelAdv13.TabIndex = 32;
            labelAdv13.Text = "UM kernel32 - kernel32.lib";
            // 
            // labelAdv12
            // 
            labelAdv12.AutoSize = true;
            labelAdv12.BorderColor = Color.DarkGray;
            labelAdv12.BorderSize = 1;
            labelAdv12.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv12.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv12.ForeColor = Color.Silver;
            labelAdv12.Location = new Point(53, 119);
            labelAdv12.ModifyClampMax = 0F;
            labelAdv12.ModifyClampMin = 0F;
            labelAdv12.ModifyControlName = "";
            labelAdv12.ModifyScale = 1F;
            labelAdv12.Name = "labelAdv12";
            labelAdv12.Size = new Size(83, 13);
            labelAdv12.TabIndex = 31;
            labelAdv12.Text = "STL - libcpmt.lib";
            // 
            // labelAdv11
            // 
            labelAdv11.AutoSize = true;
            labelAdv11.BorderColor = Color.DarkGray;
            labelAdv11.BorderSize = 1;
            labelAdv11.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv11.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv11.ForeColor = Color.Silver;
            labelAdv11.Location = new Point(53, 60);
            labelAdv11.ModifyClampMax = 0F;
            labelAdv11.ModifyClampMin = 0F;
            labelAdv11.ModifyControlName = "";
            labelAdv11.ModifyScale = 1F;
            labelAdv11.Name = "labelAdv11";
            labelAdv11.Size = new Size(162, 13);
            labelAdv11.TabIndex = 30;
            labelAdv11.Text = "Universal C Runtime ucrt include";
            // 
            // labelAdv10
            // 
            labelAdv10.AutoSize = true;
            labelAdv10.BorderColor = Color.DarkGray;
            labelAdv10.BorderSize = 1;
            labelAdv10.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv10.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv10.ForeColor = Color.Silver;
            labelAdv10.Location = new Point(53, 20);
            labelAdv10.ModifyClampMax = 0F;
            labelAdv10.ModifyClampMin = 0F;
            labelAdv10.ModifyControlName = "";
            labelAdv10.ModifyScale = 1F;
            labelAdv10.Name = "labelAdv10";
            labelAdv10.Size = new Size(113, 13);
            labelAdv10.TabIndex = 29;
            labelAdv10.Text = "STL / Compiler include";
            // 
            // labelAdv9
            // 
            labelAdv9.AutoSize = true;
            labelAdv9.BorderColor = Color.DarkGray;
            labelAdv9.BorderSize = 1;
            labelAdv9.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv9.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv9.ForeColor = SystemColors.WindowFrame;
            labelAdv9.Location = new Point(223, 200);
            labelAdv9.ModifyClampMax = 0F;
            labelAdv9.ModifyClampMin = 0F;
            labelAdv9.ModifyControlName = "";
            labelAdv9.ModifyScale = 1F;
            labelAdv9.Name = "labelAdv9";
            labelAdv9.Size = new Size(325, 13);
            labelAdv9.TabIndex = 13;
            labelAdv9.Text = "... Program Files (x86)\\Windows Kits\\10\\Lib\\XX.X.XXXXX.X\\ucrt\\x64";
            // 
            // labelAdv8
            // 
            labelAdv8.AutoSize = true;
            labelAdv8.BorderColor = Color.DarkGray;
            labelAdv8.BorderSize = 1;
            labelAdv8.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv8.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv8.ForeColor = SystemColors.WindowFrame;
            labelAdv8.Location = new Point(224, 160);
            labelAdv8.ModifyClampMax = 0F;
            labelAdv8.ModifyClampMin = 0F;
            labelAdv8.ModifyControlName = "";
            labelAdv8.ModifyScale = 1F;
            labelAdv8.Name = "labelAdv8";
            labelAdv8.Size = new Size(325, 13);
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
            labelAdv7.Location = new Point(149, 119);
            labelAdv7.ModifyClampMax = 0F;
            labelAdv7.ModifyClampMin = 0F;
            labelAdv7.ModifyControlName = "";
            labelAdv7.ModifyScale = 1F;
            labelAdv7.Name = "labelAdv7";
            labelAdv7.Size = new Size(401, 13);
            labelAdv7.TabIndex = 11;
            labelAdv7.Text = "... Microsoft Visual Studio\\20XX\\Community\\VC\\Tools\\MSVC\\XX.XX.XXXXX\\lib\\x64";
            // 
            // labelAdv6
            // 
            labelAdv6.AutoSize = true;
            labelAdv6.BorderColor = Color.DarkGray;
            labelAdv6.BorderSize = 1;
            labelAdv6.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv6.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv6.ForeColor = SystemColors.WindowFrame;
            labelAdv6.Location = new Point(225, 59);
            labelAdv6.ModifyClampMax = 0F;
            labelAdv6.ModifyClampMin = 0F;
            labelAdv6.ModifyControlName = "";
            labelAdv6.ModifyScale = 1F;
            labelAdv6.Name = "labelAdv6";
            labelAdv6.Size = new Size(324, 13);
            labelAdv6.TabIndex = 10;
            labelAdv6.Text = "... Program Files (x86)\\Windows Kits\\10\\Include\\XX.X.XXXXX.X\\ucrt";
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv5.ForeColor = SystemColors.WindowFrame;
            labelAdv5.Location = new Point(197, 20);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(355, 13);
            labelAdv5.TabIndex = 9;
            labelAdv5.Text = "... Visual Studio\\20XX\\Community\\VC\\Tools\\MSVC\\XX.XX.XXXXX\\include";
            // 
            // ucrt_lib_input
            // 
            ucrt_lib_input.BackColor = Color.FromArgb(35, 35, 35);
            ucrt_lib_input.DirPath = "";
            ucrt_lib_input.ForeColor = Color.FromArgb(120, 120, 120);
            ucrt_lib_input.Location = new Point(53, 212);
            ucrt_lib_input.Margin = new Padding(3, 2, 3, 2);
            ucrt_lib_input.Name = "ucrt_lib_input";
            ucrt_lib_input.Size = new Size(450, 27);
            ucrt_lib_input.TabIndex = 8;
            // 
            // um_kernel32_lib_input
            // 
            um_kernel32_lib_input.BackColor = Color.FromArgb(35, 35, 35);
            um_kernel32_lib_input.DirPath = "";
            um_kernel32_lib_input.ForeColor = Color.FromArgb(120, 120, 120);
            um_kernel32_lib_input.Location = new Point(53, 171);
            um_kernel32_lib_input.Margin = new Padding(3, 2, 3, 2);
            um_kernel32_lib_input.Name = "um_kernel32_lib_input";
            um_kernel32_lib_input.Size = new Size(450, 27);
            um_kernel32_lib_input.TabIndex = 7;
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv4.ForeColor = Color.Silver;
            labelAdv4.Location = new Point(12, 100);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(110, 15);
            labelAdv4.TabIndex = 6;
            labelAdv4.Text = "Library Directories";
            // 
            // stl_lib_dir_input
            // 
            stl_lib_dir_input.BackColor = Color.FromArgb(35, 35, 35);
            stl_lib_dir_input.DirPath = "";
            stl_lib_dir_input.ForeColor = Color.FromArgb(120, 120, 120);
            stl_lib_dir_input.Location = new Point(53, 130);
            stl_lib_dir_input.Margin = new Padding(3, 2, 3, 2);
            stl_lib_dir_input.Name = "stl_lib_dir_input";
            stl_lib_dir_input.Size = new Size(450, 27);
            stl_lib_dir_input.TabIndex = 5;
            // 
            // ucrt_include_input
            // 
            ucrt_include_input.BackColor = Color.FromArgb(35, 35, 35);
            ucrt_include_input.DirPath = "";
            ucrt_include_input.ForeColor = Color.FromArgb(120, 120, 120);
            ucrt_include_input.Location = new Point(53, 69);
            ucrt_include_input.Margin = new Padding(3, 2, 3, 2);
            ucrt_include_input.Name = "ucrt_include_input";
            ucrt_include_input.Size = new Size(450, 27);
            ucrt_include_input.TabIndex = 4;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(12, 4);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(53, 15);
            labelAdv3.TabIndex = 3;
            labelAdv3.Text = "Includes";
            // 
            // buttonAdv2
            // 
            buttonAdv2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAdv2.BackColor = Color.Indigo;
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
            buttonAdv2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAdv2.ForeColor = Color.Silver;
            buttonAdv2.Location = new Point(418, 131);
            buttonAdv2.Margin = new Padding(3, 2, 3, 2);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(193, 28);
            buttonAdv2.TabIndex = 29;
            buttonAdv2.Text = "Select 'Visual Studio' folder";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnSelectVisualStudioPaths;
            // 
            // panelContainer
            // 
            panelContainer.Controls.Add(groupBoxAdv1);
            panelContainer.Location = new Point(3, 166);
            panelContainer.Margin = new Padding(3, 2, 3, 2);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(618, 208);
            panelContainer.TabIndex = 30;
            // 
            // buttonAdv4
            // 
            buttonAdv4.BackColor = Color.DarkSlateBlue;
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
            buttonAdv4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAdv4.ForeColor = Color.Silver;
            buttonAdv4.Location = new Point(310, 3);
            buttonAdv4.Margin = new Padding(3, 2, 3, 2);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(301, 30);
            buttonAdv4.TabIndex = 38;
            buttonAdv4.Text = "Download 'BuildTools' (recommended)";
            buttonAdv4.UseVisualStyleBackColor = false;
            buttonAdv4.Click += OnDirectDownloadPressed;
            // 
            // labelAdv15
            // 
            labelAdv15.BorderColor = Color.DarkGray;
            labelAdv15.BorderSize = 1;
            labelAdv15.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv15.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv15.Location = new Point(88, 5);
            labelAdv15.ModifyClampMax = 0F;
            labelAdv15.ModifyClampMin = 0F;
            labelAdv15.ModifyControlName = "";
            labelAdv15.ModifyScale = 1F;
            labelAdv15.Name = "labelAdv15";
            labelAdv15.Size = new Size(223, 54);
            labelAdv15.TabIndex = 37;
            labelAdv15.Text = "'Visual Studio C++' must be installed or 'Build Tools'. You can download 'Build Tools' with the 'Download' button.";
            // 
            // buttonAdv3
            // 
            buttonAdv3.BackColor = Color.DarkSlateBlue;
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
            buttonAdv3.Location = new Point(310, 36);
            buttonAdv3.Margin = new Padding(3, 2, 3, 2);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(301, 30);
            buttonAdv3.TabIndex = 36;
            buttonAdv3.Text = "Download 'BuildTools' github (updated)";
            buttonAdv3.UseVisualStyleBackColor = false;
            buttonAdv3.Click += OnDownloadFromGithubPressed;
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.msvc_med_logo;
            pictureBoxAdv1.Location = new Point(8, 5);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(74, 54);
            pictureBoxAdv1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAdv1.TabIndex = 35;
            pictureBoxAdv1.TabStop = false;
            // 
            // cl_exe_input
            // 
            cl_exe_input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cl_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            cl_exe_input.FilePath = "";
            cl_exe_input.Location = new Point(24, 85);
            cl_exe_input.Margin = new Padding(3, 2, 3, 2);
            cl_exe_input.Name = "cl_exe_input";
            cl_exe_input.Size = new Size(388, 29);
            cl_exe_input.TabIndex = 31;
            // 
            // buttonAdv5
            // 
            buttonAdv5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAdv5.BackColor = Color.Indigo;
            buttonAdv5.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv5.BorderSize = 1;
            buttonAdv5.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv5.expandImage = false;
            buttonAdv5.extraText = "";
            buttonAdv5.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv5.extraTextColor = Color.Black;
            buttonAdv5.extraTextFont = null;
            buttonAdv5.extraTextOffset = new Point(0, 0);
            buttonAdv5.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv5.FocusEnabled = false;
            buttonAdv5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAdv5.ForeColor = Color.Silver;
            buttonAdv5.Location = new Point(418, 86);
            buttonAdv5.Margin = new Padding(3, 2, 3, 2);
            buttonAdv5.Name = "buttonAdv5";
            buttonAdv5.PaintImageOnSelected = true;
            buttonAdv5.processEnterKey = true;
            buttonAdv5.resizeImage = new Point(0, 0);
            buttonAdv5.Selected = false;
            buttonAdv5.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv5.Size = new Size(193, 29);
            buttonAdv5.TabIndex = 32;
            buttonAdv5.Text = "Select 'BuildTools' folder";
            buttonAdv5.UseVisualStyleBackColor = false;
            buttonAdv5.Click += OnUseBuildToolsHardcodedPaths;
            // 
            // labelAdv16
            // 
            labelAdv16.AutoSize = true;
            labelAdv16.BorderColor = Color.DarkGray;
            labelAdv16.BorderSize = 1;
            labelAdv16.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv16.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv16.ForeColor = SystemColors.WindowFrame;
            labelAdv16.Location = new Point(189, 71);
            labelAdv16.ModifyClampMax = 0F;
            labelAdv16.ModifyClampMin = 0F;
            labelAdv16.ModifyControlName = "";
            labelAdv16.ModifyScale = 1F;
            labelAdv16.Name = "labelAdv16";
            labelAdv16.Size = new Size(264, 13);
            labelAdv16.TabIndex = 33;
            labelAdv16.Text = "..\\VC\\Tools\\MSVC\\14.39.33519\\bin\\Hostx64\\x64\\cl.exe";
            // 
            // labelAdv17
            // 
            labelAdv17.AutoSize = true;
            labelAdv17.BorderColor = Color.DarkGray;
            labelAdv17.BorderSize = 1;
            labelAdv17.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv17.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv17.ForeColor = SystemColors.WindowFrame;
            labelAdv17.Location = new Point(189, 116);
            labelAdv17.ModifyClampMax = 0F;
            labelAdv17.ModifyClampMin = 0F;
            labelAdv17.ModifyControlName = "";
            labelAdv17.ModifyScale = 1F;
            labelAdv17.Name = "labelAdv17";
            labelAdv17.Size = new Size(268, 13);
            labelAdv17.TabIndex = 34;
            labelAdv17.Text = "..\\VC\\Tools\\MSVC\\14.39.33519\\bin\\Hostx64\\x64\\lib.exe";
            // 
            // MsvcBuildSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonAdv4);
            Controls.Add(buttonAdv3);
            Controls.Add(labelAdv1);
            Controls.Add(labelAdv17);
            Controls.Add(labelAdv15);
            Controls.Add(labelAdv16);
            Controls.Add(pictureBoxAdv1);
            Controls.Add(buttonAdv5);
            Controls.Add(cl_exe_input);
            Controls.Add(panelContainer);
            Controls.Add(buttonAdv2);
            Controls.Add(lib_exe_input);
            Controls.Add(labelAdv2);
            Name = "MsvcBuildSetup";
            Size = new Size(618, 475);
            groupBoxAdv1.ResumeLayout(false);
            groupBoxAdv1.PerformLayout();
            panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private UI.FileInput lib_exe_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.ButtonAdv okButton;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private UI.DirectoryInput stl_include_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private UI.DirectoryInput um_kernel32_lib_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private UI.DirectoryInput stl_lib_dir_input;
        private UI.DirectoryInput ucrt_include_input;
        private UI.DirectoryInput ucrt_lib_input;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private VampirioCode.UI.Controls.LabelAdv labelAdv6;
        private VampirioCode.UI.Controls.LabelAdv labelAdv9;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.LabelAdv labelAdv7;
        private VampirioCode.UI.Controls.LabelAdv labelAdv14;
        private VampirioCode.UI.Controls.LabelAdv labelAdv13;
        private VampirioCode.UI.Controls.LabelAdv labelAdv12;
        private VampirioCode.UI.Controls.LabelAdv labelAdv11;
        private VampirioCode.UI.Controls.LabelAdv labelAdv10;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private Panel panelContainer;
        private VampirioCode.UI.Controls.LabelAdv labelAdv15;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv4;
        private UI.FileInput cl_exe_input;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv5;
        private VampirioCode.UI.Controls.LabelAdv labelAdv16;
        private VampirioCode.UI.Controls.LabelAdv labelAdv17;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv6;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv7;
    }
}
