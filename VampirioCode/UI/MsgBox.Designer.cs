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
            button2 = new Controls.ButtonAdv();
            groupBoxAdv1 = new Controls.GroupBoxAdv();
            icon = new Controls.PictureBoxAdv();
            descLabel = new Controls.LabelAdv();
            button1 = new Controls.ButtonAdv();
            button0 = new Controls.ButtonAdv();
            groupBoxAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(30, 30, 30);
            button2.BorderColor = Color.FromArgb(25, 25, 25);
            button2.BorderSize = 2;
            button2.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            button2.expandImage = false;
            button2.extraText = "";
            button2.extraTextAlign = ContentAlignment.MiddleCenter;
            button2.extraTextColor = Color.Black;
            button2.extraTextFont = null;
            button2.extraTextOffset = new Point(0, 0);
            button2.FocusColor = Color.FromArgb(24, 81, 115);
            button2.FocusEnabled = true;
            button2.ForeColor = Color.FromArgb(224, 224, 224);
            button2.Location = new Point(436, 211);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.PaintImageOnSelected = true;
            button2.processEnterKey = true;
            button2.resizeImage = new Point(0, 0);
            button2.Selected = false;
            button2.SelectedColor = Color.FromArgb(0, 122, 204);
            button2.Size = new Size(108, 32);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // groupBoxAdv1
            // 
            groupBoxAdv1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAdv1.BackColor = Color.FromArgb(52, 52, 52);
            groupBoxAdv1.BorderColor = Color.FromArgb(64, 64, 64);
            groupBoxAdv1.BorderSize = 2;
            groupBoxAdv1.Controls.Add(icon);
            groupBoxAdv1.Controls.Add(descLabel);
            groupBoxAdv1.CStyle = UI.Controls.GroupBoxAdv.CustomStyle.SOLID;
            groupBoxAdv1.Location = new Point(16, 18);
            groupBoxAdv1.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdv1.Name = "groupBoxAdv1";
            groupBoxAdv1.Padding = new Padding(4, 5, 4, 5);
            groupBoxAdv1.Size = new Size(528, 181);
            groupBoxAdv1.TabIndex = 3;
            groupBoxAdv1.TabStop = false;
            groupBoxAdv1.Text = "groupBoxAdv1";
            // 
            // icon
            // 
            icon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icon.Image = null;
            icon.Location = new Point(474, 18);
            icon.Margin = new Padding(4, 5, 4, 5);
            icon.Name = "icon";
            icon.Size = new Size(37, 37);
            icon.SizeMode = PictureBoxSizeMode.CenterImage;
            icon.TabIndex = 7;
            icon.TabStop = false;
            // 
            // descLabel
            // 
            descLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            descLabel.BorderColor = Color.DarkGray;
            descLabel.BorderSize = 1;
            descLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            descLabel.ForeColor = Color.Silver;
            descLabel.Location = new Point(18, 18);
            descLabel.Margin = new Padding(4, 0, 4, 0);
            descLabel.ModifyClampMax = 0F;
            descLabel.ModifyClampMin = 0F;
            descLabel.ModifyControlName = "";
            descLabel.ModifyScale = 1F;
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(436, 144);
            descLabel.TabIndex = 2;
            descLabel.Text = "Test Message\r\nLine 1\r\nLine 2\r\n";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(30, 30, 30);
            button1.BorderColor = Color.FromArgb(25, 25, 25);
            button1.BorderSize = 2;
            button1.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            button1.expandImage = false;
            button1.extraText = "";
            button1.extraTextAlign = ContentAlignment.MiddleCenter;
            button1.extraTextColor = Color.Black;
            button1.extraTextFont = null;
            button1.extraTextOffset = new Point(0, 0);
            button1.FocusColor = Color.FromArgb(24, 81, 115);
            button1.FocusEnabled = true;
            button1.ForeColor = Color.FromArgb(224, 224, 224);
            button1.Location = new Point(320, 211);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.PaintImageOnSelected = true;
            button1.processEnterKey = true;
            button1.resizeImage = new Point(0, 0);
            button1.Selected = false;
            button1.SelectedColor = Color.FromArgb(0, 122, 204);
            button1.Size = new Size(108, 32);
            button1.TabIndex = 5;
            button1.Text = "No";
            button1.UseVisualStyleBackColor = false;
            // 
            // button0
            // 
            button0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button0.BackColor = Color.FromArgb(30, 30, 30);
            button0.BorderColor = Color.FromArgb(25, 25, 25);
            button0.BorderSize = 2;
            button0.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            button0.expandImage = false;
            button0.extraText = "";
            button0.extraTextAlign = ContentAlignment.MiddleCenter;
            button0.extraTextColor = Color.Black;
            button0.extraTextFont = null;
            button0.extraTextOffset = new Point(0, 0);
            button0.FocusColor = Color.FromArgb(24, 81, 115);
            button0.FocusEnabled = true;
            button0.ForeColor = Color.FromArgb(224, 224, 224);
            button0.Location = new Point(204, 211);
            button0.Margin = new Padding(4, 5, 4, 5);
            button0.Name = "button0";
            button0.PaintImageOnSelected = true;
            button0.processEnterKey = true;
            button0.resizeImage = new Point(0, 0);
            button0.Selected = false;
            button0.SelectedColor = Color.FromArgb(0, 122, 204);
            button0.Size = new Size(108, 32);
            button0.TabIndex = 6;
            button0.Text = "Yes";
            button0.UseVisualStyleBackColor = false;
            // 
            // MsgBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(560, 253);
            Controls.Add(button0);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(groupBoxAdv1);
            Margin = new Padding(4, 5, 4, 5);
            MinimizeBox = false;
            Name = "MsgBox";
            groupBoxAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ResumeLayout(false);
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
