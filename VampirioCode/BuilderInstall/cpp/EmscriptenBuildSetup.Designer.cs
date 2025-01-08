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
            SuspendLayout();
            // 
            // emsdk_bat_input
            // 
            emsdk_bat_input.BackColor = Color.FromArgb(35, 35, 35);
            emsdk_bat_input.FilePath = "";
            emsdk_bat_input.Location = new Point(20, 44);
            emsdk_bat_input.Name = "emsdk_bat_input";
            emsdk_bat_input.Size = new Size(514, 40);
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
            labelAdv1.Location = new Point(20, 21);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(192, 20);
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
            labelAdv5.Location = new Point(293, 24);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(203, 17);
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
            buttonAdv2.Location = new Point(549, 21);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(122, 74);
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
            labelAdv2.Location = new Point(293, 100);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(296, 17);
            labelAdv2.TabIndex = 33;
            labelAdv2.Text = "C:\\programs_dev\\node-v20.11.0-win-x64\\nodejs.exe";
            // 
            // nodejs_exe_input
            // 
            nodejs_exe_input.BackColor = Color.FromArgb(35, 35, 35);
            nodejs_exe_input.FilePath = "";
            nodejs_exe_input.Location = new Point(20, 120);
            nodejs_exe_input.Name = "nodejs_exe_input";
            nodejs_exe_input.Size = new Size(514, 40);
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
            labelAdv3.Location = new Point(20, 97);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(195, 20);
            labelAdv3.TabIndex = 31;
            labelAdv3.Text = "'node.exe' interpreter path";
            // 
            // EmscriptenBuildSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(labelAdv2);
            Controls.Add(nodejs_exe_input);
            Controls.Add(labelAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(labelAdv5);
            Controls.Add(emsdk_bat_input);
            Controls.Add(labelAdv1);
            Name = "EmscriptenBuildSetup";
            Size = new Size(706, 544);
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
    }
}
