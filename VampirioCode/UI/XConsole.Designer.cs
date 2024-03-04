namespace VampirioCode.UI
{
    partial class XConsole
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
            tabPanel = new Controls.TabPanel();
            clearButton = new Controls.ButtonAdv();
            SuspendLayout();
            // 
            // tabPanel
            // 
            tabPanel.BackColor = Color.FromArgb(30, 30, 30);
            tabPanel.Dock = DockStyle.Fill;
            tabPanel.Location = new Point(0, 0);
            tabPanel.Name = "tabPanel";
            tabPanel.PaintMode = UI.Controls.TabManagement.TabPaintMode.UserPaintOver;
            tabPanel.Size = new Size(685, 259);
            tabPanel.TabIndex = 2;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearButton.BorderColor = Color.FromArgb(20, 20, 20);
            clearButton.BorderSize = 1;
            clearButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            clearButton.expandImage = false;
            clearButton.extraText = "";
            clearButton.extraTextAlign = ContentAlignment.MiddleCenter;
            clearButton.extraTextColor = Color.Black;
            clearButton.extraTextFont = null;
            clearButton.extraTextOffset = new Point(0, 0);
            clearButton.FocusColor = Color.FromArgb(24, 81, 115);
            clearButton.FocusEnabled = false;
            clearButton.ForeColor = Color.Silver;
            clearButton.Location = new Point(615, 1);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 23);
            clearButton.TabIndex = 3;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearPressed;
            // 
            // XConsole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(clearButton);
            Controls.Add(tabPanel);
            Name = "XConsole";
            Size = new Size(685, 259);
            ResumeLayout(false);
        }

        #endregion
        private Controls.TabPanel tabPanel;
        private Controls.ButtonAdv clearButton;
    }
}
