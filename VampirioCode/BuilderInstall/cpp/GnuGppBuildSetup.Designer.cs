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
            labelAdv1.Location = new Point(28, 29);
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
            wsl_distro_name.Location = new Point(28, 136);
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
            labelAdv2.Location = new Point(28, 56);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(380, 68);
            labelAdv2.TabIndex = 29;
            labelAdv2.Text = "commonly an Ubuntu is installed called just right 'Ubuntu' but if another distro was created and used with gnu g++ that should be used";
            // 
            // GnuGppBuildSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            Controls.Add(labelAdv2);
            Controls.Add(wsl_distro_name);
            Controls.Add(labelAdv1);
            Name = "GnuGppBuildSetup";
            Size = new Size(706, 544);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.TextBoxAdv wsl_distro_name;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
    }
}
