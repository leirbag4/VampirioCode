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
            codeContainer = new Panel();
            testButton = new Button();
            footerui1 = new UI.FooterUI();
            splitContainer1 = new SplitContainer();
            tabControl = new UI.Controls.TabControlAdv();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // codeContainer
            // 
            codeContainer.Location = new Point(0, 0);
            codeContainer.Name = "codeContainer";
            codeContainer.Size = new Size(790, 495);
            codeContainer.TabIndex = 0;
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
            // footerui1
            // 
            footerui1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footerui1.BackColor = Color.FromArgb(20, 20, 20);
            footerui1.Character = 0;
            footerui1.Line = 0;
            footerui1.Location = new Point(2, 673);
            footerui1.Name = "footerui1";
            footerui1.Size = new Size(798, 26);
            footerui1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer1.Location = new Point(5, 45);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(codeContainer);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl);
            splitContainer1.Size = new Size(790, 622);
            splitContainer1.SplitterDistance = 336;
            splitContainer1.TabIndex = 3;
            // 
            // tabControl
            // 
            tabControl.AllowDrop = true;
            tabControl.ArrowsBackColor = Color.LightGray;
            tabControl.ArrowsColor = Color.Black;
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.DragAndDrop = true;
            tabControl.FontColor = Color.Black;
            tabControl.InnerBorderColor = Color.DarkGray;
            tabControl.ItemSize = new Size(200, 25);
            tabControl.Location = new Point(194, 76);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(250, 125);
            tabControl.TabColor = Color.LightGray;
            tabControl.TabIndex = 0;
            tabControl.TabSelectedColor = Color.Gray;
            tabControl.TopBorderColor = Color.DarkGray;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(242, 92);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(242, 92);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 700);
            Controls.Add(splitContainer1);
            Controls.Add(footerui1);
            Controls.Add(testButton);
            Name = "App";
            Text = "Vampirio Code";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel codeContainer;
        private Button testButton;
        private UI.FooterUI footerui1;
        private SplitContainer splitContainer1;
        private UI.Controls.TabControlAdv tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
