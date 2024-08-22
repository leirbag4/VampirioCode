namespace VampirioCode.BuilderSetting.UI
{
    partial class FindPackageInput
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
            input = new TextBox();
            findButton = new VampirioCode.UI.Controls.ButtonAdv();
            SuspendLayout();
            // 
            // input
            // 
            input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input.BackColor = Color.FromArgb(60, 60, 60);
            input.BorderStyle = BorderStyle.FixedSingle;
            input.ForeColor = Color.Silver;
            input.Location = new Point(3, 4);
            input.Name = "input";
            input.Size = new Size(157, 27);
            input.TabIndex = 0;
            // 
            // findButton
            // 
            findButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            findButton.BackColor = Color.FromArgb(30, 30, 30);
            findButton.BorderColor = Color.FromArgb(10, 10, 10);
            findButton.BorderSize = 1;
            findButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            findButton.expandImage = false;
            findButton.extraText = "";
            findButton.extraTextAlign = ContentAlignment.MiddleCenter;
            findButton.extraTextColor = Color.Black;
            findButton.extraTextFont = null;
            findButton.extraTextOffset = new Point(0, 0);
            findButton.FocusColor = Color.FromArgb(24, 81, 115);
            findButton.FocusEnabled = false;
            findButton.ForeColor = Color.FromArgb(120, 120, 120);
            findButton.Image = Properties.Resources.mmenu_mini_find;
            findButton.Location = new Point(166, 3);
            findButton.Name = "findButton";
            findButton.PaintImageOnSelected = true;
            findButton.processEnterKey = true;
            findButton.resizeImage = new Point(0, 0);
            findButton.Selected = false;
            findButton.SelectedColor = Color.FromArgb(0, 122, 204);
            findButton.Size = new Size(29, 29);
            findButton.TabIndex = 30;
            findButton.UseVisualStyleBackColor = false;
            findButton.Click += OnFindPressed;
            // 
            // FindPackageInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(findButton);
            Controls.Add(input);
            Name = "FindPackageInput";
            Size = new Size(198, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox input;
        private VampirioCode.UI.Controls.ButtonAdv findButton;
    }
}
