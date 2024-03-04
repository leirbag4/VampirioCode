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
            // XConsole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(tabPanel);
            Name = "XConsole";
            Size = new Size(685, 259);
            ResumeLayout(false);
        }

        #endregion
        private Controls.TabPanel tabPanel;
    }
}
