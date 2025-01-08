namespace VampirioCode.BuilderInstall.cpp
{
    partial class GnuGppBuildSetup
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
            wsl_distro_name = new VampirioCode.UI.Controls.TextBoxAdv();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            buttonAdv2 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            wslInstalledTick = new PictureBox();
            labelAdv6 = new VampirioCode.UI.Controls.LabelAdv();
            labelAdv7 = new VampirioCode.UI.Controls.LabelAdv();
            distroInstalledTick = new PictureBox();
            groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            pictureBoxAdv1 = new VampirioCode.UI.Controls.PictureBoxAdv();
            buttonAdv1 = new VampirioCode.UI.Controls.ButtonAdv();
            labelAdv8 = new VampirioCode.UI.Controls.LabelAdv();
            groupBoxAdv2 = new VampirioCode.UI.Controls.GroupBoxAdv();
            ((System.ComponentModel.ISupportInitialize)wslInstalledTick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)distroInstalledTick).BeginInit();
            groupBoxAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).BeginInit();
            groupBoxAdv2.SuspendLayout();
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
            labelAdv1.Location = new Point(10, 23);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(128, 20);
            labelAdv1.TabIndex = 1;
            labelAdv1.Text = "WSL distro name";
            // 
            // wsl_distro_name
            // 
            wsl_distro_name.AllowBackspace = true;
            wsl_distro_name.AllowTextEdition = true;
            wsl_distro_name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            wsl_distro_name.AutoEdition = false;
            wsl_distro_name.AutoSelect = false;
            wsl_distro_name.BackColor = Color.FromArgb(30, 30, 30);
            wsl_distro_name.BorderStyle = BorderStyle.FixedSingle;
            wsl_distro_name.ExcludeCharacters = null;
            wsl_distro_name.ForeColor = Color.Silver;
            wsl_distro_name.IncludeOnlyCharacters = null;
            wsl_distro_name.LeftLeadingCharacter = '\0';
            wsl_distro_name.Location = new Point(10, 130);
            wsl_distro_name.Name = "wsl_distro_name";
            wsl_distro_name.Size = new Size(380, 27);
            wsl_distro_name.TabIndex = 28;
            // 
            // labelAdv2
            // 
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(10, 50);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(380, 68);
            labelAdv2.TabIndex = 29;
            labelAdv2.Text = "commonly an Ubuntu is installed called just right 'Ubuntu' but if another distro was created and used with gnu g++ that should be used, so change the name";
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
            buttonAdv2.Location = new Point(268, 189);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(122, 33);
            buttonAdv2.TabIndex = 30;
            buttonAdv2.Text = "Check";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnCheckPressed;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(10, 195);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(240, 20);
            labelAdv3.TabIndex = 31;
            labelAdv3.Text = "Check if WSL subsystem is installed";
            // 
            // labelAdv4
            // 
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv4.ForeColor = Color.FromArgb(130, 130, 130);
            labelAdv4.Location = new Point(24, 46);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(612, 68);
            labelAdv4.TabIndex = 32;
            labelAdv4.Text = "WSL (Windows Subsystem for Linux) enables running Linux distributions natively on Windows, allowing developers to use Linux tools, scripts, and apps directly within a Windows environment.";
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdv5.ForeColor = Color.Silver;
            labelAdv5.Location = new Point(24, 14);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(38, 20);
            labelAdv5.TabIndex = 33;
            labelAdv5.Text = "Info";
            // 
            // wslInstalledTick
            // 
            wslInstalledTick.Image = Properties.Resources.med_tick_off;
            wslInstalledTick.Location = new Point(125, 241);
            wslInstalledTick.Name = "wslInstalledTick";
            wslInstalledTick.Size = new Size(24, 20);
            wslInstalledTick.TabIndex = 34;
            wslInstalledTick.TabStop = false;
            // 
            // labelAdv6
            // 
            labelAdv6.AutoSize = true;
            labelAdv6.BorderColor = Color.DarkGray;
            labelAdv6.BorderSize = 1;
            labelAdv6.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv6.ForeColor = Color.Silver;
            labelAdv6.Location = new Point(10, 241);
            labelAdv6.ModifyClampMax = 0F;
            labelAdv6.ModifyClampMin = 0F;
            labelAdv6.ModifyControlName = "";
            labelAdv6.ModifyScale = 1F;
            labelAdv6.Name = "labelAdv6";
            labelAdv6.Size = new Size(98, 20);
            labelAdv6.TabIndex = 35;
            labelAdv6.Text = "WSL Installed";
            // 
            // labelAdv7
            // 
            labelAdv7.AutoSize = true;
            labelAdv7.BorderColor = Color.DarkGray;
            labelAdv7.BorderSize = 1;
            labelAdv7.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv7.ForeColor = Color.Silver;
            labelAdv7.Location = new Point(183, 241);
            labelAdv7.ModifyClampMax = 0F;
            labelAdv7.ModifyClampMin = 0F;
            labelAdv7.ModifyControlName = "";
            labelAdv7.ModifyScale = 1F;
            labelAdv7.Name = "labelAdv7";
            labelAdv7.Size = new Size(109, 20);
            labelAdv7.TabIndex = 37;
            labelAdv7.Text = "Distro Installed";
            // 
            // distroInstalledTick
            // 
            distroInstalledTick.Image = Properties.Resources.med_tick_off;
            distroInstalledTick.Location = new Point(310, 241);
            distroInstalledTick.Name = "distroInstalledTick";
            distroInstalledTick.Size = new Size(24, 20);
            distroInstalledTick.TabIndex = 36;
            distroInstalledTick.TabStop = false;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv1.BorderSize = 1;
            groupBoxAdv1.Controls.Add(pictureBoxAdv1);
            groupBoxAdv1.Controls.Add(buttonAdv1);
            groupBoxAdv1.Controls.Add(labelAdv8);
            groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(440, 138);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Size = new Size(250, 352);
            groupBoxAdv1.TabIndex = 38;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // pictureBoxAdv1
            // 
            pictureBoxAdv1.Image = Properties.Resources.wsl_flat_logo_small;
            pictureBoxAdv1.Location = new Point(55, 80);
            pictureBoxAdv1.Name = "pictureBoxAdv1";
            pictureBoxAdv1.Size = new Size(131, 60);
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
            buttonAdv1.Location = new Point(55, 182);
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
            buttonAdv1.Click += OnDownloadWSLManPressed;
            // 
            // labelAdv8
            // 
            labelAdv8.BorderColor = Color.DarkGray;
            labelAdv8.BorderSize = 1;
            labelAdv8.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAdv8.ForeColor = SystemColors.GradientActiveCaption;
            labelAdv8.Location = new Point(6, 10);
            labelAdv8.ModifyClampMax = 0F;
            labelAdv8.ModifyClampMin = 0F;
            labelAdv8.ModifyControlName = "";
            labelAdv8.ModifyScale = 1F;
            labelAdv8.Name = "labelAdv8";
            labelAdv8.Size = new Size(238, 72);
            labelAdv8.TabIndex = 30;
            labelAdv8.Text = "You can install WSLMan to install and manage distros from WSL";
            // 
            // groupBoxAdv2
            // 
            groupBoxAdv2.BorderColor = Color.FromArgb(60, 60, 60);
            groupBoxAdv2.BorderSize = 1;
            groupBoxAdv2.Controls.Add(labelAdv1);
            groupBoxAdv2.Controls.Add(wsl_distro_name);
            groupBoxAdv2.Controls.Add(labelAdv7);
            groupBoxAdv2.Controls.Add(labelAdv2);
            groupBoxAdv2.Controls.Add(distroInstalledTick);
            groupBoxAdv2.Controls.Add(buttonAdv2);
            groupBoxAdv2.Controls.Add(labelAdv6);
            groupBoxAdv2.Controls.Add(labelAdv3);
            groupBoxAdv2.Controls.Add(wslInstalledTick);
            groupBoxAdv2.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv2.Location = new Point(19, 138);
            groupBoxAdv2.Name = "groupBoxAdv2";
            groupBoxAdv2.Size = new Size(415, 352);
            groupBoxAdv2.TabIndex = 39;
            groupBoxAdv2.TabStop = false;
            groupBoxAdv2.Text = "groupBoxAdv2";
            // 
            // GnuGppBuildSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(groupBoxAdv2);
            Controls.Add(groupBoxAdv1);
            Controls.Add(labelAdv5);
            Controls.Add(labelAdv4);
            Name = "GnuGppBuildSetup";
            Size = new Size(706, 544);
            ((System.ComponentModel.ISupportInitialize)wslInstalledTick).EndInit();
            ((System.ComponentModel.ISupportInitialize)distroInstalledTick).EndInit();
            groupBoxAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdv1).EndInit();
            groupBoxAdv2.ResumeLayout(false);
            groupBoxAdv2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.TextBoxAdv wsl_distro_name;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private PictureBox wslInstalledTick;
        private VampirioCode.UI.Controls.LabelAdv labelAdv6;
        private VampirioCode.UI.Controls.LabelAdv labelAdv7;
        private PictureBox distroInstalledTick;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private VampirioCode.UI.Controls.LabelAdv labelAdv8;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.PictureBoxAdv pictureBoxAdv1;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv2;
    }
}
