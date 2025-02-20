﻿namespace VampirioCode.BuilderInstall.cpp
{
    partial class CLangBuildSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLangBuildSetup));
            labelAdv1 = new VampirioCode.UI.Controls.LabelAdv();
            clang_exe_input = new UI.FileInput();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            auto_fill_ckbox = new CheckBox();
            labelAdv6 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            clang_lib_input = new UI.DirectoryInput();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv10 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            clang_include_input = new UI.DirectoryInput();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            groupBoxAdv2 = new VampirioCode.UI.Controls.GroupBoxAdv();
            labelAdv7 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv3 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv17 = new VampirioCode.UI.Controls.LabelAdv();
            clang_llvm_ar_exe_input = new UI.FileInput();
            labelAdv9 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv11 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv1.SuspendLayout();
            groupBoxAdv2.SuspendLayout();
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
            labelAdv1.Location = new Point(26, 11);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(163, 15);
            labelAdv1.TabIndex = 2;
            labelAdv1.Text = "'clang++.exe' compiler path";
            labelAdv1.Click += labelAdv1_Click;
            // 
            // clang_exe_input
            // 
            clang_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            clang_exe_input.FilePath = "";
            clang_exe_input.Location = new Point(26, 24);
            clang_exe_input.Margin = new Padding(3, 2, 3, 2);
            clang_exe_input.Name = "clang_exe_input";
            clang_exe_input.Size = new Size(450, 30);
            clang_exe_input.TabIndex = 3;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(65, 65, 65);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(auto_fill_ckbox);
            groupBoxAdv1.Controls.Add(labelAdv6);
            groupBoxAdv1.Controls.Add(labelAdv2);
            groupBoxAdv1.Controls.Add(labelAdv4);
            groupBoxAdv1.Controls.Add(clang_lib_input);
            groupBoxAdv1.Controls.Add(labelAdv3);
            groupBoxAdv1.Controls.Add(labelAdv10);
            groupBoxAdv1.Controls.Add(labelAdv5);
            groupBoxAdv1.Controls.Add(clang_include_input);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(21, 105);
            groupBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Padding = new Padding(3, 2, 3, 2);
            groupBoxAdv1.Size = new Size(572, 140);
            groupBoxAdv1.TabIndex = 4;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // auto_fill_ckbox
            // 
            auto_fill_ckbox.AutoSize = true;
            auto_fill_ckbox.ForeColor = Color.Silver;
            auto_fill_ckbox.Location = new Point(478, 10);
            auto_fill_ckbox.Margin = new Padding(3, 2, 3, 2);
            auto_fill_ckbox.Name = "auto_fill_ckbox";
            auto_fill_ckbox.Size = new Size(70, 19);
            auto_fill_ckbox.TabIndex = 38;
            auto_fill_ckbox.Text = "Auto-fill";
            auto_fill_ckbox.UseVisualStyleBackColor = true;
            // 
            // labelAdv6
            // 
            labelAdv6.AutoSize = true;
            labelAdv6.BorderColor = Color.DarkGray;
            labelAdv6.BorderSize = 1;
            labelAdv6.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv6.ForeColor = Color.Silver;
            labelAdv6.Location = new Point(19, 70);
            labelAdv6.ModifyClampMax = 0F;
            labelAdv6.ModifyClampMin = 0F;
            labelAdv6.ModifyControlName = "";
            labelAdv6.ModifyScale = 1F;
            labelAdv6.Name = "labelAdv6";
            labelAdv6.Size = new Size(110, 15);
            labelAdv6.TabIndex = 37;
            labelAdv6.Text = "Library Directories";
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(52, 88);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(52, 13);
            labelAdv2.TabIndex = 36;
            labelAdv2.Text = "CLang lib";
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv4.ForeColor = SystemColors.WindowFrame;
            labelAdv4.Location = new Point(195, 88);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(196, 13);
            labelAdv4.TabIndex = 35;
            labelAdv4.Text = "C:\\programs_dev\\clang_llvm_18_1_0\\lib";
            // 
            // clang_lib_input
            // 
            clang_lib_input.BackColor = Color.FromArgb(35, 35, 35);
            clang_lib_input.DirPath = "";
            clang_lib_input.ForeColor = Color.FromArgb(120, 120, 120);
            clang_lib_input.Location = new Point(52, 98);
            clang_lib_input.Margin = new Padding(3, 2, 3, 2);
            clang_lib_input.Name = "clang_lib_input";
            clang_lib_input.Size = new Size(450, 27);
            clang_lib_input.TabIndex = 34;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(19, 10);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(53, 15);
            labelAdv3.TabIndex = 33;
            labelAdv3.Text = "Includes";
            // 
            // labelAdv10
            // 
            labelAdv10.AutoSize = true;
            labelAdv10.BorderColor = Color.DarkGray;
            labelAdv10.BorderSize = 1;
            labelAdv10.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv10.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv10.ForeColor = Color.Silver;
            labelAdv10.Location = new Point(52, 25);
            labelAdv10.ModifyClampMax = 0F;
            labelAdv10.ModifyClampMin = 0F;
            labelAdv10.ModifyControlName = "";
            labelAdv10.ModifyScale = 1F;
            labelAdv10.Name = "labelAdv10";
            labelAdv10.Size = new Size(74, 13);
            labelAdv10.TabIndex = 32;
            labelAdv10.Text = "CLang include";
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv5.ForeColor = SystemColors.WindowFrame;
            labelAdv5.Location = new Point(195, 25);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(218, 13);
            labelAdv5.TabIndex = 31;
            labelAdv5.Text = "C:\\programs_dev\\clang_llvm_18_1_0\\include";
            // 
            // clang_include_input
            // 
            clang_include_input.BackColor = Color.FromArgb(35, 35, 35);
            clang_include_input.DirPath = "";
            clang_include_input.ForeColor = Color.FromArgb(120, 120, 120);
            clang_include_input.Location = new Point(52, 35);
            clang_include_input.Margin = new Padding(3, 2, 3, 2);
            clang_include_input.Name = "clang_include_input";
            clang_include_input.Size = new Size(450, 27);
            clang_include_input.TabIndex = 30;
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
            buttonAdv2.Location = new Point(481, 29);
            buttonAdv2.Margin = new Padding(3, 2, 3, 2);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(107, 56);
            buttonAdv2.TabIndex = 30;
            buttonAdv2.Text = "Use a reference hardcoded paths";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnUseHardcodedPaths;
            // 
            // groupBoxAdv2
            // 
            groupBoxAdv2.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv2.BorderSize = 1;
            groupBoxAdv2.Controls.Add(labelAdv7);
            groupBoxAdv2.Controls.Add(buttonAdv1);
            groupBoxAdv2.Controls.Add(pictureBoxAdv1);
            groupBoxAdv2.Controls.Add(buttonAdv3);
            groupBoxAdv2.Controls.Add(labelAdv8);
            groupBoxAdv2.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv2.Location = new Point(21, 249);
            groupBoxAdv2.Margin = new Padding(3, 2, 3, 2);
            groupBoxAdv2.Name = "groupBoxAdv2";
            groupBoxAdv2.Padding = new Padding(3, 2, 3, 2);
            groupBoxAdv2.Size = new Size(572, 142);
            groupBoxAdv2.TabIndex = 41;
            groupBoxAdv2.TabStop = false;
            groupBoxAdv2.Text = "groupBoxAdv2";
            // 
            // labelAdv7
            // 
            labelAdv7.BorderColor = Color.DarkGray;
            labelAdv7.BorderSize = 1;
            labelAdv7.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv7.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv7.Location = new Point(158, 63);
            labelAdv7.ModifyClampMax = 0F;
            labelAdv7.ModifyClampMin = 0F;
            labelAdv7.ModifyControlName = "";
            labelAdv7.ModifyScale = 1F;
            labelAdv7.Name = "labelAdv7";
            labelAdv7.Size = new Size(258, 65);
            labelAdv7.TabIndex = 34;
            labelAdv7.Text = "A know working version is the 18.1.0\r\nA portable version can be downloaded here";
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
            buttonAdv1.Location = new Point(435, 81);
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
            pictureBoxAdv1.Image = Properties.Resources.llvm_med_logo;
            pictureBoxAdv1.Location = new Point(19, 63);
            pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(110, 65);
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
            buttonAdv3.Location = new Point(48, 445);
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
            labelAdv8.Text = resources.GetString("labelAdv8.Text");
            // 
            // labelAdv17
            // 
            labelAdv17.AutoSize = true;
            labelAdv17.BorderColor = Color.DarkGray;
            labelAdv17.BorderSize = 1;
            labelAdv17.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv17.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv17.ForeColor = SystemColors.WindowFrame;
            labelAdv17.Location = new Point(190, 57);
            labelAdv17.ModifyClampMax = 0F;
            labelAdv17.ModifyClampMin = 0F;
            labelAdv17.ModifyControlName = "";
            labelAdv17.ModifyScale = 1F;
            labelAdv17.Name = "labelAdv17";
            labelAdv17.Size = new Size(254, 13);
            labelAdv17.TabIndex = 44;
            labelAdv17.Text = "C:\\programs_dev\\clang_llvm_18_1_0\\bin\\llvm-ar.exe";
            // 
            // clang_llvm_ar_input
            // 
            clang_llvm_ar_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            clang_llvm_ar_exe_input.FilePath = "";
            clang_llvm_ar_exe_input.Location = new Point(25, 68);
            clang_llvm_ar_exe_input.Margin = new Padding(3, 2, 3, 2);
            clang_llvm_ar_exe_input.Name = "clang_llvm_ar_input";
            clang_llvm_ar_exe_input.Size = new Size(450, 30);
            clang_llvm_ar_exe_input.TabIndex = 43;
            // 
            // labelAdv9
            // 
            labelAdv9.AutoSize = true;
            labelAdv9.BorderColor = Color.DarkGray;
            labelAdv9.BorderSize = 1;
            labelAdv9.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv9.ForeColor = Color.Silver;
            labelAdv9.Location = new Point(25, 55);
            labelAdv9.ModifyClampMax = 0F;
            labelAdv9.ModifyClampMin = 0F;
            labelAdv9.ModifyControlName = "";
            labelAdv9.ModifyScale = 1F;
            labelAdv9.Name = "labelAdv9";
            labelAdv9.Size = new Size(157, 15);
            labelAdv9.TabIndex = 42;
            labelAdv9.Text = "'llvm-ar.exe' compiler path";
            // 
            // labelAdv11
            // 
            labelAdv11.AutoSize = true;
            labelAdv11.BorderColor = Color.DarkGray;
            labelAdv11.BorderSize = 1;
            labelAdv11.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv11.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelAdv11.ForeColor = SystemColors.WindowFrame;
            labelAdv11.Location = new Point(195, 13);
            labelAdv11.ModifyClampMax = 0F;
            labelAdv11.ModifyClampMin = 0F;
            labelAdv11.ModifyControlName = "";
            labelAdv11.ModifyScale = 1F;
            labelAdv11.Name = "labelAdv11";
            labelAdv11.Size = new Size(262, 13);
            labelAdv11.TabIndex = 45;
            labelAdv11.Text = "C:\\programs_dev\\clang_llvm_18_1_0\\bin\\clang++.exe";
            // 
            // CLangBuildSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(labelAdv11);
            Controls.Add(labelAdv17);
            Controls.Add(clang_llvm_ar_exe_input);
            Controls.Add(labelAdv9);
            Controls.Add(labelAdv1);
            Controls.Add(groupBoxAdv2);
            Controls.Add(buttonAdv2);
            Controls.Add(groupBoxAdv1);
            Controls.Add(clang_exe_input);
            Name = "CLangBuildSetup";
            Size = new Size(618, 408);
            groupBoxAdv1.ResumeLayout(false);
            groupBoxAdv1.PerformLayout();
            groupBoxAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private UI.FileInput clang_exe_input;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv10;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private UI.DirectoryInput clang_include_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private UI.DirectoryInput clang_lib_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv6;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private CheckBox auto_fill_ckbox;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv2;
        private VampirioCode.UI.Controls.LabelAdv labelAdv7;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv17;
        private UI.FileInput clang_llvm_ar_exe_input;
        private VampirioCode.UI.Controls.LabelAdv labelAdv9;
        private VampirioCode.UI.Controls.LabelAdv labelAdv11;
    }
}
