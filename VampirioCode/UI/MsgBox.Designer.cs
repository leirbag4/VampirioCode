using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.button2 = new VampirioCode.UI.Controls.ButtonAdv();
            this.groupBoxAdv1 = new VampirioCode.UI.Controls.GroupBoxAdv();
            this.icon = new VampirioCode.UI.Controls.PictureBoxAdv();
            this.descLabel = new VampirioCode.UI.Controls.LabelAdv();
            this.button1 = new VampirioCode.UI.Controls.ButtonAdv();
            this.button0 = new VampirioCode.UI.Controls.ButtonAdv();
            this.groupBoxAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button2.BorderSize = 2;
            this.button2.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            this.button2.expandImage = false;
            this.button2.extraText = "";
            this.button2.extraTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.extraTextColor = System.Drawing.Color.Black;
            this.button2.extraTextFont = null;
            this.button2.extraTextOffset = new System.Drawing.Point(0, 0);
            this.button2.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(115)))));
            this.button2.FocusEnabled = true;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.Location = new System.Drawing.Point(342, 194);
            this.button2.Name = "button2";
            this.button2.PaintImageOnSelected = true;
            this.button2.processEnterKey = true;
            this.button2.resizeImage = new System.Drawing.Point(0, 0);
            this.button2.Selected = false;
            this.button2.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.Size = new System.Drawing.Size(112, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBoxAdv1
            // 
            this.groupBoxAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAdv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.groupBoxAdv1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxAdv1.BorderSize = 2;
            this.groupBoxAdv1.Controls.Add(this.icon);
            this.groupBoxAdv1.Controls.Add(this.descLabel);
            this.groupBoxAdv1.CStyle = VampirioCode.UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            this.groupBoxAdv1.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAdv1.Name = "groupBoxAdv1";
            this.groupBoxAdv1.Size = new System.Drawing.Size(442, 172);
            this.groupBoxAdv1.TabIndex = 3;
            this.groupBoxAdv1.TabStop = false;
            this.groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // icon
            // 
            this.icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.icon.Image = ((System.Drawing.Image)(resources.GetObject("icon.Image")));
            this.icon.Location = new System.Drawing.Point(356, 16);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(70, 60);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icon.TabIndex = 7;
            this.icon.TabStop = false;
            // 
            // descLabel
            // 
            this.descLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descLabel.BorderColor = System.Drawing.Color.DarkGray;
            this.descLabel.BorderSize = 1;
            this.descLabel.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            this.descLabel.ForeColor = System.Drawing.Color.Silver;
            this.descLabel.Location = new System.Drawing.Point(27, 33);
            this.descLabel.ModifyClampMax = 0F;
            this.descLabel.ModifyClampMin = 0F;
            this.descLabel.ModifyControlName = "";
            this.descLabel.ModifyScale = 1F;
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(309, 107);
            this.descLabel.TabIndex = 2;
            this.descLabel.Text = "Test Message\r\nLine 1\r\nLine 2\r\n";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button1.BorderSize = 2;
            this.button1.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            this.button1.expandImage = false;
            this.button1.extraText = "";
            this.button1.extraTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.extraTextColor = System.Drawing.Color.Black;
            this.button1.extraTextFont = null;
            this.button1.extraTextOffset = new System.Drawing.Point(0, 0);
            this.button1.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(115)))));
            this.button1.FocusEnabled = true;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(224, 194);
            this.button1.Name = "button1";
            this.button1.PaintImageOnSelected = true;
            this.button1.processEnterKey = true;
            this.button1.resizeImage = new System.Drawing.Point(0, 0);
            this.button1.Selected = false;
            this.button1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "No";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button0
            // 
            this.button0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button0.BorderSize = 2;
            this.button0.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            this.button0.expandImage = false;
            this.button0.extraText = "";
            this.button0.extraTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button0.extraTextColor = System.Drawing.Color.Black;
            this.button0.extraTextFont = null;
            this.button0.extraTextOffset = new System.Drawing.Point(0, 0);
            this.button0.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(115)))));
            this.button0.FocusEnabled = true;
            this.button0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button0.Location = new System.Drawing.Point(106, 194);
            this.button0.Name = "button0";
            this.button0.PaintImageOnSelected = true;
            this.button0.processEnterKey = true;
            this.button0.resizeImage = new System.Drawing.Point(0, 0);
            this.button0.Selected = false;
            this.button0.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button0.Size = new System.Drawing.Size(112, 32);
            this.button0.TabIndex = 6;
            this.button0.Text = "Yes";
            this.button0.UseVisualStyleBackColor = false;
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(466, 235);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxAdv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBoxAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VampirioCode.UI.Controls.ButtonAdv button2;
        private VampirioCode.UI.Controls.GroupBoxAdv groupBoxAdv1;
        private VampirioCode.UI.Controls.LabelAdv descLabel;
        private VampirioCode.UI.Controls.ButtonAdv button1;
        private VampirioCode.UI.Controls.ButtonAdv button0;
        private VampirioCode.UI.Controls.PictureBoxAdv icon;
    }
}
