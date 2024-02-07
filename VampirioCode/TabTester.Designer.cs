namespace VampirioCode
{
    partial class TabTester
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
            tabControlWin = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button1 = new Button();
            button2 = new Button();
            tabControl = new UI.Controls.TabControlX();
            button3 = new Button();
            button4 = new Button();
            console = new UI.XConsole();
            button5 = new Button();
            clearButton = new UI.Controls.ButtonAdv();
            tabControlWin.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlWin
            // 
            tabControlWin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControlWin.Controls.Add(tabPage1);
            tabControlWin.Controls.Add(tabPage2);
            tabControlWin.Location = new Point(760, 386);
            tabControlWin.Name = "tabControlWin";
            tabControlWin.SelectedIndex = 0;
            tabControlWin.Size = new Size(364, 153);
            tabControlWin.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(356, 120);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(356, 120);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(760, 545);
            button1.Name = "button1";
            button1.Size = new Size(114, 29);
            button1.TabIndex = 1;
            button1.Text = "add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(880, 545);
            button2.Name = "button2";
            button2.Size = new Size(122, 29);
            button2.TabIndex = 2;
            button2.Text = "remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.BackColor = Color.FromArgb(60, 60, 60);
            tabControl.Location = new Point(25, 12);
            tabControl.Name = "tabControl";
            tabControl.Size = new Size(552, 335);
            tabControl.TabIndex = 3;
            tabControl.Text = "tabControlx1";
            // 
            // button3
            // 
            button3.Location = new Point(146, 361);
            button3.Name = "button3";
            button3.Size = new Size(122, 29);
            button3.TabIndex = 5;
            button3.Text = "remove";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnRemove;
            // 
            // button4
            // 
            button4.Location = new Point(26, 361);
            button4.Name = "button4";
            button4.Size = new Size(114, 29);
            button4.TabIndex = 4;
            button4.Text = "add";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OnAdd;
            // 
            // xConsole1
            // 
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(25, 415);
            console.Name = "xConsole1";
            console.Size = new Size(686, 193);
            console.TabIndex = 6;
            // 
            // button5
            // 
            button5.Location = new Point(455, 361);
            button5.Name = "button5";
            button5.Size = new Size(122, 29);
            button5.TabIndex = 7;
            button5.Text = "reset";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OnResetPressed;
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
            clearButton.Location = new Point(637, 415);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 22);
            clearButton.TabIndex = 8;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearPressed;
            // 
            // TabTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1157, 620);
            Controls.Add(clearButton);
            Controls.Add(button5);
            Controls.Add(console);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(tabControl);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControlWin);
            Name = "TabTester";
            Text = "TabTester";
            tabControlWin.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlWin;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button button2;
        private UI.Controls.TabControlX tabControl;
        private Button button3;
        private Button button4;
        private UI.XConsole console;
        private Button button5;
        private UI.Controls.ButtonAdv clearButton;
    }
}