namespace VampirioCode.Tests
{
    partial class TabTester2
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
            tabPanel = new UI.Controls.TabPanel();
            console = new UI.XConsole();
            clearButton = new UI.Controls.ButtonAdv();
            SuspendLayout();
            // 
            // tabPanel
            // 
            tabPanel.BackColor = Color.FromArgb(30, 30, 200);
            tabPanel.Location = new Point(24, 12);
            tabPanel.Name = "tabPanel";
            tabPanel.Size = new Size(513, 296);
            tabPanel.TabIndex = 0;
            tabPanel.Text = "tabPanel";
            // 
            // console
            // 
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(24, 446);
            console.Name = "console";
            console.Size = new Size(686, 193);
            console.TabIndex = 7;
            // 
            // clearButton
            // 
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
            clearButton.Location = new Point(641, 446);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 22);
            clearButton.TabIndex = 9;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearConsolePressed;
            // 
            // TabTester2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1130, 651);
            Controls.Add(clearButton);
            Controls.Add(console);
            Controls.Add(tabPanel);
            Name = "TabTester2";
            Text = "TabTester2";
            ResumeLayout(false);
        }

        #endregion

        private UI.Controls.TabPanel tabPanel;
        private UI.XConsole console;
        private UI.Controls.ButtonAdv clearButton;
    }
}