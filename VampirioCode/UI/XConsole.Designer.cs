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
            outp = new RichTextBox();
            tabControl = new Controls.TabControlAdv();
            tabConsole = new TabPage();
            tabErrors = new TabPage();
            tabControl.SuspendLayout();
            tabConsole.SuspendLayout();
            SuspendLayout();
            // 
            // outp
            // 
            outp.BackColor = Color.FromArgb(30, 30, 30);
            outp.BorderStyle = BorderStyle.None;
            outp.Dock = DockStyle.Fill;
            outp.ForeColor = Color.Silver;
            outp.Location = new Point(0, 0);
            outp.Name = "outp";
            outp.Size = new Size(677, 226);
            outp.TabIndex = 0;
            outp.Text = "";
            // 
            // tabControl
            // 
            tabControl.AllowDrop = true;
            tabControl.ArrowsBackColor = Color.LightGray;
            tabControl.ArrowsColor = Color.Black;
            tabControl.Controls.Add(tabConsole);
            tabControl.Controls.Add(tabErrors);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DragAndDrop = false;
            tabControl.FontColor = Color.Black;
            tabControl.InnerBorderColor = Color.DarkGray;
            tabControl.ItemSize = new Size(200, 25);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(0, 0);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(685, 259);
            tabControl.TabColor = Color.LightGray;
            tabControl.TabIndex = 1;
            tabControl.TabSelectedColor = Color.Gray;
            tabControl.TopBorderColor = Color.DarkGray;
            // 
            // tabConsole
            // 
            tabConsole.Controls.Add(outp);
            tabConsole.Location = new Point(4, 29);
            tabConsole.Margin = new Padding(0);
            tabConsole.Name = "tabConsole";
            tabConsole.Size = new Size(677, 226);
            tabConsole.TabIndex = 0;
            tabConsole.Text = "console";
            tabConsole.UseVisualStyleBackColor = true;
            // 
            // tabErrors
            // 
            tabErrors.Location = new Point(4, 29);
            tabErrors.Name = "tabErrors";
            tabErrors.Size = new Size(192, 67);
            tabErrors.TabIndex = 1;
            tabErrors.Text = "errors";
            tabErrors.UseVisualStyleBackColor = true;
            // 
            // XConsole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(tabControl);
            Name = "XConsole";
            Size = new Size(685, 259);
            tabControl.ResumeLayout(false);
            tabConsole.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox outp;
        private Controls.TabControlAdv tabControl;
        private TabPage tabConsole;
        private TabPage tabErrors;
    }
}
