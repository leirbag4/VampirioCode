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
            tabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabPanel.BackColor = Color.FromArgb(30, 30, 30);
            tabPanel.Location = new Point(0, 0);
            tabPanel.Margin = new Padding(3, 2, 3, 2);
            tabPanel.Name = "tabPanel";
            tabPanel.PaintMode = UI.Controls.TabManagement.TabPaintMode.UserPaintOver;
            tabPanel.Size = new Size(570, 194);
            tabPanel.TabIndex = 2;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.None;
            clearButton.BorderColor = Color.FromArgb(24, 24, 24);
            clearButton.BorderSize = 1;
            clearButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            clearButton.expandImage = false;
            clearButton.extraText = "";
            clearButton.extraTextAlign = ContentAlignment.MiddleCenter;
            clearButton.extraTextColor = SystemColors.ButtonShadow;
            clearButton.extraTextFont = null;
            clearButton.extraTextOffset = new Point(0, 0);
            clearButton.FocusColor = Color.FromArgb(24, 81, 115);
            clearButton.FocusEnabled = false;
            clearButton.ForeColor = SystemColors.ButtonShadow;
            clearButton.Location = new Point(534, 0);
            clearButton.Margin = new Padding(3, 2, 3, 2);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(65, 28);
            clearButton.TabIndex = 3;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearPressed;
            // 
            // XConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(clearButton);
            Controls.Add(tabPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "XConsole";
            Size = new Size(599, 194);
            ResumeLayout(false);
        }

        #endregion
        private Controls.TabPanel tabPanel;
        private Controls.ButtonAdv clearButton;
    }
}
