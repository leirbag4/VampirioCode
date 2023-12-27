namespace VampirioCode
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            testButton = new Button();
            footer = new UI.FooterUI();
            splitContainer = new SplitContainer();
            xconsole = new UI.XConsole();
            vampDocManager1 = new VampDocManager.DocManager();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // testButton
            // 
            testButton.FlatStyle = FlatStyle.Flat;
            testButton.ForeColor = Color.DarkOrchid;
            testButton.Location = new Point(12, 10);
            testButton.Name = "testButton";
            testButton.Size = new Size(94, 29);
            testButton.TabIndex = 1;
            testButton.Text = "test";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += OnTestPressed;
            // 
            // footer
            // 
            footer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footer.BackColor = Color.FromArgb(20, 20, 20);
            footer.Character = 0;
            footer.Line = 0;
            footer.Location = new Point(4, 673);
            footer.Name = "footer";
            footer.Size = new Size(792, 26);
            footer.TabIndex = 2;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer.Location = new Point(4, 45);
            splitContainer.Margin = new Padding(0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(vampDocManager1);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(xconsole);
            splitContainer.Size = new Size(792, 630);
            splitContainer.SplitterDistance = 474;
            splitContainer.TabIndex = 3;
            // 
            // xconsole
            // 
            xconsole.BackColor = Color.FromArgb(40, 40, 40);
            xconsole.Dock = DockStyle.Fill;
            xconsole.Location = new Point(0, 0);
            xconsole.Name = "xconsole";
            xconsole.Size = new Size(792, 152);
            xconsole.TabIndex = 0;
            // 
            // vampDocManager1
            // 
            vampDocManager1.Dock = DockStyle.Fill;
            vampDocManager1.Location = new Point(0, 0);
            vampDocManager1.Name = "vampDocManager1";
            vampDocManager1.Size = new Size(792, 474);
            vampDocManager1.TabIndex = 0;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 700);
            Controls.Add(splitContainer);
            Controls.Add(footer);
            Controls.Add(testButton);
            Name = "App";
            Text = "Vampirio Code";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button testButton;
        private UI.FooterUI footer;
        private SplitContainer splitContainer;
        private UI.XConsole xconsole;
        private VampDocManager.DocManager vampDocManager1;
    }
}
