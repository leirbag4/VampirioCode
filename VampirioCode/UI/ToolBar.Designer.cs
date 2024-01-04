namespace VampirioCode.UI
{
    partial class ToolBar
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
            startButton = new Controls.ButtonAdv();
            reloadButton = new Controls.ButtonAdv();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BorderColor = Color.DarkGray;
            startButton.BorderSize = 0;
            startButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            startButton.expandImage = false;
            startButton.extraText = "";
            startButton.extraTextAlign = ContentAlignment.MiddleCenter;
            startButton.extraTextColor = Color.Black;
            startButton.extraTextFont = null;
            startButton.extraTextOffset = new Point(0, 0);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FocusColor = Color.FromArgb(24, 81, 115);
            startButton.FocusEnabled = false;
            startButton.Image = Properties.Resources.play_icon;
            startButton.Location = new Point(48, 2);
            startButton.Name = "startButton";
            startButton.PaintImageOnSelected = true;
            startButton.processEnterKey = true;
            startButton.resizeImage = new Point(0, 0);
            startButton.Selected = false;
            startButton.SelectedColor = Color.FromArgb(0, 122, 204);
            startButton.Size = new Size(26, 26);
            startButton.TabIndex = 0;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += OnStartPressed;
            // 
            // reloadButton
            // 
            reloadButton.BorderColor = Color.DarkGray;
            reloadButton.BorderSize = 0;
            reloadButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            reloadButton.expandImage = false;
            reloadButton.extraText = "";
            reloadButton.extraTextAlign = ContentAlignment.MiddleCenter;
            reloadButton.extraTextColor = Color.Black;
            reloadButton.extraTextFont = null;
            reloadButton.extraTextOffset = new Point(0, 0);
            reloadButton.FlatStyle = FlatStyle.Flat;
            reloadButton.FocusColor = Color.FromArgb(24, 81, 115);
            reloadButton.FocusEnabled = false;
            reloadButton.Image = Properties.Resources.reload_icon;
            reloadButton.Location = new Point(10, 2);
            reloadButton.Name = "reloadButton";
            reloadButton.PaintImageOnSelected = true;
            reloadButton.processEnterKey = true;
            reloadButton.resizeImage = new Point(0, 0);
            reloadButton.Selected = false;
            reloadButton.SelectedColor = Color.FromArgb(0, 122, 204);
            reloadButton.Size = new Size(26, 26);
            reloadButton.TabIndex = 1;
            reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += OnReloadPressed;
            // 
            // ToolBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(reloadButton);
            Controls.Add(startButton);
            Name = "ToolBar";
            Size = new Size(659, 28);
            ResumeLayout(false);
        }

        #endregion

        private Controls.ButtonAdv startButton;
        private Controls.ButtonAdv reloadButton;
    }
}
